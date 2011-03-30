using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class CatalogoMedicamentoController
    {
        public static void criar(int medicamentoId, int fornecedorId, double preco, DateTime vigencia_inicio)
        {
            Medicamento medicamento = Medicamento.buscarPorId(medicamentoId);
            Fornecedor fornecedor = Fornecedor.buscarPorId(fornecedorId);
            CatalogoMedicamento catalogo = new CatalogoMedicamento(medicamento, fornecedor, preco, vigencia_inicio);
            catalogo.criar();
        }

        public static void apagar(int id)
        {
            CatalogoMedicamento catalogo = CatalogoMedicamento.buscarPorId(id);
            catalogo.apagar();
        }

        public static void atualizar(int id, int medicamentoId, int fornecedorId, double preco, DateTime vigencia_inicio)
        {
            CatalogoMedicamento catalogo = CatalogoMedicamento.buscarPorId(id);
            Medicamento medicamento = Medicamento.buscarPorId(medicamentoId);
            Fornecedor fornecedor = Fornecedor.buscarPorId(fornecedorId);
            catalogo.Medicamento = medicamento;
            catalogo.Fornecedor = fornecedor;
            catalogo.Preco_unitario = preco;
            catalogo.Vigencia_inicio = vigencia_inicio;

            catalogo.atualizar();
        }

        public static CatalogoMedicamento buscarPorId(int id)
        {
            return CatalogoMedicamento.buscarPorId(id);
        }

        public static DataTable listar()
        {
            return CatalogoMedicamento.listar();
        }
    }
}
