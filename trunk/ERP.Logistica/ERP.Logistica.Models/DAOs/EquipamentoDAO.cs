using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ERP.Logistica.Models.DAOs
{
    public class EquipamentoDAO
    {
        //private static string connectionSettings = System.Configuration.ConfigurationManager.AppSettings["ERPLogisticaConnectionString"];
        //private static string connectionSettings = "Data Source=ls01;Initial Catalog=erp_logistica;Integrated Security=True";
        //private static string connectionSettings = "Data Source=JUN-PC;Initial Catalog=erp_logistica;Integrated Security=True";
        private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

        public static void criar(string nome, string descricao)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "INSERT INTO Equipamento (Nome, Descricao) VALUES (";
                sql +=  "'" + nome + "','" + descricao + "')";
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
                string sql = "DELETE FROM Equipamento WHERE id = " + id;
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

        public static void atualizar(int id, string nome, string descricao)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "UPDATE Equipamento SET Nome = '" + nome + "'," + "Descricao = '" + descricao + "' WHERE id = " + id;
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
                string sql = "SELECT * FROM Equipamento WHERE id = " + id;
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

        public static DataTable listarEquipamentosDisponiveis()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT Id, Nome + ' (' + CONVERT(VARCHAR(50), Id) + ') ' AS 'Equipamento' FROM Equipamento;";
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

        public static DataTable listar()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT * FROM Equipamento";
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
