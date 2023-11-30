using System.ComponentModel.DataAnnotations;

namespace AgendaMedWebApp.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "É obrigatório confirmar a senha atual.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a nova senha.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "É obrigatório confirmar a nova senha.")]
        public string NewPasswordConfirmation { get; set; }
    }
}