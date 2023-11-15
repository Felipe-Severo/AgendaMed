using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Utils
{
    public class DBConnect
    {
        private IConfiguration _configuration = null;

        public DBConnect()
        {
            //var builder - new ConfigurationBuilder
        }

        private const string DBConnection = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=Appointment_Scheduling_SystemDB;User ID=sa;Password=Senac@2021;";


        public static string GetDBConnection()
        {
            return DBConnection;
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT COUNT(ID) FROM PEOPLE";

                    var reader = cmd.ExecuteReader();
                    reader.Read();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}