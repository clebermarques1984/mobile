//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace itgMobile.Droid.intranet.itg.cms_ws {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ConsultasSoap", Namespace="http://tempuri.org/")]
    public partial class Consultas : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ConsultaConsolidadaValoresPagarOperationCompleted;
        
        private System.Threading.SendOrPostCallback RelatorioComissaoPagarDetalhePDFOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConsultaDetalheMovimentoPagoOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConsultaDominiosOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConsultaCNPJporNumSusepOperationCompleted;
        
        private System.Threading.SendOrPostCallback AlertaPagamentosOperationCompleted;
        
        private System.Threading.SendOrPostCallback MarcarAlertaPagamentosOperationCompleted;
        
        private System.Threading.SendOrPostCallback RelatorioDemonstrativoComissaoPagoPDFOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConsultaConsolidadaPagamentoPorDataOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConsultaDemonstrativoPagoOperationCompleted;
        
        /// <remarks/>
        public Consultas() {
            this.Url = "http://200.152.194.6:8888/consultas.asmx";
        }
        
        public Consultas(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        public event ConsultaConsolidadaValoresPagarCompletedEventHandler ConsultaConsolidadaValoresPagarCompleted;
        
        /// <remarks/>
        public event RelatorioComissaoPagarDetalhePDFCompletedEventHandler RelatorioComissaoPagarDetalhePDFCompleted;
        
        /// <remarks/>
        public event ConsultaDetalheMovimentoPagoCompletedEventHandler ConsultaDetalheMovimentoPagoCompleted;
        
        /// <remarks/>
        public event ConsultaDominiosCompletedEventHandler ConsultaDominiosCompleted;
        
        /// <remarks/>
        public event ConsultaCNPJporNumSusepCompletedEventHandler ConsultaCNPJporNumSusepCompleted;
        
        /// <remarks/>
        public event AlertaPagamentosCompletedEventHandler AlertaPagamentosCompleted;
        
        /// <remarks/>
        public event MarcarAlertaPagamentosCompletedEventHandler MarcarAlertaPagamentosCompleted;
        
        /// <remarks/>
        public event RelatorioDemonstrativoComissaoPagoPDFCompletedEventHandler RelatorioDemonstrativoComissaoPagoPDFCompleted;
        
        /// <remarks/>
        public event ConsultaConsolidadaPagamentoPorDataCompletedEventHandler ConsultaConsolidadaPagamentoPorDataCompleted;
        
        /// <remarks/>
        public event ConsultaDemonstrativoPagoCompletedEventHandler ConsultaDemonstrativoPagoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConsultaConsolidadaValoresPagar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConsultaConsolidadaValoresPagar(string Parametros) {
            object[] results = this.Invoke("ConsultaConsolidadaValoresPagar", new object[] {
                        Parametros});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConsultaConsolidadaValoresPagarAsync(string Parametros) {
            this.ConsultaConsolidadaValoresPagarAsync(Parametros, null);
        }
        
        /// <remarks/>
        public void ConsultaConsolidadaValoresPagarAsync(string Parametros, object userState) {
            if ((this.ConsultaConsolidadaValoresPagarOperationCompleted == null)) {
                this.ConsultaConsolidadaValoresPagarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultaConsolidadaValoresPagarOperationCompleted);
            }
            this.InvokeAsync("ConsultaConsolidadaValoresPagar", new object[] {
                        Parametros}, this.ConsultaConsolidadaValoresPagarOperationCompleted, userState);
        }
        
        private void OnConsultaConsolidadaValoresPagarOperationCompleted(object arg) {
            if ((this.ConsultaConsolidadaValoresPagarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultaConsolidadaValoresPagarCompleted(this, new ConsultaConsolidadaValoresPagarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RelatorioComissaoPagarDetalhePDF", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RelatorioComissaoPagarDetalhePDF(string Parametros) {
            object[] results = this.Invoke("RelatorioComissaoPagarDetalhePDF", new object[] {
                        Parametros});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RelatorioComissaoPagarDetalhePDFAsync(string Parametros) {
            this.RelatorioComissaoPagarDetalhePDFAsync(Parametros, null);
        }
        
        /// <remarks/>
        public void RelatorioComissaoPagarDetalhePDFAsync(string Parametros, object userState) {
            if ((this.RelatorioComissaoPagarDetalhePDFOperationCompleted == null)) {
                this.RelatorioComissaoPagarDetalhePDFOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRelatorioComissaoPagarDetalhePDFOperationCompleted);
            }
            this.InvokeAsync("RelatorioComissaoPagarDetalhePDF", new object[] {
                        Parametros}, this.RelatorioComissaoPagarDetalhePDFOperationCompleted, userState);
        }
        
        private void OnRelatorioComissaoPagarDetalhePDFOperationCompleted(object arg) {
            if ((this.RelatorioComissaoPagarDetalhePDFCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RelatorioComissaoPagarDetalhePDFCompleted(this, new RelatorioComissaoPagarDetalhePDFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConsultaDetalheMovimentoPago", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConsultaDetalheMovimentoPago(string Parametros) {
            object[] results = this.Invoke("ConsultaDetalheMovimentoPago", new object[] {
                        Parametros});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConsultaDetalheMovimentoPagoAsync(string Parametros) {
            this.ConsultaDetalheMovimentoPagoAsync(Parametros, null);
        }
        
        /// <remarks/>
        public void ConsultaDetalheMovimentoPagoAsync(string Parametros, object userState) {
            if ((this.ConsultaDetalheMovimentoPagoOperationCompleted == null)) {
                this.ConsultaDetalheMovimentoPagoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultaDetalheMovimentoPagoOperationCompleted);
            }
            this.InvokeAsync("ConsultaDetalheMovimentoPago", new object[] {
                        Parametros}, this.ConsultaDetalheMovimentoPagoOperationCompleted, userState);
        }
        
        private void OnConsultaDetalheMovimentoPagoOperationCompleted(object arg) {
            if ((this.ConsultaDetalheMovimentoPagoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultaDetalheMovimentoPagoCompleted(this, new ConsultaDetalheMovimentoPagoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConsultaDominios", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConsultaDominios() {
            object[] results = this.Invoke("ConsultaDominios", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConsultaDominiosAsync() {
            this.ConsultaDominiosAsync(null);
        }
        
        /// <remarks/>
        public void ConsultaDominiosAsync(object userState) {
            if ((this.ConsultaDominiosOperationCompleted == null)) {
                this.ConsultaDominiosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultaDominiosOperationCompleted);
            }
            this.InvokeAsync("ConsultaDominios", new object[0], this.ConsultaDominiosOperationCompleted, userState);
        }
        
        private void OnConsultaDominiosOperationCompleted(object arg) {
            if ((this.ConsultaDominiosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultaDominiosCompleted(this, new ConsultaDominiosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConsultaCNPJporNumSusep", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConsultaCNPJporNumSusep(string Parametros) {
            object[] results = this.Invoke("ConsultaCNPJporNumSusep", new object[] {
                        Parametros});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConsultaCNPJporNumSusepAsync(string Parametros) {
            this.ConsultaCNPJporNumSusepAsync(Parametros, null);
        }
        
        /// <remarks/>
        public void ConsultaCNPJporNumSusepAsync(string Parametros, object userState) {
            if ((this.ConsultaCNPJporNumSusepOperationCompleted == null)) {
                this.ConsultaCNPJporNumSusepOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultaCNPJporNumSusepOperationCompleted);
            }
            this.InvokeAsync("ConsultaCNPJporNumSusep", new object[] {
                        Parametros}, this.ConsultaCNPJporNumSusepOperationCompleted, userState);
        }
        
        private void OnConsultaCNPJporNumSusepOperationCompleted(object arg) {
            if ((this.ConsultaCNPJporNumSusepCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultaCNPJporNumSusepCompleted(this, new ConsultaCNPJporNumSusepCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AlertaPagamentos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string AlertaPagamentos() {
            object[] results = this.Invoke("AlertaPagamentos", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void AlertaPagamentosAsync() {
            this.AlertaPagamentosAsync(null);
        }
        
        /// <remarks/>
        public void AlertaPagamentosAsync(object userState) {
            if ((this.AlertaPagamentosOperationCompleted == null)) {
                this.AlertaPagamentosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAlertaPagamentosOperationCompleted);
            }
            this.InvokeAsync("AlertaPagamentos", new object[0], this.AlertaPagamentosOperationCompleted, userState);
        }
        
        private void OnAlertaPagamentosOperationCompleted(object arg) {
            if ((this.AlertaPagamentosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AlertaPagamentosCompleted(this, new AlertaPagamentosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/MarcarAlertaPagamentos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string MarcarAlertaPagamentos(string Parametros) {
            object[] results = this.Invoke("MarcarAlertaPagamentos", new object[] {
                        Parametros});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void MarcarAlertaPagamentosAsync(string Parametros) {
            this.MarcarAlertaPagamentosAsync(Parametros, null);
        }
        
        /// <remarks/>
        public void MarcarAlertaPagamentosAsync(string Parametros, object userState) {
            if ((this.MarcarAlertaPagamentosOperationCompleted == null)) {
                this.MarcarAlertaPagamentosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMarcarAlertaPagamentosOperationCompleted);
            }
            this.InvokeAsync("MarcarAlertaPagamentos", new object[] {
                        Parametros}, this.MarcarAlertaPagamentosOperationCompleted, userState);
        }
        
        private void OnMarcarAlertaPagamentosOperationCompleted(object arg) {
            if ((this.MarcarAlertaPagamentosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MarcarAlertaPagamentosCompleted(this, new MarcarAlertaPagamentosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RelatorioDemonstrativoComissaoPagoPDF", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RelatorioDemonstrativoComissaoPagoPDF(string Parametros) {
            object[] results = this.Invoke("RelatorioDemonstrativoComissaoPagoPDF", new object[] {
                        Parametros});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RelatorioDemonstrativoComissaoPagoPDFAsync(string Parametros) {
            this.RelatorioDemonstrativoComissaoPagoPDFAsync(Parametros, null);
        }
        
        /// <remarks/>
        public void RelatorioDemonstrativoComissaoPagoPDFAsync(string Parametros, object userState) {
            if ((this.RelatorioDemonstrativoComissaoPagoPDFOperationCompleted == null)) {
                this.RelatorioDemonstrativoComissaoPagoPDFOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRelatorioDemonstrativoComissaoPagoPDFOperationCompleted);
            }
            this.InvokeAsync("RelatorioDemonstrativoComissaoPagoPDF", new object[] {
                        Parametros}, this.RelatorioDemonstrativoComissaoPagoPDFOperationCompleted, userState);
        }
        
        private void OnRelatorioDemonstrativoComissaoPagoPDFOperationCompleted(object arg) {
            if ((this.RelatorioDemonstrativoComissaoPagoPDFCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RelatorioDemonstrativoComissaoPagoPDFCompleted(this, new RelatorioDemonstrativoComissaoPagoPDFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConsultaConsolidadaPagamentoPorData", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConsultaConsolidadaPagamentoPorData(string Parametros) {
            object[] results = this.Invoke("ConsultaConsolidadaPagamentoPorData", new object[] {
                        Parametros});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConsultaConsolidadaPagamentoPorDataAsync(string Parametros) {
            this.ConsultaConsolidadaPagamentoPorDataAsync(Parametros, null);
        }
        
        /// <remarks/>
        public void ConsultaConsolidadaPagamentoPorDataAsync(string Parametros, object userState) {
            if ((this.ConsultaConsolidadaPagamentoPorDataOperationCompleted == null)) {
                this.ConsultaConsolidadaPagamentoPorDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultaConsolidadaPagamentoPorDataOperationCompleted);
            }
            this.InvokeAsync("ConsultaConsolidadaPagamentoPorData", new object[] {
                        Parametros}, this.ConsultaConsolidadaPagamentoPorDataOperationCompleted, userState);
        }
        
        private void OnConsultaConsolidadaPagamentoPorDataOperationCompleted(object arg) {
            if ((this.ConsultaConsolidadaPagamentoPorDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultaConsolidadaPagamentoPorDataCompleted(this, new ConsultaConsolidadaPagamentoPorDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConsultaDemonstrativoPago", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConsultaDemonstrativoPago(string Parametros) {
            object[] results = this.Invoke("ConsultaDemonstrativoPago", new object[] {
                        Parametros});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConsultaDemonstrativoPagoAsync(string Parametros) {
            this.ConsultaDemonstrativoPagoAsync(Parametros, null);
        }
        
        /// <remarks/>
        public void ConsultaDemonstrativoPagoAsync(string Parametros, object userState) {
            if ((this.ConsultaDemonstrativoPagoOperationCompleted == null)) {
                this.ConsultaDemonstrativoPagoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultaDemonstrativoPagoOperationCompleted);
            }
            this.InvokeAsync("ConsultaDemonstrativoPago", new object[] {
                        Parametros}, this.ConsultaDemonstrativoPagoOperationCompleted, userState);
        }
        
        private void OnConsultaDemonstrativoPagoOperationCompleted(object arg) {
            if ((this.ConsultaDemonstrativoPagoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultaDemonstrativoPagoCompleted(this, new ConsultaDemonstrativoPagoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void ConsultaConsolidadaValoresPagarCompletedEventHandler(object sender, ConsultaConsolidadaValoresPagarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultaConsolidadaValoresPagarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultaConsolidadaValoresPagarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RelatorioComissaoPagarDetalhePDFCompletedEventHandler(object sender, RelatorioComissaoPagarDetalhePDFCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RelatorioComissaoPagarDetalhePDFCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RelatorioComissaoPagarDetalhePDFCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void ConsultaDetalheMovimentoPagoCompletedEventHandler(object sender, ConsultaDetalheMovimentoPagoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultaDetalheMovimentoPagoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultaDetalheMovimentoPagoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void ConsultaDominiosCompletedEventHandler(object sender, ConsultaDominiosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultaDominiosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultaDominiosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void ConsultaCNPJporNumSusepCompletedEventHandler(object sender, ConsultaCNPJporNumSusepCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultaCNPJporNumSusepCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultaCNPJporNumSusepCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void AlertaPagamentosCompletedEventHandler(object sender, AlertaPagamentosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AlertaPagamentosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AlertaPagamentosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void MarcarAlertaPagamentosCompletedEventHandler(object sender, MarcarAlertaPagamentosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MarcarAlertaPagamentosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MarcarAlertaPagamentosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RelatorioDemonstrativoComissaoPagoPDFCompletedEventHandler(object sender, RelatorioDemonstrativoComissaoPagoPDFCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RelatorioDemonstrativoComissaoPagoPDFCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RelatorioDemonstrativoComissaoPagoPDFCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void ConsultaConsolidadaPagamentoPorDataCompletedEventHandler(object sender, ConsultaConsolidadaPagamentoPorDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultaConsolidadaPagamentoPorDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultaConsolidadaPagamentoPorDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void ConsultaDemonstrativoPagoCompletedEventHandler(object sender, ConsultaDemonstrativoPagoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultaDemonstrativoPagoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultaDemonstrativoPagoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}
