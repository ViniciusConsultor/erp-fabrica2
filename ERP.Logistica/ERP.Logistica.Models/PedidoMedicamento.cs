using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.Logistica.Models
{
    public class PedidoMedicamento
    {
        private int _id;
        private int _quantidade;
        private DateTime _requisicao;
        private int _lote;
        private float _lotePreco;
        private int _efetuado;

        #region Constructors

        public PedidoMedicamento(int quantidade, DateTime requisicao, int lote, int efetuado)
        {
            this._quantidade = quantidade;
            this._requisicao = requisicao;
            this._lote = lote;
            this._lotePreco = PedidoMedicamentoDAO.buscarPrecoDeLote(lote);
            this._efetuado = efetuado;
        }

        public PedidoMedicamento(int id, int quantidade, DateTime requisicao, int lote, int efetuado)
            : this(quantidade, requisicao, lote, efetuado)
        {
            this._id = id;
        }

        public PedidoMedicamento(int id, int quantidade, DateTime requisicao, int lote, float preco, int efetuado)
        {
            this._quantidade = quantidade;
            this._requisicao = requisicao;
            this._lote = lote;
            this._lotePreco = preco;
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

        public int Lote
        {
            get { return _lote; }
            set
            {
                _lote = value;
                _lotePreco = PedidoMedicamentoDAO.buscarPrecoDeLote(_lote);
            }
        }

        public float LotePreco
        {
            get { return _lotePreco; }
        }

        public int Efetuado
        {
            get { return _efetuado; }
            set { _efetuado = value; }
        }

        #endregion

        public void criar()
        {
            PedidoMedicamentoDAO.criar(Quantidade, DateTime.Now, Lote, Efetuado);
        }

        public void atualizar()
        {
            PedidoMedicamentoDAO.atualizar(Id, Quantidade, Requisicao, Lote, Efetuado);
        }

        public void apagar()
        {
            PedidoMedicamentoDAO.apagar(Id);
        }

        public float calcularValor()
        {
            return Quantidade * LotePreco;
        }

        #region Static Methods

        public static PedidoMedicamento buscarPorId(int id)
        {
            DataSet ds = PedidoMedicamentoDAO.buscarPorId(id);
            DataRow row = (DataRow)ds.Tables[0].Rows[0];
            PedidoMedicamento pedido = new PedidoMedicamento(id, (int)row["Quantidade"], (DateTime)row["Requisicao"], (int)row["Medicamento_Fornecedor"], (int)row["Efetuado"]);

            return pedido;
        }

        public static List<PedidoMedicamento> buscarPorRequisicao(int ano, int mes)
        {
            List<PedidoMedicamento> list = new List<PedidoMedicamento>();
            DataSet ds = PedidoMedicamentoDAO.buscarPorRequisicao(ano, mes);
            PedidoMedicamento pedido;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                pedido = new PedidoMedicamento((int)row["id"], (int)row["Quantidade"], (DateTime)row["Requisicao"], (int)row["Medicamento_Fornecedor"], (float)Convert.ToDouble(row["Preço_Unitário"]), (int)row["Efetuado"]);
                list.Add(pedido);
            }

            return list;
        }

        public static DataTable listar()
        {
            return PedidoMedicamentoDAO.listar();
        }

        public static DataTable listarMedicamentosFornecedores()
        {
            return PedidoMedicamentoDAO.listarMedicamentosFornecedores();
        }

        public static DataTable listarRequisicoesRecentes()
        {
            DataSet ds = PedidoMedicamentoDAO.buscarPorRequisicao(DateTime.Today.Year, DateTime.Today.Month);
            return ds.Tables[0];
        }

        public static float calcularGastoMensal(int ano, int mes)
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
        }

        #endregion
    }
}
