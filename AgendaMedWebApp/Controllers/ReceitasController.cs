using AgendaMed.Business.Genericos;
using AgendaMedWebApp.Business.Genericos;
using AgendaMedWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMed.Controllers
{

    public class ReceitasController : Controller
    {

        public IActionResult Index()
        {
            var model = new ReceitasModel();

            var receitas = Receita.Read();
            foreach (var receita in receitas)
            {
                model.Receitas.Add(item: new ReceitaModel(receita));
            }

            return View(model);
        }

        public IActionResult Add()
        {
            ViewBag.Medicamentos = new List<MedicamentoModel>();
            foreach (var medicamento in Medicamento.Read())
            {
                ViewBag.Medicamentos.Add(new MedicamentoModel(medicamento));
            }

            return View();
        }


        [HttpPost]
        public IActionResult Add(ReceitaModel receita)
        {
            var id = receita.GetReceita().Create();
            return RedirectToAction("Update", new { Id = id });
        }

        public IActionResult Update(long id)
        {
            ViewBag.Medicamentos = new List<MedicamentoModel>();
            foreach (var medicamento in Medicamento.Read())
            {
                ViewBag.Medicamento.Add(new MedicamentoModel(medicamento));
            }

            return View(new ReceitaModel(Receita.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Update(ReceitaModel receita)
        {
            receita.GetReceita().Update();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            return View(new ReceitaModel(Receita.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Delete(ReceitaModel receita)
        {
            receita.GetReceita().Delete();
            return RedirectToAction("Index");
        }

        public IActionResult AddMedicamento(long receita)
        {
            ViewBag.Receita = receita;
            ViewBag.Medicamentos = new List<MedicamentoModel>();

            foreach (var medicamento in Medicamento.Read())
            {
                ViewBag.Produtos.Add(new MedicamentoModel(medicamento));
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddProduto(ReceitaMedicamentoModel receitaMedicamento)
        {
            receitaMedicamento.GetReceitaMedicamento().Create();
            return RedirectToAction("Update", new { id = receitaMedicamento.Prescription_Id });
        }
        public IActionResult DeleteMedicamento(long id)
        {
            var model = new ReceitaMedicamentoModel(ReceitaMedicamentos.ReadOne(id));
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteMedicamento(ReceitaMedicamentoModel receitaMedicamento)
        {
            receitaMedicamento.GetReceitaMedicamento().Delete();
            return RedirectToAction("Update", new { id = receitaMedicamento.Prescription_Id });
        }
    }
}
