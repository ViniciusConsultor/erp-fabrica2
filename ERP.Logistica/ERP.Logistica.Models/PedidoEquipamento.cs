using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP.Logistica.Models.DAOs;

namespace ERP.Logistica.Models
{
    public class PedidoEquipamento
    {
        private int _id;
        private DateTime _requisicao;
        private int _encomenda;
        private float _encomendaPreco;
        private int _efetuado;
        private Disponibilidade _disponibilidade;

        #region Constructors

        public PedidoEquipamento(DateTime requisicao, int encomenda, int disponibilidade, int efetuado)
        {
            this._requisicao = requisicao;
            this._encomenda = encomenda;
            this._encomendaPreco = PedidoEquipamentoDAO.buscarPrecoDeEncomenda(encomenda);
            this._disponibilidade = Disponibilidade.buscarPorId(disponibilidade);
            this._efetuado = efetuado;
        }

        public PedidoEquipamento(int id, DateTime requisicao, int encomenda, int disponibilidade, int efetuado)
            : this(requisicao, encomenda, disponibilidade, efetuado)
        {
            this._id = id;
        }

        public PedidoEquipamento(int id, DateTime requisicao, int encomenda, float preco, int disponibilidade, int efetuado)
        {
            this._id = id;
            this._requisicao = requisicao;
            this._encomenda = encomenda;
            this._encomendaPreco = preco;
            this._disponibilidade = Disponibilidade.buscarPorId(disponibilidade);
            this._efetuado = efetuado;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public DateTime Requisicao
        {
            get { return _requisicao; }
            set { _requisicao = value; }
        }

        public int Encomenda
        {
            get { return _encomenda; }
            set
            {
                _encomenda = value;
                _encomendaPreco = PedidoEquipamentoDAO.buscarPrecoDeEncomenda(_encomenda);
            }
        }

        public float EncomendaPreco
        {
            get { return _encomendaPreco; }
        }

        public Disponibilidade Disponibilidade
        {
            get { return _disponibilidade; }
            set { _disponibilidade = value; }
        }

        public int Efetuado
        {
            get { return _efetuado; }
            set { _efetuado = value; }
        }

        #endregion

        public void criar()
        {
            if (Disponibilidade != null)
            {
                Disponibilidade.criar();
                PedidoEquipamentoDAO.criar(Disponibilidade.Id, DateTime.Now, Encomenda, Efetuado);
            }
            else
            {
                // Cria um pedido sem relação com uma Disponibilidade
                PedidoEquipamentoDAO.criar(0, DateTime.Now, Encomenda, Efetuado);
            }
        }

        public void atualizar()
        {
            if (Disponibilidade != null)
            {
                // Cria disponibilidade caso ela não seja encontrada no banco e o pedido esteja efetuado
                Disponibilidade disponibilidade = Disponibilidade.buscarPorId(Disponibilidade.Id);
                if (disponibilidade == null && Efetuado == 1)
                {
                    Disponibilidade.criar();
                }
                PedidoEquipamentoDAO.atualizar(Id, Disponibilidade.Id, Requisicao, Encomenda, Efetuado);
            }
            else
            {
                PedidoEquipamentoDAO.atualizar(Id, 0, Requisicao, Encomenda, Efetuado);
            }
        }

        public void apagar()
        {
            PedidoEquipamentoDAO.apagar(Id);
        }

        public float calcularValor()
        {
            return EncomendaPreco;
        }

        public int obterEquipamento()
        {
            return PedidoEquipamentoDAO.buscarEquipamentoDeEncomenda(Encomenda);
        }

        #region Static Methods

        public static PedidoEquipamento buscarPorId(int id)
        {
            PedidoEquipamento pedido = null;
            DataSet ds = PedidoEquipamentoDAO.buscarPorId(id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = (DataRow)ds.Tables[0].Rows[0];
                pedido = new PedidoEquipamento(id, (DateTime)row["Requisicao"], (int)row["Equipamentos_Fornecedores"], (int)row["Disponibilidade"], (int)row["Efetuado"]);
            }

            return pedido;
        }

        /*public static List<PedidoEquipamento> buscarPorRequisicao(int ano, int mes)
        {
            List<PedidoEquipamento> list = new List<PedidoEquipamento>();
            DataSet ds = PedidoEquipamentoDAO.buscarPorRequisicao(ano, mes);
            PedidoEquipamento pedido;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                pedido = new PedidoEquipamento((int)row["id"], (DateTime)row["Requisicao"], (int)row["Equipamentos_Fornecedores"], (float)Convert.ToDouble(row["Preço_Unitário"]), (int)row["Disponibilidade"], (int)row["Efetuado"]);
                list.Add(pedido);
            }

            return list;
        }*/

        public static DataTable listar()
        {
            return PedidoEquipamentoDAO.listar();
        }

        public static DataTable listarEncomendasDisponiveis()
        {
            return PedidoEquipamentoDAO.listarEncomendasDisponiveis();
        }

        public static DataTable listarPorRequisicao(DateTime inicio, DateTime fim, bool apenasEfetuados)
        {
            return PedidoEquipamentoDAO.listarPorRequisicao(inicio, fim, apenasEfetuados);
        }

        /*public static float calcularGastoMensal(int ano, int mes)
        {
            List<PedidoEquipamento> list = PedidoEquipamento.buscarPorRequisicao(ano, mes);
            float gasto = 0;

            foreach (PedidoEquipamento pe in list)
            {
                if (pe.Efetuado == 1)
                {
                    gasto += (pe.EncomendaPreco);
                }
            }

            return gasto;
        }*/

        #endregion
    }
}
