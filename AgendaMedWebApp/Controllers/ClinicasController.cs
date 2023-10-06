using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{
    public class ClinicasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
