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
            Estoque estoque = new Estoque(medicamento, quantidade, validade,localizacao);
            estoque.criar();
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

        public static bool alterar_quantidade(int id, int quantidade_adicionada)
        {
            Estoque estoque = Estoque.buscarPorId(id);
            if (quantidade_adicionada < 0)
            {
                if (quantidade_adicionada > estoque.Quantidade)
                {
                    return false;
                }
                else if (quantidade_adicionada == estoque.Quantidade)
                {
                    int quantidade_total = Estoque.buscar_Quantidade_por_Medicamento(estoque.Medicamento.Id);
                    if (estoque.Quantidade == quantidade_total)
                    {
                        // cria novo pedido
                        // deleta do banco
                        return true;
                    }
                }
            }
            estoque.Quantidade = estoque.Quantidade + quantidade_adicionada;
            estoque.atualizar();
            return true;
        }
    }
}
