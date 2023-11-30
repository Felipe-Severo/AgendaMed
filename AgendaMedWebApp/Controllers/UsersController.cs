using Microsoft.AspNetCore.Mvc;
using AgendaMedWebApp.Models;
using AgendaMedWebApp.Business.Genericos;
using Microsoft.AspNetCore.Authorization;

namespace AgendaMedWebApp.Controllers
{
    public class UsersController : Controller
    {
        //[Authorize("Admin")]
        public IActionResult Index()
        {
            var model = new UsersModel();

            foreach (var usuario in Business.Genericos.User.Read())
            {
                model.Users.Add(new UserModel(usuario));
            }

            return View(model);
        }


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
        public IActionResult Add(UserModel userModel)
        {
            var id = userModel.GetUser().Create();
            return RedirectToAction("Update", new { id = id });
        }

        public IActionResult Update(long id)
        {
            return View(new UserModel(Business.Genericos.User.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Update(UserModel userModel)
        {
            userModel.GetUser().Update();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            return View(new UserModel(Business.Genericos.User.ReadOne(id)));
        }

        [HttpPost]
        public IActionResult Delete(UserModel userModel)
        {
            userModel.GetUser().Delete();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UploadFoto(IFormFile uploadFoto)
        {
            if (uploadFoto != null && uploadFoto.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    uploadFoto.CopyTo(ms);
                    byte[] fotoBytes = ms.ToArray();

                }
            }

            return RedirectToAction("Perfil");
        }
    }
}