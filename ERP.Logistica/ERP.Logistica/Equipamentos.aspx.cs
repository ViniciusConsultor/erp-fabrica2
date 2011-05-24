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
    public partial class Equipamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = EquipamentoController.listar();
            gvEquipamento.DataSource = dt;
            gvEquipamento.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EquipamentosForm.aspx?ID=Novo");
        }

        protected void gvEquipamento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EquipamentoController.apagar(Convert.ToInt32(gvEquipamento.DataKeys[e.RowIndex].Values[0].ToString()));
            atualizar();
        }

        protected void gvEquipamento_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/EquipamentosForm.aspx?ID=" + gvEquipamento.DataKeys[e.NewEditIndex].Values[0].ToString());
        }

    }
}