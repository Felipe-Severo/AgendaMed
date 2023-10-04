using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public class Pessoa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        private static long _currentId = 0;
        public static List<Pessoa> Pessoas = new List<Pessoa>()
        {
            new Pessoa
            {
            Nome = "Fanny",
            Cpf = "1515155"


            },
                        new Pessoa
            {
            Nome = "Juliana",
            Cpf = "1515155"

            },
                                    new Pessoa
            {
            Nome = "Gustavo",
            Cpf = "1515155"
            }



        };
        public Pessoa()
        {
            Id = ++_currentId;
        }

    }
}

