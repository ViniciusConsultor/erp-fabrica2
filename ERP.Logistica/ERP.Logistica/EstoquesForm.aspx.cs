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
    public partial class EstoqueForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                ddlMedicamento.DataSource = MedicamentoController.listar();
                ddlMedicamento.DataTextField = "Nome";
                ddlMedicamento.DataValueField = "Id";
                ddlMedicamento.DataBind();

                // Pedido Existente
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    ERP.Logistica.Models.Estoque estoque = EstoqueController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = estoque.Id.ToString();
                    ddlMedicamento.SelectedValue = estoque.Medicamento.Id.ToString();
                    ddlMedicamento.Enabled = false;
                    tbQuantidade.Text = estoque.Quantidade.ToString();
                    tbQuantidade.Enabled = true;
                    tbValidade.Text = estoque.Validade.ToString("dd/MM/yyyy");
                    tbValidade.Enabled = true;
                    tbLocalizacao.Text = estoque.Localizacao.ToString();
                    tbLocalizacao.Enabled = true;
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                EstoqueController.criar(Convert.ToInt32(ddlMedicamento.SelectedValue), Convert.ToInt32(tbQuantidade.Text), Convert.ToDateTime(tbValidade.Text), tbLocalizacao.Text);
            }
            else
            {
                ERP.Logistica.Models.Estoque estoque = EstoqueController.buscarPorId(Convert.ToInt32(hfId.Value));
                EstoqueController.atualizar(estoque.Id, estoque.Medicamento.Id, Convert.ToInt32(tbQuantidade.Text), Convert.ToDateTime(tbValidade.Text), tbLocalizacao.Text);
            }
            Response.Redirect("/Estoques.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Estoques.aspx");
        }

    }
}