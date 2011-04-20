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
    public partial class CatalogoEquipamentosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                ddlEquipamento.DataSource = EquipamentoController.listar();
                ddlEquipamento.DataTextField = "Nome";
                ddlEquipamento.DataValueField = "Id";
                ddlEquipamento.DataBind();

                ddlFornecedor.DataSource = FornecedorController.listar();
                ddlFornecedor.DataTextField = "Nome";
                ddlFornecedor.DataValueField = "Id";
                ddlFornecedor.DataBind();

                // Pedido Existente
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    CatalogoEquipamento catalogo = CatalogoEquipamentoController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = catalogo.Id.ToString();
                    ddlEquipamento.SelectedValue = catalogo.Equipamento.Id.ToString();
                    ddlEquipamento.Enabled = false;
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
                CatalogoEquipamentoController.criar(Convert.ToInt32(ddlEquipamento.SelectedValue), Convert.ToInt32(ddlFornecedor.SelectedValue), Convert.ToDouble(tbPreco.Text), Convert.ToDateTime(tbVigencia.Text));
            }
            else
            {
                CatalogoEquipamento catalogo = CatalogoEquipamentoController.buscarPorId(Convert.ToInt32(hfId.Value));
                CatalogoEquipamentoController.atualizar(catalogo.Id, catalogo.Equipamento.Id, catalogo.Fornecedor.Id, Convert.ToInt32(tbPreco.Text), Convert.ToDateTime(tbVigencia.Text));
            }
            Response.Redirect("/CatalogoEquipamentos.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CatalogoEquipamentos.aspx");
        }
    }
}