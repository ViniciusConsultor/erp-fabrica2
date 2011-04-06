using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP.Logistica.Models.DAOs;

namespace ERP.Logistica.Models
{
    public class Login
    {
        private int _id;
        private string _username;
        private string _senha;
        private string _email;

        #region Constructors

        public Login(string username, string senha, string email)
        {
            this._username = username;
            this._senha = senha;
            this._email = email;
        }

        public Login(int id, string username, string senha, string email)
            : this(username, senha, email)
        {
            this._id = id;
        }


        #endregion

        #region Properties
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Id
        {
            get { return _id; }
        }

        #endregion



        public void criar()
        {
            LoginDAO.criar(UserName, Senha, Email);
        }

        public void apagar()
        {
            LoginDAO.apagar(Id);
        }

        public void atualizar()
        {
            LoginDAO.atualizar(Id, UserName, Senha, Email);
        }

        public static bool validUser(string username, string senha)
        {
            return LoginDAO.validUser(username, senha);
        }


        #region static methods

        public static Login buscarPorId(int id)
        {
            DataSet ds = LoginDAO.buscarPorId(id);
            DataRow row = (DataRow)ds.Tables[0].Rows[0];
            Login user = new Login(id, (string)row["UserName"], (string)row["Senha"], (string)row["Email"]);

            return user;
        }


        #endregion
    }
}
