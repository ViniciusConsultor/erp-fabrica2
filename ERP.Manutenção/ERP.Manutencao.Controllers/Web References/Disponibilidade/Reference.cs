﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace ERP.Manutencao.Controllers.Disponibilidade {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="DisponibilidadeWSSoap", Namespace="http://tempuri.org/")]
    public partial class DisponibilidadeWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback obterListagemDisponibiladeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public DisponibilidadeWS() {
            this.Url = global::ERP.Manutencao.Controllers.Properties.Settings.Default.ERP_Manutencao_Controllers_br_usp_pcs_labsoft_DisponibilidadeWS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event obterListagemDisponibiladeCompletedEventHandler obterListagemDisponibiladeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/obterListagemDisponibilade", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable obterListagemDisponibilade() {
            object[] results = this.Invoke("obterListagemDisponibilade", new object[0]);
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void obterListagemDisponibiladeAsync() {
            this.obterListagemDisponibiladeAsync(null);
        }
        
        /// <remarks/>
        public void obterListagemDisponibiladeAsync(object userState) {
            if ((this.obterListagemDisponibiladeOperationCompleted == null)) {
                this.obterListagemDisponibiladeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnobterListagemDisponibiladeOperationCompleted);
            }
            this.InvokeAsync("obterListagemDisponibilade", new object[0], this.obterListagemDisponibiladeOperationCompleted, userState);
        }
        
        private void OnobterListagemDisponibiladeOperationCompleted(object arg) {
            if ((this.obterListagemDisponibiladeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.obterListagemDisponibiladeCompleted(this, new obterListagemDisponibiladeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void obterListagemDisponibiladeCompletedEventHandler(object sender, obterListagemDisponibiladeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class obterListagemDisponibiladeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal obterListagemDisponibiladeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591