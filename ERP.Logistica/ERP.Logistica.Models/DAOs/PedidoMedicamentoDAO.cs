using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ERP.Logistica.Models.DAOs
{
    public class PedidoMedicamentoDAO
    {
       //private static string connectionSettings = System.Configuration.ConfigurationManager.AppSettings["ERPLogisticaConnectionString"];
       //private static string connectionSettings = "Data Source=ls01;Initial Catalog=erp_logistica;Integrated Security=True";
       //private static string connectionSettings = "Data Source=JUN-PC;Initial Catalog=erp_logistica;Integrated Security=True";
       private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

       public static void criar(int quantidade, DateTime requisicao, int catalogoMed, int efetuado)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               string sql = "INSERT INTO Pedido_Medicamento (Quantidade, Requisicao, Catalogo_Medicamento, Efetuado) VALUES (";
               sql += quantidade + ", '" + requisicao.ToString("yyyy-MM-dd HH:mm:ss") + "', " + catalogoMed + "," + efetuado + ")";
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
               string sql = "DELETE FROM Pedido_Medicamento WHERE id = " + id;
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

       public static void atualizar(int id, int quantidade, DateTime requisicao, int catalogoMed, int efetuado, int reportarEstorno)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               string sql = "UPDATE Pedido_Medicamento SET Quantidade = " + quantidade + ", " + "Efetuado = " + efetuado + ", Reportar_Estorno = " + reportarEstorno + " WHERE id = " + id;
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
               string sql = "SELECT * FROM Pedido_Medicamento WHERE id = " + id;
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método buscar por id: " + ex.Message);
           }
       }

       public static DataSet buscar(int ano, int mes)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT PM.id, PM.Quantidade, PM.Requisicao, PM.Catalogo_Medicamento, L.Preco_Unitario, PM.Efetuado FROM (SELECT * FROM Pedido_Medicamento WHERE YEAR(Requisicao) = " + ano + "AND MONTH(Requisicao) = " + mes + ") AS PM LEFT JOIN Catalogo_Medicamento AS L ON PM.Catalogo_Medicamento = L.id;";
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método buscar: " + ex.Message);
           }
       }

       public static DataSet buscarEstornadosAte(DateTime limite, bool todos)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql;
               if (!todos)
               {
                   sql = "SELECT PM.id, PM.Quantidade, PM.Requisicao, PM.Catalogo_Medicamento, L.Preco_Unitario, PM.Efetuado FROM (SELECT * FROM Pedido_Medicamento WHERE Requisicao <= '" + limite.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Reportar_Estorno = 1) AS PM LEFT JOIN Catalogo_Medicamento AS L ON PM.Catalogo_Medicamento = L.id;";
               }
               else
               {
                   sql = "SELECT PM.id, PM.Quantidade, PM.Requisicao, PM.Catalogo_Medicamento, L.Preco_Unitario, PM.Efetuado FROM (SELECT * FROM Pedido_Medicamento WHERE Requisicao <= '" + limite.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Efetuado = 0) AS PM LEFT JOIN Catalogo_Medicamento AS L ON PM.Catalogo_Medicamento = L.id;";
               }
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método buscar estornados ate: " + ex.Message);
           }
       }

       public static void marcarEstornoReportado(DateTime limite)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               string sql = "UPDATE Pedido_Medicamento SET Reportar_Estorno = 0 WHERE Requisicao <= '" + limite.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Reportar_Estorno = 1;";
               SqlCommand cmd = new SqlCommand(sql, connection);
               cmd.CommandType = CommandType.Text;
               connection.Open();
               cmd.ExecuteNonQuery();
               connection.Dispose();
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método marcar estorno reportado: " + ex.Message);
           }
       }

       public static double buscarPrecoDeLote(int idCatalogoMed)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT Preco_Unitario FROM Catalogo_Medicamento WHERE id = " + idCatalogoMed + ";";
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               if (ds.Tables[0].Rows.Count > 0)
               {
                   return Convert.ToDouble(ds.Tables[0].Rows[0][0]);
               }
               else
               {
                   return 0.0;
               }
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método buscar preco de lote: " + ex.Message);
           }
       }

       public static DataTable listar()
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT PM.id AS 'Id', M.Nome AS 'Produto', F.Nome AS 'Fornecedor', PM.Quantidade AS 'Quantidade', L.Preco_Unitario AS 'Preco', PM.Requisicao AS 'Requisicao', PM.Efetuado FROM ((Pedido_Medicamento AS PM LEFT JOIN Catalogo_Medicamento AS L ON PM.Catalogo_Medicamento = L.id) LEFT JOIN Medicamento AS M ON L.Medicamento = M.id) LEFT JOIN Fornecedor AS F ON L.Fornecedor = F.id ORDER BY Requisicao DESC;";
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

       public static DataTable listarPorRequisicao(DateTime inicio, DateTime fim, bool apenasEfetuados)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql;
               if (apenasEfetuados)
               {
                   sql = "SELECT PM.id AS 'Id', M.Nome AS 'Produto', F.Nome AS 'Fornecedor', PM.Quantidade AS 'Quantidade', L.Preco_Unitario AS 'Preco', PM.Requisicao AS 'Requisicao' FROM ((Pedido_Medicamento AS PM LEFT JOIN Catalogo_Medicamento AS L ON PM.Catalogo_Medicamento = L.id) LEFT JOIN Medicamento AS M ON L.Medicamento = M.id) LEFT JOIN Fornecedor AS F ON L.Fornecedor = F.id WHERE Requisicao >= '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Requisicao <= '" + fim.ToString("yyyy-MM-dd HH:mm:ss") + "' AND PM.Efetuado >= 1 ORDER BY Requisicao DESC;";
               }
               else
               {
                   sql = "SELECT PM.id AS 'Id', M.Nome AS 'Produto', F.Nome AS 'Fornecedor', PM.Quantidade AS 'Quantidade', L.Preco_Unitario AS 'Preco', PM.Requisicao AS 'Requisicao', PM.Efetuado FROM ((Pedido_Medicamento AS PM LEFT JOIN Catalogo_Medicamento AS L ON PM.Catalogo_Medicamento = L.id) LEFT JOIN Medicamento AS M ON L.Medicamento = M.id) LEFT JOIN Fornecedor AS F ON L.Fornecedor = F.id WHERE Requisicao >= '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Requisicao <= '" + fim.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY Requisicao DESC;";
               }
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               return ds.Tables[0];
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método listar por requisicao: " + ex.Message);
           }
       }

       public static DataTable listarCatalogoMedDisponiveis()
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               //string sql = "SELECT L.id AS Id, M.Nome + ' - ' + F.Nome + ' - ' + CONVERT(VARCHAR(50), L.Preco_Unitario) AS Catalogo_Medicamento FROM (Catalogo_Medicamento AS L LEFT JOIN Medicamento AS M ON L.Medicamento = M.id) LEFT JOIN Fornecedor AS F ON L.Fornecedor = F.id;";
               string sql = "SELECT L.id AS Id, M.Nome + ' - ' + F.Nome + ' - ' + CONVERT(VARCHAR(50), L.Preco_Unitario) AS 'Catalogo_Medicamento', L.Fornecedor, L.Medicamento, L.Vigencia_Inicio FROM ((Catalogo_Medicamento AS L LEFT JOIN Medicamento AS M ON L.Medicamento = M.id) LEFT JOIN Fornecedor AS F ON L.Fornecedor = F.id) WHERE Vigencia_Inicio = (SELECT MAX(Vigencia_Inicio) FROM Catalogo_Medicamento AS LAUX WHERE LAUX.Fornecedor = L.Fornecedor AND LAUX.Medicamento = L.Medicamento)";
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               return ds.Tables[0];
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método listar catalogo med disp: " + ex.Message);
           }
       }
    }
}
