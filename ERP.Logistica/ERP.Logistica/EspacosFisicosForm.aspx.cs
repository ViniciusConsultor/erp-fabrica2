using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Logistica.Controllers;
using ERP.Logistica.Models;

namespace ERP.Logistica
{
    public partial class EspacosFisicosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                // Pedido Existente
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    EspacoFisico espaco = EspacosFisicosController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = espaco.Id.ToString();
                    tbNome.Text = espaco.Nome;
                    tbAndar.Text = espaco.Andar.ToString();
                    tbNumero.Text = espaco.Numero.ToString();
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EspacosFisicos.aspx");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                if (tbAndar.Text != "")
                {
                    EspacosFisicosController.criar(tbNome.Text, Convert.ToInt32(tbAndar.Text), Convert.ToInt32(tbNumero.Text));
                }
                else
                {
                    EspacosFisicosController.criar(tbNome.Text, 0, Convert.ToInt32(tbNumero.Text));
                }
            }
            else
            {
                EspacoFisico espaco = EspacosFisicosController.buscarPorId(Convert.ToInt32(hfId.Value));
                EspacosFisicosController.atualizar(espaco.Id, tbNome.Text, Convert.ToInt32(tbAndar.Text), Convert.ToInt32(tbNumero.Text));
            }
            Response.Redirect("/EspacosFisicos.aspx");
        }
    }
}