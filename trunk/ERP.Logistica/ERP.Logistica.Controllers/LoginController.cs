using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;
using System.Security.Cryptography;


namespace ERP.Logistica.Controllers
{
    public class LoginController
    {
        public static void criar(string username, string senha, string email)
        {
            HashAlgorithm mhash = new SHA1CryptoServiceProvider();
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(senha);
            byte[] bytHash = mhash.ComputeHash(bytValue);
            mhash.Clear();
            senha = Convert.ToBase64String(bytHash);
            Login user = new Login(username, senha, email);
            user.criar();
        }

        public static void apagar(int id)
        {
            Login user = Login.buscarPorId(id);
            user.apagar();

        }

        public static void atualizar(int id, string username, string senha, string email)
        {
            HashAlgorithm mhash = new SHA1CryptoServiceProvider();
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(senha);
            byte[] bytHash = mhash.ComputeHash(bytValue);
            mhash.Clear();
            senha = Convert.ToBase64String(bytHash);

            Login user = Login.buscarPorId(id);
            user.UserName = username;
            user.Senha = senha;
            user.Email = email;

            user.atualizar();
        }

        public static Login buscarPorId(int id)
        {
            return Login.buscarPorId(id);
        }

    }
}

