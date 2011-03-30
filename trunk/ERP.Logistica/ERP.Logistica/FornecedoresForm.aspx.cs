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
    public partial class FornecedorForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    ERP.Logistica.Models.Fornecedor fornecedor = FornecedorController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = fornecedor.Id.ToString();
                    tbNome.Text = fornecedor.Nome.ToString();
                    tbNome.Enabled = false;
                    tbTelefone.Text = fornecedor.Telefone.ToString();
                    tbTelefone.Enabled = true;
                    tbEmail.Text = fornecedor.Email.ToString();
                    tbEmail.Enabled = true;
                    tbLocalizacao.Text = fornecedor.Localizacao.ToString();
                    tbLocalizacao.Enabled = true;
                    tbRanking.Text = fornecedor.Ranking.ToString();
                    tbRanking.Enabled = true;
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                FornecedorController.criar(tbNome.Text, tbTelefone.Text, tbEmail.Text, tbLocalizacao.Text, Convert.ToInt32(tbRanking.Text));
            }
            else
            {
                // caso de update
                ERP.Logistica.Models.Fornecedor fornecedor = FornecedorController.buscarPorId(Convert.ToInt32(hfId.Value));
                FornecedorController.atualizar(fornecedor.Id, tbNome.Text, tbTelefone.Text, tbEmail.Text, tbLocalizacao.Text, Convert.ToInt32(tbRanking.Text));
            }
            Response.Redirect("/Fornecedores.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Fornecedores.aspx");
        }
    }
}