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
    public partial class Catalago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = CatalogoMedicamentoController.listar();
            gvCatalogo.DataSource = dt;
            gvCatalogo.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CatalogoMedicamentosForm.aspx?ID=Novo");
        }

        protected void gvCatalogo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/CatalogoMedicamentosForm.aspx?ID=" + gvCatalogo.DataKeys[e.NewEditIndex].Values[0].ToString());
        }

        protected void gvCatalogo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CatalogoMedicamentoController.apagar(Convert.ToInt32(gvCatalogo.DataKeys[e.RowIndex].Values[0].ToString()));
            atualizar();
        }

    }
}