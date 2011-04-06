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
            return TarefaManutencao.listar();
        }

    }
}

