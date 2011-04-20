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
        private string _consulta;
        private Medicamento _medicamento;
        private int _add_red;

        #region Constructors

        public HistoricoMedicamento(Medicamento medicamento, string consulta, int add_red)
        {
            this._medicamento = medicamento;
            this._consulta = consulta;
            this._add_red = add_red;
        }

        public HistoricoMedicamento(int id, Medicamento medicamento, string consulta, int add_red)
            : this(medicamento, consulta, add_red)
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

        public string Consulta
        {
            get { return _consulta; }
            set { _consulta = value; }
        }

        public int Add_red
        {
            get { return _add_red; }
            set { _add_red = value; }
        }
		

        #endregion

        public void criar()
        {
            HistoricoMedicamentoDAO.criar(Medicamento.Id, Consulta, Add_red);
        }

        #region Static Methods

        public static DataTable listar()
        {
            return HistoricoMedicamentoDAO.listar();
        }

        #endregion
    }
}
