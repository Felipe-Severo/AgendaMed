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
        public int Numero { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public static List<Clinica> Read()
        {
            var result = new List<Clinica>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, CLINIC_NAME, CNPJ, CEP, STREET, NEIGHBORHOOD, NUMBER, PHONE_NUMBER, CITY, UF FROM CLINICS";

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
                        Numero = reader.GetInt32(6),
                        Telefone = reader.GetString(7),
                        Cidade = reader.GetString(8),
                        UF = reader.GetString(9),
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
                cmd.CommandText = "SELECT ID,CLINIC_NAME, CNPJ, CEP, STREET, NEIGHBORHOOD, NUMBER, PHONE_NUMBER, CITY, UF FROM CLINICS WHERE ID = @ID";
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
                        Numero = reader.GetInt32(6),
                        Telefone = reader.GetString(7),
                        Cidade = reader.GetString(8),
                        UF = reader.GetString(9),
                    };

                    result = clinica;
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
                cmd.CommandText = "INSERT INTO CLINICS (CLINIC_NAME, CNPJ, CEP, STREET, NEIGHBORHOOD, NUMBER, PHONE_NUMBER, CITY, UF )" +
                                  $"OUTPUT INSERTED.ID VALUES (@CLINIC_NAME, @CNPJ, @CEP, @STREET, @NEIGHBORHOOD, @NUMBER, @PHONE_NUMBER, @CITY, @UF)";

                cmd.Parameters.Add(new SqlParameter("@CLINIC_NAME", Nome));
                cmd.Parameters.Add(new SqlParameter("@CNPJ", CNPJ));
                cmd.Parameters.Add(new SqlParameter("@CEP", Cep));
                cmd.Parameters.Add(new SqlParameter("@STREET", Rua));
                cmd.Parameters.Add(new SqlParameter("@NEIGHBORHOOD", Bairro));
                cmd.Parameters.Add(new SqlParameter("@NUMBER", Numero));
                cmd.Parameters.Add(new SqlParameter("@PHONE_NUMBER", Telefone));
                cmd.Parameters.Add(new SqlParameter("@CITY", Cidade));
                cmd.Parameters.Add(new SqlParameter("@UF", UF));

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update(long id)
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE CLINICS SET CLINIC_NAME = @CLINIC_NAME, CNPJ = @CNPJ, CEP = @CEP, STREET = @STREET, NEIGHBORHOOD = @NEIGHBORHOOD, NUMBER = @NUMBER, PHONE_NUMBER = @PHONE_NUMBER, CITY = @CITY, UF = @UF WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.Parameters.Add(new SqlParameter("@CLINIC_NAME", Nome));
                cmd.Parameters.Add(new SqlParameter("@CNPJ", CNPJ));
                cmd.Parameters.Add(new SqlParameter("@CEP", Cep));
                cmd.Parameters.Add(new SqlParameter("@STREET", Rua));
                cmd.Parameters.Add(new SqlParameter("@NEIGHBORHOOD", Bairro));
                cmd.Parameters.Add(new SqlParameter("@NUMBER", Numero));
                cmd.Parameters.Add(new SqlParameter("@PHONE_NUMBER", Telefone));
                cmd.Parameters.Add(new SqlParameter("@CITY", Cidade));
                cmd.Parameters.Add(new SqlParameter("@UF", UF));

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM CLINICS WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.ExecuteNonQuery();
            }
        }
    }

}
