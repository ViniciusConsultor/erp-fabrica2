using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Manutencao.Controllers;
using ERP.Manutencao.Models;

namespace ERP.Manutenção
{
    public partial class TarefaManutencaoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                ddEstado.Items.Insert(0, "Aberto");
                ddEstado.Items.Insert(1, "Em Execução");
                ddEstado.Items.Insert(2, "Concluído");
                ddEstado.Items.Insert(3, "Periódico");              
                ddEstado.DataBind();

                if (Request.QueryString["ID"] != "Novo" && Request.QueryString["ID"] != null)
                {
                    Manutencao.Models.TarefaManutencao tarefa = Manutencao.Models.TarefaManutencao.buscarPorId(Convert.ToInt32(Request.QueryString["ID"]));
                    hfId.Value = tarefa.Id.ToString();
                    ddEstado.SelectedValue = tarefa.Estado;
                    tbDescricao.Text = tarefa.Descricao;
                    tbLocal.Text = tarefa.Local;
                    tbEquipamento.Text = tarefa.Equipamento;
                    tbDataIni.Text = tarefa.InicioManutencao.ToString().Substring(0, 10);
                    tbHoraIni.Text = tarefa.InicioManutencao.ToString().Substring(11, 5);
                    tbDataFim.Text = tarefa.FimManutencao.ToString().Substring(0, 10);
                    tbHoraFim.Text = tarefa.FimManutencao.ToString().Substring(11, 5);
                    
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            if (hfId.Value == "Novo")
            {
                TarefaManutencaoController.criar(tbDescricao.Text, tbLocal.Text, tbEquipamento.Text, ddEstado.SelectedValue, Convert.ToDateTime(tbDataIni.Text + " " + tbHoraIni.Text + ":00"), Convert.ToDateTime(tbDataFim.Text + " " + tbHoraFim.Text + ":00")/*clInicioManutencao.SelectedDate, clFimManutencao.SelectedDate*/);
            }
            else
            {
                Manutencao.Models.TarefaManutencao tarefa = TarefaManutencaoController.buscarPorId(Convert.ToInt32(hfId.Value));
                TarefaManutencaoController.atualizar(tarefa.Id, tbDescricao.Text, tbLocal.Text, tbEquipamento.Text, ddEstado.SelectedValue, Convert.ToDateTime(tbDataIni.Text + " " + tbHoraIni.Text + ":00"), Convert.ToDateTime(tbDataFim.Text + " " + tbHoraFim.Text + ":00")/*clInicioManutencao.SelectedDate, clFimManutencao.SelectedDate*/);

            }
            Response.Redirect("/TarefaManutencao.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/TarefaManutencao.aspx");
        }

    }
}