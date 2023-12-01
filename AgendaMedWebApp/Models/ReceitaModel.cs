using AgendaMedWebApp.Business.Genericos;
using System.Drawing;

namespace AgendaMedWebApp.Models{
       

    public class ReceitaModel
    {
        public long Id { get; set; }
        public DateTime DataPrescricao { get; set; }
        public string Prescricao { get; set; }


        public ReceitaModel()
        {

        }

        public ReceitaModel(Receita receita)
        {
            Id = receita.Id;
            DataPrescricao = receita.DataPrescricao;
            Prescricao = receita.Prescricao;
        

        }

        public Receita GetReceita()
        {
            return new Receita()
            {
                Id = Id,
                DataPrescricao = DataPrescricao,
                Prescricao = Prescricao
            };
        }


    }
}
