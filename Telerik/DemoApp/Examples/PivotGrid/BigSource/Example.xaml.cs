using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Telerik.Pivot.Core;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.PivotGrid.SampleData;

namespace Telerik.Windows.Examples.PivotGrid.BigSource
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        private RandomOrdersGenerator randomOrders;
        private LocalDataSourceProvider dataProvider;

        private DateTime startTime;

        public Example()
        {
            InitializeComponent();
            this.randomOrders = this.Resources["RandomOrders"] as RandomOrdersGenerator;
            this.dataProvider = this.Resources["DataProvider"] as LocalDataSourceProvider;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.randomOrders != null)
            {
                this.randomOrders.GenerateOrders();
                this.randomOrders.ProgressChanged += RandomOrdersGenerator_ProgressChanged;
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (this.randomOrders != null)
            {
                this.randomOrders.Cancel();
            }
            if (this.dataProvider != null)
            {
                this.dataProvider.StatusChanged -= DataProvider_StatusChanged;
            }
        }

        private void RandomOrdersGenerator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                // Invoke on the UIThread
                this.Dispatcher.BeginInvoke(new Action(this.RandomOrdersGenerator_ProgressChanged));
            }
        }

        private void RandomOrdersGenerator_ProgressChanged()
        {
            this.OrdersProgressDisplay.Visibility = Visibility.Collapsed;
            this.GroupButton.Visibility = Visibility.Visible;
        }

        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataProvider != null)
            {
                this.GroupButton.Visibility = Visibility.Collapsed;
                this.dataProvider.StatusChanged += DataProvider_StatusChanged;
                this.startTime = DateTime.UtcNow;
                this.dataProvider.ItemsSource = this.randomOrders.Orders;
            }
        }

        private void DataProvider_StatusChanged(object sender, EventArgs e)
        {
            // Invoke on the UIThread
            this.Dispatcher.BeginInvoke(new Action(this.DataProvider_StatusChanged));
        }

        private void DataProvider_StatusChanged()
        {
            if (this.dataProvider.Status == DataProviderStatus.Ready || this.dataProvider.Status == DataProviderStatus.Faulted)
            {
                var runningTime = new TimeSpan(DateTime.UtcNow.Ticks - this.startTime.Ticks);
                this.dataProvider.StatusChanged -= DataProvider_StatusChanged;
                System.Diagnostics.Debug.WriteLine(this.dataProvider.Status);
                RadWindow.Alert(String.Format("Grouped 5000000 orders in {0:ss\\.fff} seconds.", runningTime));
            }
        }
    }
}
