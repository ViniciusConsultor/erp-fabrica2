using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP.Logistica.Models.DAOs;

namespace ERP.Logistica.Models
{
    public class EspacoFisico
    {
        private int _id;
        private string _nome;
        private int _andar;
        private int _numero;

        #region Constructor

        public EspacoFisico(string nome, int andar, int numero)
        {
            this._nome = nome;
            this._andar = andar;
            this._numero = numero;
        }

        public EspacoFisico(int id, string nome, int andar, int numero)
        {
            this._id = id;
            this._nome = nome;
            this._andar = andar;
            this._numero = numero;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public string Nome
        {
            get
            {
                if (_nome == null || _nome == "")
                {
                    return "Sem Nome";
                }
                return _nome;
            }
            set { _nome = value; }
        }

        public int Andar
        {
            get { return _andar; }
            set { _andar = value; }
        }

        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        #endregion

        public void criar()
        {
            EspacoFisicoDAO.criar(Nome, Andar, Numero);
        }

        public void atualizar()
        {
            EspacoFisicoDAO.atualizar(Id, Nome, Andar, Numero);
        }

        public void apagar()
        {
            EspacoFisicoDAO.apagar(Id);
        }

        #region Static Methods

        public static EspacoFisico buscarPorId(int id)
        {
            EspacoFisico espaco = null;
            DataSet ds = EspacoFisicoDAO.buscarPorId(id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = (DataRow)ds.Tables[0].Rows[0];
                espaco = new EspacoFisico(id, (string)row["Nome"], (int)row["Andar"], (int)row["Numero"]);
            }

            return espaco;
        }

        public static DataTable listar()
        {
            return EspacoFisicoDAO.listar();
        }

        public static DataTable listarEspacosFisicosDisponiveis()
        {
            return EspacoFisicoDAO.listarEspacosFisicosDisponiveis();
        }

        #endregion
    }
}
