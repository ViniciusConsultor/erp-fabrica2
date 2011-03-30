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
    public partial class GerenciaLotesQuantidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                ERP.Logistica.Models.Estoque estoque = EstoqueController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                Medicamento medicamento = MedicamentoController.buscarPorId(Convert.ToInt32(Request.QueryString["MEDID"]));
                hfIdMed.Value = medicamento.Id.ToString();
                hfIdEst.Value = estoque.Id.ToString();
                tbMedicamento.Text = medicamento.Nome.ToString();
                tbMedicamento.Enabled = false;
                tbQuantidade.Text = estoque.Quantidade.ToString();
                tbQuantidade.Enabled = false;
                tbValidade.Text = estoque.Validade.ToString();
                tbValidade.Enabled = false;
                tbLocalizacao.Text = estoque.Localizacao.ToString();
                tbLocalizacao.Enabled = false;
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {

            EstoqueController.alterar_quantidade(Convert.ToInt32(hfIdEst.Value), Convert.ToInt32(tbAdicao.Text));
            Response.Redirect("/GerenciaEstMedLotes.aspx?ID=" + hfIdMed.Value);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/GerenciaEstMedLotes.aspx?ID=" + hfIdMed.Value);
        }
    }
}