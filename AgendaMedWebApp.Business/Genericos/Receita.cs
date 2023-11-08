using AgendaMedWebApp.Business.Utils;
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
        public int Medicamentos { get; set; }
        public decimal Dosagem { get; set; }
        public int PosologiaHora { get; set; }
        public int PosologiaDias { get; set; }

        public List<ReceitaMedicamentos> _Medicamento { get; set; }  = new List<ReceitaMedicamentos>();
    



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

                        receita._Medicamento = ReceitaMedicamentos.Read(venda.Id);

                        result.Add(venda);
                    }
                }

                return result;
            }

            public static Venda ReadOne(long id)
            {
                Venda result = null;

                using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT ID, CLIENTE, VALOR, DATA, VENDEDOR, FORMAPAGAMENTO FROM VENDAS WHERE ID = @ID";
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Venda venda = new Venda()
                        {
                            Id = reader.GetInt32(0),
                            Cliente = reader.GetInt32(1),
                            Valor = reader.GetDecimal(2),
                            Data = reader.GetDateTime(3),
                            Vendedor = reader.GetInt32(4),
                            FormaPagamento = (FormaPagamento)reader.GetInt32(5),
                        };
                        venda.Produtos = VendaProduto.Read(venda.Id);

                        result = venda;
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
                    cmd.CommandText = "INSERT INTO VENDAS (CLIENTE, VALOR, DATA, VENDEDOR, FORMAPAGAMENTO)" +
                                      $"VALUES (@CLIENTE, @VALOR, @DATA, @VENDEDOR, @FORMAPAGAMENTO)";

                    cmd.Parameters.Add(new SqlParameter("@CLIENTE", Cliente));
                    cmd.Parameters.Add(new SqlParameter("@VALOR", Valor));
                    cmd.Parameters.Add(new SqlParameter("@DATA", Data));
                    cmd.Parameters.Add(new SqlParameter("@VENDEDOR", Vendedor));
                    cmd.Parameters.Add(new SqlParameter("@FORMAPAGAMENTO", FormaPagamento));

                    cmd.ExecuteNonQuery();
                }
            }

            public void Update()
            {
                using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE VENDAS SET CLIENTE = @CLIENTE, VALOR = @VALOR, DATA = @DATA, VENDEDOR = @VENDEDOR, FORMAPAGAMENTO = @FORMAPAGAMENTO WHERE ID = @ID";

                    cmd.Parameters.Add(new SqlParameter("@ID", Id));
                    cmd.Parameters.Add(new SqlParameter("@CLIENTE", Cliente));
                    cmd.Parameters.Add(new SqlParameter("@VALOR", Valor));
                    cmd.Parameters.Add(new SqlParameter("@DATA", Data));
                    cmd.Parameters.Add(new SqlParameter("@VENDEDOR", Vendedor));
                    cmd.Parameters.Add(new SqlParameter("@FORMAPAGAMENTO", FormaPagamento));

                    cmd.ExecuteNonQuery();
                }
            }

            public void Delete()
            {
                using (var conn = new SqlConnection(DBConnect.GetDBConnection()))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM VENDAS WHERE ID = @ID";

                    cmd.Parameters.Add(new SqlParameter("@ID", Id));
                    cmd.ExecuteNonQuery();
                }
            }

            public class Medicamento
            {
            }
        }
    }
}

