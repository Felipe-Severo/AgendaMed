using System.Globalization;
using AgendaMedWebApp.Business.Genericos;


namespace AgendaMedWebApp.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public AccessType AccessType { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        //public DateTime BirthDate { get; set; } =
        //    DateTime.ParseExact("01/01/1900", "dd/mm/yyyy", CultureInfo.InvariantCulture);
        public string PhoneNumber { get; set; }
    }
}
