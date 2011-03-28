using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class PedidosEquipamentosController
    {
        public static void criar(DateTime requisicao, int catalogoEquip, int efetuado, int espacoFisico)
        {
            PedidoEquipamento pedido = new PedidoEquipamento(requisicao, catalogoEquip, 0, efetuado);

            // Contabilizar no estoque caso efetuado
            if (utilizarVerba(pedido.calcularValor()))
            {
                // Cria disponibilidade e associa com pedido
                Disponibilidade disponibilidade = new Disponibilidade(pedido.obterEquipamento(), espacoFisico);
                pedido.Disponibilidade = disponibilidade;
            }
            else
            {
                // Pede verba adicional e verifica se a compra pode ser efetuada
                float verbaAdicional = FinanceiroTeste.obterVerba(pedido.calcularValor());
                Caixa caixa = Caixa.obterCaixa();
                caixa.adicionar(verbaAdicional, true);

                if (utilizarVerba(pedido.calcularValor()))
                {
                    // Cria disponibilidade e associa com pedido
                    Disponibilidade disponibilidade = new Disponibilidade(pedido.obterEquipamento(), espacoFisico);
                    pedido.Disponibilidade = disponibilidade;
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
            PedidoEquipamento pedido = PedidoEquipamento.buscarPorId(id);
            if (pedido.Efetuado != 1)
            {
                pedido.apagar();
            }
        }

        public static void atualizar(int id, DateTime requisicao, int catalogoEquip, int efetuado, int espacoFisico)
        {
            PedidoEquipamento pedido = PedidoEquipamento.buscarPorId(id);
            pedido.Requisicao = requisicao;
            pedido.CatalogoEquip = catalogoEquip;
            // Se mudou para efetuado, contabiliza o estoque, se mudou para estornado verifica se é possivel
            // antes de modificar estoque. (Preciso de interface para obter e editar o estoque)
            if (efetuado == 1 && pedido.Efetuado == 0) // Mudou para efetuado
            {
                // Contabilizar no estoque caso efetuado
                if (utilizarVerba(pedido.calcularValor()))
                {
                    // Cria disponibilidade e associa com pedido
                    Disponibilidade disponibilidade = new Disponibilidade(pedido.obterEquipamento(), espacoFisico);
                    pedido.Disponibilidade = disponibilidade;
                }
                else
                {
                    // Pede verba adicional e verifica se a compra pode ser efetuada
                    float verbaAdicional = FinanceiroTeste.obterVerba(pedido.calcularValor());
                    Caixa caixa = Caixa.obterCaixa();
                    caixa.adicionar(verbaAdicional, true);

                    if (utilizarVerba(pedido.calcularValor()))
                    {
                        // Cria disponibilidade e associa com pedido
                        Disponibilidade disponibilidade = new Disponibilidade(pedido.obterEquipamento(), espacoFisico);
                        pedido.Disponibilidade = disponibilidade;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (efetuado == 0 && pedido.Efetuado == 1) // Mudou para estornado
            {
                if (pedido.Disponibilidade != null)
                {
                    pedido.Disponibilidade.apagar();
                    pedido.Disponibilidade = null;
                }
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

        /*public static float calcularGastoMensal(int ano, int mes)
        {
            return PedidoEquipamento.calcularGastoMensal(ano, mes);
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
