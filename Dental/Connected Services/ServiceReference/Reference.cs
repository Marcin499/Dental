﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dental.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Pacjent", Namespace="http://schemas.datacontract.org/2004/07/DAL.Model")]
    [System.SerializableAttribute()]
    public partial class Pacjent : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HasloField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImieField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NazwiskoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PESELField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Dental.ServiceReference.Adres PacjentAdresField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PacjentIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PowtorzHasloField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TelefonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Haslo {
            get {
                return this.HasloField;
            }
            set {
                if ((object.ReferenceEquals(this.HasloField, value) != true)) {
                    this.HasloField = value;
                    this.RaisePropertyChanged("Haslo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Imie {
            get {
                return this.ImieField;
            }
            set {
                if ((object.ReferenceEquals(this.ImieField, value) != true)) {
                    this.ImieField = value;
                    this.RaisePropertyChanged("Imie");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nazwisko {
            get {
                return this.NazwiskoField;
            }
            set {
                if ((object.ReferenceEquals(this.NazwiskoField, value) != true)) {
                    this.NazwiskoField = value;
                    this.RaisePropertyChanged("Nazwisko");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PESEL {
            get {
                return this.PESELField;
            }
            set {
                if ((object.ReferenceEquals(this.PESELField, value) != true)) {
                    this.PESELField = value;
                    this.RaisePropertyChanged("PESEL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Dental.ServiceReference.Adres PacjentAdres {
            get {
                return this.PacjentAdresField;
            }
            set {
                if ((object.ReferenceEquals(this.PacjentAdresField, value) != true)) {
                    this.PacjentAdresField = value;
                    this.RaisePropertyChanged("PacjentAdres");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PacjentID {
            get {
                return this.PacjentIDField;
            }
            set {
                if ((this.PacjentIDField.Equals(value) != true)) {
                    this.PacjentIDField = value;
                    this.RaisePropertyChanged("PacjentID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PowtorzHaslo {
            get {
                return this.PowtorzHasloField;
            }
            set {
                if ((object.ReferenceEquals(this.PowtorzHasloField, value) != true)) {
                    this.PowtorzHasloField = value;
                    this.RaisePropertyChanged("PowtorzHaslo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Telefon {
            get {
                return this.TelefonField;
            }
            set {
                if ((this.TelefonField.Equals(value) != true)) {
                    this.TelefonField = value;
                    this.RaisePropertyChanged("Telefon");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Typ {
            get {
                return this.TypField;
            }
            set {
                if ((object.ReferenceEquals(this.TypField, value) != true)) {
                    this.TypField = value;
                    this.RaisePropertyChanged("Typ");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Adres", Namespace="http://schemas.datacontract.org/2004/07/DAL.Model")]
    [System.SerializableAttribute()]
    public partial class Adres : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AdresIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Dental.ServiceReference.Pacjent AdresPacjentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MiastoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PacjentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UlicaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WojewodztwoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AdresID {
            get {
                return this.AdresIDField;
            }
            set {
                if ((this.AdresIDField.Equals(value) != true)) {
                    this.AdresIDField = value;
                    this.RaisePropertyChanged("AdresID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Dental.ServiceReference.Pacjent AdresPacjent {
            get {
                return this.AdresPacjentField;
            }
            set {
                if ((object.ReferenceEquals(this.AdresPacjentField, value) != true)) {
                    this.AdresPacjentField = value;
                    this.RaisePropertyChanged("AdresPacjent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Kod {
            get {
                return this.KodField;
            }
            set {
                if ((object.ReferenceEquals(this.KodField, value) != true)) {
                    this.KodField = value;
                    this.RaisePropertyChanged("Kod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Miasto {
            get {
                return this.MiastoField;
            }
            set {
                if ((object.ReferenceEquals(this.MiastoField, value) != true)) {
                    this.MiastoField = value;
                    this.RaisePropertyChanged("Miasto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Numer {
            get {
                return this.NumerField;
            }
            set {
                if ((object.ReferenceEquals(this.NumerField, value) != true)) {
                    this.NumerField = value;
                    this.RaisePropertyChanged("Numer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PacjentId {
            get {
                return this.PacjentIdField;
            }
            set {
                if ((this.PacjentIdField.Equals(value) != true)) {
                    this.PacjentIdField = value;
                    this.RaisePropertyChanged("PacjentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ulica {
            get {
                return this.UlicaField;
            }
            set {
                if ((object.ReferenceEquals(this.UlicaField, value) != true)) {
                    this.UlicaField = value;
                    this.RaisePropertyChanged("Ulica");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Wojewodztwo {
            get {
                return this.WojewodztwoField;
            }
            set {
                if ((object.ReferenceEquals(this.WojewodztwoField, value) != true)) {
                    this.WojewodztwoField = value;
                    this.RaisePropertyChanged("Wojewodztwo");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPacjentList", ReplyAction="http://tempuri.org/IService/GetPacjentListResponse")]
        Dental.ServiceReference.Pacjent[] GetPacjentList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPacjentList", ReplyAction="http://tempuri.org/IService/GetPacjentListResponse")]
        System.Threading.Tasks.Task<Dental.ServiceReference.Pacjent[]> GetPacjentListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPacjentByID", ReplyAction="http://tempuri.org/IService/GetPacjentByIDResponse")]
        Dental.ServiceReference.Pacjent GetPacjentByID(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPacjentByID", ReplyAction="http://tempuri.org/IService/GetPacjentByIDResponse")]
        System.Threading.Tasks.Task<Dental.ServiceReference.Pacjent> GetPacjentByIDAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/PacjentInsert", ReplyAction="http://tempuri.org/IService/PacjentInsertResponse")]
        void PacjentInsert(Dental.ServiceReference.Pacjent pacjent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/PacjentInsert", ReplyAction="http://tempuri.org/IService/PacjentInsertResponse")]
        System.Threading.Tasks.Task PacjentInsertAsync(Dental.ServiceReference.Pacjent pacjent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/PacjentUpdate", ReplyAction="http://tempuri.org/IService/PacjentUpdateResponse")]
        void PacjentUpdate(Dental.ServiceReference.Pacjent pacjent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/PacjentUpdate", ReplyAction="http://tempuri.org/IService/PacjentUpdateResponse")]
        System.Threading.Tasks.Task PacjentUpdateAsync(Dental.ServiceReference.Pacjent pacjent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/PacjentDelete", ReplyAction="http://tempuri.org/IService/PacjentDeleteResponse")]
        void PacjentDelete(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/PacjentDelete", ReplyAction="http://tempuri.org/IService/PacjentDeleteResponse")]
        System.Threading.Tasks.Task PacjentDeleteAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Dental.ServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Dental.ServiceReference.IService>, Dental.ServiceReference.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Dental.ServiceReference.Pacjent[] GetPacjentList() {
            return base.Channel.GetPacjentList();
        }
        
        public System.Threading.Tasks.Task<Dental.ServiceReference.Pacjent[]> GetPacjentListAsync() {
            return base.Channel.GetPacjentListAsync();
        }
        
        public Dental.ServiceReference.Pacjent GetPacjentByID(int id) {
            return base.Channel.GetPacjentByID(id);
        }
        
        public System.Threading.Tasks.Task<Dental.ServiceReference.Pacjent> GetPacjentByIDAsync(int id) {
            return base.Channel.GetPacjentByIDAsync(id);
        }
        
        public void PacjentInsert(Dental.ServiceReference.Pacjent pacjent) {
            base.Channel.PacjentInsert(pacjent);
        }
        
        public System.Threading.Tasks.Task PacjentInsertAsync(Dental.ServiceReference.Pacjent pacjent) {
            return base.Channel.PacjentInsertAsync(pacjent);
        }
        
        public void PacjentUpdate(Dental.ServiceReference.Pacjent pacjent) {
            base.Channel.PacjentUpdate(pacjent);
        }
        
        public System.Threading.Tasks.Task PacjentUpdateAsync(Dental.ServiceReference.Pacjent pacjent) {
            return base.Channel.PacjentUpdateAsync(pacjent);
        }
        
        public void PacjentDelete(int id) {
            base.Channel.PacjentDelete(id);
        }
        
        public System.Threading.Tasks.Task PacjentDeleteAsync(int id) {
            return base.Channel.PacjentDeleteAsync(id);
        }
    }
}