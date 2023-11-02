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

            var vendas = Pessoa.Read();
            foreach (var venda in vendas)
            {
                model.Pessoas.Add(new PessoaModel(venda));
            }

            return View(model);
        }
        //public IActionResult Index()
        //{
        //    var model = new PessoasModel();
        //    foreach (var pessoa in Pessoa.Read())
        //    {
        //        model.Pessoas.Add(new PessoaModel(pessoa));
        //    }
        //    return View(model);
        //    foreach (var pessoa in Business.Genericos.Pessoa.Pessoas)
        //    {
        //        model.Pessoas.Add(new PessoaModel()
        //        {
        //            Nome = pessoa.Nome,
        //            Cpf = pessoa.Cpf,
        //            Telefone = pessoa.Telefone,
        //            DataNascimento = pessoa.DataNascimento,

        //            Id = pessoa.Id,
        //            Nome = pessoa.Nome,
        //            Sobrenome = pessoa.Sobrenome,
        //            Cpf = pessoa.Cpf,
        //            Crm = pessoa.Crm;
        //            DataNascimento = pessoa.DataNascimento,
        //            Telefone = pessoa.Telefone,
        //    });
        //    }
        //    return View(model);
        //}

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PessoaModel pessoaModel)
        {
            var id = pessoaModel.GetPessoa().Create();
            return RedirectToAction("Update", new { id = id });
        }

        //public IActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Add(PessoaModel pessoaModel)
        //{
        //    var pessoaCadastro = new Business.Genericos.Pessoa()
        //    {
        //        Nome = pessoaModel.Nome,
        //        Cpf = pessoaModel.Cpf,
        //        Telefone = pessoaModel.Telefone,
        //        DataNascimento = pessoaModel.DataNascimento,
        //    };

        //    Business.Genericos.Pessoa.Pessoas.Add(pessoaCadastro);
        //    return RedirectToAction("Index");
        //}


        public IActionResult Update(long id)
        {
            return View(new PessoaModel(Pessoa.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Update(PessoaModel pessoaModel)
        {
            pessoaModel.GetPessoa().Update();
            return RedirectToAction("Index");
        }
        //public IActionResult Update(long id)
        //{
        //    var model = new PessoaModel();
        //    Business.Genericos.Pessoa pessoaAlterar = null;

        //    foreach (var pessoa in Business.Genericos.Pessoa.Pessoas)
        //    {
        //        if (pessoa.Id == id)
        //        {
        //            pessoaAlterar = pessoa;
        //            break;
        //        }
        //    }

        //    if (pessoaAlterar == null)
        //    {
        //        throw new Exception("Não existe usuário cadastrado com o ID informado!");
        //    }

        //    model.Id = id;
        //    model.Nome = pessoaAlterar.Nome;
        //    model.Cpf = pessoaAlterar.Cpf;
        //    model.Telefone = pessoaAlterar.Telefone;
        //    model.DataNascimento = pessoaAlterar.DataNascimento;

        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Update(PessoaModel pessoaAtualizado)
        //{
        //    var pessoaCadastrado = Pessoa.Pessoas.FirstOrDefault(x => x.Id == pessoaAtualizado.Id);

        //    if (pessoaCadastrado == null)
        //    {
        //        throw new Exception("Esse usuário não existe!");
        //    }

        //    pessoaCadastrado.Nome = pessoaAtualizado.Nome;
        //    pessoaCadastrado.Cpf = pessoaAtualizado.Cpf;
        //    pessoaCadastrado.Telefone = pessoaAtualizado.Telefone;
        //    pessoaCadastrado.DataNascimento = pessoaAtualizado.DataNascimento;

        //    return RedirectToAction("Index");
        //}




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


        //public IActionResult Delete(long id)
        //{
        //    var pessoaCadastrada = Pessoa.Pessoas.FirstOrDefault(x => x.Id == id);
        //    if (pessoaCadastrada == null)
        //    {
        //        throw new Exception("Esse ser não existe!");
        //    }

        //    var model = new PessoaModel();
        //    model.Id = id;
        //    model.Nome = pessoaCadastrada.Nome;
        //    model.Cpf = pessoaCadastrada.Cpf;
        //    model.Telefone = pessoaCadastrada.Telefone;


        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Delete(PessoaModel pessoaModel)
        //{
        //    var pessoaCadastrada = Pessoa.Pessoas.FirstOrDefault(x => x.Id == pessoaModel.Id);
        //    if (pessoaCadastrada == null)
        //    {
        //        throw new Exception("Esse ser não existe!");
        //    }

        //    Pessoa.Pessoas.Remove(pessoaCadastrada);

        //    return RedirectToAction("Index");
        //}
    }
}
