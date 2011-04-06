using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class MedicamentoController
    {
        public static void criar(string nome, string descricao, string medida)
        {
            Medicamento medicamento = new Medicamento(nome, descricao, medida);
            medicamento.criar();
        }

        public static void apagar(int id)
        {
            Medicamento medicamento = Medicamento.buscarPorId(id);
            //if (medicamento.Quantidade == 0)
            //{
                medicamento.apagar();
            //}
        }

        public static void atualizar(int id, string nome, string descricao, string medida)
        {
            Medicamento medicamento = Medicamento.buscarPorId(id);
            medicamento.Nome = nome;
            medicamento.Descricao = descricao;
            medicamento.Medida = medida;

            medicamento.atualizar();
        }

        public static Medicamento buscarPorId(int id)
        {
            return Medicamento.buscarPorId(id);
        }

        public static DataTable listar()
        {
            return Medicamento.listar();
        }
    }
}
