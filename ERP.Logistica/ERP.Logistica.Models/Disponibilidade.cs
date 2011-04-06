using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models.DAOs;
using System.Data;

namespace ERP.Logistica.Models
{
    public class Disponibilidade
    {
        private int _id;
        private Equipamento _equipamento;
        private EspacoFisico _espacoFisico;

        #region Constructors

        public Disponibilidade(Equipamento equipamento, EspacoFisico espacoFisico)
        {
            this._equipamento = equipamento;
            this._espacoFisico = espacoFisico;
        }

        public Disponibilidade(int id, Equipamento equipamento, EspacoFisico espacoFisico)
            : this(equipamento, espacoFisico)
        {
            this._id = id;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public Equipamento Equipamento
        {
            get { return _equipamento; }
            set { _equipamento = value; }
        }

        public EspacoFisico EspacoFisico
        {
            get { return _espacoFisico; }
            set { _espacoFisico = value; }
        }

        #endregion

        public void criar()
        {
            if (EspacoFisico != null)
            {
                _id = DisponibilidadeDAO.criar(Equipamento.Id, EspacoFisico.Id);
            }
            else
            {
                _id = DisponibilidadeDAO.criar(Equipamento.Id, 0);
            }
        }

        public void atualizar()
        {
            if (EspacoFisico != null)
            {
                DisponibilidadeDAO.atualizar(Id, Equipamento.Id, EspacoFisico.Id);
            }
            else
            {
                DisponibilidadeDAO.atualizar(Id, Equipamento.Id, 0);
            }
        }

        public void apagar()
        {
            DisponibilidadeDAO.apagar(Id);
        }

        #region Static Methods

        public static Disponibilidade buscarPorId(int id)
        {
            Disponibilidade disp = null;
            DataSet ds = DisponibilidadeDAO.buscarPorId(id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = (DataRow)ds.Tables[0].Rows[0];
                Equipamento equipamento = Equipamento.buscarPorId((int)row["Equipamento"]);
                EspacoFisico espaco = EspacoFisico.buscarPorId((int)row["Espaco_Fisico"]);
                disp = new Disponibilidade(id, equipamento, espaco);
            }

            return disp;
        }

        public static DataTable listar()
        {
            return DisponibilidadeDAO.listar();
        }

        #endregion
    }
}
