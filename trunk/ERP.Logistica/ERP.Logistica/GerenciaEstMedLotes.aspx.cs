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
    public partial class GerenciaEstMedLotes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                    Medicamento medicamento = MedicamentoController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = medicamento.Id.ToString();
                    tbMedicamento.Text = medicamento.Nome.ToString();
                    tbMedicamento.Enabled = false;
                    tbMedida.Text = medicamento.Medida.ToString();
                    tbMedida.Enabled = false;
                    tbDescricao.Text = medicamento.Descricao.ToString();
                    tbDescricao.Enabled = false;
                    DataTable dt = EstoqueController.listar_por_Medicamento(medicamento.Id);
                    gvEstoque.DataSource = dt;
                    gvEstoque.DataBind();
            }
        }

        protected void gvEstoque_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/GerenciaLotesQuantidades.aspx?ID=" + gvEstoque.DataKeys[e.NewEditIndex].Values[0].ToString() + "&MEDID=" + hfId.Value.ToString());
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/GerenciaEstMed.aspx");
        }
    }
}