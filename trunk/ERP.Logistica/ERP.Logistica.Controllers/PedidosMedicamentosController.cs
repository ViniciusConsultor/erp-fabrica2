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
        public static void criar(int quantidade, DateTime requisicao, int catalogoMed, int efetuado)
        {
            PedidoMedicamento pedido = new PedidoMedicamento(quantidade, requisicao, catalogoMed, efetuado);

            // Contabilizar no estoque caso efetuado
            if (efetuado == 1)
            {
                if (utilizarVerba(pedido.calcularValor()))
                {
                    MedicamentosTeste.adicionarQuantidade(pedido.CatalogoMed, pedido.Quantidade);
                }
                else
                {
                    // Pede verba adicional e verifica se a compra pode ser efetuada
                    float verbaAdicional = FinanceiroTeste.obterVerba(pedido.calcularValor());
                    Caixa caixa = Caixa.obterCaixa();
                    caixa.adicionar(verbaAdicional, true);

                    if (utilizarVerba(pedido.calcularValor()))
                    {
                        MedicamentosTeste.adicionarQuantidade(pedido.CatalogoMed, pedido.Quantidade);
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
            pedido.CatalogoMed = lote;
            // Se mudou para efetuado, contabiliza o estoque, se mudou para estornado verifica se é possivel
            // antes de modificar estoque. (Preciso de interface para obter e editar o estoque)
            if (efetuado == 1 && pedido.Efetuado == 0) // Mudou para efetuado
            {
                if (utilizarVerba(pedido.calcularValor()))
                {
                    MedicamentosTeste.adicionarQuantidade(pedido.CatalogoMed, pedido.Quantidade);
                }
                else
                {
                    // Pede verba adicional e verifica se a compra pode ser efetuada
                    float verbaAdicional = FinanceiroTeste.obterVerba(pedido.calcularValor());
                    Caixa caixa = Caixa.obterCaixa();
                    caixa.adicionar(verbaAdicional, true);

                    if (utilizarVerba(pedido.calcularValor()))
                    {
                        MedicamentosTeste.adicionarQuantidade(pedido.CatalogoMed, pedido.Quantidade);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (efetuado == 0 && pedido.Efetuado == 1) // Mudou para estornado
            {
                if (!MedicamentosTeste.removerQuantidade(pedido.CatalogoMed, pedido.Quantidade))
                {
                    return;
                }
                // Registra reembolso
                Caixa caixa = Caixa.obterCaixa();
                caixa.adicionar(pedido.calcularValor(), false);
            }
            pedido.Efetuado = efetuado;
            pedido.atualizar();
        }

        public static PedidoMedicamento buscarPorId(int id)
        {
            return PedidoMedicamento.buscarPorId(id);
        }

        public static DataTable listar()
        {
            return PedidoMedicamento.listar();
        }

        public static DataTable listarCatalogoMedDisponiveis()
        {
            return PedidoMedicamento.listarCatalogoMedDisponiveis();
        }

        public static DataTable listarPorRequisicao(DateTime inicio, DateTime fim, bool apenasEfetuados)
        {
            return PedidoMedicamento.listarPorRequisicao(inicio, fim, apenasEfetuados);
        }

        /*public static float calcularGastoMensal(int ano, int mes)
        {
            return PedidoMedicamento.calcularGastoMensal(ano, mes);
        }*/

        public static bool utilizarVerba(float gastoAdicional)
        {
            Caixa caixa = Caixa.obterCaixa();
            if (caixa.Verba >= gastoAdicional)
            {
                caixa.remover(gastoAdicional);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
