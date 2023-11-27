using AgendaMedWebApp.Business.Genericos;

namespace AgendaMedWebApp.Models
{
    public class ReceitaModel
    {
        public long Id { get; set; }
        public DateTime DataPrescricao { get; set; }
        //public int Medicamento { get; set; }
        //public decimal Dosagem { get; set; }
        //public int PosologiaHora { get; set; }
        //public int PosologiaDias { get; set; }

        public List<ReceitaMedicamentoModel> Medicamentos { get; set; } = new List<ReceitaMedicamentoModel>();


        public ReceitaModel(Receita receita)
        {
            Id = receita.Id;
            DataPrescricao = receita.DataPrescricao;


            foreach (var medicamento in receita._Medicamento)
            {
                Medicamentos.Add(new ReceitaMedicamentoModel(medicamento));
            }
        }

        public Receita GetReceita()
        {
            return new Receita()
            {
                Id = Id,
                DataPrescricao = DataPrescricao,

            };

        }




    }
}
