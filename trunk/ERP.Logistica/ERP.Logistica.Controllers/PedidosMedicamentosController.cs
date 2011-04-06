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
            if (!utilizarVerba(pedido.calcularValor()))
            {
                // Pede verba adicional e verifica se a compra pode ser efetuada
                double verbaAdicional = FinanceiroTeste.obterVerba(pedido.calcularValor());
                Caixa caixa = Caixa.obterCaixa();
                caixa.adicionar(verbaAdicional, true);

                if (!utilizarVerba(pedido.calcularValor()))
                {
                    return;
                }
            }

            pedido.criar();
        }

        public static bool apagar(int id)
        {
            PedidoMedicamento pedido = PedidoMedicamento.buscarPorId(id);
            // Apaga caso seja um estorno já reportado ao Financeiro
            if (pedido.apagavel())
            {
                pedido.apagar();
                return true;
            }
            return false;
        }

        public static void atualizar(int id, int quantidade, DateTime requisicao, int catalogMed, int efetuado, DateTime validade)
        {
            PedidoMedicamento pedido = PedidoMedicamento.buscarPorId(id);
            pedido.Quantidade = quantidade;
            pedido.Requisicao = requisicao;
            pedido.CatalogoMed = catalogMed;
            // Se mudou para efetuado, contabiliza o estoque, se mudou para estornado verifica se é possivel
            // antes de modificar estoque. (Preciso de interface para obter e editar o estoque)
            if (efetuado == 2 && pedido.Efetuado == 1) // Mudou para efetuado
            {
                CatalogoMedicamento catalogo = CatalogoMedicamento.buscarPorId(catalogMed);
                Estoque estoque = new Estoque(catalogo.Medicamento, quantidade, validade, "");
                estoque.criar();
            }
            else if (efetuado == 0 && pedido.Efetuado == 1) // Mudou para estornado
            {
                pedido.ReportarEstorno = 1;

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

        public static bool utilizarVerba(double gastoAdicional)
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
