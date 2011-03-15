using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class PedidosMedicamentosController
    {
        public static void criar(int quantidade, DateTime requisicao, int lote, int efetuado)
        {
            PedidoMedicamento pedido = new PedidoMedicamento(quantidade, requisicao, lote, efetuado);

            // TODO: Contabilizar no estoque caso efetuado
            if (efetuado == 1)
            {
                if (validarVerbaMensal(pedido.calcularValor()))
                {
                }
                else
                {
                    return;
                }
            }

            pedido.criar();
        }

        public static void apagar(int id)
        {
            PedidoMedicamento pedido = PedidoMedicamento.buscarPorId(id);
            if (pedido.Efetuado != 1)
            {
                pedido.apagar();
            }
        }

        public static void atualizar(int id, int quantidade, DateTime requisicao, int lote, int efetuado)
        {
            PedidoMedicamento pedido = PedidoMedicamento.buscarPorId(id);
            pedido.Quantidade = quantidade;
            pedido.Requisicao = requisicao;
            pedido.Lote = lote;
            // TODO: Se mudou para efetuado, contabiliza o estoque, se mudou para estornado verifica se é possivel
            //       antes de modificar estoque. (Preciso de interface para obter e editar o estoque)
            if (efetuado == 1 && pedido.Efetuado == 0) // Mudou para efetuado
            {
                if (validarVerbaMensal(pedido.calcularValor()))
                {
                }
                else
                {
                    return;
                }
            }
            else if (efetuado == 0 && pedido.Efetuado == 1) // Mudou para estornado
            {
            }
            pedido.Efetuado = efetuado;
            pedido.atualizar();
        }

        public static PedidoMedicamento buscarPorId(int id)
        {
            return PedidoMedicamento.buscarPorId(id);
        }

        public static List<PedidoMedicamento> buscarPorRequisicao(int ano, int mes)
        {
            return PedidoMedicamento.buscarPorRequisicao(ano, mes);
        }

        public static DataTable listar()
        {
            return PedidoMedicamento.listar();
        }

        public static DataTable listarMedicamentosFornecedores()
        {
            return PedidoMedicamento.listarMedicamentosFornecedores();
        }

        public static DataTable listarRequisicoesRecentes()
        {
            return PedidoMedicamento.listarRequisicoesRecentes();
        }

        public static float calcularGastoMensal(int ano, int mes)
        {
            return PedidoMedicamento.calcularGastoMensal(ano, mes);
        }

        public static bool validarVerbaMensal(float gastoAdicional)
        {
            Caixa caixa = Caixa.obterCaixa();
            float gasto = PedidoMedicamento.calcularGastoMensal(DateTime.Today.Year, DateTime.Today.Month);

            return (gasto + gastoAdicional <= caixa.VerbaMensal);
        }
    }
}
