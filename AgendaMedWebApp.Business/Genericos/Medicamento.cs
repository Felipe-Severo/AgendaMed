//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AgendaMed.Business.Genericos
//{
//    public class Medicamento
//    {
//        public long Id { get; set; }       
//        public string Nome { get; set; }
//        public string Descricao { get; set; }
//        public decimal Dosagem { get; set; }


//        //private static long _currentId = 0;
//        //public static List<Medicamento> Medicamentos = new List<Medicamento>()
//        //{
//        //    new Medicamento
//        //    {
//        //        Nome = "Dipirona",
//        //        Descricao = "Dor de cabeça",
//        //    },
//        //};

//        //public Medicamento()
//        //{
//        //    Id = ++_currentId;
//        //}
//        public static List<Medicamento> Read()
//        {
//            var result = new List<Medicamento>();

//            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
//            {
//                conn.Open();
//                var cmd = conn.CreateCommand();
//                cmd.CommandText = "SELECT ID, NOME, DESCRICAO, DOSAGEM FROM MEDICAMENTOS";

//                var reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    Medicamento medicamento = new Medicamento()
//                    {
//                        Id = reader.GetInt32(0),
//                        Nome = reader.GetString(1),
//                        Descricao = reader.GetString(2),
//                        Dosagem = reader.GetDecimal(3),

//                    };

//                    result.Add(medicamento);
//                }
//            }

//            return result;
//        }

//        public static Medicamento ReadOne(long id)
//        {
//            Medicamento result = null;

//            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
//            {
//                conn.Open();
//                var cmd = conn.CreateCommand();
//                cmd.CommandText = "SELECT ID, NOME, DESCRICAO, DOSAGEM FROM MEDICAMENTO WHERE ID = @ID";
//                cmd.Parameters.Add(new SqlParameter("@ID", id));

//                var reader = cmd.ExecuteReader();
//                if (reader.Read())
//                {
//                    Produto medicamento = new Medicamento()
//                    {
//                        Id = reader.GetInt32(0),
//                        Nome = reader.GetString(1),
//                        Descricao = reader.GetString(2),
//                        Dosagem = reader.GetDecimal(3),
//                    };

//                    result = medicamento;
//                }
//            }

//            return result;
//        }

//        public void Create()
//        {
//            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
//            {
//                conn.Open();
//                var cmd = conn.CreateCommand();
//                cmd.CommandText = "INSERT INTO PRODUTOS (NOME, DESCRICAO, DOSAGEM )" +
//                                  $"VALUES (@NOME, @DESCRICAO, @DOSAGEM)";

//                cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
//                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", Descricao));
//                cmd.Parameters.Add(new SqlParameter("@DOSAGEM", Categoria));

//                cmd.ExecuteNonQuery();
//            }
//        }

//        public void Update()
//        {
//            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
//            {
//                conn.Open();
//                var cmd = conn.CreateCommand();
//                cmd.CommandText = "UPDATE PRODUTOS SET NOME = @NOME, DESCRICAO = @DESCRICAO, PRECO = @PRECO, CATEGORIA = @CATEGORIA WHERE ID = @ID";

//                cmd.Parameters.Add(new SqlParameter("@ID", Id));
//                cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
//                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", Descricao));
//                cmd.Parameters.Add(new SqlParameter("@PRECO", Preco));
//                cmd.Parameters.Add(new SqlParameter("@CATEGORIA", Categoria));

//                cmd.ExecuteNonQuery();
//            }
//        }

//        public void Delete()
//        {
//            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
//            {
//                conn.Open();
//                var cmd = conn.CreateCommand();
//                cmd.CommandText = "DELETE FROM PRODUTOS WHERE ID = @ID";

//                cmd.Parameters.Add(new SqlParameter("@ID", Id));
//                cmd.ExecuteNonQuery();
//            }
//        }
//    }
//}
