using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Logistica.Controllers;

namespace ERP.Logistica
{
    public partial class HistoricosEstoques : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
            {
                if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
                {
                    gvHist.DataSource = HistoricoEstoqueController.listar(Convert.ToInt32(Request.QueryString["ID"]));
                    gvHist.DataBind();
                }
            }
        }
    }
}