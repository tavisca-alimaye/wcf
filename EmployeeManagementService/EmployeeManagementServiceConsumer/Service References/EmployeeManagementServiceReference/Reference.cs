﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeManagementServiceConsumer.EmployeeManagementServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmpIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmpNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private EmployeeManagementServiceConsumer.EmployeeManagementServiceReference.Remarks remarkField;
        
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
        public int EmpId {
            get {
                return this.EmpIdField;
            }
            set {
                if ((this.EmpIdField.Equals(value) != true)) {
                    this.EmpIdField = value;
                    this.RaisePropertyChanged("EmpId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmpName {
            get {
                return this.EmpNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EmpNameField, value) != true)) {
                    this.EmpNameField = value;
                    this.RaisePropertyChanged("EmpName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public EmployeeManagementServiceConsumer.EmployeeManagementServiceReference.Remarks remark {
            get {
                return this.remarkField;
            }
            set {
                if ((object.ReferenceEquals(this.remarkField, value) != true)) {
                    this.remarkField = value;
                    this.RaisePropertyChanged("remark");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Remarks", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
    [System.SerializableAttribute()]
    public partial class Remarks : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime RemarkDateTimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkDescriptionField;
        
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
        public System.DateTime RemarkDateTimeStamp {
            get {
                return this.RemarkDateTimeStampField;
            }
            set {
                if ((this.RemarkDateTimeStampField.Equals(value) != true)) {
                    this.RemarkDateTimeStampField = value;
                    this.RaisePropertyChanged("RemarkDateTimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RemarkDescription {
            get {
                return this.RemarkDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkDescriptionField, value) != true)) {
                    this.RemarkDescriptionField = value;
                    this.RaisePropertyChanged("RemarkDescription");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeManagementServiceReference.ICreateEmployee")]
    public interface ICreateEmployee {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployee/AddEmployee", ReplyAction="http://tempuri.org/ICreateEmployee/AddEmployeeResponse")]
        void AddEmployee(EmployeeManagementServiceConsumer.EmployeeManagementServiceReference.Employee emp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployee/AddEmployee", ReplyAction="http://tempuri.org/ICreateEmployee/AddEmployeeResponse")]
        System.Threading.Tasks.Task AddEmployeeAsync(EmployeeManagementServiceConsumer.EmployeeManagementServiceReference.Employee emp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployee/AddRemark", ReplyAction="http://tempuri.org/ICreateEmployee/AddRemarkResponse")]
        void AddRemark(int id, string comments);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployee/AddRemark", ReplyAction="http://tempuri.org/ICreateEmployee/AddRemarkResponse")]
        System.Threading.Tasks.Task AddRemarkAsync(int id, string comments);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICreateEmployeeChannel : EmployeeManagementServiceConsumer.EmployeeManagementServiceReference.ICreateEmployee, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateEmployeeClient : System.ServiceModel.ClientBase<EmployeeManagementServiceConsumer.EmployeeManagementServiceReference.ICreateEmployee>, EmployeeManagementServiceConsumer.EmployeeManagementServiceReference.ICreateEmployee {
        
        public CreateEmployeeClient() {
        }
        
        public CreateEmployeeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CreateEmployeeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateEmployeeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateEmployeeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddEmployee(EmployeeManagementServiceConsumer.EmployeeManagementServiceReference.Employee emp) {
            base.Channel.AddEmployee(emp);
        }
        
        public System.Threading.Tasks.Task AddEmployeeAsync(EmployeeManagementServiceConsumer.EmployeeManagementServiceReference.Employee emp) {
            return base.Channel.AddEmployeeAsync(emp);
        }
        
        public void AddRemark(int id, string comments) {
            base.Channel.AddRemark(id, comments);
        }
        
        public System.Threading.Tasks.Task AddRemarkAsync(int id, string comments) {
            return base.Channel.AddRemarkAsync(id, comments);
        }
    }
}
