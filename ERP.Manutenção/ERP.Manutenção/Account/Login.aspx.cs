using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ERP.Manutencao.Controllers;
using ERP.Manutencao.Models;

namespace ERP.Manutenção.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
   
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if(ERP.Manutencao.Models.Login.validUser(tbUserName.Text, tbPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(tbUserName.Text, false);
            }
        }

    }
}
