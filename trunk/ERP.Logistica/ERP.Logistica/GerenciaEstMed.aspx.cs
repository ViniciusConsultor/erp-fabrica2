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
    public partial class GerenciaEstMed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Status"] != null)
            {
                switch (Request.QueryString["Status"])
                {
                    case "1":
                        vSucesso.IsValid = false;
                        break;
                    case "-1":
                        vPedido.IsValid = false;
                        break;
                }
            }
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = EstoqueController.listar_Medicamentos_Quantidades();
            gvGerencia.DataSource = dt;
            gvGerencia.DataBind();
        }

        protected void gvGerencia_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/GerenciaEstMedLotes.aspx?ID=" + gvGerencia.DataKeys[e.NewEditIndex].Values[0].ToString());
        }
    }
}