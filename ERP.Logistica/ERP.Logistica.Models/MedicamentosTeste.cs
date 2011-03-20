using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ERP.Logistica.Models
{
    public class MedicamentosTeste
    {
        //private static string connectionSettings = System.Configuration.ConfigurationManager.AppSettings["ERPLogisticaConnectionString"];
        //private static string connectionSettings = "Data Source=ls01;Initial Catalog=erp_logistica;Integrated Security=True";
        //private static string connectionSettings = "Data Source=JUN-PC;Initial Catalog=erp_logistica;Integrated Security=True";
        private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

        public static int obterQuantidade(int lote)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT M.Quantidade AS 'Quantidade' FROM [erp_logistica].[dbo].[Medicamento_Fornecedor(Lote)] AS L LEFT JOIN [erp_logistica].[dbo].[Medicamento] AS M ON L.Medicamento = M.id WHERE L.id = " + lote + ";";
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                da.Fill(ds, "PedidoMedicamento");
                connection.Close();

                return Convert.ToInt32(ds.Tables[0].Rows[0]["Quantidade"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
            }
        }

        public static void alterarQuantidade(int lote, int quantidade)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "UPDATE [erp_logistica].[dbo].[Medicamento] SET Quantidade = " + quantidade + " WHERE id = (SELECT TOP 1 Medicamento FROM [erp_logistica].[dbo].[Medicamento_Fornecedor(Lote)] WHERE id = " + lote + ");";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
            }
        }
    }
}
