//using AgendaMed.Models;
//using Microsoft.AspNetCore.Mvc;
//using AgendaMedWebApp.Business.Genericos;
//using AgendaMedWebApp.Models;

//namespace AgendaMed.Controllers
//{
//    public class ClinicasController : Controller
//    {

//        public IActionResult Index()
//        {
//            var model = new ClinicasModel();

//            foreach (var clinica in AgendaMedWebApp.Business.Genericos.Clínica.Clinica)
//            {
//                model.Clinicas.Add(new ClinicaModel()
//                {
//                    Nome = clinica.Nome,
//                    CNPJ = clinica.CNPJ,
//                    Cep = clinica.Cep,
//                    Rua = clinica.Rua,
//                    Bairro = clinica.Bairro,
//                    Número = clinica.Número,
//                    Telefone = clinica.Telefone,
//                });

//            }
//            return View(model);
//        }
//        public IActionResult Add()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Add(ClinicaModel clinicaModel)
//        {
//            var clinicaCadastro = new AgendaMedWebApp.Business.Genericos.Clínica()
//            {
//                Nome = clinicaModel.Nome,
//                CNPJ = clinicaModel.CNPJ,
//                Cep = clinicaModel.Cep,
//                Rua = clinicaModel.Rua,
//                Bairro = clinicaModel.Bairro,
//                Número = clinicaModel.Número,
//                Telefone = clinicaModel.Telefone,
//            };
//            AgendaMedWebApp.Business.Genericos.Clínica.Clinica.Add(clinicaCadastro);
//            return RedirectToAction("Index");

//        }

//        public IActionResult Update(long id)
//        {
//            var model = new ClinicaModel();
//            AgendaMedWebApp.Business.Genericos.Clinica clinicaAlterar = null;

//            foreach (var clinica in AgendaMedWebApp.Business.Genericos.Clinica.Clinicas)
//            {
//                if (clinica.Id == id)
//                {
//                    clinicaAlterar = clinica;
//                    break;
//                }
//            }

//            if (clinicaAlterar == null)
//            {
//                throw new Exception("Não existe Clínica cadastrada com o ID informado!");
//            }

//            model.Id = id;
//            model.Nome = clinicaAlterar.Nome;
//            model.CNPJ = clinicaAlterar.CNPJ;
//            model.Cep = clinicaAlterar.Cep;
//            model.Rua = clinicaAlterar.Rua;
//            model.Bairro = clinicaAlterar.Bairro;
//            model.Número = clinicaAlterar.Numero;
//            model.Telefone = clinicaAlterar.Telefone;


//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Update(ClinicaModel clinicaAtualizada)
//        {
//            var clinicaCadastrada = Clinica.Clinicas.FirstOrDefault(x => x.Id == clinicaAtualizado.Id);

//            if (clinicaCadastrada == null)
//            {
//                throw new Exception("Essa clínica não existe!");
//            }

//            clinicaCadastrada.Nome = clinicaAtualizada.Nome;
//            clinicaCadastrada.CNPJ = clinicaAtualizada.CNPJ;
//            clinicaCadastrada.Cep = clinicaAtualizada.Cep;
//            clinicaCadastrada.Rua = clinicaAtualizada.Rua;
//            clinicaCadastrada.Bairro = clinicaAtualizada.Bairro;
//            clinicaCadastrada.Numero = clinicaAtualizada.Número;
//            clinicaCadastrada.Telefone = clinicaAtualizada.Telefone;

//            return RedirectToAction("Index");
//        }

//        public IActionResult Delete(long id)
//        {
//            var clinicaCadastrada = AgendaMedWebApp.Business.Genericos.Clinica.Clinicas.FirstOrDefault(x => x.Id == id);
//            if (clinicaCadastrada == null)
//            {
//                throw new Exception("Essa clínica não existe!");
//            }

//            var model = new ClinicaModel();
//            model.Id = id;
//            model.Nome = clinicaCadastrada.Nome;
//            model.CNPJ = clinicaCadastrada.CNPJ;
//            model.Cep = clinicaCadastrada.Cep;
//            model.Rua = clinicaCadastrada.Rua;
//            model.Bairro = clinicaCadastrada.Bairro;
//            model.Número = clinicaCadastrada.Numero;
//            model.Telefone = clinicaCadastrada.Telefone;

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Delete(ClinicaModel clinicaModel)
//        {
//            var clinicaCadastrada = AgendaMedWebApp.Business.Genericos.Clinica.Clinicas.FirstOrDefault(x => x.Id == clinicaModel.Id);
//            if (clinicaCadastrada == null)
//            {
//                throw new Exception("Essa clínica não existe!");
//            }

//            AgendaMedWebApp.Business.Genericos.Clinica.Clinicas.Remove(clinicaCadastrada);

//            return RedirectToAction("Index");
//        }
//    }
//}
