using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ERP.Logistica.Models.DAOs
{
    public class HistoricoEstoqueDAO
    {
        private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

        public static void criar(string consultaId, DateTime data, int addRed, int medicamentoId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "INSERT INTO Historico_Medicamento (Consulta_Id, Data, Add_Red, Medicamento_Id) VALUES (";
                sql += "'" + consultaId + "','" + data.ToString("yyyy-MM-dd HH:mm:ss") + "'," + addRed + "," + medicamentoId + ")";
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

        public static DataTable listar(int medId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT * FROM (Historico_Medicamento AS HM LEFT JOIN Medicamento AS M ON HM.Medicamento_Id = M.Id) WHERE HM.Medicamento_Id = " + medId + ";";
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
