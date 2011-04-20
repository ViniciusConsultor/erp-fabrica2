﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP.Logistica.Models.DAOs;

namespace ERP.Logistica.Models
{
    public class PedidoMedicamento
    {
        private int _id;
        private int _quantidade;
        private DateTime _requisicao;
        private int _catalogoMed;
        private double _catalogoMedPreco;
        private int _efetuado;
        private int _reportarEstorno;

        #region Constructors

        public PedidoMedicamento(int quantidade, DateTime requisicao, int catalogoMed, int efetuado)
        {
            this._quantidade = quantidade;
            this._requisicao = requisicao;
            this._catalogoMed = catalogoMed;
            this._catalogoMedPreco = PedidoMedicamentoDAO.buscarPrecoDeLote(catalogoMed);
            this._efetuado = efetuado;
            this._reportarEstorno = 0;
        }

        public PedidoMedicamento(int id, int quantidade, DateTime requisicao, int catalogoMed, int efetuado, int reportarEstorno)
            : this(quantidade, requisicao, catalogoMed, efetuado)
        {
            this._id = id;
            this._reportarEstorno = reportarEstorno;
        }

        public PedidoMedicamento(int id, int quantidade, DateTime requisicao, int catalogoMed, double preco, int efetuado, int reportarEstorno)
        {
            this._quantidade = quantidade;
            this._requisicao = requisicao;
            this._catalogoMed = catalogoMed;
            this._catalogoMedPreco = preco;
            this._efetuado = efetuado;
            this._reportarEstorno = reportarEstorno;
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

        public DateTime Requisicao
        {
            get { return _requisicao; }
            set { _requisicao = value; }
        }

        public int CatalogoMed
        {
            get { return _catalogoMed; }
            set
            {
                _catalogoMed = value;
                _catalogoMedPreco = PedidoMedicamentoDAO.buscarPrecoDeLote(_catalogoMed);
            }
        }

        public double CatalogoMedPreco
        {
            get { return _catalogoMedPreco; }
        }

        public int Efetuado
        {
            get { return _efetuado; }
            set { _efetuado = value; }
        }

        public int ReportarEstorno
        {
            get { return _reportarEstorno; }
            set { _reportarEstorno = value; }
        }

        #endregion

        public void criar()
        {
            PedidoMedicamentoDAO.criar(Quantidade, DateTime.Now, CatalogoMed, Efetuado);
        }

        public void atualizar()
        {
            PedidoMedicamentoDAO.atualizar(Id, Quantidade, Requisicao, CatalogoMed, Efetuado, ReportarEstorno);
        }

        public void apagar()
        {
            PedidoMedicamentoDAO.apagar(Id);
        }

        public double calcularValor()
        {
            return Quantidade * CatalogoMedPreco;
        }

        public bool apagavel()
        {
            return (Efetuado == 0 && ReportarEstorno == 0);
        }

        public bool editavel()
        {
            return (Efetuado == 1);
        }

        #region Static Methods

        public static PedidoMedicamento buscarPorId(int id)
        {
            PedidoMedicamento pedido = null;
            DataSet ds = PedidoMedicamentoDAO.buscarPorId(id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = (DataRow)ds.Tables[0].Rows[0];
                pedido = new PedidoMedicamento(id, (int)row["Quantidade"], (DateTime)row["Requisicao"], (int)row["Catalogo_Medicamento"], (int)row["Efetuado"], (int)row["Reportar_Estorno"]);
            }

            return pedido;
        }

        public static double calcularValorEstornadoAte(DateTime limite, bool todos)
        {
            double valor = 0;
            DataSet ds = PedidoMedicamentoDAO.buscarEstornadosAte(limite, todos);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                valor += (Convert.ToDouble(row["Preco_Unitario"]) * (int)row["Quantidade"]);
            }

            return valor;
        }

        public static void marcarEstornoReportado(DateTime limite)
        {
            PedidoMedicamentoDAO.marcarEstornoReportado(limite);
        }

        public static DataTable listar()
        {
            return PedidoMedicamentoDAO.listar();
        }

        public static DataTable listarCatalogoMedDisponiveis()
        {
            return PedidoMedicamentoDAO.listarCatalogoMedDisponiveis();
        }

        public static DataTable listarPorRequisicao(DateTime inicio, DateTime fim, bool apenasEfetuados)
        {
            return PedidoMedicamentoDAO.listarPorRequisicao(inicio, fim, apenasEfetuados);
        }


        #endregion
    }
}