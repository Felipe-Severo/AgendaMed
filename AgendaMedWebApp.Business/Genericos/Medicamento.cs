using AgendaMedWebApp.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMed.Business.Genericos
{
    public class Medicamento
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Dosagem { get; set; }



        public Medicamento()
        {

        }
        public static List<Medicamento> Read()
        {
            var result = new List<Medicamento>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, MEDICATION_NAME, DESCRIPTION, DOSAGE FROM MEDICATIONS";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Medicamento medicamento = new Medicamento()  
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Descricao = reader.GetString(2),
                        Dosagem = reader.GetInt32(3),

                    };

                    result.Add(medicamento);
                }
            }

            return result;
        }

        public static Medicamento ReadOne(long id)
        {
            Medicamento result = null;

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, MEDICATION_NAME, DESCRIPTION, DOSAGE FROM MEDICATIONS WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Medicamento medicamento = new Medicamento()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Descricao = reader.GetString(2),
                        Dosagem = reader.GetInt32(3),
                    };

                    result = medicamento;
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
                cmd.CommandText = "INSERT INTO MEDICATIONS (MEDICATION_NAME, DESCRIPTION, DOSAGE )" +
                                  $"VALUES (@NOME, @DESCRICAO, @DOSAGEM)";

                cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", Descricao));
                cmd.Parameters.Add(new SqlParameter("@DOSAGEM", Dosagem));

                cmd.ExecuteNonQuery();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE MEDICATIONS SET MEDICATION_NAME = @NOME, DESCRIPTION = @DESCRICAO, DOSAGE = @DOSAGEM WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", Descricao));
                cmd.Parameters.Add(new SqlParameter("@DOSAGEM", Dosagem));

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM MEDICATIONS WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
