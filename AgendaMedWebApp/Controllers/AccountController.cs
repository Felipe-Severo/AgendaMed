using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Reflection;
using System.Security.Claims;
using AgendaMedWebApp.Models;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ChangePassword(ChangePasswordModel model)
    {
        // Utilizamos o 4 pq é a quinta propriedade definida ao logar.
        long userId = long.Parse(User.Claims.ToArray()[4].Value);
        var user = AgendaMedWebApp.Business.Genericos.User.ReadOne(userId);

        if (model.NewPassword != model.NewPasswordConfirmation)
        {
            ModelState.AddModelError(string.Empty, "É necessário confirmar a senha");
            return View(model);
        }

        if (!user.IsValidPassword(model.Password))
        {
            ModelState.AddModelError(string.Empty, "Senha inválida");
            return View(model);
        }

        user.UpdatePassword(model.NewPassword);
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var user = AgendaMedWebApp.Business.Genericos.User.ReadOne(model.Username, model.Password);
        if (user != null)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Login),
                    new Claim(ClaimTypes.Name, user.Pessoa.ToString()),
                    new Claim("AccessType", user.AccessType.ToString()),
                    new Claim("ID", user.Id.ToString()),
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}