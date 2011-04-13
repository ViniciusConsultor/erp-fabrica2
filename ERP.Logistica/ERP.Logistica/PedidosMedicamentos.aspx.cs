using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Logistica.Controllers;
using System.Data;
using ERP.Logistica.Models;
using System.Drawing;

namespace ERP.Logistica
{
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = PedidosMedicamentosController.listar();
            gvPedidos.DataSource = dt;
            gvPedidos.DataBind();

            lbValorVerba.Text = Caixa.obterCaixa().Verba.ToString();
        }

        protected void gvPedidos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (!PedidosMedicamentosController.apagar(Convert.ToInt32(gvPedidos.DataKeys[e.RowIndex].Values[0].ToString())))
            {
                lbAviso.ForeColor = Color.Red;
            }
            else
            {
                atualizar();
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PedidosMedicamentosForm.aspx?ID=Novo");
        }

        protected void gvPedidos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/PedidosMedicamentosForm.aspx?ID=" + gvPedidos.DataKeys[e.NewEditIndex].Values[0].ToString());
        }

        protected void btnMes_Click(object sender, EventArgs e)
        {
            DataTable dt = PedidosMedicamentosController.listarPorRequisicao(DateTime.Today.Subtract(new TimeSpan(DateTime.Today.Day, 0, 0, 0)), DateTime.Today.Add(new TimeSpan(23, 59, 59)), false);
            gvPedidos.DataSource = dt;
            gvPedidos.DataBind();
        }
    }
}