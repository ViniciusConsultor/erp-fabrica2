using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Manutencao.Controllers;
using System.Data;
using ERP.Manutencao.Models;

namespace ERP.Manutenção
{
    public partial class TarefaManutencao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = TarefaManutencaoController.listar();
            gvTarefas.DataSource = dt;
            gvTarefas.DataBind();
        }

        protected void gvTarefas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TarefaManutencaoController.apagar(Convert.ToInt32(gvTarefas.DataKeys[e.RowIndex].Values[0].ToString()));
            atualizar();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/TarefaManutencaoForm.aspx?ID=Novo");
        }

        protected void gvTarefas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/TarefaManutencaoForm.aspx?ID=" + gvTarefas.DataKeys[e.NewEditIndex].Values[0].ToString());
        }

    }
}