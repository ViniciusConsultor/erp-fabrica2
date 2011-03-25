using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class DisponibilidadesController
    {
        public static void apagar(int id)
        {
            Disponibilidade espaco = Disponibilidade.buscarPorId(id);
            espaco.apagar();
        }

        public static void atualizar(int id, int equipamento, int espacoFisico)
        {
            Disponibilidade disp = Disponibilidade.buscarPorId(id);
            Equipamento equip = Equipamento.buscarPorId(equipamento);
            disp.Equipamento = equip;
            EspacoFisico espaco = EspacoFisico.buscarPorId(espacoFisico);
            disp.EspacoFisico = espaco;
            disp.atualizar();
        }

        public static Disponibilidade buscarPorId(int id)
        {
            return Disponibilidade.buscarPorId(id);
        }

        public static DataTable listar()
        {
            return Disponibilidade.listar();
        }
    }
}
