using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public class Receita
    {
        public long Id { get; set; }       
        public DateTime DataPrescricao { get; set; }
        public int Medicamento { get; set; }
        public decimal Dosagem { get; set; }
        public int PosologiaHora { get; set; }
        public int PosologiaDias { get; set; }



        private static long _currentId = 0;
        public static List<Receita> Receitas = new List<Receita>()
        {
            new Receita
            {
            DataPrescricao = DateTime.Parse("05/11/2023"),
            Medicamento = 10,
            PosologiaHora = 12,
            PosologiaDias =5,
            Dosagem = 0,           
            },
             new Receita
            {
            DataPrescricao = DateTime.Parse("05/11/2023"),
            Medicamento = 0,
            PosologiaHora = 8,
            PosologiaDias =7,
            Dosagem = 0,
            },

        };

        public Receita()
        {
            Id = ++_currentId;
        }
    }
}
