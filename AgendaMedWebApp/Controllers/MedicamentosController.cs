using AgendaMed.Business.Genericos;
using AgendaMedWebApp.Business.Genericos;
using AgendaMedWebApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace AgendaMed.Controllers
{
    public class MedicamentosController : Controller
    {
        private Medicamento medicamento;

        public IActionResult Index()
        {
            var model = new MedicamentosModel();

            foreach (var medicamento in Medicamento.Read())
            {
                model.Medicamentos.Add(new MedicamentoModel(medicamento));
            }
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MedicamentoModel medicamento)
        {
            medicamento.GetProduto().Create();
            return RedirectToAction("Index");
        }

        public IActionResult Update(long id)
        {
            var medicamento = Medicamento.ReadOne(id);
            if (medicamento == null)
            {
                return BadRequest("O medicamento não foi encontrado!");
            }

            return View(new MedicamentoModel(medicamento));
        }

        [HttpPost]
        public IActionResult Update(MedicamentoModel medicamento)
        {
            medicamento.GetProduto().Update();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            var produto = Medicamento.ReadOne(id);
            if (produto == null)
            {
                return BadRequest("O medicamento não foi encontrado!");
            }

            return View(new MedicamentoModel(medicamento));
        }

        [HttpPost]
        public IActionResult Delete(MedicamentoModel medicamento)
        {
            medicamento.GetProduto().Delete();
            return RedirectToAction("Index");
        }
    }
}