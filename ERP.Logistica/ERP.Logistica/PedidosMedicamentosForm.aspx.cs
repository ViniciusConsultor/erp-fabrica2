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
                ddlMedForn.DataTextField = "Catalogo_Medicamento";
                ddlMedForn.DataValueField = "Id";
                ddlMedForn.DataBind();
                rblEfetuado.Visible = false;
                lbEstado.Visible = false;
                tbValidade.Visible = false;
                lbValidade.Visible = false;

                // Pedido Existente
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    PedidoMedicamento pedido = PedidosMedicamentosController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = pedido.Id.ToString();
                    ddlMedForn.SelectedValue = pedido.CatalogoMed.ToString();
                    ddlMedForn.Enabled = false;
                    tbQuant.Text = pedido.Quantidade.ToString();
                    tbQuant.Enabled = false;
                    if (pedido.editavel())
                    {
                        rblEfetuado.SelectedValue = "2";
                        rblEfetuado.Visible = true;
                        lbEstado.Visible = true;
                        tbValidade.Visible = true;
                        lbValidade.Visible = true;
                    }
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                PedidosMedicamentosController.criar(Convert.ToInt32(tbQuant.Text), DateTime.Now, Convert.ToInt32(ddlMedForn.SelectedValue), 1);
            }
            else
            {
                DateTime validade = DateTime.Today;
                if (rblEfetuado.SelectedValue == "2")
                {
                    if (tbValidade.Text == "")
                    {
                        vValidadeObrig.IsValid = false;
                        return;
                    }
                    else
                    {
                        validade = Convert.ToDateTime(tbValidade.Text);
                    }
                }

                PedidoMedicamento pedido = PedidosMedicamentosController.buscarPorId(Convert.ToInt32(hfId.Value));
                PedidosMedicamentosController.atualizar(pedido.Id, pedido.Quantidade, DateTime.Now, pedido.CatalogoMed, Convert.ToInt32(rblEfetuado.SelectedValue), validade);
            }
            Response.Redirect("/PedidosMedicamentos.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PedidosMedicamentos.aspx");
        }

    }
}