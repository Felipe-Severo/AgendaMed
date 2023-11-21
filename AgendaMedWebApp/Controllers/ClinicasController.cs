using AgendaMedWebApp.Business.Genericos;
using AgendaMedWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedWebApp.Controllers
{
    public class ClinicasController : Controller
    {
        public IActionResult Index()
        {
            var model = new ClinicasModel();
            foreach (var clinica in Clinica.Read())
            {
                model.Clinicas.Add(new ClinicaModel(clinica));
            }
            return View(model);
          
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ClinicaModel clinicaModel)
        {
            var id = clinicaModel.GetClinica().Create();
            return RedirectToAction("Index", new { id = id });
        }

        


        public IActionResult Update(long id)
        {
            return View(new ClinicaModel(Clinica.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Update(ClinicaModel clinicaModel)
        {
            clinicaModel.GetClinica().Update(clinicaModel.Id);
            return RedirectToAction("Index");
        }
       
     




        public IActionResult Delete(long id)
        {
            return View(new ClinicaModel(Clinica.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Delete(ClinicaModel clinicaModel)
        {
            clinicaModel.GetClinica().Delete();
            return RedirectToAction("Index");
        }


    
    }
}
