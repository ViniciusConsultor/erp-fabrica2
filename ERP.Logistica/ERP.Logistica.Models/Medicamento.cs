using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.Logistica.Models
{
    public class Medicamento
    {
        private int _id;
        private int _quantidade;
		private string _nome;
		private string _descricao;
		private string _medida;

        #region Constructors

        public Medicamento(int quantidade, string nome, string descricao, string medida)
        {
            this._quantidade = quantidade;
            this._nome = nome;
            this._descricao = descricao;
            this._medida = medida;
        }

        public Medicamento(int id, int quantidade, string nome, string descricao, string medida)
            : this(quantidade, nome, descricao, medida)
        {
            this._id = id;
        }

        public Medicamento(string nome, string descricao, string medida)
			: this( 0, nome, descricao, medida)
        {
        }
		
		public Medicamento(string nome, string medida)
			: this( 0, nome, null, medida)
        {
        }


        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
		
		 public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
		
		 public string Medida
        {
            get { return _medida; }
            set { _medida = value; }
        }

        #endregion

        public void criar()
        {
            MedicamentoDAO.criar(Quantidade, Nome, Descricao, Medida);
        }

        public void atualizar()
        {
            MedicamentoDAO.atualizar(Id, Quantidade, Nome, Descricao, Medida);
        }

        public void apagar()
        {
            MedicamentoDAO.apagar(Id);
        }
		
		public void adicionar(int quantidade)
		{
			Quantidade += quantidade;
			this.atualizar();
		}
		
		public void remover(int quantidade)
		{
			if (Quantidade >= quantidade)
			{
				Quantidade -= quantidade;
				this.atualizar();
				if (Quantidade == 0)
				{
				}
			}
		}

        #region Static Methods

        public static Medicamento buscarPorId(int id)
        {
            DataSet ds = MedicamentoDAO.buscarPorId(id);
            DataRow row = (DataRow)ds.Tables[0].Rows[0];
            Medicamento medicamento = new Medicamento(id, (int)row["Quantidade"], (string)row["Nome"], (string)row["Descricao"], (string)row["Medida"]);

            return medicamento;
        }

        public static DataTable listar()
        {
            return MedicamentoDAO.listar();
        }

        /*public static DataTable listarFornecedores(Medicamento medicamento)
        {
            return FornecedoresDAO.listarFornecedores(medicamento);
        }*/

        #endregion
    }
}
