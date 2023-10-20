using AgendaMedWebApp.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public class Pessoa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }


        public static List<Pessoa> Read()
        {
            var result = new List<Pessoa>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NOME, CPF, CRM, TELEFONE FROM PESSOAS";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pessoa pessoa = new Pessoa()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Cpf = reader.GetString(2),
                        Crm = reader.GetString(3),
                        Telefone = reader.GetString(4)
                    };

                    result.Add(pessoa);
                }
            }

            return result;
        }
        //private static long _currentId = 0;
        //public static List<Pessoa> Pessoas = new List<Pessoa>()
        //{
        //    new Pessoa
        //    {
        //    Nome = "Fanny",
        //    Cpf = "1515155",
        //    Crm = "1234",
        //    Telefone = "41 95895635",


        //    },

        //    new Pessoa
        //    {
        //    Nome = "Juliana",
        //    Cpf = "1515155",
        //       Crm = "1234",
        //    Telefone = "41 95895635",



        //    },

        //    new Pessoa
        //    {
        //    Nome = "Gustavo",
        //    Cpf = "1515155",
        //       Crm = "1234",
        //    Telefone = "41 95895635",

        //    }
        //};

        //public Pessoa()
        //{
        //    Id = ++_currentId;
        //}

    }
}

