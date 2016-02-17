using System;
using System.Linq;

namespace Telerik.Windows.Examples.DomainDataSource.FirstLook
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
		private DateTime startTime;

		public Example()
        {
            InitializeComponent();
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
			e.Column.ShowDistinctFilters = false;
		}
    }
}
