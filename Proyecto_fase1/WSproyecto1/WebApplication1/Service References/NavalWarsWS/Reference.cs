﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.NavalWarsWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Persona", Namespace="http://schemas.datacontract.org/2004/07/WSproyecto1.Objetos")]
    [System.SerializableAttribute()]
    public partial class Persona : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool conectadoField;
        
        private string mailField;
        
        private WebApplication1.NavalWarsWS.ListaDOfJuego209EgP0h mis_partidasField;
        
        private string passwordField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool conectado {
            get {
                return this.conectadoField;
            }
            set {
                if ((this.conectadoField.Equals(value) != true)) {
                    this.conectadoField = value;
                    this.RaisePropertyChanged("conectado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string mail {
            get {
                return this.mailField;
            }
            set {
                if ((object.ReferenceEquals(this.mailField, value) != true)) {
                    this.mailField = value;
                    this.RaisePropertyChanged("mail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public WebApplication1.NavalWarsWS.ListaDOfJuego209EgP0h mis_partidas {
            get {
                return this.mis_partidasField;
            }
            set {
                if ((object.ReferenceEquals(this.mis_partidasField, value) != true)) {
                    this.mis_partidasField = value;
                    this.RaisePropertyChanged("mis_partidas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ListaDOfJuego209EgP0h", Namespace="http://schemas.datacontract.org/2004/07/WSproyecto1.Arbol")]
    [System.SerializableAttribute()]
    public partial class ListaDOfJuego209EgP0h : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int countField;
        
        private WebApplication1.NavalWarsWS.NodeOfJuego209EgP0h finField;
        
        private WebApplication1.NavalWarsWS.NodeOfJuego209EgP0h raizField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int count {
            get {
                return this.countField;
            }
            set {
                if ((this.countField.Equals(value) != true)) {
                    this.countField = value;
                    this.RaisePropertyChanged("count");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public WebApplication1.NavalWarsWS.NodeOfJuego209EgP0h fin {
            get {
                return this.finField;
            }
            set {
                if ((object.ReferenceEquals(this.finField, value) != true)) {
                    this.finField = value;
                    this.RaisePropertyChanged("fin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public WebApplication1.NavalWarsWS.NodeOfJuego209EgP0h raiz {
            get {
                return this.raizField;
            }
            set {
                if ((object.ReferenceEquals(this.raizField, value) != true)) {
                    this.raizField = value;
                    this.RaisePropertyChanged("raiz");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NodeOfJuego209EgP0h", Namespace="http://schemas.datacontract.org/2004/07/WSproyecto1.Nodos")]
    [System.SerializableAttribute()]
    public partial class NodeOfJuego209EgP0h : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private WebApplication1.NavalWarsWS.NodeOfJuego209EgP0h anteriorField;
        
        private WebApplication1.NavalWarsWS.Juego itemField;
        
        private WebApplication1.NavalWarsWS.NodeOfJuego209EgP0h siguienteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public WebApplication1.NavalWarsWS.NodeOfJuego209EgP0h anterior {
            get {
                return this.anteriorField;
            }
            set {
                if ((object.ReferenceEquals(this.anteriorField, value) != true)) {
                    this.anteriorField = value;
                    this.RaisePropertyChanged("anterior");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public WebApplication1.NavalWarsWS.Juego item {
            get {
                return this.itemField;
            }
            set {
                if ((object.ReferenceEquals(this.itemField, value) != true)) {
                    this.itemField = value;
                    this.RaisePropertyChanged("item");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public WebApplication1.NavalWarsWS.NodeOfJuego209EgP0h siguiente {
            get {
                return this.siguienteField;
            }
            set {
                if ((object.ReferenceEquals(this.siguienteField, value) != true)) {
                    this.siguienteField = value;
                    this.RaisePropertyChanged("siguiente");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Juego", Namespace="http://schemas.datacontract.org/2004/07/WSproyecto1.Objetos")]
    [System.SerializableAttribute()]
    public partial class Juego : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int destruidosField;
        
        private bool ganoField;
        
        private string oponenteField;
        
        private int sobrevivientesField;
        
        private int unidades_desplegadasField;
        
        private string usuarioField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int destruidos {
            get {
                return this.destruidosField;
            }
            set {
                if ((this.destruidosField.Equals(value) != true)) {
                    this.destruidosField = value;
                    this.RaisePropertyChanged("destruidos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool gano {
            get {
                return this.ganoField;
            }
            set {
                if ((this.ganoField.Equals(value) != true)) {
                    this.ganoField = value;
                    this.RaisePropertyChanged("gano");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string oponente {
            get {
                return this.oponenteField;
            }
            set {
                if ((object.ReferenceEquals(this.oponenteField, value) != true)) {
                    this.oponenteField = value;
                    this.RaisePropertyChanged("oponente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int sobrevivientes {
            get {
                return this.sobrevivientesField;
            }
            set {
                if ((this.sobrevivientesField.Equals(value) != true)) {
                    this.sobrevivientesField = value;
                    this.RaisePropertyChanged("sobrevivientes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int unidades_desplegadas {
            get {
                return this.unidades_desplegadasField;
            }
            set {
                if ((this.unidades_desplegadasField.Equals(value) != true)) {
                    this.unidades_desplegadasField = value;
                    this.RaisePropertyChanged("unidades_desplegadas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string usuario {
            get {
                return this.usuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.usuarioField, value) != true)) {
                    this.usuarioField = value;
                    this.RaisePropertyChanged("usuario");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Nodo", Namespace="http://schemas.datacontract.org/2004/07/WSproyecto1.Nodos")]
    [System.SerializableAttribute()]
    public partial class Nodo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private WebApplication1.NavalWarsWS.Nodo derField;
        
        private WebApplication1.NavalWarsWS.Persona itemField;
        
        private WebApplication1.NavalWarsWS.Nodo izqField;
        
        private string keyField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public WebApplication1.NavalWarsWS.Nodo der {
            get {
                return this.derField;
            }
            set {
                if ((object.ReferenceEquals(this.derField, value) != true)) {
                    this.derField = value;
                    this.RaisePropertyChanged("der");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public WebApplication1.NavalWarsWS.Persona item {
            get {
                return this.itemField;
            }
            set {
                if ((object.ReferenceEquals(this.itemField, value) != true)) {
                    this.itemField = value;
                    this.RaisePropertyChanged("item");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public WebApplication1.NavalWarsWS.Nodo izq {
            get {
                return this.izqField;
            }
            set {
                if ((object.ReferenceEquals(this.izqField, value) != true)) {
                    this.izqField = value;
                    this.RaisePropertyChanged("izq");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string key {
            get {
                return this.keyField;
            }
            set {
                if ((object.ReferenceEquals(this.keyField, value) != true)) {
                    this.keyField = value;
                    this.RaisePropertyChanged("key");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NavalWarsWS.INavalWarsService")]
    public interface INavalWarsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/newPersona", ReplyAction="http://tempuri.org/INavalWarsService/newPersonaResponse")]
        WebApplication1.NavalWarsWS.Persona newPersona(string password, string mail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/newPersona", ReplyAction="http://tempuri.org/INavalWarsService/newPersonaResponse")]
        System.Threading.Tasks.Task<WebApplication1.NavalWarsWS.Persona> newPersonaAsync(string password, string mail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/insertar", ReplyAction="http://tempuri.org/INavalWarsService/insertarResponse")]
        bool insertar(string nick, WebApplication1.NavalWarsWS.Persona persona);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/insertar", ReplyAction="http://tempuri.org/INavalWarsService/insertarResponse")]
        System.Threading.Tasks.Task<bool> insertarAsync(string nick, WebApplication1.NavalWarsWS.Persona persona);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/buscar", ReplyAction="http://tempuri.org/INavalWarsService/buscarResponse")]
        WebApplication1.NavalWarsWS.Nodo buscar(string nick);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/buscar", ReplyAction="http://tempuri.org/INavalWarsService/buscarResponse")]
        System.Threading.Tasks.Task<WebApplication1.NavalWarsWS.Nodo> buscarAsync(string nick);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/eliminar", ReplyAction="http://tempuri.org/INavalWarsService/eliminarResponse")]
        bool eliminar(string nick);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/eliminar", ReplyAction="http://tempuri.org/INavalWarsService/eliminarResponse")]
        System.Threading.Tasks.Task<bool> eliminarAsync(string nick);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/modificar", ReplyAction="http://tempuri.org/INavalWarsService/modificarResponse")]
        bool modificar(string nick, WebApplication1.NavalWarsWS.Persona persona);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/modificar", ReplyAction="http://tempuri.org/INavalWarsService/modificarResponse")]
        System.Threading.Tasks.Task<bool> modificarAsync(string nick, WebApplication1.NavalWarsWS.Persona persona);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/newJuego", ReplyAction="http://tempuri.org/INavalWarsService/newJuegoResponse")]
        WebApplication1.NavalWarsWS.Juego newJuego(string usuario, string oponente, int unidades_desplegadas, int sobrevivientes, int destruidos, int gano);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/newJuego", ReplyAction="http://tempuri.org/INavalWarsService/newJuegoResponse")]
        System.Threading.Tasks.Task<WebApplication1.NavalWarsWS.Juego> newJuegoAsync(string usuario, string oponente, int unidades_desplegadas, int sobrevivientes, int destruidos, int gano);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/agregarJuego", ReplyAction="http://tempuri.org/INavalWarsService/agregarJuegoResponse")]
        bool agregarJuego(WebApplication1.NavalWarsWS.Juego nuevo, string usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/agregarJuego", ReplyAction="http://tempuri.org/INavalWarsService/agregarJuegoResponse")]
        System.Threading.Tasks.Task<bool> agregarJuegoAsync(WebApplication1.NavalWarsWS.Juego nuevo, string usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/graficarArbolBinario", ReplyAction="http://tempuri.org/INavalWarsService/graficarArbolBinarioResponse")]
        bool graficarArbolBinario(string ruta_destino);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/graficarArbolBinario", ReplyAction="http://tempuri.org/INavalWarsService/graficarArbolBinarioResponse")]
        System.Threading.Tasks.Task<bool> graficarArbolBinarioAsync(string ruta_destino);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/debug", ReplyAction="http://tempuri.org/INavalWarsService/debugResponse")]
        string debug();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/debug", ReplyAction="http://tempuri.org/INavalWarsService/debugResponse")]
        System.Threading.Tasks.Task<string> debugAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/cargaUsuarios", ReplyAction="http://tempuri.org/INavalWarsService/cargaUsuariosResponse")]
        bool cargaUsuarios(string direccion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/cargaUsuarios", ReplyAction="http://tempuri.org/INavalWarsService/cargaUsuariosResponse")]
        System.Threading.Tasks.Task<bool> cargaUsuariosAsync(string direccion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/cargaJuegos", ReplyAction="http://tempuri.org/INavalWarsService/cargaJuegosResponse")]
        bool cargaJuegos(string direccion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INavalWarsService/cargaJuegos", ReplyAction="http://tempuri.org/INavalWarsService/cargaJuegosResponse")]
        System.Threading.Tasks.Task<bool> cargaJuegosAsync(string direccion);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INavalWarsServiceChannel : WebApplication1.NavalWarsWS.INavalWarsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NavalWarsServiceClient : System.ServiceModel.ClientBase<WebApplication1.NavalWarsWS.INavalWarsService>, WebApplication1.NavalWarsWS.INavalWarsService {
        
        public NavalWarsServiceClient() {
        }
        
        public NavalWarsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NavalWarsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NavalWarsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NavalWarsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebApplication1.NavalWarsWS.Persona newPersona(string password, string mail) {
            return base.Channel.newPersona(password, mail);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.NavalWarsWS.Persona> newPersonaAsync(string password, string mail) {
            return base.Channel.newPersonaAsync(password, mail);
        }
        
        public bool insertar(string nick, WebApplication1.NavalWarsWS.Persona persona) {
            return base.Channel.insertar(nick, persona);
        }
        
        public System.Threading.Tasks.Task<bool> insertarAsync(string nick, WebApplication1.NavalWarsWS.Persona persona) {
            return base.Channel.insertarAsync(nick, persona);
        }
        
        public WebApplication1.NavalWarsWS.Nodo buscar(string nick) {
            return base.Channel.buscar(nick);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.NavalWarsWS.Nodo> buscarAsync(string nick) {
            return base.Channel.buscarAsync(nick);
        }
        
        public bool eliminar(string nick) {
            return base.Channel.eliminar(nick);
        }
        
        public System.Threading.Tasks.Task<bool> eliminarAsync(string nick) {
            return base.Channel.eliminarAsync(nick);
        }
        
        public bool modificar(string nick, WebApplication1.NavalWarsWS.Persona persona) {
            return base.Channel.modificar(nick, persona);
        }
        
        public System.Threading.Tasks.Task<bool> modificarAsync(string nick, WebApplication1.NavalWarsWS.Persona persona) {
            return base.Channel.modificarAsync(nick, persona);
        }
        
        public WebApplication1.NavalWarsWS.Juego newJuego(string usuario, string oponente, int unidades_desplegadas, int sobrevivientes, int destruidos, int gano) {
            return base.Channel.newJuego(usuario, oponente, unidades_desplegadas, sobrevivientes, destruidos, gano);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.NavalWarsWS.Juego> newJuegoAsync(string usuario, string oponente, int unidades_desplegadas, int sobrevivientes, int destruidos, int gano) {
            return base.Channel.newJuegoAsync(usuario, oponente, unidades_desplegadas, sobrevivientes, destruidos, gano);
        }
        
        public bool agregarJuego(WebApplication1.NavalWarsWS.Juego nuevo, string usuario) {
            return base.Channel.agregarJuego(nuevo, usuario);
        }
        
        public System.Threading.Tasks.Task<bool> agregarJuegoAsync(WebApplication1.NavalWarsWS.Juego nuevo, string usuario) {
            return base.Channel.agregarJuegoAsync(nuevo, usuario);
        }
        
        public bool graficarArbolBinario(string ruta_destino) {
            return base.Channel.graficarArbolBinario(ruta_destino);
        }
        
        public System.Threading.Tasks.Task<bool> graficarArbolBinarioAsync(string ruta_destino) {
            return base.Channel.graficarArbolBinarioAsync(ruta_destino);
        }
        
        public string debug() {
            return base.Channel.debug();
        }
        
        public System.Threading.Tasks.Task<string> debugAsync() {
            return base.Channel.debugAsync();
        }
        
        public bool cargaUsuarios(string direccion) {
            return base.Channel.cargaUsuarios(direccion);
        }
        
        public System.Threading.Tasks.Task<bool> cargaUsuariosAsync(string direccion) {
            return base.Channel.cargaUsuariosAsync(direccion);
        }
        
        public bool cargaJuegos(string direccion) {
            return base.Channel.cargaJuegos(direccion);
        }
        
        public System.Threading.Tasks.Task<bool> cargaJuegosAsync(string direccion) {
            return base.Channel.cargaJuegosAsync(direccion);
        }
    }
}
