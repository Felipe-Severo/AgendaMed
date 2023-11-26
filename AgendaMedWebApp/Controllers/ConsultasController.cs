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
            //var consultaCadastro = new Business.Genericos.Consulta()
            //{
            //    Medico = consultaModel.Medico,
            //    Paciente = consultaModel.Paciente,
            //    DataConsulta = consultaModel.DataConsulta,
            //    StatusConsulta = consultaModel.StatusConsulta,
            //    Sintomas = consultaModel.Sintomas,
            //    Exames = consultaModel.Exames,
            //    Recomendacoes = consultaModel.Recomendacoes,
            //    DataAgendamento = consultaModel.DataAgendamento,
            //};

            //Business.Genericos.Consulta.Read().Add(consultaCadastro);
            //return RedirectToAction("Index");


            var id = consultaModel.GetConsulta().Create();
            return RedirectToAction("Index", new { id = id });
        }

        public IActionResult Update(long id)
        {
            var model = new ConsultaModel();
            Business.Genericos.Consulta consultaAlterar = null;

            foreach (var consulta in Business.Genericos.Consulta.Read())
            {
                if (consulta.Id == id)
                {
                    consultaAlterar = consulta;
                    break;
                }
            }

            if (consultaAlterar == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }

            model.Id = id;
            model.Paciente = consultaAlterar.Paciente;
            model.Medico = consultaAlterar.Medico;
            model.DataConsulta = consultaAlterar.DataConsulta;
            model.StatusConsulta = consultaAlterar.StatusConsulta;
            model.Sintomas = consultaAlterar.Sintomas;
            model.Exames = consultaAlterar.Exames;
            model.Recomendacoes = consultaAlterar.Recomendacoes;

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ConsultaModel consultaAtualizado)
        {
            var consultaCadastrado = Consulta.Read().FirstOrDefault(x => x.Id == consultaAtualizado.Id);

            if (consultaCadastrado == null)
            {
                throw new Exception("Esse usuário não existe!");
            }

            consultaCadastrado.Paciente = consultaAtualizado.Paciente;
            consultaCadastrado.Medico = consultaAtualizado.Medico;
            consultaCadastrado.DataConsulta = consultaAtualizado.DataConsulta;
            consultaCadastrado.StatusConsulta = consultaAtualizado.StatusConsulta;
            consultaCadastrado.Sintomas = consultaAtualizado.Sintomas;
            consultaCadastrado.Exames = consultaAtualizado.Exames;
            consultaCadastrado.Recomendacoes = consultaAtualizado.Recomendacoes;

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
