using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ERP.Logistica.Models
{
    public class PedidoMedicamentoDAO
    {
       //private static string connectionSettings = System.Configuration.ConfigurationManager.AppSettings["ERPLogisticaConnectionString"];
       //private static string connectionSettings = "Data Source=ls01;Initial Catalog=erp_logistica;Integrated Security=True";
       //private static string connectionSettings = "Data Source=JUN-PC;Initial Catalog=erp_logistica;Integrated Security=True";
       private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

       public static void criar(int quantidade, DateTime requisicao, int lote, int efetuado)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               string sql = "INSERT INTO PedidoMedicamento (Quantidade, Requisicao, Medicamento_Fornecedor, Efetuado) VALUES (";
               sql += quantidade + ", '" + requisicao.ToString("yyyy-MM-dd HH:mm:ss") + "', " + lote + "," + efetuado + ")";
               SqlCommand cmd = new SqlCommand(sql, connection);
               cmd.CommandType = CommandType.Text;
               connection.Open();
               cmd.ExecuteNonQuery();
               connection.Dispose();
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método criar: " + ex.Message);
           }
       }

       
       public static void apagar(int id)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               string sql = "DELETE FROM PedidoMedicamento WHERE id = " + id;
               SqlCommand cmd = new SqlCommand(sql, connection);
               cmd.CommandType = CommandType.Text;
               connection.Open();
               cmd.ExecuteNonQuery();
               connection.Dispose();
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método apagar: " + ex.Message);
           }
       }

       public static void atualizar(int id, int quantidade, DateTime requisicao, int lote, int efetuado)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               string sql = "UPDATE PedidoMedicamento SET Quantidade = " + quantidade + ", " + "Efetuado = " + efetuado + " WHERE id = " + id;
               SqlCommand cmd = new SqlCommand(sql, connection);
               cmd.CommandType = CommandType.Text;
               connection.Open();
               cmd.ExecuteNonQuery();
               connection.Dispose();
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método atualizar: " + ex.Message);
           }
       }

       public static DataSet buscarPorId(int id)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT * FROM PedidoMedicamento WHERE id = " + id;
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds, "PedidoMedicamento");
               connection.Close();

               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
           }
       }

       public static DataSet buscarPorRequisicao(int ano, int mes)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT PM.id, PM.Quantidade, PM.Requisicao, PM.Medicamento_Fornecedor, L.Preço_Unitário, PM.Efetuado FROM (SELECT * FROM PedidoMedicamento WHERE YEAR(Requisicao) = " + ano + "AND MONTH(Requisicao) = " + mes + ") AS PM LEFT JOIN [Medicamento_Fornecedor(Lote)] AS L ON PM.Medicamento_Fornecedor = L.id;";
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
           }
       }

       public static DataSet buscarInfoCompletaPorRequisicao(int ano, int mes)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT PM.id, M.Nome AS Medicamento, F.Nome AS Fornecedor, PM.Quantidade, L.Preço_Unitário AS Preco, PM.Requisicao AS Requisicao, PM.Efetuado FROM ((PedidoMedicamento AS PM LEFT JOIN [Medicamento_Fornecedor(Lote)] AS L ON PM.Medicamento_Fornecedor = L.id) LEFT JOIN Medicamento AS M ON L.Medicamento = M.id) LEFT JOIN Fornecedor AS F ON L.Fornecedor = F.id WHERE YEAR(Requisicao) = " + ano + "AND MONTH(Requisicao) = " + mes + ";";
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
           }
       }

       public static float buscarPrecoDeLote(int idLote)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT Preço_Unitário FROM [Medicamento_Fornecedor(Lote)] WHERE id = " + idLote + ";";
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               return (float)Convert.ToDouble(ds.Tables[0].Rows[0][0]);
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
           }
       }

       public static DataTable listar()
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT PM.id, M.Nome AS Medicamento, F.Nome AS Fornecedor, PM.Quantidade, L.Preço_Unitário AS Preco, PM.Requisicao, PM.Efetuado FROM ((PedidoMedicamento AS PM LEFT JOIN [Medicamento_Fornecedor(Lote)] AS L ON PM.Medicamento_Fornecedor = L.id) LEFT JOIN Medicamento AS M ON L.Medicamento = M.id) LEFT JOIN Fornecedor AS F ON L.Fornecedor = F.id;";
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               return ds.Tables[0];
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
           }
       }

       public static DataTable listarMedicamentosFornecedores()
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT L.id AS Id, M.Nome + ' - ' + F.Nome + ' - ' + CONVERT(VARCHAR(50), L.Preço_Unitário) AS Lote FROM ([Medicamento_Fornecedor(Lote)] AS L LEFT JOIN Medicamento AS M ON L.Medicamento = M.id) LEFT JOIN Fornecedor AS F ON L.Fornecedor = F.id;";
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               return ds.Tables[0];
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
           }
       }
    }
}
