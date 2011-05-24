using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Logistica.Controllers;
using ERP.Logistica.Models;

namespace ERP.Logistica.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            if (hfId.Value == "Novo")
            {
                LoginController.criar(tbUserName.Text, tbPassword.Text, tbEmail.Text);
            }
            else
            {
                ERP.Logistica.Models.Login user = LoginController.buscarPorId(Convert.ToInt32(hfId.Value));
                LoginController.atualizar(user.Id, tbUserName.Text, tbPassword.Text, tbEmail.Text);

            }

            Response.Redirect("/Account/Login.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Login.aspx");
        }

    }
}
