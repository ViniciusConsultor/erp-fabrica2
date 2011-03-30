using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.Logistica.Models
{
    public class CatalogoEquipamento
    {
        private int _id;
        private Equipamento _equipamento;
        private Fornecedor _fornecedor;
        private double _preco_unitario;
        private DateTime _vigencia_inicio;

        #region Constructors

        public CatalogoEquipamento(Equipamento equipamento, Fornecedor fornecedor, double preco_unitario, DateTime vigencia_inicio)
        {
            this._equipamento = equipamento;
            this._fornecedor = fornecedor;
            this._preco_unitario = preco_unitario;
            this._vigencia_inicio = vigencia_inicio;
        }

        public CatalogoEquipamento(int id, Equipamento equipamento, Fornecedor fornecedor, double preco_unitario, DateTime vigencia_inicio)
            : this(equipamento, fornecedor, preco_unitario, vigencia_inicio)
        {
            this._id = id;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public Equipamento Equipamento
        {
            get { return _equipamento; }
            set { _equipamento = value; }
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
            CatalogoEquipamentoDAO.criar(Equipamento.Id, Fornecedor.Id, Preco_unitario, Vigencia_inicio);
        }

        public void atualizar()
        {
            CatalogoEquipamentoDAO.atualizar(Id, Equipamento.Id, Fornecedor.Id, Preco_unitario, Vigencia_inicio);
        }

        public void apagar()
        {
            CatalogoEquipamentoDAO.apagar(Id);
        }

        #region Static Methods

        public static CatalogoEquipamento buscarPorId(int id)
        {
            DataSet ds = CatalogoEquipamentoDAO.buscarPorId(id);
            DataRow row = (DataRow)ds.Tables[0].Rows[0];
            Equipamento equipamento = Equipamento.buscarPorId((int)row["equipamento"]);
            Fornecedor fornecedor = Fornecedor.buscarPorId((int)row["Fornecedor"]);
            CatalogoEquipamento catalogo = new CatalogoEquipamento(id, equipamento, fornecedor, (double)row["Preco_Unitario"], (DateTime)row["Vigencia_Inicio"]);

            return catalogo;
        }

        public static DataTable listar()
        {
            return CatalogoEquipamentoDAO.listar();
        }

        #endregion
    }
}
