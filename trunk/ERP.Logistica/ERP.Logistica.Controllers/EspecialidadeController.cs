using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Controllers.RHServico;
using System.Data;


namespace ERP.Logistica.Controllers
{
    public class EspecialidadeController
    {

        public static DataTable listaEspecialidades()
        {
            RH_Servico servico = new RH_Servico();

            DataSet especialidades = servico.listEspecialidade();

            DataTable tabela = especialidades.Tables[0];

            return tabela;
        }

    }
}
