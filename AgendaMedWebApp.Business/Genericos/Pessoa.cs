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
        public string Sobrenome { get; set; }
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
                cmd.CommandText = "SELECT ID, FIRST_NAME, LAST_NAME, CPF, CRM, BIRTH_DATE, PHONE_NUMBER FROM PEOPLE";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pessoa pessoa = new Pessoa()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Sobrenome = reader.GetString(2),
                        Cpf = reader.GetString(3),
                        Crm = reader.GetString(4),
                        DataNascimento = reader.GetDateTime(5),
                        Telefone = reader.GetString(6)
                    };

                    result.Add(pessoa);
                }
            }

            return result;
        }

        public static Pessoa ReadOne(long id)
        {
            Pessoa result = null;

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, FIRST_NAME, LAST_NAME, CPF, CRM, BIRTH_DATE, PHONE_NUMBER FROM PEOPLE WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Pessoa pessoa = new Pessoa()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Sobrenome = reader.GetString(2),
                        Cpf = reader.GetString(3),
                        Crm = reader.GetString(4),
                        DataNascimento = reader.GetDateTime(5),
                        Telefone = reader.GetString(6)
                    };

                    result = pessoa;
                }
            }

            return result;
        }

        public long Create()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO PEOPLE (FIRST_NAME, LAST_NAME, CPF, CRM, BIRTH_DATE, PHONE_NUMBER) " +
                    $"OUTPUT INSERTED.ID VALUES (@FIRST_NAME, @LAST_NAME, @CPF, @CRM, @BIRTH_DATE, @PHONE_NUMBER)";

                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", Nome));
                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", Nome));
                cmd.Parameters.Add(new SqlParameter("@LAST_NAME", Cpf));
                cmd.Parameters.Add(new SqlParameter("@CPF", Cpf));
                cmd.Parameters.Add(new SqlParameter("@CRM", Crm));
                cmd.Parameters.Add(new SqlParameter("@BIRTH_DATE", DataNascimento));
                cmd.Parameters.Add(new SqlParameter("@PHONE_NUMBER", Telefone));

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE PEOPLE SET FIRST_NAME = @FIRST_NAME, LAST_NAME = @LAST_NAME, CPF = @CPF, " +
                    $"CRM = @CRM, BIRTH_DATE = @BIRTH_DATE, PHONE_NUMBER = @PHONE_NUMBER WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", Nome));
                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", Nome));
                cmd.Parameters.Add(new SqlParameter("@LAST_NAME", Cpf));
                cmd.Parameters.Add(new SqlParameter("@CPF", Cpf));
                cmd.Parameters.Add(new SqlParameter("@CRM", Crm));
                cmd.Parameters.Add(new SqlParameter("@BIRTH_DATE", DataNascimento));
                cmd.Parameters.Add(new SqlParameter("@PHONE_NUMBER", Telefone));

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM PEOPLE WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.ExecuteNonQuery();
            }
        }

    }
}

