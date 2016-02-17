using System;
using System.Linq;
using Examples.Web.Services;
using System.ServiceModel.DomainServices.Client;
using System.Collections.Generic;
using Telerik.Windows.Controls.GridView;
using System.Windows.Threading;

namespace Telerik.Windows.Examples.DomainDataSource.QueryParameters
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
		private DateTime startTime;
		private bool categoriesLoaded;
		private bool distinctOrderYearsLoaded;
		private readonly DispatcherTimer loadTimer = new DispatcherTimer();

		public Example()
        {
            InitializeComponent();

			ColumnSortDescriptor salesSortDescriptor = new ColumnSortDescriptor();
			salesSortDescriptor.Column = this.radGridView.Columns[1];
			salesSortDescriptor.SortDirection = System.ComponentModel.ListSortDirection.Descending;
			this.radGridView.SortDescriptors.Add(salesSortDescriptor);
			
			SalesContext context = new SalesContext();
			EntityQuery<Year> distinctOrderYearsQuery = context.GetDistinctOrderYearsQuery();
			context.Load<Year>(distinctOrderYearsQuery
				, LoadBehavior.RefreshCurrent
				, this.OnDistinctOrderYearsLoaded
				, null);

			this.loadTimer = new DispatcherTimer();
			loadTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
			loadTimer.Tick += this.OnLoadTimerTick;
			loadTimer.Start();
        }

		private void OnLoadTimerTick(object sender, EventArgs e)
		{
			// Since both available categories and distinct sales order years 
			// are retrieved asynchronously from the server, this timer will 
			// periodically poll whether they have come back to the client,
			// and once they are on the client it will launch a load request
			// for the main data source. From then on, changing anything 
			// will automatically reload since AutoLoad is true.
			if (this.categoriesLoaded && this.distinctOrderYearsLoaded)
			{
				this.loadTimer.Stop();
				this.SalesByCategoryDataSource.AutoLoad = true;
			}
		}

		private void OnDistinctOrderYearsLoaded(LoadOperation<Year> loadOperation)
		{
			if (loadOperation.HasError)
			{
				loadOperation.MarkErrorAsHandled();
				return;
			}

			IList<int> distinctOrderYears = new List<int>();
			foreach (Year year in loadOperation.Entities)
			{
				distinctOrderYears.Add(year.ID);
			}

			this.ordYearComboBox.ItemsSource = distinctOrderYears;
			this.ordYearComboBox.SelectedIndex = 0;
			this.distinctOrderYearsLoaded = true;
		}

		private void OnCategoriesDataSourceLoadedData(object sender, Controls.DomainServices.LoadedDataEventArgs e)
		{
			if (e.HasError)
			{
				e.MarkErrorAsHandled();
			}
			else
			{
				this.categoriesLoaded = true;
			}
		}

		private void OnSalesByCategoryDataSourceLoadingData(object sender, Controls.DomainServices.LoadingDataEventArgs e)
		{
			string categoryName = null;
			if (e.Query.Parameters["categoryName"] != null)
			{
				categoryName = e.Query.Parameters["categoryName"].ToString();
			}

			string ordYear = null;
			if (e.Query.Parameters["ordYear"] != null)
			{
				ordYear = e.Query.Parameters["ordYear"].ToString();
			}

			if (categoryName == null || ordYear == null)
			{
				e.Cancel = true;
				return;
			}

			e.LoadBehavior = LoadBehavior.RefreshCurrent;

			string query = string.Format("GetSalesByCategory(\"{0}\", {1})", categoryName, ordYear);
			
			if (e.Query.Query != null)
			{
				// If we have filtering or sorting
				query += e.Query.Query.ToString().Replace("Examples.Web.Models.SalesByCategory_Result[]", string.Empty);
			}
			
			this.startTime = DateTime.Now;
			this.debugTextBox.Text = string.Format("--> Sending query to server: {0}\r\n", query);
		}

		private void OnSalesByCategoryDataSourceLoadedData(object sender, Controls.DomainServices.LoadedDataEventArgs e)
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
    }
}
