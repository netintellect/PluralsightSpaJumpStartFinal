using System;
using System.Linq;
using Telerik.Windows.Data;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.DomainDataSource.SearchAsYouType
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
		private DateTime startTime;
		private readonly DispatcherTimer loadTimer;

		public Example()
        {
            InitializeComponent();

			this.loadTimer = new DispatcherTimer();
			// You can control the load delay between typing in the textbox and going to the server.
			this.loadTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
			this.loadTimer.Tick += this.OnLoadTimerTick;
	
			this.customersDataSource.FilterDescriptors.LogicalOperator = FilterCompositionLogicalOperator.Or;
			this.customersDataSource.Load();
        }

		private void OnLoadTimerTick(object sender, EventArgs e)
		{
			if (this.loadTimer.IsEnabled)
			{
				this.loadTimer.Stop();
			}
			
			foreach (FilterDescriptor fd in this.customersDataSource.FilterDescriptors)
			{
				fd.Value = this.searchTextBox.Text;
			}

			this.customersDataSource.Load();
		}

		private void OnSearchTextBoxTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			if (this.loadTimer.IsEnabled)
			{
				this.loadTimer.Stop();
			}
			
			this.loadTimer.Start();
		}

		private void OnCustomersDataSourceLoadingData(object sender, Telerik.Windows.Controls.DomainServices.LoadingDataEventArgs e)
		{
			this.startTime = DateTime.Now;
			string query = "GetCustomers";
			if (e.Query.Query != null)
			{
				query = e.Query.Query.ToString();
			}

			this.debugTextBox.Text = string.Format("--> Sending query to server: {0}\r\n", query);
		}

		private void OnCustomersDataSourceLoadedData(object sender, Telerik.Windows.Controls.DomainServices.LoadedDataEventArgs e)
		{
			if (e.HasError)
			{
				e.MarkErrorAsHandled();
				this.debugTextBox.Text = string.Format("<-- Server returned the following error: {0}\r\n"
					, e.Error);
			}
			else if (e.Cancelled)
			{
				this.debugTextBox.Text = string.Format("<-- Load operation was cancelled\r\n");
			}
			else
			{
				TimeSpan elapsedTime = DateTime.Now - this.startTime;
				this.debugTextBox.Text += string.Format("<-- Server returned {0} entities {1} ms\r\n"
					, e.Entities.Count()
					, elapsedTime.Milliseconds);
			}
		}

		private void OnRadGridViewAutoGeneratingColumn(object sender, Controls.GridViewAutoGeneratingColumnEventArgs e)
		{
			GridViewBoundColumnBase boundColumn = e.Column as GridViewBoundColumnBase;
			if (boundColumn != null)
			{
				switch (boundColumn.UniqueName)
				{
					case "ContactName":
					case "ContactTitle":
					case "CompanyName":
					case "Address":
					case "City":
					case "Country":
						FilterDescriptor fd = new FilterDescriptor(e.Column.UniqueName
							, FilterOperator.Contains
							, FilterDescriptor.UnsetValue);
						this.customersDataSource.FilterDescriptors.Add(fd);
						break;
				}
			}
		}
	}
}
