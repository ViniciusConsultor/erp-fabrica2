using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models.DAOs;
using System.Data;

namespace ERP.Logistica.Models
{
    public class Caixa
    {
        private float _verba;

        public Caixa()
        {
            this._verba = 0;
        }

        public float Verba
        {
            get { return _verba; }
            set { _verba = value; }
        }

        public bool remover(float valor)
        {
            if (Verba >= valor)
            {
                Verba -= valor;
                CaixaDAO.atualizarVerba(Verba, false);
                return true;
            }
            return false;
        }

        public void adicionar(float valor, bool atualizarData)
        {
            Verba += valor;
            CaixaDAO.atualizarVerba(Verba, atualizarData);
        }

        public static Caixa obterCaixa()
        {
            DataTable dt = CaixaDAO.obterVerba();
            Caixa caixa = new Caixa();

            if(dt.Rows.Count > 0)
            {
                caixa.Verba = (float)Convert.ToDouble(dt.Rows[0]["Quantidade"]);
            }
            return caixa;
        }
    }
}
