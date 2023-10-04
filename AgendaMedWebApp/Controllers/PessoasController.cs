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
            foreach (var pessoa in Pessoa.Pessoas)
            {
                model.Pessoas.Add(new PessoaModel() 
                {
                    Nome = pessoa.Nome, 
                    Cpf = pessoa.Cpf, 
                    Crm = pessoa.Crm,  
                    Telefone = pessoa.Telefone, 
                });

            }
            return View(model);
        }
    }
}
