using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class CitasController : BaseController<Cita, int>
    {
        public CitasController(ClinicaContext context) : base(context) { }
    }
}