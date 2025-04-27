using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class EspeciesController : BaseController<Especie, int>
    {
        public EspeciesController(ClinicaContext context) : base(context) { }
    }
}
