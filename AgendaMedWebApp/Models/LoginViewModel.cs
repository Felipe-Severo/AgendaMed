using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AgendaMedWebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Nome de Usuário é obrigatório.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}