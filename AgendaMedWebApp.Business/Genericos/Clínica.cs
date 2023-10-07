using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public class Clínica
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }

        public string Cep { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        public string Número { get; set; }

        public string Telefone { get; set; }

        private static long _currentId = 0;
        public static List<Clínica> Clinica = new List<Clínica>()
        {
            new Clínica
            {
                Nome = "Interblu Centro Clínico",
                CNPJ = "03.738.703/0001-00",
                Cep = "89010203",
                Rua = "Sete de Setembro",
                Bairro = "Centro",
                Número = "1535",
                Telefone = "(47) 3231-2700",

            }
        };

        public Clínica() => Id = ++_currentId;

    }
}
