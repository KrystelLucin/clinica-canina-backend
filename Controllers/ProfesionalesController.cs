using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class ProfesionalesController : BaseController<Profesional, int>
    {
        public ProfesionalesController(ClinicaContext context) : base(context) { }
    }
}