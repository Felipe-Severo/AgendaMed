using AgendaMed.Business.Genericos;
using AgendaMedWebApp.Business.Utils;
using System;
using System.Collections.Generic;
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
                cmd.CommandText = "SELECT ID, DOCTOR_ID, PATIENT_ID, PRESCRIPTION_ID, APPOINTMENT_DATETIME, SYMPTOMS, TESTS, RECOMMENDATIONS, APPOINTMENT_STATUS, CREATED_ON FROM APPOINTMENTS";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Consulta consulta = new Consulta()
                    {
                        Id = reader.GetInt32(0),
                        Medico = reader.GetInt32(1),
                        Paciente = reader.GetInt32(2),
                        Receita = reader.GetInt32(3),
                        DataConsulta = reader.GetDateTime(4),
                        Sintomas = reader.GetString(5),
                        Exames = reader.GetString(6),
                        Recomendacoes = reader.GetString(7),
                        StatusConsulta = (StatusConsulta) reader.GetInt32(8),
                        DataAgendamento = reader.GetDateTime(9),
                        
                       
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
                cmd.CommandText = "SELECT ID, DOCTOR_ID, PATIENT_ID, PRESCRIPTION_ID, APPOINTMENT_DATE, SYMPTOMS, TESTS, RECOMMENDATIONS, APPOINTMENT_STATUS, CREATED_ON FROM APPOINTMENTS WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Consulta consulta = new Consulta()
                    {
                        Id = reader.GetInt32(0),
                        Medico = reader.GetInt32(1),
                        Paciente = reader.GetInt32(2),
                        Receita = reader.GetInt32(3),
                        DataConsulta = reader.GetDateTime(4),
                        Sintomas = reader.GetString(5),
                        Exames = reader.GetString(6),
                        Recomendacoes = reader.GetString(7),
                        StatusConsulta = (StatusConsulta)reader.GetInt32(8),
                        DataAgendamento = reader.GetDateTime(9),
                    };

                    result = consulta;
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
                cmd.CommandText = "INSERT INTO APPOINTMENTS (DOCTOR_ID, PATIENT_ID, PRESCRIPTION_ID, APPOINTMENT_DATE, SYMPTOMS, TESTS, RECOMMENDATIONS, APPOINTMENT_STATUS, CREATED_ON )" +
                                  $"VALUES (@MEDICO_ID, @PACIENTE_ID, @RECEITA_ID, @DATA_CONSULTA, @SINTOMAS, @EXAMES, @RECOMENDACOES, @STATUS_DA_CONSULTA, @DATA_AGENDAMENTO)";

                cmd.Parameters.Add(new SqlParameter("@MEDICO_ID", Medico));
                cmd.Parameters.Add(new SqlParameter("@PACIENTE_ID", Paciente));
                cmd.Parameters.Add(new SqlParameter("@RECEITA_ID", Receita));
                cmd.Parameters.Add(new SqlParameter("@DATA_CONSULTA", DataConsulta));
                cmd.Parameters.Add(new SqlParameter("@SINTOMAS", Sintomas));
                cmd.Parameters.Add(new SqlParameter("@EXAMES", Exames));
                cmd.Parameters.Add(new SqlParameter("@RECOMENDACOES", Recomendacoes));
                cmd.Parameters.Add(new SqlParameter("@STATUS_DA_CONSULTA", StatusConsulta));
                cmd.Parameters.Add(new SqlParameter("@DATA_AGENDAMENTO", DataAgendamento));




                cmd.ExecuteNonQuery();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE APPOINTMENTS SET DOCTOR_ID = @MEDICO_ID, PATIENT_ID = @PACIENTE_ID, RECEITA_ID = @RECEITA_ID, DATA_CONSULTA = @DATA_CONSULTA, HORA_CONSULTA = @HORA_CONSULTA, SINTOMAS = @SINTOMAS, EXAMES = @EXAMES, RECOMENDACOES = @RECOMENDACOES, STATUS_DA_CONSULTA = @STATUS_DA_CONSULTA, DATA_AGENDAMENTO = @CREATED_ON WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@MEDICO_ID", Medico));
                cmd.Parameters.Add(new SqlParameter("@PACIENTE_ID", Paciente));
                cmd.Parameters.Add(new SqlParameter("@RECEITA_ID", Receita));
                cmd.Parameters.Add(new SqlParameter("@DATA_CONSULTA", DataConsulta));
                cmd.Parameters.Add(new SqlParameter("@SINTOMAS", Sintomas));
                cmd.Parameters.Add(new SqlParameter("@EXAMES", Exames));
                cmd.Parameters.Add(new SqlParameter("@RECOMENDACOES", Recomendacoes));
                cmd.Parameters.Add(new SqlParameter("@STATUS_DA_CONSULTA", StatusConsulta));

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
    

