using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class EstoqueController
    {
        public static void criar(int medicamentoId, int quantidade, DateTime validade, string localizacao)
        {
            Medicamento medicamento = Medicamento.buscarPorId(medicamentoId);
            //if (CatalogoMedicamento.ExisteCatalagoParaMedicamento(medicamento))
            //{
                Estoque estoque = new Estoque(medicamento, quantidade, validade, localizacao);
                estoque.criar();
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public static void apagar(int id)
        {
            Estoque estoque = Estoque.buscarPorId(id);
            estoque.apagar();
        }

        public static void atualizar(int id, int medicamentoId, int quantidade, DateTime validade, string localizacao)
        {
            Estoque estoque = Estoque.buscarPorId(id);
            Medicamento medicamento = Medicamento.buscarPorId(medicamentoId);
            estoque.Medicamento = medicamento;
            estoque.Quantidade = quantidade;
            estoque.Validade = validade;
            estoque.Localizacao = localizacao;

            estoque.atualizar();
        }

        public static Estoque buscarPorId(int id)
        {
            return Estoque.buscarPorId(id);
        }

        public static DataTable listar()
        {
            return Estoque.listar();
        }

        public static DataTable listar_Medicamentos_Quantidades()
        {
            return Estoque.listar_Medicamentos_Quantidades();
        }

        public static DataTable listar_por_Medicamento(int medicamentoId)
        {
            return Estoque.listar_por_Medicamento(medicamentoId);
        }

        public static int alterar_quantidade(int id, int quantidade_adicionada, string consulta)
        {
            Estoque estoque = Estoque.buscarPorId(id);
            HistoricoMedicamento historico = new HistoricoMedicamento(estoque.Medicamento, consulta);
            historico.criar();
            if (quantidade_adicionada < 0)
            {
                if (Math.Abs(quantidade_adicionada) > estoque.Quantidade)
                {
                    return -2;
                }
                else if (Math.Abs(quantidade_adicionada) == estoque.Quantidade)
                {
                    int quantidade_total = Estoque.buscar_Quantidade_por_Medicamento(estoque.Medicamento);
                    // caso não tenha mais nada no estoque
                    int quantidade_antiga = estoque.Quantidade;
                    estoque.apagar();
                    if (quantidade_antiga == quantidade_total)
                    {
                        // cria novo pedido
                        if (CatalogoMedicamento.ExisteCatalagoParaMedicamento(estoque.Medicamento))
                        {
                            CatalogoMedicamento catalogo = CatalogoMedicamento.buscarPorMedicamento(estoque.Medicamento);
                            if (PedidosMedicamentosController.criar(10, DateTime.Now, catalogo.Id, 0) == -1)
                            {
                                return -1;
                            }
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            estoque.Quantidade = estoque.Quantidade + quantidade_adicionada;
            estoque.atualizar();
            return 0;
        }
    }
}
