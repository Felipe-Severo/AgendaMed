using AgendaMedWebApp.Business.Genericos;
namespace AgendaMedWebApp.Models
{
    public class ConsultaModel
    {
        public long Id { get; set; }
        public long Medico { get; set; }
        public long Paciente { get; set; }
        public DateTime DataConsulta { get; set; }
        public StatusConsulta StatusConsulta { get; set; }
        public string Sintomas { get; set; }
        public string Recomendacoes { get; set; }
        public string Exames { get; set; }
        public DateTime DataAgendamento { get; set; } = DateTime.Now;


        public ConsultaModel()
        {

        }

        public ConsultaModel(Consulta consulta)
        {
            Id = consulta.Id;
            Medico = consulta.Medico;
            Paciente = consulta.Paciente;
            DataConsulta = consulta.DataConsulta;
            StatusConsulta = consulta.StatusConsulta;
            Sintomas = consulta.Sintomas;
            Recomendacoes = consulta.Recomendacoes;
            Exames = consulta.Exames;
            DataAgendamento = consulta.DataAgendamento;

        }

        public Consulta GetConsulta()
        {
            return new Consulta()
            {
                Id = Id,
                Medico = Medico,
                Paciente = Paciente,
                DataConsulta = DataConsulta,
                StatusConsulta = StatusConsulta,
                Sintomas = Sintomas,
                Recomendacoes = Recomendacoes,
                Exames = Exames,
                DataAgendamento = DataAgendamento,

            };
        }
    }
}
