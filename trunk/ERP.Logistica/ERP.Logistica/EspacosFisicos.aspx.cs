using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Logistica.Controllers;
using System.Data;

namespace ERP.Logistica
{
    public partial class EspacosFisicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = EspacosFisicosController.listar();
            gvEspacos.DataSource = dt;
            gvEspacos.DataBind();
        }

        protected void gvEspacos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EspacosFisicosController.apagar(Convert.ToInt32(gvEspacos.DataKeys[e.RowIndex].Values[0].ToString()));
            atualizar();
        }

        protected void gvEspacos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/EspacosFisicosForm.aspx?ID=" + gvEspacos.DataKeys[e.NewEditIndex].Values[0].ToString());
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EspacosFisicosForm.aspx?ID=Novo");
        }
    }
}