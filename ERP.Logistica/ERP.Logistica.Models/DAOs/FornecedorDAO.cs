using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ERP.Logistica.Models
{
    public class FornecedorDAO
    {
        //private static string connectionSettings = System.Configuration.ConfigurationManager.AppSettings["ERPLogisticaConnectionString"];
        //private static string connectionSettings = "Data Source=ls01;Initial Catalog=erp_logistica;Integrated Security=True";
        private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

        public static void criar(string nome, string telefone, string email, string localizacao, int ranking)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "INSERT INTO Fornecedor (Nome, Telefone, Email, Localizacao, Ranking) VALUES (";
                sql +="'" + nome + "','" + telefone + "','" + email + "','" + localizacao + "',"+ ranking +")";
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
                string sql = "DELETE FROM Fornecedor WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                //throw new Exception("Ocorreu um erro no método apagar: " + ex.Message);
            }
        }

        public static void atualizar(int id, string nome, string telefone, string email, string localizacao, int ranking)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "UPDATE Fornecedor SET Nome = '" + nome + "', " + "Telefone = '" + telefone + "'," + "Email = '" + email + "'," + "Localizacao = '" + localizacao + "'," + "Ranking = " + ranking +  " WHERE id = " + id;
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
                string sql = "SELECT * FROM Fornecedor WHERE id = " + id;
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                da.Fill(ds, "Fornecedor");
                connection.Close();

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro no método buscar por id: " + ex.Message);
            }
        }

        public static DataTable listar()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT * FROM Fornecedor ORDER BY Ranking";
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
