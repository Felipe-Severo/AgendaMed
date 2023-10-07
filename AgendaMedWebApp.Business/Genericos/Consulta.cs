using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public enum StatusConsulta
    {
        Agendado = 0,
        Cancelado = 1,
        Vencido = 2,
        Realizado = 3,
    }


    public class Consulta
    {
        public long Id { get; set; }
        public string Medico { get; set; }
        public string Paciente { get; set; }
        public DateTime DataConsulta { get; set; }
        public StatusConsulta StatusConsulta { get; set; }
        public string Sintomas { get; set; }
        public string Recomendacoes { get; set; }
        public string Exames { get; set;}


        private static long _currentId = 0;
        public static List<Consulta> Consultas = new List<Consulta>()
        {
            new Consulta
            {
                Medico = "Dr. Orlando",
                Paciente = "Everaldo da Silva",
                

            }
            
        };

        public Consulta()
        {
            Id = ++_currentId;
        }
    }
    
}
