using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class RazasController : BaseController<Raza, int>
    {
        public RazasController(ClinicaContext context) : base(context) { }
    }
}
