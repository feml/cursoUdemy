﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fml.srRndc {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="srRndc.IBPMServices")]
    public interface IBPMServices {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el espacio de nombres de contenedor (urn:BPMServicesIntf-IBPMServices) del mensaje AtenderMensajeRNDCRequest no coincide con el valor predeterminado (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:BPMServicesIntf-IBPMServices#AtenderMensajeRNDC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        fml.srRndc.AtenderMensajeRNDCResponse AtenderMensajeRNDC(fml.srRndc.AtenderMensajeRNDCRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:BPMServicesIntf-IBPMServices#AtenderMensajeRNDC", ReplyAction="*")]
        System.Threading.Tasks.Task<fml.srRndc.AtenderMensajeRNDCResponse> AtenderMensajeRNDCAsync(fml.srRndc.AtenderMensajeRNDCRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el espacio de nombres de contenedor (urn:BPMServicesIntf-IBPMServices) del mensaje AtenderMensajeBPMRequest no coincide con el valor predeterminado (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:BPMServicesIntf-IBPMServices#AtenderMensajeBPM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        fml.srRndc.AtenderMensajeBPMResponse AtenderMensajeBPM(fml.srRndc.AtenderMensajeBPMRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:BPMServicesIntf-IBPMServices#AtenderMensajeBPM", ReplyAction="*")]
        System.Threading.Tasks.Task<fml.srRndc.AtenderMensajeBPMResponse> AtenderMensajeBPMAsync(fml.srRndc.AtenderMensajeBPMRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AtenderMensajeRNDC", WrapperNamespace="urn:BPMServicesIntf-IBPMServices", IsWrapped=true)]
    public partial class AtenderMensajeRNDCRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string Request;
        
        public AtenderMensajeRNDCRequest() {
        }
        
        public AtenderMensajeRNDCRequest(string Request) {
            this.Request = Request;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AtenderMensajeRNDCResponse", WrapperNamespace="urn:BPMServicesIntf-IBPMServices", IsWrapped=true)]
    public partial class AtenderMensajeRNDCResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string @return;
        
        public AtenderMensajeRNDCResponse() {
        }
        
        public AtenderMensajeRNDCResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AtenderMensajeBPM", WrapperNamespace="urn:BPMServicesIntf-IBPMServices", IsWrapped=true)]
    public partial class AtenderMensajeBPMRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string Request;
        
        public AtenderMensajeBPMRequest() {
        }
        
        public AtenderMensajeBPMRequest(string Request) {
            this.Request = Request;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AtenderMensajeBPMResponse", WrapperNamespace="urn:BPMServicesIntf-IBPMServices", IsWrapped=true)]
    public partial class AtenderMensajeBPMResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string @return;
        
        public AtenderMensajeBPMResponse() {
        }
        
        public AtenderMensajeBPMResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBPMServicesChannel : fml.srRndc.IBPMServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BPMServicesClient : System.ServiceModel.ClientBase<fml.srRndc.IBPMServices>, fml.srRndc.IBPMServices {
        
        public BPMServicesClient() {
        }
        
        public BPMServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BPMServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BPMServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BPMServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        fml.srRndc.AtenderMensajeRNDCResponse fml.srRndc.IBPMServices.AtenderMensajeRNDC(fml.srRndc.AtenderMensajeRNDCRequest request) {
            return base.Channel.AtenderMensajeRNDC(request);
        }
        
        public string AtenderMensajeRNDC(string Request) {
            fml.srRndc.AtenderMensajeRNDCRequest inValue = new fml.srRndc.AtenderMensajeRNDCRequest();
            inValue.Request = Request;
            fml.srRndc.AtenderMensajeRNDCResponse retVal = ((fml.srRndc.IBPMServices)(this)).AtenderMensajeRNDC(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<fml.srRndc.AtenderMensajeRNDCResponse> fml.srRndc.IBPMServices.AtenderMensajeRNDCAsync(fml.srRndc.AtenderMensajeRNDCRequest request) {
            return base.Channel.AtenderMensajeRNDCAsync(request);
        }
        
        public System.Threading.Tasks.Task<fml.srRndc.AtenderMensajeRNDCResponse> AtenderMensajeRNDCAsync(string Request) {
            fml.srRndc.AtenderMensajeRNDCRequest inValue = new fml.srRndc.AtenderMensajeRNDCRequest();
            inValue.Request = Request;
            return ((fml.srRndc.IBPMServices)(this)).AtenderMensajeRNDCAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        fml.srRndc.AtenderMensajeBPMResponse fml.srRndc.IBPMServices.AtenderMensajeBPM(fml.srRndc.AtenderMensajeBPMRequest request) {
            return base.Channel.AtenderMensajeBPM(request);
        }
        
        public string AtenderMensajeBPM(string Request) {
            fml.srRndc.AtenderMensajeBPMRequest inValue = new fml.srRndc.AtenderMensajeBPMRequest();
            inValue.Request = Request;
            fml.srRndc.AtenderMensajeBPMResponse retVal = ((fml.srRndc.IBPMServices)(this)).AtenderMensajeBPM(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<fml.srRndc.AtenderMensajeBPMResponse> fml.srRndc.IBPMServices.AtenderMensajeBPMAsync(fml.srRndc.AtenderMensajeBPMRequest request) {
            return base.Channel.AtenderMensajeBPMAsync(request);
        }
        
        public System.Threading.Tasks.Task<fml.srRndc.AtenderMensajeBPMResponse> AtenderMensajeBPMAsync(string Request) {
            fml.srRndc.AtenderMensajeBPMRequest inValue = new fml.srRndc.AtenderMensajeBPMRequest();
            inValue.Request = Request;
            return ((fml.srRndc.IBPMServices)(this)).AtenderMensajeBPMAsync(inValue);
        }
    }
}
