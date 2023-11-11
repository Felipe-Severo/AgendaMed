//using AgendaMedWebApp.Business.Genericos;
//using AgendaMedWebApp.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace AgendaMedWebApp.Controllers
//{
//    public class ConsultasController : Controller
//    {
//        public IActionResult Index()
//        {
//            var model = new ConsultasModel();

//            foreach (var consulta in Business.Genericos.Consulta.Read())
//            {
//                model.Consultas.Add(new ConsultaModel()
//                {
//                    Medico = consulta.Medico,
//                    Paciente = consulta.Paciente,
//                    DataConsulta = consulta.DataConsulta,
//                    StatusConsulta = consulta.StatusConsulta,
//                    Sintomas = consulta.Sintomas,
//                    Exames = consulta.Exames,
//                    Recomendacoes = consulta.Recomendacoes,
//                });
//            }
//            return View(model);
//        }

//        public IActionResult Add()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Add(ConsultaModel consultaModel)
//        {
//            var consultaCadastro = new Business.Genericos.Consulta()
//            {
//                Medico = consultaModel.Medico,
//                Paciente = consultaModel.Paciente,
//                DataConsulta = consultaModel.DataConsulta,
//                StatusConsulta = consultaModel.StatusConsulta,
//                Sintomas = consultaModel.Sintomas,
//                Exames = consultaModel.Exames,
//                Recomendacoes = consultaModel.Recomendacoes,
//            };

//            Business.Genericos.Consulta.Add(consultaCadastro);
//            return RedirectToAction("Index");
//        }

//        public IActionResult Update(long id)
//        {
//            var model = new ConsultaModel();
//            Business.Genericos.Consulta consultaAlterar = null;

//            foreach (var consulta in Business.Genericos.Consulta.Consultas)
//            {
//                if (consulta.Id == id)
//                {
//                    consultaAlterar = consulta;
//                    break;
//                }
//            }

//            if (consultaAlterar == null)
//            {
//                throw new Exception("Não existe usuário cadastrado com o ID informado!");
//            }

//            model.Id = id;
//            model.Paciente = consultaAlterar.Paciente;
//            model.Medico = consultaAlterar.Medico;
//            model.DataConsulta = consultaAlterar.DataConsulta;
//            model.StatusConsulta = consultaAlterar.StatusConsulta;
//            model.Sintomas = consultaAlterar.Sintomas;
//            model.Exames = consultaAlterar.Exames;
//            model.Recomendacoes = consultaAlterar.Recomendacoes;

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Update(ConsultaModel consultaAtualizado)
//        {
//            var consultaCadastrado = Consulta.Consultas.FirstOrDefault(x => x.Id == consultaAtualizado.Id);

//            if (consultaCadastrado == null)
//            {
//                throw new Exception("Esse usuário não existe!");
//            }

//            consultaCadastrado.Paciente = consultaAtualizado.Paciente;
//            consultaCadastrado.Medico = consultaAtualizado.Medico;
//            consultaCadastrado.DataConsulta = consultaAtualizado.DataConsulta;
//            consultaCadastrado.StatusConsulta = consultaAtualizado.StatusConsulta;
//            consultaCadastrado.Sintomas = consultaAtualizado.Sintomas;
//            consultaCadastrado.Exames = consultaAtualizado.Exames;
//            consultaCadastrado.Recomendacoes = consultaAtualizado.Recomendacoes;

//            return RedirectToAction("Index");
//        }


//        //public IActionResult Delete(long id)
//        //{
//        //    var pessoaCadastrada = Pessoa.Pessoas.FirstOrDefault(x => x.Id == id);
//        //    if (pessoaCadastrada == null)
//        //    {
//        //        throw new Exception("Esse ser não existe!");
//        //    }

//        //    var model = new PessoaModel();
//        //    model.Id = id;
//        //    model.Nome = pessoaCadastrada.Nome;
//        //    model.Cpf = pessoaCadastrada.Cpf;
//        //    model.Telefone = pessoaCadastrada.Telefone;


//        //    return View(model);
//        //}

//        //[HttpPost]
//        //public IActionResult Delete(PessoaModel pessoaModel)
//        //{
//        //    var pessoaCadastrada = Pessoa.Pessoas.FirstOrDefault(x => x.Id == pessoaModel.Id);
//        //    if (pessoaCadastrada == null)
//        //    {
//        //        throw new Exception("Esse ser não existe!");
//        //    }

//        //    Pessoa.Pessoas.Remove(pessoaCadastrada);

//        //    return RedirectToAction("Index");
//        //}
//    }
//}
