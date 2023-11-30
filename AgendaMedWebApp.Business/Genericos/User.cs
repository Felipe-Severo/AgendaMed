using AgendaMedWebApp.Business.Utils;
using System.Data.SqlClient;


namespace AgendaMedWebApp.Business.Genericos
{
    public enum AccessType
    {
        Admin = 0,
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
        public byte[] Pic { get; set; }
        public string PicName { get; set; }

        public static List<User> Read()
        {
            var result = new List<User>();

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, PERSON_ID, LOGIN, PASSWORD, ACCESS_TYPE, PICNAME, PIC FROM USERS";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User()
                    {
                        Id = reader.GetInt32(0),
                        Pessoa = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                        Login = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Password = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        AccessType = (AccessType)reader.GetInt32(4),
                        PicName = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Pic = !reader.IsDBNull(6) ? (byte[])reader.GetValue(6) : null,
                        //PicName = reader.GetString(5),
                        //Pic = reader["PIC"] != DBNull.Value ? (byte[])reader["PIC"] : null,
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
                cmd.CommandText = "SELECT ID, PERSON_ID, LOGIN, PASSWORD, ACCESS_TYPE, PICNAME, PIC FROM USERS WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User()
                    {
                        Id = reader.GetInt32(0),
                        Pessoa = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                        Login = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Password = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        AccessType = (AccessType)reader.GetInt32(4),
                        PicName = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty,
                        Pic = !reader.IsDBNull(6) ? (byte[])reader.GetValue(6) : null,
                        //PicName = reader.GetString(5),
                        //Pic = reader["PIC"] != DBNull.Value ? (byte[])reader["PIC"] : null,
                    };

                    result = user;
                }
            }

            return result;
        }

        public static User ReadOne(string login, string password)
        {
            User result = null;
            string passwordHash = HashGenerator.GenerateHash(password, HashType.MD5);

            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, PERSON_ID, LOGIN, PASSWORD, ACCESS_TYPE FROM USERS WHERE LOGIN = @LOGIN AND PASSWORD = @PASSWORD";
                cmd.Parameters.Add(new SqlParameter("@LOGIN", login));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", passwordHash));
                
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

        public bool IsValidPassword(string password)
        {
            return HashGenerator.GenerateHash(password, HashType.MD5).Equals(Password);
        }

        public void UpdatePassword(string newPassword)
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"UPDATE USERS SET PASSWORD = @PASSWORD WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@ID", Id));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", HashGenerator.GenerateHash(newPassword, HashType.MD5)));

                cmd.ExecuteNonQuery();
            }
        }

        public long Create()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"INSERT INTO USERS (PERSON_ID, LOGIN, PASSWORD, ACCESS_TYPE{(Pic != null ? ", PIC, PICNAME" : string.Empty)}) " +
                                  $"OUTPUT INSERTED.ID VALUES (@PERSON_ID, @LOGIN, @PASSWORD, @ACCESS_TYPE{(Pic != null ? ", @PIC, @PICNAME" : string.Empty)})";

                cmd.Parameters.Add(new SqlParameter("@PERSON_ID", Pessoa));
                cmd.Parameters.Add(new SqlParameter("@LOGIN", Login));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", HashGenerator.GenerateHash(Password, HashType.MD5)));
                cmd.Parameters.Add(new SqlParameter("@ACCESS_TYPE", AccessType.GetHashCode()));

                if (Pic != null)
                {
                    cmd.Parameters.Add(new SqlParameter("@PIC", Pic));
                    cmd.Parameters.Add(new SqlParameter("@PICNAME", PicName));
                }

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"UPDATE USERS SET LOGIN = @LOGIN, PASSWORD = @PASSWORD, ACCESSTYPE = @ACCESS_TYPE{(Pic != null ? ", PIC = @PIC, PICNAME = @PICNAME" : string.Empty)} WHERE ID = @ID";

                cmd.Parameters.Add(new SqlParameter("@LOGIN", Login));
                cmd.Parameters.Add(new SqlParameter("@PERSON_ID", Pessoa));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", Password));
                cmd.Parameters.Add(new SqlParameter("@ACCESS_TYPE", AccessType.GetHashCode()));

                if (Pic != null)
                {
                    cmd.Parameters.Add(new SqlParameter("@PIC", Pic));
                    cmd.Parameters.Add(new SqlParameter("@PICNAME", PicName));
                }

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
