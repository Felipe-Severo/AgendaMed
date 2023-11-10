using AgendaMed.Business.Genericos;

namespace AgendaMedWebApp.Models
{
    public class MedicamentoModel
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Dosagem { get; set; }
        public object Medicamentos { get; internal set; }

        public MedicamentoModel()
        {

        }

        public MedicamentoModel(Medicamento medicamento)
        {
            Id = medicamento.Id;
            Nome = medicamento.Nome;
            Descricao = medicamento.Descricao;
            Dosagem = medicamento.Dosagem;

        }

        internal Medicamento GetMedicamento()
        {
            return new Medicamento() { Id = Id, Nome = Nome, Descricao = Descricao, Dosagem = Dosagem };
        }
    }
}
