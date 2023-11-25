﻿using AgendaMed.Business.Genericos;
using AgendaMedWebApp.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public class ReceitaMedicamentos
    {

        public long Id { get; set; }
        public Medicamento Medication_Id { get; set; }
        public long Prescription_Id { get; set; }
        //public decimal Dosage { get; set; }
        public string Posology { get; set; }

        public static List<ReceitaMedicamentos> Read()
        {
            var result = new List<ReceitaMedicamentos>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, MEDICATION_ID, PRESCRIPTION_ID, POSOLOGY FROM MEDICATION_PRESCRIPTION";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReceitaMedicamentos medicamento = new ReceitaMedicamentos()
                    {
                        Id = reader.GetInt32(0),
                        Medication_Id = Medicamento.ReadOne(reader.GetInt32(1)),
                        Prescription_Id = reader.GetInt32(2),

                        Posology = reader.GetString(4),
                    };

                    result.Add(medicamento);
                }
            }

            return result;
        }

        public static List<ReceitaMedicamentos> Read(long Id)
        {
            var result = new List<ReceitaMedicamentos>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, MEDICATION_ID, PRESCRIPTION_ID, POSOLOGY FROM MEDICATION_PRESCRIPTIONS";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReceitaMedicamentos medicamento = new ReceitaMedicamentos()
                    {
                        Id = reader.GetInt32(0),
                        Medication_Id = Medicamento.ReadOne(reader.GetInt32(1)),
                        Prescription_Id = reader.GetInt32(2),

                        Posology = reader.GetString(4),
                    };

                    result.Add(medicamento);
                }
            }

            return result;
        }

        public static ReceitaMedicamentos ReadOne(long id)
        {
            ReceitaMedicamentos result = null;

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, MEDICATION_ID, PRESCRIPTION_ID, POSOLOGY FROM MEDICATION_PRESCRIPTION WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ReceitaMedicamentos medicamento = new ReceitaMedicamentos()
                    {
                        Id = reader.GetInt32(0),
                        Medication_Id = Medicamento.ReadOne(reader.GetInt32(1)),
                        Prescription_Id = reader.GetInt32(2),

                        Posology = reader.GetString(4),
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
                cmd.CommandText = "INSERT INTO MEDICATION_PRESCRIPTIONS (MEDICATION_ID, PRESCRIPTION_ID, POSOLOGY, ID)" +
                                  $"VALUES (@MEDICATION_ID, @PRESCRIPTION_ID, @POSOLOGY, @ID)";

                cmd.Parameters.Add(new SqlParameter("@MEDICATION_ID", Medication_Id));
                cmd.Parameters.Add(new SqlParameter("@PRESCRIPTION_ID", Prescription_Id));

                cmd.Parameters.Add(new SqlParameter("@POSOLOGY", Posology));
                cmd.Parameters.Add(new SqlParameter("@ID", Id));

                cmd.ExecuteNonQuery();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE MEDICATION_PRESCRIPTIONS SET MEDICATION_ID = @MEDICATION_ID, PRESCRIPTION_ID = @PRESCRIPTION_ID , POSOLOGY = @POSOLOGY WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@MEDICATION_ID", Medication_Id));
                cmd.Parameters.Add(new SqlParameter("@PRESCRIPTION_ID", Prescription_Id));

                cmd.Parameters.Add(new SqlParameter("@PRESCRIPTION", Posology));

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM MEDICATION_PRESCRIPTIONS WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.ExecuteNonQuery();
            }
        }


    }
}

