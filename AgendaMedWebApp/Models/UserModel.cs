using System.Globalization;
using AgendaMedWebApp.Business.Genericos;


namespace AgendaMedWebApp.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public PessoaModel Pessoa { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public AccessType AccessType { get; set; }
    }
}
