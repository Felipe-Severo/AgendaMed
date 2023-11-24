using AgendaMedWebApp.Business.Genericos;

namespace AgendaMedWebApp.Models
{
    public class ClinicaModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; } 
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public ClinicaModel()
        {

        }

        public ClinicaModel(Clinica clinica)
        {
            Id = clinica.Id;
            Nome = clinica.Nome;
            CNPJ = clinica.CNPJ;
            Cep = clinica.Cep;
            Rua = clinica.Rua;
            Bairro = clinica.Bairro;
            Numero = clinica.Numero;
            Telefone = clinica.Telefone;
            Cidade = clinica.Cidade;
            UF = clinica.UF;

        }

        public Clinica GetClinica()
        {
            return new Clinica()
            {
                Id = Id,
                Nome = Nome,
                CNPJ = CNPJ,
                Cep = Cep,
                Rua = Rua,
                Bairro = Bairro,
                Numero = Numero,
                Telefone = Telefone,
                Cidade = Cidade,
                UF = UF,
            };
        }
    }
}
