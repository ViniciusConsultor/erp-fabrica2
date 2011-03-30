using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.Logistica.Models
{
    public class CatalogoMedicamento
    {
        private int _id;
        private Medicamento _medicamento;
        private Fornecedor _fornecedor;
        private double _preco_unitario;
        private DateTime _vigencia_inicio;

        #region Constructors

        public CatalogoMedicamento(Medicamento medicamento, Fornecedor fornecedor, double preco_unitario, DateTime vigencia_inicio)
        {
            this._medicamento = medicamento;
            this._fornecedor = fornecedor;
            this._preco_unitario = preco_unitario;
            this._vigencia_inicio = vigencia_inicio;
        }

        public CatalogoMedicamento(int id, Medicamento medicamento, Fornecedor fornecedor, double preco_unitario, DateTime vigencia_inicio)
            : this(medicamento, fornecedor, preco_unitario, vigencia_inicio)
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

        public Fornecedor Fornecedor
        {
            get { return _fornecedor; }
            set { _fornecedor = value; }
        }

        public double Preco_unitario
        {
            get { return _preco_unitario; }
            set { _preco_unitario = value; }
        }

        public DateTime Vigencia_inicio
        {
            get { return _vigencia_inicio; }
            set { _vigencia_inicio = value; }
        }
		
        #endregion

        public void criar()
        {
            CatalogoMedicamentoDAO.criar(Medicamento.Id, Fornecedor.Id, Preco_unitario, Vigencia_inicio);
        }

        public void atualizar()
        {
            CatalogoMedicamentoDAO.atualizar(Id, Medicamento.Id, Fornecedor.Id, Preco_unitario, Vigencia_inicio);
        }

        public void apagar()
        {
            CatalogoMedicamentoDAO.apagar(Id);
        }

        #region Static Methods

        public static CatalogoMedicamento buscarPorId(int id)
        {
            DataSet ds = CatalogoMedicamentoDAO.buscarPorId(id);
            DataRow row = (DataRow)ds.Tables[0].Rows[0];
            Medicamento medicamento = Medicamento.buscarPorId((int)row["Medicamento"]);
            Fornecedor fornecedor = Fornecedor.buscarPorId((int)row["Fornecedor"]);
            CatalogoMedicamento catalogo = new CatalogoMedicamento(id, medicamento, fornecedor, (double)row["Preco_Unitario"], (DateTime)row["Vigencia_Inicio"]);

            return catalogo;
        }

        public static DataTable listar()
        {
            return CatalogoMedicamentoDAO.listar();
        }

        #endregion
    }
}
