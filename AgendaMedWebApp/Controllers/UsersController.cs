using Microsoft.AspNetCore.Mvc;
using AgendaMedWebApp.Models;
using AgendaMedWebApp.Business.Genericos;


namespace AgendaMedWebApp.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            var model = new UsersModel();

            //foreach (var usuario in User.Read())
            //{
            //    model.Users.Add(new UserModel(usuario));
            //}

            return View(model);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserModel userModel)
        {
            var usuarioCadastro = new Business.Genericos.User()
            {
                Login = userModel.Login,
                Password = userModel.Password,
                AccessType = userModel.AccessType,
            };

            Business.Genericos.User.Read().Add(usuarioCadastro);
            return RedirectToAction("Index");
        }

        public IActionResult Update(long id)
        {
            var model = new UserModel();
            Business.Genericos.User usuarioAlterar = null;

            foreach (var usuario in Business.Genericos.User.Read())
            {
                if (usuario.Id == id)
                {
                    usuarioAlterar = usuario;
                    break;
                }
            }

            if (usuarioAlterar == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }

            model.Id = id;
            model.Login = usuarioAlterar.Login;
            model.Password = usuarioAlterar.Password;
            model.AccessType = usuarioAlterar.AccessType;

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UserModel usuarioAtualizado)
        {
            var model = new UserModel();
            Business.Genericos.User usuarioAlterar = null;

            foreach (var usuario in Business.Genericos.User.Read())
            {
                if (usuario.Id == usuarioAtualizado.Id)
                {
                    usuarioAlterar = usuario;
                    break;
                }
            }

            if (usuarioAlterar == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }


            usuarioAlterar.Login = usuarioAtualizado.Login;
            usuarioAlterar.Password = usuarioAtualizado.Password;
            usuarioAlterar.AccessType = usuarioAtualizado.AccessType;

            if (usuarioAtualizado.Password != "00000000" && usuarioAtualizado.Password != usuarioAlterar.Password)
            {
                usuarioAlterar.Password = usuarioAtualizado.Password;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            var model = new UserModel();
            Business.Genericos.User usuarioAlterar = null;

            foreach (var usuario in Business.Genericos.User.Read())
            {
                if (usuario.Id == id)
                {
                    usuarioAlterar = usuario;
                    break;
                }
            }

            if (usuarioAlterar == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }

            model.Id = id;
            model.Login = usuarioAlterar.Login;
            model.Password = usuarioAlterar.Password;
            model.AccessType = usuarioAlterar.AccessType;

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(UserModel usuarioAtualizado)
        {
            var model = new UserModel();
            Business.Genericos.User usuarioExcluir = null;

            foreach (var usuario in Business.Genericos.User.Read())
            {
                if (usuario.Id == usuarioAtualizado.Id)
                {
                    usuarioExcluir = usuario;
                    break;
                }
            }

            if (usuarioExcluir == null)
            {
                throw new Exception("Não existe usuário cadastrado com o ID informado!");
            }

            Business.Genericos.User.Read().Remove(usuarioExcluir);

            return RedirectToAction("Index");
        }
    }
}