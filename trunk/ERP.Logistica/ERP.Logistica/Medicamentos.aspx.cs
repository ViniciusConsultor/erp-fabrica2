﻿using System;
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
    public partial class Medicamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizar();
        }

        private void atualizar()
        {
            DataTable dt = MedicamentoController.listar();
            gvMedicamento.DataSource = dt;
            gvMedicamento.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MedicamentosForm.aspx?ID=Novo");
        }

        protected void gvMedicamento_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/MedicamentosForm.aspx?ID=" + gvMedicamento.DataKeys[e.NewEditIndex].Values[0].ToString());
        }

        protected void gvMedicamento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MedicamentoController.apagar(Convert.ToInt32(gvMedicamento.DataKeys[e.RowIndex].Values[0].ToString()));
            atualizar();
        }

    }
}