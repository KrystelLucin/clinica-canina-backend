using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class CitasController : BaseController<Cita, int>
    {
        public CitasController(ClinicaContext context) : base(context)
        {
            _context = context;
        }

        // Cita by Fecha
        [Authorize]
        [HttpGet("byFecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetByFecha(string fecha)
        {
            if (!DateTime.TryParse(fecha, out DateTime parsedFecha))
                return BadRequest("Formato de fecha inválido. Usa yyyy-MM-dd");

            var citas = await _context.Citas
                .Where(c =>
                    c.FechaHora.Date == parsedFecha.Date &&
                    c.DeletedAt == null)
                .ToListAsync();

            return Ok(citas);
        }

        // Cita by Profesional
        [Authorize]
        [HttpGet("byProfesional/{id}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetByProfesional(int id)
        {
            var citas = await _context.Citas
                .Where(c => c.IdProfesional == id && c.DeletedAt == null)
                .ToListAsync();

            return Ok(citas);
        }

        // Cita By Mascota
        [Authorize]
        [HttpGet("byMascota/{id}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetByMascota(int id)
        {
            var citas = await _context.Citas
                .Where(c => c.IdMascota == id && c.DeletedAt == null)
                .ToListAsync();

            return Ok(citas);
        }


    }
}