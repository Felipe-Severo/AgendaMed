using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public enum AccessType
    {
        Adm = 0,
        Doctor = 1,
        Patient = 2,
    }

    public class User
    {
        public long Id { get; set; }
        public Pessoas Pessoas { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        //public DateTime BirthDate { get; set; } = 
        //    DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public AccessType AccessType { get; set; }

        private static long _currentId = 0;
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Name = "Marco ",
                LastName = "Antonio Angelo",
                Nickname = "marco.angelo",
                Email = "marco.angelo@prof.sc.senac.br",
                CPF = "00100100101",
                //BirthDate = DateTime.ParseExact("20/09/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                PhoneNumber = "(47)99999-8877",
                Password = "Bolinha",
                AccessType = AccessType.Doctor,
            }
        };


        public User()
        {
            Id = ++_currentId;
        }
    }
}
