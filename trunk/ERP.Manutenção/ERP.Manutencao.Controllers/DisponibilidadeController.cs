using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Manutencao.Controllers.Disponibilidade;
using System.Data;

namespace ERP.Manutencao.Controllers
{
    public class DisponibilidadeController
    {
        public static DataTable listarLocais()
        {
            DisponibilidadeWS servico = new DisponibilidadeWS();
            DataTable disponibilidade = servico.obterListagemDisponibilade();

            DataTable locais = disponibilidade.Clone();
            locais.Clear();

            DataRow novaRow = null;
            Boolean pertence = false;

            foreach (DataRow row1 in disponibilidade.Rows)
            {
                pertence = false;
                foreach (DataRow row2 in locais.Rows)
                {
                    if (row2.ItemArray[3].Equals(row1.ItemArray[3]))
                    {
                        pertence = true;
                        break;
                    }

                }
                
                if (!pertence)
                {
                    novaRow = locais.NewRow();
                    novaRow["Equipamento"] = row1["Equipamento"];
                    novaRow["EquipamentoId"] = row1["EquipamentoId"];
                    novaRow["Espaco"] = row1["Espaco"];
                    novaRow["EspacoFisicoId"] = row1["EspacoFisicoId"];
                    novaRow["Andar"] = row1["Andar"];
                    novaRow["Numero"] = row1["Numero"];
                    locais.Rows.Add(novaRow);
                }
            }

            return locais;
        }

        public static DataTable listarEquipamentos()
        {
            DisponibilidadeWS servico = new DisponibilidadeWS();
            DataTable disponibilidade = servico.obterListagemDisponibilade();

            DataTable equipamentos = disponibilidade.Clone();
            equipamentos.Clear();

            Boolean pertence = false;
            DataRow novaRow = null;


            foreach (DataRow row1 in disponibilidade.Rows)
            {
                pertence = false;
                foreach (DataRow row2 in equipamentos.Rows)
                {
                    if (row2.ItemArray[1].Equals(row1.ItemArray[1]))
                    {
                        pertence = true;
                        break;
                    }

                }
                
                if (!pertence)
                {
                    novaRow = equipamentos.NewRow();
                    novaRow["Equipamento"] = row1["Equipamento"];
                    novaRow["EquipamentoId"] = row1["EquipamentoId"];
                    novaRow["Espaco"] = row1["Espaco"];
                    novaRow["EspacoFisicoId"] = row1["EspacoFisicoId"];
                    novaRow["Andar"] = row1["Andar"];
                    novaRow["Numero"] = row1["Numero"];
                    equipamentos.Rows.Add(novaRow);
                }
            }

            return equipamentos;
        }        

    }
}
