using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class DetalleServiciosController : BaseController<DetalleServicio, int>
    {
        public DetalleServiciosController(ClinicaContext context) : base(context) { }
    }
}