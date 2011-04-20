using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;
using ERP.Logistica.Controllers.consulta;


namespace ERP.Logistica.Controllers
{
    public class ConsultaController
    {
        public static List<string> obterMedico()
        {

            FornecedorServicos servicos = new FornecedorServicos();
            Agendamento[] consultas = servicos.AllAgendamentos();

            List<string> medicopaciente = new List<string>();

            foreach (Agendamento consulta in consultas)
            {
                medicopaciente.Add(consulta.medico_nome + "-" + consulta.paciente_nome + "-" + consulta.dataAtendimento.ToString());
            }

            return medicopaciente;

        }

    }
}
