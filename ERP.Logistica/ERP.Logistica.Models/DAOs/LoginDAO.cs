using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace ERP.Logistica.Models.DAOs
{
    class LoginDAO
    {
        //private static string connectionSettings = System.Configuration.ConfigurationManager.AppSettings["ERPLogisticaConnectionString"];
        //private static string connectionSettings = "Data Source=ls01;Initial Catalog=erp_manutencao;Integrated Security=True";
        //private static string connectionSettings = "Data Source=JUN-PC;Initial Catalog=erp_logistica;Integrated Security=True";
        private static string connectionSettings = "Data Source=143.107.102.24;Initial Catalog=erp_logistica; User ID=erp_logistica; Password=labsoft-2011; MultipleActiveResultSets=True";

        public static void criar(string username, string senha, string email)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "INSERT INTO Login (UserName, Senha, Email) VALUES ('";
                sql += username + "', '" + senha + "', '" + email + "')";
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
                string sql = "DELETE FROM Login WHERE id = " + id;
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

        public static void atualizar(int id, string username, string senha, string email)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                string sql = "UPDATE TarefaManutencao SET UserName = '" + username + "', " + "Senha = '" + senha + "', " + "Email = '" + email + "' WHERE id = " + id;
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
                string sql = "SELECT * FROM Login WHERE id = " + id;
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                da.Fill(ds, "Login");
                connection.Close();

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro no método listar: " + ex.Message);
            }
        }

        public static bool validUser(string username, string senha)
        {
            HashAlgorithm mhash = new SHA1CryptoServiceProvider();
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(senha);
            byte[] bytHash = mhash.ComputeHash(bytValue);
            mhash.Clear();
            senha = Convert.ToBase64String(bytHash);

            SqlCommand cmd;
            string senhalocalizada = "";

            try
            {
                SqlConnection connection = new SqlConnection(connectionSettings);
                connection.Open();
                cmd = new SqlCommand("SELECT senha FROM Login WHERE UserName = '" + username + "'", connection);
                senhalocalizada = (string)cmd.ExecuteScalar();
                cmd.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
            }

            if (senhalocalizada == senha)
                return true;
            else
                return false;
        }

    }
}
