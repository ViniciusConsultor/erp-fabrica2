using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Logistica.Controllers;
using System.Data;
using ERP.Logistica.Models;

namespace ERP.Logistica
{
    public partial class Fornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = FornecedorController.listar();
            gvFornecedor.DataSource = dt;
            gvFornecedor.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/FornecedoresForm.aspx?ID=Novo");
        }

        protected void gvFornecedor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/FornecedoresForm.aspx?ID=" + gvFornecedor.DataKeys[e.NewEditIndex].Values[0].ToString());
        }

        protected void gvFornecedor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            FornecedorController.apagar(Convert.ToInt32(gvFornecedor.DataKeys[e.RowIndex].Values[0].ToString()));
            atualizar();
        }
    }
}