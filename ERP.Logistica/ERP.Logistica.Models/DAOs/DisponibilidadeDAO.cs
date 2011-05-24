using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ERP.Logistica.Models.DAOs
{
    public class DisponibilidadeDAO
    {
        //private static string connectionSettings = System.Configuration.ConfigurationManager.AppSettings["ERPLogisticaConnectionString"];
        //private static string connectionSettings = "Data Source=ls01;Initial Catalog=erp_logistica;Integrated Security=True";
        //private static string connectionSettings = "Data Source=JUN-PC;Initial Catalog=erp_logistica;Integrated Security=True";
        private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

        public static int criar(int equipamento, int espacoFisico)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "INSERT INTO Disponibilidade (Equipamento, Espaco_Fisico) VALUES (";
                sql += equipamento + ", " + espacoFisico + ")";
                string sqlID = "SELECT TOP 1 Id FROM Disponibilidade WHERE Equipamento = " + equipamento + "AND Espaco_Fisico = " + espacoFisico + " ORDER BY Id DESC;";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(sqlID, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connection.Dispose();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return (int)ds.Tables[0].Rows[0][0];
                }
                else
                {
                    return 0;
                }
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
                string sql = "DELETE FROM Disponibilidade WHERE id = " + id;
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

        public static void atualizar(int id, int equipamento, int espacoFisico)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "UPDATE Disponibilidade SET Equipamento = " + equipamento + ", Espaco_Fisico = " + espacoFisico + " WHERE id = " + id;
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
                string sql = "SELECT * FROM Disponibilidade WHERE id = " + id;
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

        public static DataTable listar()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT D.Id, E.Nome AS 'Equipamento', EF.Nome AS 'Espaco', EF.Andar AS 'Andar', EF.Numero AS 'Numero' FROM ((Disponibilidade AS D LEFT JOIN Equipamento AS E ON D.Equipamento = E.id) LEFT JOIN Espaco_Fisico AS EF ON D.Espaco_Fisico = EF.id);";
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

        public static DataTable listarEquipamentosDisponiveis()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT Id, Nome + ' (' + CONVERT(VARCHAR(50), Id) + ') ' AS 'Equipamento' FROM Equipamento";// WHERE Id NOT IN (SELECT Equipamento FROM Disponibilidade);";
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

        public static DataTable WebListar()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                // TODO: Incluir nomes
                string sql = "SELECT D.Id AS 'EquipamentoId', E.Nome AS 'Equipamento', EF.Id AS 'EspacoFisicoId', EF.Nome AS 'Espaco', EF.Andar AS 'Andar', EF.Numero AS 'Numero' FROM ((Disponibilidade AS D LEFT JOIN Equipamento AS E ON D.Equipamento = E.id) RIGHT JOIN Espaco_Fisico AS EF ON D.Espaco_Fisico = EF.id);";
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
