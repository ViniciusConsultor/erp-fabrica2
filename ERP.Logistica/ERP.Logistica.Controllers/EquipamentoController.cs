using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class EquipamentoController
    {
        public static void criar(string nome, string descricao)
        {
            Equipamento equipamento = new Equipamento(nome, descricao);
            equipamento.criar();
        }

        public static void apagar(int id)
        {
            Equipamento equipamento = Equipamento.buscarPorId(id);
            //if (medicamento.Quantidade == 0)
            //{
            equipamento.apagar();
            //}
        }

        public static void atualizar(int id, string nome, string descricao)
        {
            Equipamento equipamento = Equipamento.buscarPorId(id);
            equipamento.Nome = nome;
            equipamento.Descricao = descricao;

            equipamento.atualizar();
        }

        public static Equipamento buscarPorId(int id)
        {
            return Equipamento.buscarPorId(id);
        }

        public static DataTable listar()
        {
            return Equipamento.listar();
        }

        public static DataTable listarEquipamentosDisponiveis()
        {
            return Equipamento.listarEquipamentosDisponiveis();
        }
    }
}
