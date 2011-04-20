using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ERP.Logistica.Models
{
    public class EstoqueDAO
    {
        private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";
        public static void criar(int medicamentoId, int quantidade, DateTime validade, string localizacao)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "INSERT INTO Estoque (Medicamento, Quantidade, Validade, Localizacao) VALUES (";
                sql += medicamentoId + "," + quantidade + ",'" + validade.ToString("yyyy-MM-dd HH:mm:ss") + "','" + localizacao + "')";
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
                string sql = "DELETE FROM Estoque WHERE id = " + id;
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

        public static void atualizar(int id, int medicamentoId, int quantidade, DateTime validade, string localizacao)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "UPDATE Estoque SET Medicamento = " + medicamentoId + ", " + "Quantidade = " + quantidade + "," + "Validade = '" + validade.ToString("yyyy-MM-dd HH:mm:ss") + "'," + "Localizacao = '" + localizacao + "' WHERE id = " + id;
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
                string sql = "SELECT * FROM Estoque WHERE id = " + id;
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

        public static DataTable listar()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT E.id, E.Quantidade, E.validade, E.Localizacao, M.Nome AS Medicamento FROM Estoque AS E inner join Medicamento AS M on E.Medicamento=M.id";
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

        public static DataTable listar_Medicamentos_Quantidades()
        {
            DateTime date = DateTime.Now.Date;
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT M.id AS id, M.Nome AS Medicamento, R.Quantidade AS Quantidade FROM Medicamento as M inner join (SELECT Medicamento, SUM(Quantidade) AS Quantidade FROM Estoque WHERE Validade >= '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "' GROUP BY Medicamento) AS R ON M.id=R.Medicamento";
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

        public static DataTable listar_por_Medicamento(int medicamentoId)
        {
            DateTime date = DateTime.Now.Date;
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT * FROM Estoque WHERE Medicamento = " + medicamentoId + " AND Validade >= '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "'";
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

        public static DataSet buscar_Quantidade_por_Medicamento(int medicamentoId)
        {
            DateTime date = DateTime.Now.Date;
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT SUM(Quantidade) AS Quantidade FROM Estoque WHERE Validade >= '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Medicamento = "+ medicamentoId + " GROUP BY Medicamento";
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                da.Fill(ds);
                connection.Close();

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro no método buscar_Quantidade_por_Medicamento: " + ex.Message);
            }
        }
    }
}
