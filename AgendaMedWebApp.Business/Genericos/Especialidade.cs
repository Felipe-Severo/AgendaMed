using AgendaMedWebApp.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMed.Business.Genericos
{
    public class Especialidade
    {
        public long Id { get; set; }
        public string NomeEspecialidade { get; set; }

        public static List<Especialidade> Read()
        {
            var result = new List<Especialidade>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, SPECIALTY_NAME FROM SPECIALTIES";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Especialidade especialidade = new Especialidade()
                    {
                        Id = reader.GetInt32(0),
                        NomeEspecialidade = reader.GetString(1),

                    };

                    result.Add(especialidade);
                }
            }

            return result;
        }

        public static Especialidade ReadOne(long id)
        {
            Especialidade result = null;

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, SPECIALTY_NAME FROM SPECIALTIES WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Especialidade especialidade = new Especialidade()
                    {
                        Id = reader.GetInt32(0),
                        NomeEspecialidade = reader.GetString(1),

                    };

                    result = especialidade;
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
                cmd.CommandText = "INSERT INTO SPECIALTIES (SPECIALTY_NAME )" +
                                  $"OUTPUT INSERTED.ID VALUES (@NOME)";

                cmd.Parameters.Add(new SqlParameter("@NOME", NomeEspecialidade));

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE SPECIALTIES SET SPECIALTY_NAME = @SPECIALTY_NAME WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.Parameters.Add(new SqlParameter("@SPECIALTY_NAME", NomeEspecialidade));

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM SPECIALTIES WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.ExecuteNonQuery();
            }
        }
    }

}

