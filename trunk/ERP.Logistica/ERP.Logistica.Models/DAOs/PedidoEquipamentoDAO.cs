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

       public static void criar(int disponibilidade, DateTime requisicao, int encomenda, int efetuado)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               string sql = "INSERT INTO PedidoEquipamento (Disponibilidade, Requisicao, Equipamentos_Fornecedores, Efetuado) VALUES (";
               sql += disponibilidade + ", '" + requisicao.ToString("yyyy-MM-dd HH:mm:ss") + "', " + encomenda + "," + efetuado + ")";
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
               string sql = "DELETE FROM PedidoEquipamento WHERE id = " + id;
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

       public static void atualizar(int id, int disponibilidade, DateTime requisicao, int encomenda, int efetuado)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               string sql = "UPDATE PedidoEquipamento SET Disponibilidade = " + disponibilidade + ", " + "Efetuado = " + efetuado + " WHERE id = " + id;
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
               string sql = "SELECT * FROM PedidoEquipamento WHERE id = " + id;
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
               string sql = "SELECT PE.id, PE.Disponibilidade, PE.Requisicao, PE.Equipamentos_Fornecedores, EN.Preço_Unitário, PE.Efetuado FROM (SELECT * FROM PedidoEquipamento WHERE YEAR(Requisicao) = " + ano + "AND MONTH(Requisicao) = " + mes + ") AS PE LEFT JOIN [Equipamentos_Fornecedores(Encomenda)] AS EN ON PE.Equipamentos_Fornecedores = EN.id;";
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

       public static float buscarPrecoDeEncomenda(int idEncomenda)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT Preço_Unitário FROM [Equipamentos_Fornecedores(Encomenda)] WHERE id = " + idEncomenda + ";";
               SqlDataAdapter da = new SqlDataAdapter(sql, connection);

               DataSet ds = new DataSet();
               da.Fill(ds);
               connection.Close();

               if (ds.Tables[0].Rows.Count > 0)
               {
                   return (float)Convert.ToDouble(ds.Tables[0].Rows[0][0]);
               }
               else
               {
                   return 0F;
               }
           }
           catch (Exception ex)
           {
               throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
           }
       }

       public static int buscarEquipamentoDeEncomenda(int idEncomenda)
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT Equipamento FROM [Equipamentos_Fornecedores(Encomenda)] WHERE id = " + idEncomenda + ";";
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
               string sql = "SELECT PE.id, E.Nome AS Equipamento, F.Nome AS Fornecedor, PE.Disponibilidade, EN.Preço_Unitário AS Preco, PE.Requisicao AS Requisicao, PE.Efetuado FROM ((PedidoEquipamento AS PE LEFT JOIN [Equipamentos_Fornecedores(Encomenda)] AS EN ON PE.Equipamentos_Fornecedores = EN.id) LEFT JOIN Equipamento AS E ON EN.Equipamento = E.id) LEFT JOIN Fornecedor AS F ON EN.Fornecedor = F.id ORDER BY Requisicao DESC;";
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
                   sql = "SELECT PE.id, E.Nome AS Equipamento, F.Nome AS Fornecedor, EN.Preço_Unitário AS Preco, PE.Requisicao AS Requisicao FROM ((PedidoEquipamento AS PE LEFT JOIN [Equipamentos_Fornecedores(Encomenda)] AS EN ON PE.Equipamentos_Fornecedores = EN.id) LEFT JOIN Equipamento AS E ON EN.Equipamento = E.id) LEFT JOIN Fornecedor AS F ON EN.Fornecedor = F.id WHERE Requisicao >= '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Requisicao <= '" + fim.ToString("yyyy-MM-dd HH:mm:ss") + "' AND PE.Efetuado = 1 ORDER BY Requisicao DESC;";
               }
               else
               {
                   sql = "SELECT PE.id, E.Nome AS Equipamento, F.Nome AS Fornecedor, EN.Preço_Unitário AS Preco, PE.Requisicao AS Requisicao, PE.Efetuado FROM ((PedidoEquipamento AS PE LEFT JOIN [Equipamentos_Fornecedores(Encomenda)] AS EN ON PE.Equipamentos_Fornecedores = EN.id) LEFT JOIN Equipamento AS E ON EN.Equipamento = E.id) LEFT JOIN Fornecedor AS F ON EN.Fornecedor = F.id WHERE Requisicao >= '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Requisicao <= '" + fim.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY Requisicao DESC;";
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

       public static DataTable listarEncomendasDisponiveis()
       {
           try
           {
               SqlConnection connection = new SqlConnection(connectionSettings);
               connection.Open();
               string sql = "SELECT EN.id AS Id, E.Nome + ' - ' + F.Nome + ' - ' + CONVERT(VARCHAR(50), EN.Preço_Unitário) AS Encomenda FROM ([Equipamentos_Fornecedores(Encomenda)] AS EN LEFT JOIN Equipamento AS E ON EN.Equipamento = E.id) LEFT JOIN Fornecedor AS F ON EN.Fornecedor = F.id;";
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
