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
    public partial class CatalogoEquipamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = CatalogoEquipamentoController.listar();
            gvCatalogo.DataSource = dt;
            gvCatalogo.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CatalogoEquipamentosForm.aspx?ID=Novo");
        }

        protected void gvCatalogo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/CatalogoEquipamentosForm.aspx?ID=" + gvCatalogo.DataKeys[e.NewEditIndex].Values[0].ToString());
        }

        protected void gvCatalogo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CatalogoEquipamentoController.apagar(Convert.ToInt32(gvCatalogo.DataKeys[e.RowIndex].Values[0].ToString()));
            atualizar();
        }

    }
}