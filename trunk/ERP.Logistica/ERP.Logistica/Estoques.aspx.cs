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
    public partial class Estoque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = EstoqueController.listar();
            gvEstoque.DataSource = dt;
            gvEstoque.DataBind();
        }

        protected void gvEstoque_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/EstoquesForm.aspx?ID=" + gvEstoque.DataKeys[e.NewEditIndex].Values[0].ToString());
        }

        protected void gvEstoque_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EstoqueController.apagar(Convert.ToInt32(gvEstoque.DataKeys[e.RowIndex].Values[0].ToString()));
            atualizar();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EstoquesForm.aspx?ID=Novo");
        }
    }
}