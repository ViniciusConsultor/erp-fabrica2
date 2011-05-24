using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Controllers.AgendaWS;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class ConsultasController
    {
        public static List<string> listar()
        {
            FornecedorServicos agenda = new FornecedorServicos();
            Agendamento[] agendaList = agenda.AllAgendamentos();

            List<string> lista = new List<string>();

            foreach (Agendamento ag in agendaList)
            {
                lista.Add(ag.medico_nome + " - " + ag.paciente_nome + " - " + ag.dataAtendimento.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            return lista;
        }
    }
}
