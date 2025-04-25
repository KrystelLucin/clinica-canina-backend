using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaCanina.API.Data;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ClinicaCanina.API.Controllers
{
    //Controller base CRUD para todas las tablas
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T, TKey> : ControllerBase where T : class
    {
        protected ClinicaContext _context;

        public BaseController(ClinicaContext context)
        {
            _context = context;
        }

        protected virtual object? GetId(T entity)
        {
            var prop = typeof(T).GetProperties()
                .FirstOrDefault(p => Attribute.IsDefined(p, typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));

            return prop?.GetValue(entity);
        }

        // Get all
        [Authorize]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            var query = _context.Set<T>().AsQueryable();

            var deletedAtProp = typeof(T).GetProperty("DeletedAt");
            if (deletedAtProp != null)
            {
                var element = Expression.Parameter(typeof(T), "element");
                var propExpr = Expression.Property(element, deletedAtProp);
                var nullConstant = Expression.Constant(null, typeof(DateTime?));
                var compare = Expression.Equal(propExpr, nullConstant);
                var lambda = Expression.Lambda<Func<T, bool>>(compare, element);

                query = query.Where(lambda);
            }

            var result = await query.ToListAsync();
            return Ok(result);
        }


        // Get by id
        [Authorize]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetById(TKey id)
        {
            var keyProp = typeof(T).GetProperties()
                .FirstOrDefault(p => Attribute.IsDefined(p, typeof(KeyAttribute)));

            if (keyProp == null)
                return BadRequest("No se pudo determinar la clave primaria del modelo.");

            var element = Expression.Parameter(typeof(T), "element");
            var property = Expression.Property(element, keyProp.Name);
            var idValue = Expression.Constant(id, keyProp.PropertyType);
            var compare = Expression.Equal(property, idValue);
            var lambda = Expression.Lambda<Func<T, bool>>(compare, element);

            var entity = await _context.Set<T>().FirstOrDefaultAsync(lambda);

            if (entity == null)
                return NotFound();

            // Validar DeletedAt si existe y está en uso
            var deletedAtProp = typeof(T).GetProperty("DeletedAt");
            if (deletedAtProp != null)
            {
                var deletedValue = deletedAtProp.GetValue(entity) as DateTime?;
                if (deletedValue != null)
                    return NotFound();
            }

            return Ok(entity);
        }



        // Create
        [Authorize]
        [HttpPost]
        public virtual async Task<ActionResult<T>> Create(T entity)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = int.TryParse(userIdClaim, out var parsedId) ? parsedId : (int?)null;

            var createdBy = typeof(T).GetProperty("CreatedBy");
            if (createdBy != null && createdBy.PropertyType == typeof(int?))
                createdBy.SetValue(entity, userId);

            var createdAt = typeof(T).GetProperty("CreatedAt");
            if (createdAt != null && (createdAt.PropertyType == typeof(DateTime) || createdAt.PropertyType == typeof(DateTime?)))
                createdAt.SetValue(entity, DateTime.UtcNow);

            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = GetId(entity) }, entity);
        }


        // Update
        [Authorize]
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(TKey id, T entity)
        {
            var current = await _context.Set<T>().FindAsync(id);
            if (current == null)
                return NotFound();

            var deletedAtProp = typeof(T).GetProperty("DeletedAt");
            if (deletedAtProp != null)
            {
                var deletedValue = deletedAtProp.GetValue(current) as DateTime?;
                if (deletedValue != null)
                    return BadRequest("No se puede modificar un registro eliminado.");
            }

            _context.Entry(current).CurrentValues.SetValues(entity);

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = int.TryParse(userIdClaim, out var parsedId) ? parsedId : (int?)null;

            var updatedBy = typeof(T).GetProperty("UpdatedBy");
            if (updatedBy != null && updatedBy.PropertyType == typeof(int?))
                updatedBy.SetValue(current, userId);

            var updatedAt = typeof(T).GetProperty("UpdatedAt");
            if (updatedAt != null && (updatedAt.PropertyType == typeof(DateTime) || updatedAt.PropertyType == typeof(DateTime?)))
                updatedAt.SetValue(current, DateTime.UtcNow);

            await _context.SaveChangesAsync();
            return Ok(new { message = "Registro actualizado correctamente." });
        }


        // Delete
        [Authorize]
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TKey id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
                return NotFound();

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = int.TryParse(userIdClaim, out var parsedId) ? parsedId : (int?)null;
            var now = DateTime.UtcNow;

            var deletedAtProp = typeof(T).GetProperty("DeletedAt");
            if (deletedAtProp != null && (deletedAtProp.PropertyType == typeof(DateTime) || deletedAtProp.PropertyType == typeof(DateTime?)))
            {
                deletedAtProp.SetValue(entity, now);

                var deletedByProp = typeof(T).GetProperty("DeletedBy");
                if (deletedByProp != null && deletedByProp.PropertyType == typeof(int?))
                    deletedByProp.SetValue(entity, userId);

                await _context.SaveChangesAsync();
                return Ok(new { message = "Registro eliminado correctamente (soft delete)." });
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registro eliminado permanentemente." });
        }

    }
}
