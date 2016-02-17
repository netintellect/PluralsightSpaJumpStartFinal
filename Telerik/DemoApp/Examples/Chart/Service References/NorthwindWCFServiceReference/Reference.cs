﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.50826.0
// 
namespace Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/Examples.Web", IsReference=true)]
    public partial class Product : Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.EntityObject {
        
        private System.Nullable<int> CategoryIDField;
        
        private bool DiscontinuedField;
        
        private int ProductIDField;
        
        private string ProductNameField;
        
        private string QuantityPerUnitField;
        
        private System.Nullable<short> ReorderLevelField;
        
        private System.Nullable<int> SupplierIDField;
        
        private System.Nullable<decimal> UnitPriceField;
        
        private System.Nullable<short> UnitsInStockField;
        
        private System.Nullable<short> UnitsOnOrderField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> CategoryID {
            get {
                return this.CategoryIDField;
            }
            set {
                if ((this.CategoryIDField.Equals(value) != true)) {
                    this.CategoryIDField = value;
                    this.RaisePropertyChanged("CategoryID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Discontinued {
            get {
                return this.DiscontinuedField;
            }
            set {
                if ((this.DiscontinuedField.Equals(value) != true)) {
                    this.DiscontinuedField = value;
                    this.RaisePropertyChanged("Discontinued");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductName {
            get {
                return this.ProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNameField, value) != true)) {
                    this.ProductNameField = value;
                    this.RaisePropertyChanged("ProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string QuantityPerUnit {
            get {
                return this.QuantityPerUnitField;
            }
            set {
                if ((object.ReferenceEquals(this.QuantityPerUnitField, value) != true)) {
                    this.QuantityPerUnitField = value;
                    this.RaisePropertyChanged("QuantityPerUnit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> ReorderLevel {
            get {
                return this.ReorderLevelField;
            }
            set {
                if ((this.ReorderLevelField.Equals(value) != true)) {
                    this.ReorderLevelField = value;
                    this.RaisePropertyChanged("ReorderLevel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> SupplierID {
            get {
                return this.SupplierIDField;
            }
            set {
                if ((this.SupplierIDField.Equals(value) != true)) {
                    this.SupplierIDField = value;
                    this.RaisePropertyChanged("SupplierID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> UnitPrice {
            get {
                return this.UnitPriceField;
            }
            set {
                if ((this.UnitPriceField.Equals(value) != true)) {
                    this.UnitPriceField = value;
                    this.RaisePropertyChanged("UnitPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> UnitsInStock {
            get {
                return this.UnitsInStockField;
            }
            set {
                if ((this.UnitsInStockField.Equals(value) != true)) {
                    this.UnitsInStockField = value;
                    this.RaisePropertyChanged("UnitsInStock");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> UnitsOnOrder {
            get {
                return this.UnitsOnOrderField;
            }
            set {
                if ((this.UnitsOnOrderField.Equals(value) != true)) {
                    this.UnitsOnOrderField = value;
                    this.RaisePropertyChanged("UnitsOnOrder");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StructuralObject", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses", IsReference=true)]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.EntityObject))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product))]
    public partial class StructuralObject : object, System.ComponentModel.INotifyPropertyChanged {
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityObject", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses", IsReference=true)]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product))]
    public partial class EntityObject : Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.StructuralObject {
        
        private Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.EntityKey EntityKeyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.EntityKey EntityKey {
            get {
                return this.EntityKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityKeyField, value) != true)) {
                    this.EntityKeyField = value;
                    this.RaisePropertyChanged("EntityKey");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityKey", Namespace="http://schemas.datacontract.org/2004/07/System.Data", IsReference=true)]
    public partial class EntityKey : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string EntityContainerNameField;
        
        private System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.EntityKeyMember> EntityKeyValuesField;
        
        private string EntitySetNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EntityContainerName {
            get {
                return this.EntityContainerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityContainerNameField, value) != true)) {
                    this.EntityContainerNameField = value;
                    this.RaisePropertyChanged("EntityContainerName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.EntityKeyMember> EntityKeyValues {
            get {
                return this.EntityKeyValuesField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityKeyValuesField, value) != true)) {
                    this.EntityKeyValuesField = value;
                    this.RaisePropertyChanged("EntityKeyValues");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EntitySetName {
            get {
                return this.EntitySetNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EntitySetNameField, value) != true)) {
                    this.EntitySetNameField = value;
                    this.RaisePropertyChanged("EntitySetName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityKeyMember", Namespace="http://schemas.datacontract.org/2004/07/System.Data")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.EntityObject))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.StructuralObject))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product>))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.EntityKey))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.EntityKeyMember>))]
    public partial class EntityKeyMember : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string KeyField;
        
        private object ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key {
            get {
                return this.KeyField;
            }
            set {
                if ((object.ReferenceEquals(this.KeyField, value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="NorthwindWCFServiceReference.NorthwindWCFService")]
    public interface NorthwindWCFService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:NorthwindWCFService/LoadTopProducts", ReplyAction="urn:NorthwindWCFService/LoadTopProductsResponse")]
        System.IAsyncResult BeginLoadTopProducts(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product> EndLoadTopProducts(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface NorthwindWCFServiceChannel : Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoadTopProductsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public LoadTopProductsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NorthwindWCFServiceClient : System.ServiceModel.ClientBase<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService>, Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService {
        
        private BeginOperationDelegate onBeginLoadTopProductsDelegate;
        
        private EndOperationDelegate onEndLoadTopProductsDelegate;
        
        private System.Threading.SendOrPostCallback onLoadTopProductsCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public NorthwindWCFServiceClient() {
        }
        
        public NorthwindWCFServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NorthwindWCFServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NorthwindWCFServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NorthwindWCFServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<LoadTopProductsCompletedEventArgs> LoadTopProductsCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService.BeginLoadTopProducts(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginLoadTopProducts(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product> Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService.EndLoadTopProducts(System.IAsyncResult result) {
            return base.Channel.EndLoadTopProducts(result);
        }
        
        private System.IAsyncResult OnBeginLoadTopProducts(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService)(this)).BeginLoadTopProducts(callback, asyncState);
        }
        
        private object[] OnEndLoadTopProducts(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product> retVal = ((Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService)(this)).EndLoadTopProducts(result);
            return new object[] {
                    retVal};
        }
        
        private void OnLoadTopProductsCompleted(object state) {
            if ((this.LoadTopProductsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.LoadTopProductsCompleted(this, new LoadTopProductsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void LoadTopProductsAsync() {
            this.LoadTopProductsAsync(null);
        }
        
        public void LoadTopProductsAsync(object userState) {
            if ((this.onBeginLoadTopProductsDelegate == null)) {
                this.onBeginLoadTopProductsDelegate = new BeginOperationDelegate(this.OnBeginLoadTopProducts);
            }
            if ((this.onEndLoadTopProductsDelegate == null)) {
                this.onEndLoadTopProductsDelegate = new EndOperationDelegate(this.OnEndLoadTopProducts);
            }
            if ((this.onLoadTopProductsCompletedDelegate == null)) {
                this.onLoadTopProductsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnLoadTopProductsCompleted);
            }
            base.InvokeAsync(this.onBeginLoadTopProductsDelegate, null, this.onEndLoadTopProductsDelegate, this.onLoadTopProductsCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService CreateChannel() {
            return new NorthwindWCFServiceClientChannel(this);
        }
        
        private class NorthwindWCFServiceClientChannel : ChannelBase<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService>, Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService {
            
            public NorthwindWCFServiceClientChannel(System.ServiceModel.ClientBase<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.NorthwindWCFService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginLoadTopProducts(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("LoadTopProducts", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product> EndLoadTopProducts(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product> _result = ((System.Collections.ObjectModel.ObservableCollection<Telerik.Windows.Examples.Chart.NorthwindWCFServiceReference.Product>)(base.EndInvoke("LoadTopProducts", _args, result)));
                return _result;
            }
        }
    }
}
