﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using ERP.Logistica.Controllers;

namespace ERP.Logistica
{
    /// <summary>
    /// Summary description for PedidosWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PedidosWS : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable obterRelatorioMedicamentos(DateTime inicio, DateTime fim)
        {
            return PedidosMedicamentosController.listarPorRequisicao(inicio, fim, true);
        }

        [WebMethod]
        public DataTable obterRelatorioEquipamentos(DateTime inicio, DateTime fim)
        {
            return PedidosEquipamentosController.listarPorRequisicao(inicio, fim, true);
        }

        [WebMethod]
        public double obterValorEstornadoMedicamentos(DateTime limite)
        {
            return PedidosMedicamentosController.calcularValorEstornado(limite, false);
        }

        [WebMethod]
        public double obterValorEstornadoEquipamentos(DateTime limite)
        {
            return PedidosEquipamentosController.calcularValorEstornado(limite, false);
        }
    }
}
