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
    public partial class PedidosEquipamentosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                ddlEquipForn.DataSource = PedidosEquipamentosController.listarCatalogoEquipDisponiveis();
                ddlEquipForn.DataTextField = "Catalogo_Equipamento";
                ddlEquipForn.DataValueField = "Id";
                ddlEquipForn.DataBind();
                ddlAloc.DataSource = EspacosFisicosController.listarEspacosFisicosDisponiveis();
                ddlAloc.DataTextField = "EspacoFisico";
                ddlAloc.DataValueField = "Id";
                ddlAloc.DataBind();
                rblEfetuado.Visible = false;
                lbEstado.Visible = false;

                // Pedido Existente
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    PedidoEquipamento pedido = PedidosEquipamentosController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = pedido.Id.ToString();
                    ddlEquipForn.SelectedValue = pedido.CatalogoEquip.ToString();
                    ddlEquipForn.Enabled = false;
                    if (pedido.Disponibilidade != null && pedido.Disponibilidade.EspacoFisico != null)
                    {
                        ddlAloc.SelectedValue = pedido.Disponibilidade.EspacoFisico.Id.ToString();
                    }
                    if (pedido.Efetuado == 1) // Se o pedido foi efetuado, não permite definição de uma alocação
                    {
                        ddlAloc.Enabled = false;
                    }
                    if (pedido.editavel())
                    {
                        rblEfetuado.SelectedValue = "2";
                        rblEfetuado.Visible = true;
                        lbEstado.Visible = true;
                    }
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                if (ddlAloc.SelectedValue == null || ddlAloc.SelectedValue == "")
                {
                    PedidosEquipamentosController.criar(DateTime.Now, Convert.ToInt32(ddlEquipForn.SelectedValue), Convert.ToInt32(rblEfetuado.SelectedValue), 0);
                }
                else
                {
                    PedidosEquipamentosController.criar(DateTime.Now, Convert.ToInt32(ddlEquipForn.SelectedValue), Convert.ToInt32(rblEfetuado.SelectedValue), Convert.ToInt32(ddlAloc.SelectedValue));
                }
            }
            else
            {
                PedidoEquipamento pedido = PedidosEquipamentosController.buscarPorId(Convert.ToInt32(hfId.Value));
                if (pedido.Efetuado != Convert.ToInt32(rblEfetuado.SelectedValue))
                {
                    PedidosEquipamentosController.atualizar(pedido.Id, DateTime.Now, pedido.CatalogoEquip, Convert.ToInt32(rblEfetuado.SelectedValue), Convert.ToInt32(ddlAloc.SelectedValue));
                }
            }
            Response.Redirect("/PedidosEquipamentos.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PedidosEquipamentos.aspx");
        }
    }
}