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
        private const string DBConnection = "Data Source=BUE0001D023\\SQLEXPRESS;Initial Catalog=Appointment_Scheduling_SystemDB;User ID=sa;Password=Senac@2021;";

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
                    cmd.CommandText = "SELECT COUNT(ID) FROM PESSOAS";

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