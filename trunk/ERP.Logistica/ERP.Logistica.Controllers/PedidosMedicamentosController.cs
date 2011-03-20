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

            // Contabilizar no estoque caso efetuado
            if (efetuado == 1)
            {
                List<PedidoMedicamento> pedidos = PedidoMedicamento.buscarPorRequisicao(DateTime.Today.Year, DateTime.Today.Month);
                if (pedidos.Count == 0)
                {
                    Caixa caixa = new Caixa();
                    caixa.VerbaMensal = FinanceiroTeste.obterVerbaMensal();
                    caixa.atualizar();
                }

                if (validarVerbaMensal(pedido.calcularValor()))
                {
                    int quantMed = 0;
                    quantMed = MedicamentosTeste.obterQuantidade(pedido.Lote);
                    MedicamentosTeste.alterarQuantidade(pedido.Lote, quantMed + pedido.Quantidade);
                }
                else
                {
                    // Pede verba adicional suficiente para 10 pedidos
                    if (FinanceiroTeste.obterVerbaAdicional(pedido.calcularValor() * 10.0F))
                    {
                        Caixa caixa = Caixa.obterCaixa();
                        caixa.VerbaMensal += pedido.calcularValor() * 10.0F;
                        caixa.atualizar();
                    }
                    else
                    {
                        return;
                    }
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
            // Se mudou para efetuado, contabiliza o estoque, se mudou para estornado verifica se é possivel
            // antes de modificar estoque. (Preciso de interface para obter e editar o estoque)
            if (efetuado == 1 && pedido.Efetuado == 0) // Mudou para efetuado
            {
                if (validarVerbaMensal(pedido.calcularValor()))
                {
                    int quantMed = 0;
                    quantMed = MedicamentosTeste.obterQuantidade(pedido.Lote);
                    MedicamentosTeste.alterarQuantidade(pedido.Lote, quantMed + pedido.Quantidade);
                }
                else
                {
                    // Pede verba adicional suficiente para 10 pedidos
                    if (FinanceiroTeste.obterVerbaAdicional(pedido.calcularValor() * 10.0F))
                    {
                        Caixa caixa = Caixa.obterCaixa();
                        caixa.VerbaMensal += pedido.calcularValor() * 10.0F;
                        caixa.atualizar();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (efetuado == 0 && pedido.Efetuado == 1) // Mudou para estornado
            {
                int quantMed = 0;
                quantMed = MedicamentosTeste.obterQuantidade(pedido.Lote);
                if (quantMed - pedido.Quantidade > 0)
                {
                    MedicamentosTeste.alterarQuantidade(pedido.Lote, quantMed - pedido.Quantidade);
                }
                else
                {
                    return;
                }
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
            return PedidoMedicamento.listarPorRequisicao(DateTime.Today.Year, DateTime.Today.Month);
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
