using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{
    public class ConsultasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
