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
        private double _verba;
        private DateTime _ultimoAcrescimo;

        public Caixa(DateTime ultimoAcrescimo)
        {
            this._ultimoAcrescimo = ultimoAcrescimo;
            this._verba = 0;
        }

        public double Verba
        {
            get { return _verba; }
            set { _verba = value; }
        }

        public DateTime UltimoAcrescimo
        {
            get { return _ultimoAcrescimo; }
        }

        public bool remover(double valor)
        {
            if (Verba >= valor)
            {
                Verba -= valor;
                CaixaDAO.atualizarVerba(Verba, UltimoAcrescimo);
                return true;
            }
            return false;
        }

        public void adicionar(double valor, bool atualizarData)
        {
            Verba += valor;
            this._ultimoAcrescimo = DateTime.Now;
            CaixaDAO.atualizarVerba(Verba, UltimoAcrescimo);
        }

        public static Caixa obterCaixa()
        {
            DataTable dt = CaixaDAO.obterVerba();
            Caixa caixa = null;

            if(dt.Rows.Count > 0)
            {
                caixa = new Caixa(Convert.ToDateTime(dt.Rows[0]["Ultimo_Acrescimo"]));
                caixa.Verba = Convert.ToDouble(dt.Rows[0]["Quantidade"]);
            }
            return caixa;
        }
    }
}
