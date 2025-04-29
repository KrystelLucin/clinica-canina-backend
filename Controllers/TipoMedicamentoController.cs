using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class TipoMedicamentosController : BaseController<TipoMedicamento, int>
    {
        public TipoMedicamentosController(ClinicaContext context) : base(context) { }
    }
}
