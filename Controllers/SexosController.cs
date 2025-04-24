using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class SexosController : BaseController<Sexo, int>
    {
        public SexosController(ClinicaContext context) : base(context) { }
    }
}
