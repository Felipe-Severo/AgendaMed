//using Microsoft.AspNetCore.Mvc;
//using AgendaMedWebApp.Models;
//using AgendaMedWebApp.Business.Genericos;


//namespace AgendaMedWebApp.Controllers
//{
//    public class UsersController : Controller
//    {
//        public IActionResult Index()
//        {
//            //if (Business.Genericos.User.GetLoggedUser().AccessType != Business.Genericos.AccessType.Adm)
//            //{
//            //    return BadRequest("O usuário não possui acesso a esta página");
//            //}

//            var model = new UsersModel();

//            foreach (var user in Business.Genericos.User.Users)
//            {
//                model.Users.Add(new UserModel() {
//                    Id = user.Id,
//                    Name = user.Name,
//                    Nickname = user.Nickname,
//                    Email = user.Email,
//                    Password = user.Password,
//                    AccessType = user.AccessType,
//                    });
//            }

//            // Redireciona para o arquivo Index.cshtml na pasta Users
//            return View(model);
//        }

//        public IActionResult Add()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Add(UserModel userModel)
//        {
//            var usuarioCadastro = new Business.Generics.User()
//            {
//                Name = userModel.Name,
//                Nickname = userModel.Nickname,
//                Email = userModel.Email,
//                Password = userModel.Password,
//                AccessType = userModel.AccessType,
//            };

//            Business.Generics.User.Users.Add(usuarioCadastro);
//            return RedirectToAction("Index");
//        }

//        public IActionResult Update(long id)
//        {
//            var model = new UserModel();
//            Business.Generics.User usuarioAlterar = null;

//            foreach (var usuario in Business.Generics.User.Users)
//            {
//                if (usuario.Id == id)
//                {
//                    usuarioAlterar = usuario;
//                    break;
//                }
//            }

//            if (usuarioAlterar == null)
//            {
//                throw new Exception("Não existe usuário cadastrado com o ID informado!");
//            }

//            model.Id = id;
//            model.Nickname = usuarioAlterar.Nickname;
//            model.Name = usuarioAlterar.Name;
//            model.Email = usuarioAlterar.Email;
//            model.AccessType = usuarioAlterar.AccessType;

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Update(UserModel usuarioAtualizado)
//        {
//            var model = new UserModel();
//            Business.Generics.User usuarioAlterar = null;

//            foreach (var usuario in Business.Generics.User.Users)
//            {
//                if (usuario.Id == usuarioAtualizado.Id)
//                {
//                    usuarioAlterar = usuario;
//                    break;
//                }
//            }

//            if (usuarioAlterar == null)
//            {
//                throw new Exception("Não existe usuário cadastrado com o ID informado!");
//            }

//            usuarioAlterar.Name = usuarioAtualizado.Name;
//            usuarioAlterar.Nickname = usuarioAtualizado.Nickname;
//            usuarioAlterar.Email = usuarioAtualizado.Email;
//            usuarioAlterar.AccessType = usuarioAtualizado.AccessType;

//            if (usuarioAtualizado.Password != "00000000" && usuarioAtualizado.Password != usuarioAlterar.Password)
//            {
//                usuarioAlterar.Password = usuarioAtualizado.Password;
//            }

//            return RedirectToAction("Index");
//        }

//        public IActionResult Delete(long id)
//        {
//            var model = new UserModel();
//            Business.Generics.User usuarioAlterar = null;

//            foreach (var usuario in Business.Generics.User.Users)
//            {
//                if (usuario.Id == id)
//                {
//                    usuarioAlterar = usuario;
//                    break;
//                }
//            }

//            if (usuarioAlterar == null)
//            {
//                throw new Exception("Não existe usuário cadastrado com o ID informado!");
//            }

//            model.Id = id;
//            model.Nickname = usuarioAlterar.Nickname;
//            model.Name = usuarioAlterar.Name;
//            model.Email = usuarioAlterar.Email;
//            model.AccessType = usuarioAlterar.AccessType;

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Delete(UserModel usuarioAtualizado)
//        {
//            var model = new UserModel();
//            Business.Generics.User usuarioExcluir = null;

//            foreach (var usuario in Business.Generics.User.Users)
//            {
//                if (usuario.Id == usuarioAtualizado.Id)
//                {
//                    usuarioExcluir = usuario;
//                    break;
//                }
//            }

//            if (usuarioExcluir == null)
//            {
//                throw new Exception("Não existe usuário cadastrado com o ID informado!");
//            }

//            Business.Generics.User.Users.Remove(usuarioExcluir);

//            return RedirectToAction("Index");
//        }
//    }
//}