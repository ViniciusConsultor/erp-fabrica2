using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP.Logistica.Models.DAOs;

namespace ERP.Logistica.Models
{
    public class Equipamento
    {
        private int _id;
        private string _nome;
        private string _descricao;

        #region Constructor

        public Equipamento(string nome, string descricao)
        {
            this._nome = nome;
            this._descricao = descricao;
        }

        public Equipamento(int id, string nome, string descricao)
        {
            this._id = id;
            this._nome = nome;
            this._descricao = descricao;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        #endregion

        public void criar()
        {
            EquipamentoDAO.criar( Nome, Descricao);
        }

        public void atualizar()
        {
            EquipamentoDAO.atualizar(Id, Nome, Descricao);
        }

        public void apagar()
        {
            EquipamentoDAO.apagar(Id);
        }

        #region Static Methods

        public static Equipamento buscarPorId(int id)
        {
            Equipamento equipamento = null;
            DataSet ds = EquipamentoDAO.buscarPorId(id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = (DataRow)ds.Tables[0].Rows[0];
                equipamento = new Equipamento(id, (string)row["Nome"], (string)row["Descrição"]);
            }

            return equipamento;
        }

        public static DataTable listar()
        {
            //TODO: Implementar
            return null;
        }

        public static DataTable listarEquipamentosDisponiveis()
        {
            return EquipamentoDAO.listarEquipamentosDisponiveis();
        }

        #endregion
    }
}
