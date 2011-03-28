using System;
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
        private float _catalogoMedPreco;
        private int _efetuado;

        #region Constructors

        public PedidoMedicamento(int quantidade, DateTime requisicao, int catalogoMed, int efetuado)
        {
            this._quantidade = quantidade;
            this._requisicao = requisicao;
            this._catalogoMed = catalogoMed;
            this._catalogoMedPreco = PedidoMedicamentoDAO.buscarPrecoDeLote(catalogoMed);
            this._efetuado = efetuado;
        }

        public PedidoMedicamento(int id, int quantidade, DateTime requisicao, int catalogoMed, int efetuado)
            : this(quantidade, requisicao, catalogoMed, efetuado)
        {
            this._id = id;
        }

        public PedidoMedicamento(int id, int quantidade, DateTime requisicao, int catalogoMed, float preco, int efetuado)
        {
            this._quantidade = quantidade;
            this._requisicao = requisicao;
            this._catalogoMed = catalogoMed;
            this._catalogoMedPreco = preco;
            this._efetuado = efetuado;
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

        public float CatalogoMedPreco
        {
            get { return _catalogoMedPreco; }
        }

        public int Efetuado
        {
            get { return _efetuado; }
            set { _efetuado = value; }
        }

        #endregion

        public void criar()
        {
            PedidoMedicamentoDAO.criar(Quantidade, DateTime.Now, CatalogoMed, Efetuado);
        }

        public void atualizar()
        {
            PedidoMedicamentoDAO.atualizar(Id, Quantidade, Requisicao, CatalogoMed, Efetuado);
        }

        public void apagar()
        {
            PedidoMedicamentoDAO.apagar(Id);
        }

        public float calcularValor()
        {
            return Quantidade * CatalogoMedPreco;
        }

        #region Static Methods

        public static PedidoMedicamento buscarPorId(int id)
        {
            PedidoMedicamento pedido = null;
            DataSet ds = PedidoMedicamentoDAO.buscarPorId(id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = (DataRow)ds.Tables[0].Rows[0];
                pedido = new PedidoMedicamento(id, (int)row["Quantidade"], (DateTime)row["Requisicao"], (int)row["Catalogo_Medicamento"], (int)row["Efetuado"]);
            }

            return pedido;
        }

        /*public static List<PedidoMedicamento> buscarPorRequisicao(int ano, int mes)
        {
            List<PedidoMedicamento> list = new List<PedidoMedicamento>();
            DataSet ds = PedidoMedicamentoDAO.buscarPorRequisicao(ano, mes);
            PedidoMedicamento pedido;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                pedido = new PedidoMedicamento((int)row["id"], (int)row["Quantidade"], (DateTime)row["Requisicao"], (int)row["Catalogo_Medicamento"], (float)Convert.ToDouble(row["Preco_Unitario"]), (int)row["Efetuado"]);
                list.Add(pedido);
            }

            return list;
        }*/

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

        /*public static float calcularGastoMensal(int ano, int mes)
        {
            List<PedidoMedicamento> list = PedidoMedicamento.buscarPorRequisicao(ano, mes);
            float gasto = 0;

            foreach (PedidoMedicamento pm in list)
            {
                if (pm.Efetuado == 1)
                {
                    gasto += (pm.Quantidade * pm.LotePreco);
                }
            }

            return gasto;
        }*/

        #endregion
    }
}
