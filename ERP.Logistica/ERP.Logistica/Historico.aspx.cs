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
    public partial class Historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = MedicamentoController.listar();
            gvMedicamento.DataSource = dt;
            gvMedicamento.DataBind();
        }

        protected void gvMedicamento_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/HistoricosEstoques.aspx?ID=" + gvMedicamento.DataKeys[e.NewEditIndex].Values[0].ToString());
        }
    }
}