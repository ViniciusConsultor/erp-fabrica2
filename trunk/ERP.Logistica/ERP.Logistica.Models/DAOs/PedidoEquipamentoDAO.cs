using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ERP.Logistica.Models.DAOs
{
    public class PedidoEquipamentoDAO
    {
       //private static string connectionSettings = System.Configuration.ConfigurationManager.AppSettings["ERPLogisticaConnectionString"];
       //private static string connectionSettings = "Data Source=ls01;Initial Catalog=erp_logistica;Integrated Security=True";
       //private static string connectionSettings = "Data Source=JUN-PC;Initial Catalog=erp_logistica;Integrated Security=True";
       private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

       public static void criar(int disponibilidade, DateTime requisicao, int catalogoEquip, int efetuado)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               string sql = "INSERT INTO Pedido_Equipamento (Disponibilidade, Requisicao, Catalogo_Equipamento, Efetuado) VALUES (";
               sql += disponibilidade + ", '" + requisicao.ToString("yyyy-MM-dd HH:mm:ss") + "', " + catalogoEquip + "," + efetuado + ")";
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
               string sql = "DELETE FROM Pedido_Equipamento WHERE id = " + id;
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

       public static void atualizar(int id, int disponibilidade, DateTime requisicao, int catalogoEquip, int efetuado, int reportarEstorno)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               string sql = "UPDATE Pedido_Equipamento SET Disponibilidade = " + disponibilidade + ", " + "Efetuado = " + efetuado + ", Reportar_Estorno = " + reportarEstorno + " WHERE id = " + id;
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
               string sql = "SELECT * FROM Pedido_Equipamento WHERE id = " + id;
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

       /*public static DataSet buscarPorRequisicao(int ano, int mes)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT PE.id, PE.Disponibilidade, PE.Requisicao, PE.Catalogo_Equipamento, EN.Preco_Unitario, PE.Efetuado FROM (SELECT * FROM Pedido_Equipamento WHERE YEAR(Requisicao) = " + ano + "AND MONTH(Requisicao) = " + mes + ") AS PE LEFT JOIN Catalogo_Equipamento AS EN ON PE.Catalogo_Equipamento = EN.id;";
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
       }*/

       public static double buscarPrecoDeEncomenda(int idCatalogoEquip)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT Preco_Unitario FROM Catalogo_Equipamento WHERE id = " + idCatalogoEquip + ";";
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
               throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
           }
       }

       public static int buscarEquipamentoDeEncomenda(int idCatalogoEquip)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT Equipamento FROM Catalogo_Equipamento WHERE id = " + idCatalogoEquip + ";";
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               if (ds.Tables[0].Rows.Count > 0)
               {
                   return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
               }
               else
               {
                   return 0;
               }
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
               string sql = "SELECT PE.id, E.Nome AS Equipamento, F.Nome AS Fornecedor, PE.Disponibilidade, EN.Preco_Unitario AS Preco, PE.Requisicao AS Requisicao, PE.Efetuado FROM ((Pedido_Equipamento AS PE LEFT JOIN Catalogo_Equipamento AS EN ON PE.Catalogo_Equipamento = EN.id) LEFT JOIN Equipamento AS E ON EN.Equipamento = E.id) LEFT JOIN Fornecedor AS F ON EN.Fornecedor = F.id ORDER BY Requisicao DESC;";
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
                   sql = "SELECT PE.id, E.Nome AS Equipamento, F.Nome AS Fornecedor, EN.Preco_Unitario AS Preco, PE.Requisicao AS Requisicao FROM ((Pedido_Equipamento AS PE LEFT JOIN Catalogo_Equipamento AS EN ON PE.Catalogo_Equipamento = EN.id) LEFT JOIN Equipamento AS E ON EN.Equipamento = E.id) LEFT JOIN Fornecedor AS F ON EN.Fornecedor = F.id WHERE Requisicao >= '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Requisicao <= '" + fim.ToString("yyyy-MM-dd HH:mm:ss") + "' AND PE.Efetuado = 1 ORDER BY Requisicao DESC;";
               }
               else
               {
                   sql = "SELECT PE.id, E.Nome AS Equipamento, F.Nome AS Fornecedor, EN.Preco_Unitario AS Preco, PE.Requisicao AS Requisicao, PE.Efetuado FROM ((Pedido_Equipamento AS PE LEFT JOIN Catalogo_Equipamento AS EN ON PE.Catalogo_Equipamento = EN.id) LEFT JOIN Equipamento AS E ON EN.Equipamento = E.id) LEFT JOIN Fornecedor AS F ON EN.Fornecedor = F.id WHERE Requisicao >= '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Requisicao <= '" + fim.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY Requisicao DESC;";
               }
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

       public static DataTable listarCatalogoEquipDisponiveis()
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT EN.id AS Id, E.Nome + ' - ' + F.Nome + ' - ' + CONVERT(VARCHAR(50), EN.Preco_Unitario) AS Catalogo_Equipamento FROM (Catalogo_Equipamento AS EN LEFT JOIN Equipamento AS E ON EN.Equipamento = E.id) LEFT JOIN Fornecedor AS F ON EN.Fornecedor = F.id;";
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
