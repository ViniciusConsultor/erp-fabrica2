using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Logistica.Controllers;
using ERP.Logistica.Models;

namespace ERP.Logistica
{
    public partial class MedicamentoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    Medicamento medicamento = MedicamentoController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = medicamento.Id.ToString();
                    tbNome.Text = medicamento.Nome.ToString();
                    tbNome.Enabled = true;
                    tbDescricao.Text = medicamento.Descricao.ToString();
                    tbDescricao.Enabled = true;
                    tbMedida.Text = medicamento.Medida.ToString();
                    tbMedida.Enabled = true;
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                MedicamentoController.criar(tbNome.Text, tbDescricao.Text, tbMedida.Text);
            }
            else
            {
                // caso de update
                Medicamento medicamento = MedicamentoController.buscarPorId(Convert.ToInt32(hfId.Value));
                MedicamentoController.atualizar(medicamento.Id, medicamento.Nome, tbDescricao.Text, tbMedida.Text);
            }
            Response.Redirect("/Medicamentos.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Medicamentos.aspx");
        }
    }
}