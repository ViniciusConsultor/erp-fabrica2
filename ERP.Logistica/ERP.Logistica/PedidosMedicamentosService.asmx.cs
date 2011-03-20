using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using ERP.Logistica.Models;

namespace ERP.Logistica
{
    /// <summary>
    /// Summary description for PedidosMedicamentosService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PedidosMedicamentosService : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable listarPedidos(int mes, int ano)
        {
            return PedidoMedicamento.listarPorRequisicao(ano, mes);
        }
    }
}
