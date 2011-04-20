using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Logistica.Controllers;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica
{
    public partial class EspacosFisicosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                
                ddEspecialidade.DataTextField = "Nome";
                ddEspecialidade.DataValueField = "Id";
                ddEspecialidade.DataSource = EspecialidadeController.listaEspecialidades();
                ddEspecialidade.DataBind();
                ddEspecialidade.Items.Insert(0, "Sem Especialidade");
                ddEspecialidade.Items[0].Value = "0";

                // Pedido Existente
                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    EspacoFisico espaco = EspacosFisicosController.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = espaco.Id.ToString();
                    tbNome.Text = espaco.Nome;
                    tbAndar.Text = espaco.Andar.ToString();
                    tbNumero.Text = espaco.Numero.ToString();
                    ddEspecialidade.SelectedValue = espaco.Especialidade.ToString();
                    
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EspacosFisicos.aspx");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                if (tbAndar.Text != "")
                {
                    if (EspacosFisicosController.criar(tbNome.Text, Convert.ToInt32(tbAndar.Text), Convert.ToInt32(tbNumero.Text), ddEspecialidade.SelectedValue) == -1)
                    {
                        vNomeUnico.IsValid = false;
                        return;
                    }
                }
                else
                {
                    if (EspacosFisicosController.criar(tbNome.Text, 0, Convert.ToInt32(tbNumero.Text), ddEspecialidade.SelectedValue) == -1)
                    {
                        vNomeUnico.IsValid = false;
                        return;
                    }
                }
            }
            else
            {
                EspacoFisico espaco = EspacosFisicosController.buscarPorId(Convert.ToInt32(hfId.Value));
                if (EspacosFisicosController.atualizar(espaco.Id, tbNome.Text, Convert.ToInt32(tbAndar.Text), Convert.ToInt32(tbNumero.Text), ddEspecialidade.SelectedValue) == -1)
                {
                    vNomeUnico.IsValid = false;
                    return;
                }
            }
            Response.Redirect("/EspacosFisicos.aspx");
        }
    }
}