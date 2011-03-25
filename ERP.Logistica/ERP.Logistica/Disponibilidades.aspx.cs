using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERP.Logistica.Controllers;

namespace ERP.Logistica
{
    public partial class Disponibilidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = DisponibilidadesController.listar();
            gvDisp.DataSource = dt;
            gvDisp.DataBind();
        }

        protected void gvDisp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/DisponibilidadesForm.aspx?ID=" + gvDisp.DataKeys[e.NewEditIndex].Values[0].ToString());
        }

        protected void gvDisp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DisponibilidadesController.apagar(Convert.ToInt32(gvDisp.DataKeys[e.RowIndex].Values[0].ToString()));
            atualizar();
        }
    }
}