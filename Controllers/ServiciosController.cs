using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class ServiciosController : BaseController<Servicio, int>
    {
        public ServiciosController(ClinicaContext context) : base(context) {}
    }
}