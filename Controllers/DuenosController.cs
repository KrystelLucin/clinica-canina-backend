using ClinicaCanina.API.Data;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Controllers
{
    public class DuenosController : BaseController<Dueno, string>
    {
        public DuenosController(ClinicaContext context) : base(context)
        {
        }
    }
}