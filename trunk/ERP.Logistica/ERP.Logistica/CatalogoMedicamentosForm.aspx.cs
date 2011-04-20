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
    public partial class CatalogoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                ddlMedicamento.DataSource = MedicamentoController.listar();
                ddlMedicamento.DataTextField = "Nome";
                ddlMedicamento.DataValueField = "Id";
                ddlMedicamento.DataBind();

                ddlFornecedor.DataSource = FornecedorController.listar();
                ddlFornecedor.DataTextField = "Nome";
                ddlFornecedor.DataValueField = "Id";
                ddlFornecedor.DataBind();

                // Pedido Existente
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    CatalogoMedicamento catalogo = CatalogoMedicamentoController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = catalogo.Id.ToString();
                    ddlMedicamento.SelectedValue = catalogo.Medicamento.Id.ToString();
                    ddlMedicamento.Enabled = false;
                    ddlFornecedor.SelectedValue = catalogo.Fornecedor.Id.ToString();
                    ddlFornecedor.Enabled = false;
                    tbPreco.Text = catalogo.Preco_unitario.ToString();
                    tbPreco.Enabled = true;
                    tbVigencia.Text = catalogo.Vigencia_inicio.ToString("dd/MM/yyyy");
                    tbVigencia.Enabled = true;
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                CatalogoMedicamentoController.criar(Convert.ToInt32(ddlMedicamento.SelectedValue), Convert.ToInt32(ddlFornecedor.SelectedValue), Convert.ToDouble(tbPreco.Text), Convert.ToDateTime(tbVigencia.Text));
            }
            else
            {
                CatalogoMedicamento catalogo = CatalogoMedicamentoController.buscarPorId(Convert.ToInt32(hfId.Value));
                CatalogoMedicamentoController.atualizar(catalogo.Id, catalogo.Medicamento.Id, catalogo.Fornecedor.Id, Convert.ToInt32(tbPreco.Text),Convert.ToDateTime(tbVigencia.Text));
            }
            Response.Redirect("/CatalogoMedicamentos.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CatalogoMedicamentos.aspx");
        }
    }
}