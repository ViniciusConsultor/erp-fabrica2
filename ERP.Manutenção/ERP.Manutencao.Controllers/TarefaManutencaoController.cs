using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Manutencao.Models;
using System.Data;


namespace ERP.Manutencao.Controllers
{
    public class TarefaManutencaoController
    {
        public static void criar(string descricao, string local, string equipamento, string estado, DateTime iniciomanutencao, DateTime fimmanutencao)
        {
            TarefaManutencao tarefa = new TarefaManutencao(descricao, local, equipamento, estado, iniciomanutencao, fimmanutencao);
            tarefa.criar();
        }

        public static void apagar(int id)
        {
            TarefaManutencao tarefa = TarefaManutencao.buscarPorId(id);
            tarefa.apagar();

        }

        public static void atualizar(int id, string descricao, string local, string equipamento, string estado, DateTime iniciomanutencao, DateTime fimmanutencao)
        {
            TarefaManutencao tarefa = TarefaManutencao.buscarPorId(id);
            tarefa.Descricao = descricao;
            tarefa.Local = local;
            tarefa.Equipamento = equipamento;
            tarefa.Estado = estado;
            tarefa.InicioManutencao = iniciomanutencao;
            tarefa.FimManutencao = fimmanutencao;

            tarefa.atualizar();
        }

        public static TarefaManutencao buscarPorId(int id)
        {
            return TarefaManutencao.buscarPorId(id);
        }

        public static DataTable listar()
        {
            DataTable tarefas = TarefaManutencao.listar();
            DataTable locais = DisponibilidadeController.listarLocais();
            DataTable equipamentos = DisponibilidadeController.listarEquipamentos();

            foreach (DataRow row1 in locais.Rows)
            {
                foreach (DataRow row2 in tarefas.Rows)
                {
                    if (row2.ItemArray[2].Equals(row1.ItemArray[2].ToString()))
                        row2.SetField(tarefas.Columns[2], row1.ItemArray[3]);
                }
            }

            foreach (DataRow row1 in equipamentos.Rows)
            {
                foreach (DataRow row2 in tarefas.Rows)
                {
                    if (row2.ItemArray[3].Equals(row1.ItemArray[0].ToString()))
                        row2.SetField(tarefas.Columns[3], row1.ItemArray[1]);
                }
            }



            return tarefas;
        }

        public static DataTable WebListar()
        {
            return TarefaManutencao.WebListar();
        }

    }
}

