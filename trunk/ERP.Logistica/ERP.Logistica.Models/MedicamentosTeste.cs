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

        public static void adicionarQuantidade(int catalogoMed, int quantidade)
        {
            int quantMed = 0;
            quantMed = MedicamentosTeste.obterQuantidade(catalogoMed);
            MedicamentosTeste.alterarQuantidade(catalogoMed, quantMed + quantidade);
        }

        public static bool removerQuantidade(int catalogoMed, int quantidade)
        {
            int quantMed = 0;
            quantMed = MedicamentosTeste.obterQuantidade(catalogoMed);
            if (quantMed - quantidade > 0)
            {
                MedicamentosTeste.alterarQuantidade(catalogoMed, quantMed - quantidade);
                return true;
            }
            return false;
        }

        private static int obterQuantidade(int catalogoMed)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                string sql = "SELECT M.Quantidade AS 'Quantidade' FROM Catalogo_Medicamento AS L LEFT JOIN Medicamento AS M ON L.Medicamento = M.id WHERE L.id = " + catalogoMed + ";";
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                da.Fill(ds);
                connection.Close();

                return Convert.ToInt32(ds.Tables[0].Rows[0]["Quantidade"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
            }
        }

        private static void alterarQuantidade(int catalogoMed, int quantidade)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "UPDATE Medicamento SET Quantidade = " + quantidade + " WHERE id = (SELECT TOP 1 Medicamento FROM Catalogo_Medicamento WHERE id = " + catalogoMed + ");";
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
