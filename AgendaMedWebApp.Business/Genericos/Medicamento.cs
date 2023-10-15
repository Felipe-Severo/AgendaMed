using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMed.Business.Genericos
{
    public class Medicamento
    {
        public long Id { get; set; }       
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Dosagem { get; set; }


        private static long _currentId = 0;
        public static List<Medicamento> Medicamentos = new List<Medicamento>()
        {
            new Medicamento
            {
                Nome = "Dipirona",
                Descricao = "Dor de cabeça",
            },
        };

        public Medicamento()
        {
            Id = ++_currentId;
        }
    }
}
