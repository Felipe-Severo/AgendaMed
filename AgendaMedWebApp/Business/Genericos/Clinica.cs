namespace AgendaMedWebApp.Business.Genericos
{
    internal class Clinica
    {
        internal string Cep;
        internal string Bairro;
        internal string Numero;

        public static object Clinicas { get; internal set; }
        public string Nome { get; internal set; }
        public string CNPJ { get; internal set; }
        public string Rua { get; internal set; }
        public string Telefone { get; internal set; }
    }
}