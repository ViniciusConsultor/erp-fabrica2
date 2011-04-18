using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;
using ERP.Logistica.Controllers.FinServico;

namespace ERP.Logistica.Controllers
{
    public class PedidosEquipamentosController
    {
        public static int criar(DateTime requisicao, int catalogoEquip, int efetuado, int espacoFisico)
        {
            PedidoEquipamento pedido = new PedidoEquipamento(requisicao, catalogoEquip, 0, efetuado);

            // Contabilizar no estoque caso efetuado
            if (!utilizarVerba(pedido.calcularValor()))
            {
                // Pede verba adicional e verifica se a compra pode ser efetuada
                //double verbaAdicional = FinanceiroTeste.obterVerba(pedido.calcularValor());

                try
                {
                    FinlogWS serv = new FinlogWS();

                    double verbaAdicional = serv.geraCota(pedido.calcularValor());

                    Caixa caixa = Caixa.obterCaixa();
                    caixa.adicionar(verbaAdicional, true);

                    // Considera que o processo de calculo da verba já leva em conta a obtenção de todos os estornos
                    PedidoEquipamento.marcarEstornoReportado(DateTime.Now);

                }
                catch
                {
                    return -1;
                }

                if (!utilizarVerba(pedido.calcularValor()))
                {
                    return -1;
                }
            }

            pedido.criar();

            return 0;
        }

        public static bool apagar(int id)
        {
            PedidoEquipamento pedido = PedidoEquipamento.buscarPorId(id);
            // Apaga caso seja um estorno já reportado ao Financeiro
            if (pedido.apagavel())
            {
                pedido.apagar();
                return true;
            }
            return false;
        }

        public static void atualizar(int id, DateTime requisicao, int catalogoEquip, int efetuado, int espacoFisico)
        {
            PedidoEquipamento pedido = PedidoEquipamento.buscarPorId(id);
            pedido.Requisicao = requisicao;
            pedido.CatalogoEquip = catalogoEquip;
            // Se mudou para efetuado, contabiliza o estoque, se mudou para estornado verifica se é possivel
            // antes de modificar estoque. (Preciso de interface para obter e editar o estoque)
            if (efetuado == 2 && pedido.Efetuado == 1) // Mudou para efetuado
            {
                // Cria disponibilidade e associa com pedido
                Equipamento equipamento = Equipamento.buscarPorId(pedido.obterEquipamento());
                EspacoFisico espaco = EspacoFisico.buscarPorId(espacoFisico);
                Disponibilidade disponibilidade = new Disponibilidade(equipamento, espaco);
                pedido.Disponibilidade = disponibilidade;
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

        public static PedidoEquipamento buscarPorId(int id)
        {
            return PedidoEquipamento.buscarPorId(id);
        }

        public static DataTable listar()
        {
            return PedidoEquipamento.listar();
        }

        public static DataTable listarCatalogoEquipDisponiveis()
        {
            return PedidoEquipamento.listarCatalogoEquipDisponiveis();
        }

        public static DataTable listarPorRequisicao(DateTime inicio, DateTime fim, bool apenasEfetuados)
        {
            return PedidoEquipamento.listarPorRequisicao(inicio, fim, apenasEfetuados);
        }

        public static double calcularValorEstornado(DateTime limite, bool todos)
        {
            double valor = PedidoEquipamento.calcularValorEstornadoAte(limite, todos);

            PedidoEquipamento.marcarEstornoReportado(limite);

            return valor;
        }

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
