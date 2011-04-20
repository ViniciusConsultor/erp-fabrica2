using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.Logistica.Models
{
    public class HistoricoMedicamento
    {
        private int _id;
        private int _consultaId;
        private Medicamento _medicamento;
        private int _add_red;
        private DateTime _data;

        #region Constructors

        public HistoricoMedicamento(Medicamento medicamento, int consultaId, int add_red, DateTime data)
        {
            this._medicamento = medicamento;
            this._consultaId = consultaId;
            this._add_red = add_red;
            this._data = data;
        }

        public HistoricoMedicamento(int id, Medicamento medicamento, int consultaId, int add_red, DateTime data)
            : this(medicamento, consultaId, add_red, data)
        {
            this._id = id;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public Medicamento Medicamento
        {
            get { return _medicamento; }
            set { _medicamento = value; }
        }

        public int ConsultaId
        {
            get { return _consultaId; }
            set { _consultaId = value; }
        }
		
        public int Add_red
        {
            get { return _add_red; }
            set { _add_red = value; }
        }

		public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        #endregion

        public void criar()
        {
            HistoricoMedicamentoDAO.criar(Medicamento.Id, ConsultaId, Data, Add_red);
        }

        #region Static Methods

        public static DataTable listar()
        {
            return HistoricoMedicamentoDAO.listar();
        }

        #endregion
    }
}
