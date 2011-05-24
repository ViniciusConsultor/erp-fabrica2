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
		private string _nome;
		private string _descricao;
		private string _medida;

        #region Constructors

        public Medicamento(string nome, string descricao, string medida)
        {
            this._nome = nome;
            this._descricao = descricao;
            this._medida = medida;
        }

        public Medicamento(int id, string nome, string descricao, string medida)
            : this(nome, descricao, medida)
        {
            this._id = id;
        }
		
		public Medicamento(string nome, string medida)
			: this( nome, null, medida)
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
            MedicamentoDAO.criar(Nome, Descricao, Medida);
        }

        public void atualizar()
        {
            MedicamentoDAO.atualizar(Id, Nome, Descricao, Medida);
        }

        public void apagar()
        {
            MedicamentoDAO.apagar(Id);
        }

        #region Static Methods

        public static Medicamento buscarPorId(int id)
        {
            DataSet ds = MedicamentoDAO.buscarPorId(id);
            DataRow row = (DataRow)ds.Tables[0].Rows[0];
            Medicamento medicamento = new Medicamento(id, (string)row["Nome"], (string)row["Descricao"], (string)row["Medida"]);

            return medicamento;
        }

        public static DataTable listar()
        {
            return MedicamentoDAO.listar();
        }

        #endregion
    }
}
