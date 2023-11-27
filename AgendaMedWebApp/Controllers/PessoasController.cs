using AgendaMedWebApp.Business.Genericos;
using AgendaMedWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedWebApp.Controllers
{
    public class PessoasController : Controller
    {
        public IActionResult Index()
        {
            var model = new PessoasModel();
            foreach (var pessoa in Pessoa.Read())
            {
                model.Pessoas.Add(new PessoaModel(pessoa));
            }
            return View(model);
            
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PessoaModel pessoaModel)
        {
            var id = pessoaModel.GetPessoa().Create();
            return RedirectToAction("Index", new { id = id });
        }

        //[HttpPost]
        //public IActionResult HandleRegister(RegisterDTO registerDTO)
        //{
        //    var pessoa = new PessoaModel();
        //    var id = pessoa.GetPessoa().Create();

        //    var user = new UserModel();
        //    var userId = user.GetUser().Create();
        //    return RedirectToAction("Index", new { id = id });
        //}

        


        public IActionResult Update(long id)
        {
            return View(new PessoaModel(Pessoa.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Update(PessoaModel pessoaModel)
        {
            pessoaModel.GetPessoa().Update(pessoaModel.Id);
            return RedirectToAction("Index");
        }
   


        public IActionResult Delete(long id)
        {
            return View(new PessoaModel(Pessoa.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Delete(PessoaModel pessoaModel)
        {
            pessoaModel.GetPessoa().Delete();
            return RedirectToAction("Index");
        }


    }
}
