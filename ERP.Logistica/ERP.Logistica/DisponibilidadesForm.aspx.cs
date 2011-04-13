using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Logistica.Models;
using ERP.Logistica.Controllers;

namespace ERP.Logistica
{
    public partial class DisponibilidadesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                ddlEspaco.DataSource = EspacosFisicosController.listarEspacosFisicosDisponiveis();
                ddlEspaco.DataTextField = "EspacoFisico";
                ddlEspaco.DataValueField = "Id";
                ddlEspaco.DataBind();
                ddlEquip.DataSource = DisponibilidadesController.listarEquipamentosDisponiveis();
                ddlEquip.DataTextField = "Equipamento";
                ddlEquip.DataValueField = "Id";
                ddlEquip.DataBind();

                // Pedido Existente
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    Disponibilidade disp = DisponibilidadesController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = disp.Id.ToString();
                    if (disp.EspacoFisico != null)
                    {
                        ddlEspaco.SelectedValue = disp.EspacoFisico.Id.ToString();
                    }
                    else
                    {
                        ddlEspaco.SelectedValue = "0";
                    }
                    ddlEquip.SelectedValue = disp.Equipamento.Id.ToString();
                    ddlEquip.Enabled = false;
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                DisponibilidadesController.criar(Convert.ToInt32(ddlEquip.SelectedValue), Convert.ToInt32(ddlEspaco.SelectedValue));
            }
            else
            {
                Disponibilidade disp = DisponibilidadesController.buscarPorId(Convert.ToInt32(hfId.Value));
                DisponibilidadesController.atualizar(disp.Id, Convert.ToInt32(ddlEquip.SelectedValue), Convert.ToInt32(ddlEspaco.SelectedValue));
            }
            Response.Redirect("/Disponibilidades.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Disponibilidades.aspx");
        }
    }
}