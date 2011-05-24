using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class HistoricoEstoqueController
    {
        public static int criar(string consultaId, DateTime data, int addRed, int medicamentoId)
        {
            Medicamento medicamento = Medicamento.buscarPorId(medicamentoId);
            HistoricoEstoque historico = new HistoricoEstoque(consultaId, data, addRed, medicamento);
            return historico.criar();
        }

        public static DataTable listar(int medId)
        {
            return HistoricoEstoque.listar(medId);
        }
    }
}
