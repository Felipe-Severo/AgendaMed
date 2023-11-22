using AgendaMed.Business.Genericos;
using AgendaMedWebApp.Business.Genericos;
using AgendaMedWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{
    public class EspecialidadesController : Controller
    {
        public IActionResult Index()
        {
            var model = new EspecialidadesModel();
            foreach (var especialidade in Especialidade.Read())
            {
                model.Especialidades.Add(new EspecialidadeModel(especialidade));
            }
            return View(model);
           
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EspecialidadeModel especialidadeModel)
        {
            var id = especialidadeModel.GetEspecialidade().Create();
            return RedirectToAction("Index", new { id = id });
        }

        public IActionResult Update(long id)
        {
            return View(new EspecialidadeModel(Especialidade.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Update(EspecialidadeModel especialidadeModel)
        {
            especialidadeModel.GetEspecialidade().Update();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            return View(new EspecialidadeModel(Especialidade.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Delete(EspecialidadeModel especialidadeModel)
        {
            especialidadeModel.GetEspecialidade().Delete();
            return RedirectToAction("Index");
        }

    }
}
