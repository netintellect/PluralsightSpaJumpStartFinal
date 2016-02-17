using Serialization.DataProviderSerializers;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PivotGrid.Serialization
{
    public partial class Example : UserControl
    {
        private string lastSerializadProvider;
        public Example()
        {
            InitializeComponent();
            this.EnsureLoadState();
            this.Unloaded += this.OnExampleUnloaded;
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }

        private void OnSave(object sender, System.Windows.RoutedEventArgs e)
        {
            RadWindow.Confirm("Do you want to save current state?", this.OnSaveState);
        }
  
        private void OnSaveState(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                LocalDataSourceSerializer provider = new LocalDataSourceSerializer();
                this.lastSerializadProvider = provider.Serialize(this.pivotGrid.DataProvider);
                this.EnsureLoadState();
            }
        }

        private void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            RadWindow.Confirm("Are you sure you want to load the saved state?", this.OnLoadingState);
        }
  
        private void OnLoadingState(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                LocalDataSourceSerializer provider = new LocalDataSourceSerializer();
                provider.Deserialize(this.pivotGrid.DataProvider, this.lastSerializadProvider);
                this.EnsureLoadState();
            }
        }

        private bool CanLoad()
        {
            return !String.IsNullOrEmpty(this.lastSerializadProvider);
        }

        private void EnsureLoadState()
        {
            this.buttonLoad.IsEnabled = this.CanLoad();
        }
    }
}
