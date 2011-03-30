using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.Logistica.Models
{
    public class Estoque
    {
        private int _id;
        private Medicamento _medicamento;
        private int _quantidade;
        private DateTime _validade;
        private string _localizacao;

        #region Constructors

        public Estoque(Medicamento medicamento, int quantidade, DateTime validade, string localizacao)
        {
            this._medicamento = medicamento;
            this._quantidade = quantidade;
            this._validade = validade;
            this._localizacao = localizacao;
        }

        public Estoque(int id, Medicamento medicamento, int quantidade, DateTime validade, string localizacao)
            : this(medicamento, quantidade, validade, localizacao)
        {
            this._id = id;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public Medicamento Medicamento
        {
            get { return _medicamento; }
            set { _medicamento = value; }
        }

        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
		
		public DateTime Validade
        {
            get { return _validade; }
            set { _validade = value; }
        }
		
		public string Localizacao
        {
            get { return _localizacao; }
            set { _localizacao = value; }
        }

        #endregion

        public void criar()
        {
            EstoqueDAO.criar(Medicamento.Id, Quantidade, Validade, Localizacao);
        }

        public void atualizar()
        {
            EstoqueDAO.atualizar(Id, Medicamento.Id, Quantidade, Validade, Localizacao);
        }

        public void apagar()
        {
            EstoqueDAO.apagar(Id);
        }

        #region Static Methods

        public static Estoque buscarPorId(int id)
        {
            DataSet ds = EstoqueDAO.buscarPorId(id);
            DataRow row = (DataRow)ds.Tables[0].Rows[0];
            Medicamento medicamento = Medicamento.buscarPorId((int)row["Medicamento"]);
            Estoque estoque = new Estoque(id, medicamento, (int)row["Quantidade"], (DateTime)row["Validade"], (string)row["Localizacao"]);

            return estoque;
        }

        public static int buscar_Quantidade_por_Medicamento(int medicamentoId)
        {
            DataSet ds = EstoqueDAO.buscar_Quantidade_por_Medicamento(medicamentoId);
            DataRow row = (DataRow)ds.Tables[0].Rows[0];
            int quantidade_Total = (int)row["Quantidade"];
           
            return quantidade_Total;
        }

        public static DataTable listar()
        {
            return EstoqueDAO.listar();
        }

        public static DataTable listar_Medicamentos_Quantidades()
        {
            return EstoqueDAO.listar_Medicamentos_Quantidades();
        }

        public static DataTable listar_por_Medicamento(int medicamentoId)
        {
            return EstoqueDAO.listar_por_Medicamento(medicamentoId);
        }
        #endregion
    }
}
