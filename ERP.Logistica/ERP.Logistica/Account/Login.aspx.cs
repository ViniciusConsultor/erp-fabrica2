using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ERP.Logistica.Controllers;
using ERP.Logistica.Models;

namespace ERP.Logistica.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (ERP.Logistica.Models.Login.validUser(tbUserName.Text, tbPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(tbUserName.Text, false);
            }
        }

    }
}
