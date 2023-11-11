using AgendaMedWebApp.Business.Genericos;

namespace AgendaMedWebApp.Models
{
    public class PessoaModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsMedic { get; set; }

        public PessoaModel()
        {

        }

        public PessoaModel(Pessoa pessoa)
        {
            Id = pessoa.Id;
            Nome = pessoa.Nome;
            Sobrenome = pessoa.Sobrenome;
            Cpf = pessoa.Cpf;
            Crm = pessoa.Crm;
            DataNascimento = pessoa.DataNascimento;
            Telefone = pessoa.Telefone;
            IsMedic = pessoa.IsMedic;
        }

        public Pessoa GetPessoa()
        {
            return new Pessoa()
            {
                Id = Id,
                Nome = Nome,
                Sobrenome = Sobrenome,
                Cpf = Cpf,
                Crm = Crm,
                DataNascimento = DataNascimento,
                Telefone = Telefone,
        };
        }
    }
}
