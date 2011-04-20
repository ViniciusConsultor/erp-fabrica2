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
    public partial class EquipamentosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    ERP.Logistica.Models.Equipamento equipamento = EquipamentoController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = equipamento.Id.ToString();
                    tbNome.Text = equipamento.Nome.ToString();
                    tbNome.Enabled = true;
                    tbDescricao.Text = equipamento.Descricao.ToString();
                    tbDescricao.Enabled = true;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Equipamentos.aspx");
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                EquipamentoController.criar(tbNome.Text, tbDescricao.Text);
            }
            else
            {
                // caso de update
                ERP.Logistica.Models.Equipamento equipamento = EquipamentoController.buscarPorId(Convert.ToInt32(hfId.Value));
                EquipamentoController.atualizar(equipamento.Id, equipamento.Nome, tbDescricao.Text);
            }
            Response.Redirect("/Equipamentos.aspx");
        }
    }
}