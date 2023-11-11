//using AgendaMedWebApp.Business.Utils;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

//namespace AgendaMedWebApp.Business.Genericos
//{
//    public enum StatusConsulta
//    {
//        Agendado = 0,
//        Cancelado = 1,
//        Vencido = 2,
//        Realizado = 3,
//    }


//    public class Consulta
//    {
//        public long Id { get; set; }
//        public long Medico { get; set; }
//        public long Paciente { get; set; }
//        public DateTime DataConsulta { get; set; }
//        public StatusConsulta StatusConsulta { get; set; }
//        public string Sintomas { get; set; }
//        public string Recomendacoes { get; set; }
//        public string Exames { get; set;}


//        public static List<Consulta> Read()
//        {
//            var result = new List<Consulta>();

//            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
//            {
//                conn.Open();
//                var cmd = conn.CreateCommand();
//                cmd.CommandText = "SELECT ID, DOCTOR_ID, PATIENT_ID, PRESCRIPTION_ID, APPOINTMENT_DATE, " +
//                    "APPOINTMENT_TIME, SYMPTOMS, TESTS, RECOMMENDATIONS, APPOINTMENT_STATUS, APPOINTMENT_DATETIME FROM APPOINTMENTS";


//                var reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    Consulta venda = new Consulta()
//                    {
//                        Id = reader.GetInt32(0),
//                        Medico = reader.GetInt64(1),
//                        Paciente = reader.GetInt64(2),
//                        Rece
//                    };

                   

//                    result.Add(venda);
//                }
//            }

//            return result;
//        }


//    }
//}

////namespace WebApplicationMVC.Business.Genericos
////{
////    public enum FormaPagamento
////    {
////        CartaoCredito = 10,
////        CartaoDebito = 20,
////        Cheque = 30,
////        Dinheiro = 40,
////        Pix = 50,
////    }

////    public class Consulta
////    {
////        public long Id { get; set; }
////        public long Cliente { get; set; }
////        public decimal Valor { get; set; }
////        public DateTime Data { get; set; }
////        public long Vendedor { get; set; }
////        public FormaPagamento FormaPagamento { get; set; }
////        public List<ConsultaProduto> Produtos { get; set; } = new List<ConsultaProduto>();



////        public static Consulta ReadOne(long id)
////        {
////            Consulta result = null;

////            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
////            {
////                conn.Open();
////                var cmd = conn.CreateCommand();
////                cmd.CommandText = "SELECT ID, CLIENTE, VALOR, DATA, VENDEDOR, FORMAPAGAMENTO FROM VENDAS WHERE ID = @ID";
////                cmd.Parameters.Add(new SqlParameter("@ID", id));

////                var reader = cmd.ExecuteReader();
////                if (reader.Read())
////                {
////                    Consulta venda = new Consulta()
////                    {
////                        Id = reader.GetInt32(0),
////                        Cliente = reader.GetInt32(1),
////                        Data = reader.GetDateTime(3),
////                        Vendedor = reader.GetInt32(4),
////                        FormaPagamento = (FormaPagamento)reader.GetInt32(5),
////                    };
////                    venda.Produtos = ConsultaProduto.Read(venda.Id);
////                    venda.Valor = venda.Produtos.Sum(i => i.PrecoAtual * i.Quantidade);

////                    result = venda;
////                }
////            }

////            return result;
////        }

////        public long Create()
////        {
////            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
////            {
////                conn.Open();
////                var cmd = conn.CreateCommand();
////                cmd.CommandText = "INSERT INTO VENDAS (CLIENTE, VALOR, DATA, VENDEDOR, FORMAPAGAMENTO)" +
////                                  $"OUTPUT INSERTED.ID VALUES (@CLIENTE, @VALOR, @DATA, @VENDEDOR, @FORMAPAGAMENTO)";

////                cmd.Parameters.Add(new SqlParameter("@CLIENTE", Cliente));
////                cmd.Parameters.Add(new SqlParameter("@VALOR", Valor));
////                cmd.Parameters.Add(new SqlParameter("@DATA", Data));
////                cmd.Parameters.Add(new SqlParameter("@VENDEDOR", Vendedor));
////                cmd.Parameters.Add(new SqlParameter("@FORMAPAGAMENTO", FormaPagamento));

////                return (int)cmd.ExecuteScalar();
////            }
////        }

////        public void Update()
////        {
////            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
////            {
////                conn.Open();
////                var cmd = conn.CreateCommand();
////                cmd.CommandText = "UPDATE VENDAS SET CLIENTE = @CLIENTE, VALOR = @VALOR, DATA = @DATA, VENDEDOR = @VENDEDOR, FORMAPAGAMENTO = @FORMAPAGAMENTO WHERE ID = @ID";

////                cmd.Parameters.Add(new SqlParameter("@ID", Id));
////                cmd.Parameters.Add(new SqlParameter("@CLIENTE", Cliente));
////                cmd.Parameters.Add(new SqlParameter("@VALOR", Valor));
////                cmd.Parameters.Add(new SqlParameter("@DATA", Data));
////                cmd.Parameters.Add(new SqlParameter("@VENDEDOR", Vendedor));
////                cmd.Parameters.Add(new SqlParameter("@FORMAPAGAMENTO", FormaPagamento));

////                cmd.ExecuteNonQuery();
////            }
////        }

////        public void Delete()
////        {
////            using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
////            {
////                conn.Open();
////                var cmd = conn.CreateCommand();
////                cmd.CommandText = "DELETE FROM VENDAS WHERE ID = @ID";

////                cmd.Parameters.Add(new SqlParameter("@ID", Id));
////                cmd.ExecuteNonQuery();
////            }
////        }
////    }
////}