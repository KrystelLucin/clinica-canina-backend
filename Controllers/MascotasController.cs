using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaCanina.API.Controllers
{
    public class MascotasController : BaseController<Mascota, int>
    {
        public MascotasController(ClinicaContext context) : base(context)
        {
            _context = context;
        }

        // Mascota by dueño (nombre)
        [Authorize]
        [HttpGet("byDueno/{nombreDueno}")]
        public async Task<ActionResult<IEnumerable<Mascota>>> GetByNombreDueno(string nombreDueno)
        {
            var mascotas = await _context.Mascotas
                .Where(m => _context.Duenos
                    .Any(d =>
                        d.Id == m.IdDueno &&
                        d.NombreCompleto.ToLower().Contains(nombreDueno.ToLower()) &&
                        (d.DeletedAt == null))) // Solo dueños activos
                .ToListAsync();

            return Ok(mascotas);
        }

        // Mascota by dueño (id)
        [Authorize]
        [HttpGet("byDuenoId/{id}")]
        public async Task<ActionResult<IEnumerable<Mascota>>> GetByDuenoId(string id)
        {
            var mascotas = await _context.Mascotas
                .Where(m => m.IdDueno == id && m.DeletedAt == null)
                .ToListAsync();

            return Ok(mascotas);
        }

    }
}