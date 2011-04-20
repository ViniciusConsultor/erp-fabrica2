using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class HistoricoMedicamentoController
    {
        public static DataTable listar()
        {
            return HistoricoMedicamento.listar();
        }
    }
}
