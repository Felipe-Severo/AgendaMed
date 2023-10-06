using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{
    public class ReceitasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
