using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.Logistica.Models
{
    public class Fornecedor
    {
        private int _id;
        private string _nome;
        private string _telefone;
        private string _email;
        private string _localizacao;
        private int _ranking;

        #region Constructors

        public Fornecedor(string nome, string telefone, string email, string localizacao, int ranking)
        {
            this._nome = nome;
            this._telefone = telefone;
            this._email = email;
            this._localizacao = localizacao;
            this._ranking = ranking;
        }

        public Fornecedor(int id, string nome, string telefone, string email, string localizacao, int ranking)
            : this(nome, telefone, email, localizacao, ranking)
        {
            this._id = id;
        }

        public Fornecedor(string nome, string telefone, string email, string localizacao)
			: this(nome, telefone, email, localizacao, -1)
        {
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
		
		public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
		
		public string Localizacao
        {
            get { return _localizacao; }
            set { _localizacao = value; }
        }

        public int Ranking
        {
            get { return _ranking; }
            set { _ranking = value; }
        }
        #endregion

        public void criar()
        {
            FornecedorDAO.criar(Nome, Telefone, Email, Localizacao, Ranking);
        }

        public void atualizar()
        {
            FornecedorDAO.atualizar(Id, Nome, Telefone, Email, Localizacao, Ranking);
        }

        public void apagar()
        {
            FornecedorDAO.apagar(Id);
        }

        #region Static Methods

        public static Fornecedor buscarPorId(int id)
        {
            DataSet ds = FornecedorDAO.buscarPorId(id);
            DataRow row = (DataRow)ds.Tables[0].Rows[0];
            Fornecedor fornecedor = new Fornecedor(id, (string)row["Nome"], (string)row["Telefone"], (string)row["Email"], (string)row["Localizacao"], (int)row["Ranking"]);

            return fornecedor;
        }

        public static DataTable listar()
        {
            return FornecedorDAO.listar();
        }

        #endregion
    }
}
