using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class MascotasController : BaseController<Mascota, int>
    {
        public MascotasController(ClinicaContext context) : base(context) { }
    }
}