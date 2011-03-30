using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class CatalogoEquipamentoController
    {
        public static void criar(int equipamentoId, int fornecedorId, double preco, DateTime vigencia_inicio)
        {
            Equipamento equipamento = Equipamento.buscarPorId(equipamentoId);
            Fornecedor fornecedor = Fornecedor.buscarPorId(fornecedorId);
            CatalogoEquipamento catalogo = new CatalogoEquipamento(equipamento, fornecedor, preco, vigencia_inicio);
            catalogo.criar();
        }

        public static void apagar(int id)
        {
            CatalogoEquipamento catalogo = CatalogoEquipamento.buscarPorId(id);
            catalogo.apagar();
        }

        public static void atualizar(int id, int equipamentoId, int fornecedorId, double preco, DateTime vigencia_inicio)
        {
            CatalogoEquipamento catalogo = CatalogoEquipamento.buscarPorId(id);
            Equipamento equipamento = Equipamento.buscarPorId(equipamentoId);
            Fornecedor fornecedor = Fornecedor.buscarPorId(fornecedorId);
            catalogo.Equipamento = equipamento;
            catalogo.Fornecedor = fornecedor;
            catalogo.Preco_unitario = preco;
            catalogo.Vigencia_inicio = vigencia_inicio;

            catalogo.atualizar();
        }

        public static CatalogoEquipamento buscarPorId(int id)
        {
            return CatalogoEquipamento.buscarPorId(id);
        }

        public static DataTable listar()
        {
            return CatalogoEquipamento.listar();
        }
    }
}
