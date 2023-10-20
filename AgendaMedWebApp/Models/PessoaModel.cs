using AgendaMedWebApp.Business.Genericos;

namespace AgendaMedWebApp.Models
{
    public class PessoaModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public PessoaModel()
        {

        }

        public PessoaModel(Pessoa pessoa)
        {
            Id = pessoa.Id;
            Nome = pessoa.Nome;
            Cpf = pessoa.Cpf;
            Crm = pessoa.Crm;
            Telefone = pessoa.Telefone;
        }
    }
}
