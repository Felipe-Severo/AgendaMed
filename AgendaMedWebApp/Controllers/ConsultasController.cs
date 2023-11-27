using AgendaMedWebApp.Business.Genericos;
using AgendaMedWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedWebApp.Controllers
{
    public class ConsultasController : Controller
    {
        public IActionResult Index()
        {
            var model = new ConsultasModel();

            var consultas = Consulta.Read();
            foreach (var consulta in consultas)
            {
                model.Consultas.Add(new ConsultaModel(consulta));
            }
            return View(model);
        }


        //public IActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Add(ConsultaModel consultaModel)
        //{
        //    var id = consultaModel.GetConsulta().Create();
        //    return RedirectToAction("Add", new { id = id });
        //}

        public IActionResult Add()
        {
            ViewBag.Pessoas = new List<PessoaModel>();
            foreach (var pessoa in Pessoa.Read())
            {
                ViewBag.Pessoas.Add(new PessoaModel(pessoa));
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(ConsultaModel consultaModel)
        {

            var id = consultaModel.GetConsulta().Create();
            return RedirectToAction("Index", new { id = id });
        }


        public IActionResult Update(long id)
        {
            ViewBag.Pessoas = new List<PessoaModel>();
            foreach (var pessoa in Pessoa.Read())
            {
                ViewBag.Pessoas.Add(new PessoaModel(pessoa));
            }

            return View(new ConsultaModel(Consulta.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Update(ConsultaModel consulta)
        {
            consulta.GetConsulta().Update();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            return View(new ConsultaModel(Consulta.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Delete(ConsultaModel consulta)
        {
            consulta.GetConsulta().Delete();
            return RedirectToAction("Index");
        }

    }
}
