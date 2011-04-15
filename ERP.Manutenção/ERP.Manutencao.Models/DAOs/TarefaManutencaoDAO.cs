using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ERP.Manutencao.Models
{
    class TarefaManutencaoDAO
    {
        //private static string connectionSettings = System.Configuration.ConfigurationManager.AppSettings["ERPLogisticaConnectionString"];
        //private static string connectionSettings = "Data Source=ls01;Initial Catalog=erp_manutencao;Integrated Security=True";
        //private static string connectionSettings = "Data Source=JUN-PC;Initial Catalog=erp_logistica;Integrated Security=True";
        private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_manutencao; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

        public static void criar(string descricao, string local, string equipamento, string estado, DateTime iniciomanutencao, DateTime fimmanutencao)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "INSERT INTO TarefaManutencao (Descricao, Local, Equipamento, Estado, Inicio_Manutencao, Fim_Manutencao) VALUES ('";
                sql += descricao + "', '" + local + "', '" + equipamento + "', '" + estado + "', '" + iniciomanutencao.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + fimmanutencao.ToString("yyyy-MM-dd HH:mm:ss") + "')";
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
                string sql = "DELETE FROM TarefaManutencao WHERE id = " + id;
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

        public static void atualizar(int id, string descricao, string local, string equipamento, string estado, DateTime iniciomanutencao, DateTime fimmanutencao)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "UPDATE TarefaManutencao SET Descricao = '" + descricao + "', " + "Local = '" + local + "', " + "Equipamento = '" + equipamento + "', " + "Estado = '" + estado + "', " + "Inicio_Manutencao = '" + iniciomanutencao.ToString("yyyy-MM-dd HH:mm:ss") + "', Fim_Manutencao = '" + fimmanutencao.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE id = " + id;
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
                string sql = "SELECT * FROM TarefaManutencao WHERE id = " + id;
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                da.Fill(ds, "TarefaManutencao");
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
                string sql = "SELECT TM.Id, TM.Descricao AS Descricao, TM.Local AS Local, TM.Equipamento AS Equipamento, TM.Estado AS Estado, TM.Inicio_Manutencao AS Inicio_Manutencao, TM.Fim_Manutencao AS Fim_Manutencao FROM TarefaManutencao AS TM ORDER BY TM.Estado;";
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
                string sql = "SELECT TM.Id, TM.Local AS Local, TM.Inicio_Manutencao AS Inicio_Manutencao, TM.Fim_Manutencao AS Fim_Manutencao FROM TarefaManutencao AS TM WHERE TM.Estado <> 'Concluído' ORDER BY TM.Id;";
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
