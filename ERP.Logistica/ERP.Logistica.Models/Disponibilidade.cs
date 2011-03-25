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

        public Disponibilidade(int equipamento, int espacoFisico)
        {
            this._equipamento = Equipamento.buscarPorId(equipamento);
            this._espacoFisico = EspacoFisico.buscarPorId(espacoFisico);
        }

        public Disponibilidade(int id, int equipamento, int espacoFisico)
        {
            this._id = id;
            this._equipamento = Equipamento.buscarPorId(equipamento);
            this._espacoFisico = EspacoFisico.buscarPorId(espacoFisico);
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
            Disponibilidade espaco = null;
            DataSet ds = DisponibilidadeDAO.buscarPorId(id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = (DataRow)ds.Tables[0].Rows[0];
                espaco = new Disponibilidade(id, (int)row["Equipamento"], (int)row["EspacoFisico"]);
            }

            return espaco;
        }

        public static DataTable listar()
        {
            return DisponibilidadeDAO.listar();
        }

        #endregion
    }
}
