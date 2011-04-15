﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using ERP.Manutencao.Controllers;
using ERP.Manutencao.Models;
using System.Data.SqlClient;


namespace ERP.Manutenção
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private static string connectionSettings = "Data Source=ls01;Initial Catalog=erp_manutencao;Integrated Security=True";

        [WebMethod]
        public DataTable obterDatasManutencao()
        {
            return TarefaManutencaoController.WebListar(); 
        }
    }
}
