using Examples.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.DomainDataSource.DistinctValues
{
	/// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
		private RadObservableCollection<string> distinctValues = new RadObservableCollection<string>();
		private DateTime startTime;

		public Example()
        {
            InitializeComponent();
        }

		private void OnRadGridViewDistinctValuesLoading(object sender, GridViewDistinctValuesLoadingEventArgs e)
		{
			GridViewBoundColumnBase boundColumn = e.Column as GridViewBoundColumnBase;
			if (boundColumn != null)
			{
				this.distinctValues.Clear();
				e.ItemsSource = this.distinctValues;

				this.distinctValuesDataSource.QueryParameters[0].Value = boundColumn.GetDataMemberName();
				this.distinctValuesDataSource.Load();
			}
		}

		private void OnDistinctValuesDataSourceLoadingData(object sender, Telerik.Windows.Controls.DomainServices.LoadingDataEventArgs e)
		{
			e.LoadBehavior = LoadBehavior.RefreshCurrent;

			this.startTime = DateTime.Now;
			this.debugTextBox.Text = string.Format("--> Asking server for distinct values for '{0}' column\r\n"
				, this.distinctValuesDataSource.QueryParameters[0].Value.ToString());
		}
		
		private void OnDistinctValuesDataSourceLoadedData(object sender, Telerik.Windows.Controls.DomainServices.LoadedDataEventArgs e)
		{
			if (e.HasError)
			{
				e.MarkErrorAsHandled();
				this.debugTextBox.Text = string.Format("<-- Server could not get distinct values for '{0}' column: {1}\r\n"
					, this.distinctValuesDataSource.QueryParameters[0].Value
					, e.Error);
			}
			else if (e.Cancelled)
			{
				this.debugTextBox.Text = string.Format("<-- Load operation was cancelled\r\n");
			}
			else
			{
				TimeSpan elapsedTime = DateTime.Now - this.startTime;
				this.debugTextBox.Text += string.Format("<-- Server returned {0} distinct values for '{1}' column in {2} ms\r\n"
					, e.Entities.Count()
					, this.distinctValuesDataSource.QueryParameters[0].Value
					, elapsedTime.Milliseconds);
				
				List<string> list = new List<string>();

				// You might want to limit the amount of distict values
				// if you think that the user can generate a very long query.
				foreach (DistinctValue dv in e.Entities)
				{
					list.Add(dv.Value);
				}

				this.distinctValues.AddRange(list);
			}
		}

		private void OnCustomersDataSourceLoadedData(object sender, Telerik.Windows.Controls.DomainServices.LoadedDataEventArgs e)
		{
			if (e.HasError)
			{
				e.MarkErrorAsHandled();
			}
		}
    }
}
