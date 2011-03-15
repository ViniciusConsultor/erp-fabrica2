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
        private float _verbaMensal;

        public Caixa()
        {
            this._verbaMensal = 0;
        }

        public float VerbaMensal
        {
            get { return _verbaMensal; }
            set { _verbaMensal = value; }
        }

        public void atualizar()
        {
            CaixaDAO.atualizarVerbaMensal(VerbaMensal);
        }

        public static Caixa obterCaixa()
        {
            DataTable dt = CaixaDAO.obterVerba();
            Caixa caixa = new Caixa();

            if(dt.Rows.Count > 0)
            {
                caixa.VerbaMensal = (float)Convert.ToDouble(dt.Rows[0]["Quantidade"]);
            }
            return caixa;
        }
    }
}
