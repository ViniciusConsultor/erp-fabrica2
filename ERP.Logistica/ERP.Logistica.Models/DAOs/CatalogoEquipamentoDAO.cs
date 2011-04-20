using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ERP.Logistica.Models
{
    public class CatalogoEquipamentoDAO
    {
        private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

        public static void criar(int equipamentoId, int fornecedorId, double preco, DateTime Vigencia_Inicio)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "INSERT INTO Catalogo_Equipamento (Equipamento, Fornecedor, Preco_Unitario, Vigencia_Inicio) VALUES (";
                sql += equipamentoId + "," + fornecedorId + ", @preco,'" + Vigencia_Inicio.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@preco", SqlDbType.Float);
                cmd.Parameters["@preco"].Value = preco;
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
                string sql = "DELETE FROM Catalogo_Equipamento WHERE id = " + id;
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

        public static void atualizar(int id, int equipamentoId, int fornecedorId, double preco, DateTime Vigencia_Inicio)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "UPDATE Catalogo_Equipamento SET Equipamento = " + equipamentoId + ", " + "Fornecedor = " + fornecedorId + "," + "Preco_Unitario = " + preco + "," + "Vigencia_Inicio = '" + Vigencia_Inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE id = " + id;
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
                string sql = "SELECT * FROM Catalogo_Equipamento WHERE id = " + id;
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
                string sql = "SELECT R.id as id,R.Nome AS Equipamento, R.Preco_Unitario AS Preco_Unitario, F.Nome AS Fornecedor, R.Vigencia_Inicio AS Vigencia_Inicio FROM Fornecedor AS F inner join (SELECT CE.id,M.Nome, CE.Preco_Unitario, CE.Fornecedor, CE.Vigencia_Inicio FROM Catalogo_Equipamento AS CE inner join Equipamento AS M on CE.Equipamento=M.id) AS R ON R.Fornecedor=F.id";
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
