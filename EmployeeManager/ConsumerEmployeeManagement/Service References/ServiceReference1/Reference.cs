﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsumerEmployeeManagement.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManager")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmployeeIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmployeeNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsumerEmployeeManagement.ServiceReference1.Remarks remarkField;
        
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
        public int EmployeeID {
            get {
                return this.EmployeeIDField;
            }
            set {
                if ((this.EmployeeIDField.Equals(value) != true)) {
                    this.EmployeeIDField = value;
                    this.RaisePropertyChanged("EmployeeID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmployeeName {
            get {
                return this.EmployeeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeeNameField, value) != true)) {
                    this.EmployeeNameField = value;
                    this.RaisePropertyChanged("EmployeeName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsumerEmployeeManagement.ServiceReference1.Remarks remark {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Remarks", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManager")]
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICreateEmployee")]
    public interface ICreateEmployee {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployee/AddEmployee", ReplyAction="http://tempuri.org/ICreateEmployee/AddEmployeeResponse")]
        void AddEmployee();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployee/AddEmployee", ReplyAction="http://tempuri.org/ICreateEmployee/AddEmployeeResponse")]
        System.Threading.Tasks.Task AddEmployeeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployee/AddRemark", ReplyAction="http://tempuri.org/ICreateEmployee/AddRemarkResponse")]
        void AddRemark(ConsumerEmployeeManagement.ServiceReference1.Employee e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployee/AddRemark", ReplyAction="http://tempuri.org/ICreateEmployee/AddRemarkResponse")]
        System.Threading.Tasks.Task AddRemarkAsync(ConsumerEmployeeManagement.ServiceReference1.Employee e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployee/GetEmployee", ReplyAction="http://tempuri.org/ICreateEmployee/GetEmployeeResponse")]
        ConsumerEmployeeManagement.ServiceReference1.Employee GetEmployee(int empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateEmployee/GetEmployee", ReplyAction="http://tempuri.org/ICreateEmployee/GetEmployeeResponse")]
        System.Threading.Tasks.Task<ConsumerEmployeeManagement.ServiceReference1.Employee> GetEmployeeAsync(int empId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICreateEmployeeChannel : ConsumerEmployeeManagement.ServiceReference1.ICreateEmployee, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateEmployeeClient : System.ServiceModel.ClientBase<ConsumerEmployeeManagement.ServiceReference1.ICreateEmployee>, ConsumerEmployeeManagement.ServiceReference1.ICreateEmployee {
        
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
        
        public void AddEmployee() {
            base.Channel.AddEmployee();
        }
        
        public System.Threading.Tasks.Task AddEmployeeAsync() {
            return base.Channel.AddEmployeeAsync();
        }
        
        public void AddRemark(ConsumerEmployeeManagement.ServiceReference1.Employee e) {
            base.Channel.AddRemark(e);
        }
        
        public System.Threading.Tasks.Task AddRemarkAsync(ConsumerEmployeeManagement.ServiceReference1.Employee e) {
            return base.Channel.AddRemarkAsync(e);
        }
        
        public ConsumerEmployeeManagement.ServiceReference1.Employee GetEmployee(int empId) {
            return base.Channel.GetEmployee(empId);
        }
        
        public System.Threading.Tasks.Task<ConsumerEmployeeManagement.ServiceReference1.Employee> GetEmployeeAsync(int empId) {
            return base.Channel.GetEmployeeAsync(empId);
        }
    }
}
