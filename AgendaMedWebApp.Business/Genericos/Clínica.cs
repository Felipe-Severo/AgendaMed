using AgendaMedWebApp.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public class Clinica
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Número { get; set; }
        public string Telefone { get; set; }

        public static List<Clinica> Read()
        {
            var result = new List<Clinica>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NOME, CNPJ, CEP, RUA, BAIRRO, NUMERO, TELEFONE FROM CLINICAS";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clinica clinica = new Clinica()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        CNPJ = reader.GetString(2),
                        Cep = reader.GetString(3),
                        Rua = reader.GetString(4),
                        Bairro = reader.GetString(5),
                        Número = reader.GetString(6),
                        Telefone = reader.GetString(7)
                    };

                    result.Add(clinica);
                }
            }

            return result;
        }

        public static Clinica ReadOne(long id)
        {
            Clinica result = null;

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NOME, CNPJ, CEP, RUA, BAIRRO, NUMERO, TELEFONE FROM CLINICAS WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Clinica clinica = new Clinica()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        CNPJ = reader.GetString(2),
                        Cep = reader.GetString(3),
                        Rua = reader.GetString(4),
                        Bairro = reader.GetString(5),
                        Número = reader.GetString(6),
                        Telefone = reader.GetString(7)
                    };

                    result = clinica;
                }
            }

            return result;
        }

        public void Create()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO CLINICAS (NOME, CNPJ, CEP, RUA, BAIRRO, NUMERO, TELEFONE)" +
                                  $"VALUES (@NOME, @CNPJ, @CEP, @RUA, @BAIRRO, @NUMERO, @TELEFONE)";

                cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
                cmd.Parameters.Add(new SqlParameter("@CNPJ", CNPJ));
                cmd.Parameters.Add(new SqlParameter("@CEP", Cep));
                cmd.Parameters.Add(new SqlParameter("@RUA", Rua));
                cmd.Parameters.Add(new SqlParameter("@BAIRRO", Bairro));
                cmd.Parameters.Add(new SqlParameter("@NUMERO", Número));
                cmd.Parameters.Add(new SqlParameter("@TELEFONE", Telefone));

                cmd.ExecuteNonQuery();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE CLINICAS SET NOME = @NOME, CNPJ = @CNPJ, CEP = @CEP, RUA = @RUA, BAIRRO = @BAIRRO, NUMERO = @NUMERO, TELEFONE = @TELEFONE WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
                cmd.Parameters.Add(new SqlParameter("@CNPJ", CNPJ));
                cmd.Parameters.Add(new SqlParameter("@CEP", Cep));
                cmd.Parameters.Add(new SqlParameter("@RUA", Rua));
                cmd.Parameters.Add(new SqlParameter("@BAIRRO", Bairro));
                cmd.Parameters.Add(new SqlParameter("@NUMERO", Número));
                cmd.Parameters.Add(new SqlParameter("@TELEFONE", Telefone));

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM CLINICAS WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.ExecuteNonQuery();
            }
        }
    }

}
