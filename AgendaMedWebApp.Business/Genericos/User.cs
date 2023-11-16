using AgendaMedWebApp.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedWebApp.Business.Genericos
{
    public enum AccessType
    {
        Adm = 0,
        Doctor = 1,
        Patient = 2,
    }


    public class User
    {
        public long Id { get; set; }
        public long Pessoa { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public AccessType AccessType { get; set; }


        public static List<User> Read()
        {
            var result = new List<User>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, PERSON_ID, LOGIN, PASSWORD, ACCESS_TYPE FROM USERS";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User()
                    {
                        Id = reader.GetInt32(0),
                        Pessoa = reader.GetInt32(1),
                        Login = reader.GetString(2),
                        Password = reader.GetString(3),
                        AccessType = (AccessType)reader.GetInt32(4),
                    };
                    result.Add(user);
                }
            }

            return result;
        }

        public static User ReadOne(long id)
        {
            User result = null;

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, PERSON_ID, LOGIN, PASSWORD, ACCESS_TYPE FROM USERS WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User()
                    {
                        Id = reader.GetInt32(0),
                        Pessoa = reader.GetInt32(1),
                        Login = reader.GetString(2),
                        Password = reader.GetString(3),
                        AccessType = (AccessType)reader.GetInt32(4),
                    };

                    result = user;
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
                cmd.CommandText = "INSERT INTO USERS (PERSON_ID, LOGIN, PASSWORD, ACCESS_TYPE) " +
                    $"OUTPUT INSERTED.ID VALUES (@PERSON_ID, @LOGIN, @PASSWORD, @ACCESS_TYPE)";

                cmd.Parameters.Add(new SqlParameter("@PERSON_ID", Pessoa));
                cmd.Parameters.Add(new SqlParameter("@LOGIN", Login));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", Password));
                cmd.Parameters.Add(new SqlParameter("@ACCESS_TYPE", AccessType));

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE USERS SET LOGIN = @LOGIN, PASSWORD = @PASSWORD, ACCESS_TYPE = @ACCESS_TYPE  WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@LOGIN", Login));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", Password));
                cmd.Parameters.Add(new SqlParameter("@ACCESS_TYPE", AccessType));

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM USERS WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
