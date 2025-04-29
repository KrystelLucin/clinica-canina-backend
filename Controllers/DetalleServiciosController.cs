using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaCanina.API.Controllers
{
    public class DetalleServiciosController : BaseController<DetalleServicio, int>
    {
        public DetalleServiciosController(ClinicaContext context) : base(context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("byCita/{idCita}")]
        public async Task<ActionResult<DetalleServicio>> GetByCita(int idCita)
        {
            var detalle = await _context.DetalleServicios
                .FirstOrDefaultAsync(ds => ds.IdCita == idCita && ds.DeletedAt == null);

            if (detalle == null)
                return NotFound(new { message = "No se encontró un detalle de servicio para esta cita." });

            return Ok(detalle);
        }
    }
}