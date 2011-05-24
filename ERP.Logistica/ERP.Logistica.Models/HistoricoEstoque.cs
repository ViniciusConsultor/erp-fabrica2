using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models.DAOs;
using System.Data;

namespace ERP.Logistica.Models
{
    public class HistoricoEstoque
    {
        int _id;
        string _consultaId;
        DateTime _data;
        int _addRed;
        Medicamento _medicamento;

        public HistoricoEstoque(string consultaId, DateTime data, int addRed, Medicamento medicamento)
        {
            this._consultaId = consultaId;
            this._data = data;
            this._addRed = addRed;
            this._medicamento = medicamento;
        }

        public int Id
        {
            get { return _id; }
        }

        public string ConsultaId
        {
            get { return _consultaId; }
            set { _consultaId = value; }
        }

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public int AddRed
        {
            get { return _addRed; }
            set { _addRed = value; }
        }

        public Medicamento Medicamento
        {
            get { return _medicamento; }
            set { _medicamento = value; }
        }

        public int criar()
        {
            HistoricoEstoqueDAO.criar(ConsultaId, Data, AddRed, Medicamento.Id);
            return 0;
        }

        public static DataTable listar(int medId)
        {
            return HistoricoEstoqueDAO.listar(medId);
        }
    }
}
