﻿using AgendaMedWebApp.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public class Receita
    {
        public long Id { get; set; }
        public DateTime DataPrescricao { get; set; }
        

        public List<ReceitaMedicamentos> _Medicamento { get; set; } = new List<ReceitaMedicamentos>();




        //private static long _currentId = 0;
        //public static List<Receita> Receitas = new List<Receita>()
        //{
        //    new Receita
        //    {
        //    DataPrescricao = DateTime.Parse("05/11/2023"),
        //    Medicamento = 10,
        //    PosologiaHora = 12,
        //    PosologiaDias =5,
        //    Dosagem = 0,           
        //    },
        //     new Receita
        //    {
        //    DataPrescricao = DateTime.Parse("05/11/2023"),
        //    Medicamento = 0,
        //    PosologiaHora = 8,
        //    PosologiaDias =7,
        //    Dosagem = 0,
        //    },

        //};

        //public Receita()
        //{
        //    Id = ++_currentId;
        //}





        public static List<Receita> Read()
        {
            var result = new List<Receita>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, PRESCRIPTION_DATE FROM PRESCRIPTIONS";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Receita receita = new Receita()
                    {
                        Id = reader.GetInt32(0),
                        DataPrescricao = reader.GetDateTime(1),

                    };

                    receita._Medicamento = ReceitaMedicamentos.Read(receita.Id);

                    result.Add(receita);
                }
            }

            return result;
        }

        public static Receita ReadOne(long id)
        {
            Receita result = null;

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, PRESCRIPTION_DATE FROM PRESCRIPTIONS WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Receita receita = new Receita()
                    {
                        Id = reader.GetInt32(0),
                        DataPrescricao = reader.GetDateTime(1),
                    };

                    receita._Medicamento = ReceitaMedicamentos.Read(receita.Id);

                    result = receita;
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
                cmd.CommandText = "INSERT INTO PRESCRIPTIONS (PRESCRIPTION_DATE)" +
                                   $"OUTPUT INSERTED.ID VALUES (@PRESCRIPTION_DATE)";

                cmd.Parameters.Add(new SqlParameter("@PRESCRIPTION_DATE", DataPrescricao));

                return (long)cmd.ExecuteScalar();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE PRESCRIPTIONS SET PRESCRIPTION_DATE = @PRESCRIPTION_DATE WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.Parameters.Add(new SqlParameter("@PRESCRIPTION_DATE", DataPrescricao));
              

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM PRESCRIPTIONS WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.ExecuteNonQuery();
            }
        }


    }
}


