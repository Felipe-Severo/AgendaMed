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
        public Pessoa Pessoa { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string Documento { get; set; }

        public AccessType AccessType { get; set; }




        private static long _currentId = 0;


        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Pessoa = Pessoa.Pessoas.First(),
                Password = "Bolinha",
                Nickname = "Anderson",
                Documento = "CRM2224",
                AccessType = AccessType.Adm,
            }
        };


        public User()
        {
            Id = ++_currentId;
        }
    }
}
