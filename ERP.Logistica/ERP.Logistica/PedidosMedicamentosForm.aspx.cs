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
    public partial class PedidosMedicamentosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                ddlMedForn.DataSource = PedidosMedicamentosController.listarCatalogoMedDisponiveis();
                ddlMedForn.DataTextField = "Lote";
                ddlMedForn.DataValueField = "Id";
                ddlMedForn.DataBind();

                // Pedido Existente
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    PedidoMedicamento pedido = PedidosMedicamentosController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = pedido.Id.ToString();
                    ddlMedForn.SelectedValue = pedido.CatalogoMed.ToString();
                    ddlMedForn.Enabled = false;
                    tbQuant.Text = pedido.Quantidade.ToString();
                    tbQuant.Enabled = false;
                    rblEfetuado.SelectedValue = pedido.Efetuado.ToString();
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                PedidosMedicamentosController.criar(Convert.ToInt32(tbQuant.Text), DateTime.Now, Convert.ToInt32(ddlMedForn.SelectedValue), Convert.ToInt32(rblEfetuado.SelectedValue));
            }
            else
            {
                PedidoMedicamento pedido = PedidosMedicamentosController.buscarPorId(Convert.ToInt32(hfId.Value));
                if (pedido.Efetuado != Convert.ToInt32(rblEfetuado.SelectedValue))
                {
                    PedidosMedicamentosController.atualizar(pedido.Id, pedido.Quantidade, DateTime.Now, pedido.CatalogoMed, Convert.ToInt32(rblEfetuado.SelectedValue));
                }
            }
            Response.Redirect("/PedidosMedicamentos.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PedidosMedicamentos.aspx");
        }


    }
}