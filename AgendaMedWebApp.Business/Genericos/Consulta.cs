using AgendaMed.Business.Genericos;
using AgendaMedWebApp.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public enum StatusConsulta
    {
        Agendado = 0,
        Cancelado = 1,
        Vencido = 2,
        Realizado = 3,
    }


    public class Consulta
    {
        public long Id { get; set; }
        public long Medico { get; set; }
        public long Paciente { get; set; }
        public long Receita { get; set; }
        public DateTime DataConsulta { get; set; }
        public StatusConsulta StatusConsulta { get; set; }
        public string Sintomas { get; set; }
        public string Recomendacoes { get; set; }
        public string Exames { get; set;}
        public DateTime DataAgendamento { get; set; }


 
        public static List<Consulta> Read()
        {
            var result = new List<Consulta>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, DOCTOR_ID, PATIENT_ID, APPOINTMENT_DATETIME, SYMPTOMS, TESTS, RECOMMENDATIONS, APPOINTMENT_STATUS, CREATED_ON FROM APPOINTMENTS";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Consulta consulta = new Consulta()
                    {
                        Id = reader.GetInt32(0),
                        Medico = reader.IsDBNull(1) ? 0 : reader.GetInt32(1), // Verifica se o valor é nulo
                        Paciente = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        //Receita = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        DataConsulta = reader.GetDateTime(3),
                        Sintomas = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        Exames = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Recomendacoes = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        StatusConsulta = (StatusConsulta)reader.GetInt32(7),
                        DataAgendamento = reader.GetDateTime(8),
                    };
                    

                    result.Add(consulta);
                }
            }

            return result;
        }

        public static Consulta ReadOne(long id)
        {
            Consulta result = null;

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, DOCTOR_ID, PATIENT_ID, APPOINTMENT_DATETIME, SYMPTOMS, TESTS, RECOMMENDATIONS, APPOINTMENT_STATUS, CREATED_ON FROM APPOINTMENTS WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Consulta consulta = new Consulta()
                    {
                        Id = reader.GetInt32(0),
                        Medico = reader.IsDBNull(1) ? 0 : reader.GetInt32(1), // Verifica se o valor é nulo
                        Paciente = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        //Receita = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        DataConsulta = reader.GetDateTime(3),
                        Sintomas = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        Exames = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Recomendacoes = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        StatusConsulta = (StatusConsulta)reader.GetInt32(7),
                        DataAgendamento = reader.GetDateTime(8),
                    };

                    result = consulta;
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
                cmd.CommandText = "INSERT INTO APPOINTMENTS (DOCTOR_ID, PATIENT_ID, APPOINTMENT_DATETIME, SYMPTOMS, TESTS, RECOMMENDATIONS, APPOINTMENT_STATUS, CREATED_ON )" +
                                  $"OUTPUT INSERTED.ID VALUES (@DOCTOR_ID, @PATIENT_ID, @APPOINTMENT_DATETIME, @SYMPTOMS, @TESTS, @RECOMMENDATIONS, @APPOINTMENT_STATUS, @CREATED_ON)";

                cmd.Parameters.Add(new SqlParameter("@DOCTOR_ID", Medico));
                cmd.Parameters.Add(new SqlParameter("@PATIENT_ID", Paciente));
                cmd.Parameters.Add(new SqlParameter("@APPOINTMENT_DATETIME", DataConsulta));
                cmd.Parameters.Add(new SqlParameter("@SYMPTOMS", Sintomas));
                cmd.Parameters.Add(new SqlParameter("@TESTS", Exames));
                cmd.Parameters.Add(new SqlParameter("@RECOMMENDATIONS", Recomendacoes));
                cmd.Parameters.Add(new SqlParameter("@APPOINTMENT_STATUS", StatusConsulta));
                cmd.Parameters.Add(new SqlParameter("@CREATED_ON", DataAgendamento));

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE APPOINTMENTS SET DOCTOR_ID = @DOCTOR_ID, PATIENT_ID = @PATIENT_ID, APPOINTMENT_DATETIME = @APPOINTMENT_DATETIME," +
                    $"SYMPTOMS = @SYMPTOMS, TESTS = @TESTS, APPOINTMENT_STATUS = @APPOINTMENT_STATUS, RECOMMENDATIONS = @RECOMMENDATIONS, CREATED_ON = @CREATED_ON WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.Parameters.Add(new SqlParameter("@DOCTOR_ID", Medico));
                cmd.Parameters.Add(new SqlParameter("@PATIENT_ID", Paciente));
                cmd.Parameters.Add(new SqlParameter("@APPOINTMENT_DATETIME", DataConsulta));
                cmd.Parameters.Add(new SqlParameter("@SYMPTOMS", Sintomas));
                cmd.Parameters.Add(new SqlParameter("@TESTS", Exames));
                cmd.Parameters.Add(new SqlParameter("@APPOINTMENT_STATUS", Exames));
                cmd.Parameters.Add(new SqlParameter("@RECOMMENDATIONS", Recomendacoes));
                cmd.Parameters.Add(new SqlParameter("@CREATED_ON", StatusConsulta));

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM APPOINTMENTS WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
    

