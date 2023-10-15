using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMed.Business.Genericos
{
    public class Especialidade
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }


        private static long _currentId = 0;
        public static List<Especialidade> Especialidades = new List<Especialidade>()
        {
            new Especialidade
            {
                Nome = "Dermatologista",
                Codigo = "4040",
            },

        };

        public Especialidade()
        {
            Id = ++_currentId;
        }
    }
}
