using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{
    public class MedicamentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
