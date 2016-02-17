using System;
using System.Linq;
using Telerik.Windows.Data;
using Telerik.Windows.Controls;
using System.ServiceModel.DomainServices.Client;
using System.Collections.Generic;
using Examples.Web;

namespace Telerik.Windows.Examples.DomainDataSource.RadDataFilterIntegration
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
		private DateTime startTime;
		
		private IList<string> countries = new List<string>();
		private IList<string> cities = new List<string>();
		private IList<string> contactTitles = new List<string>();

		public Example()
        {
            InitializeComponent();

			// Tell RadGridView not to listen for the descriptors of the RadDomainDataSource
			// It will be used solely to display the data on the client.
			this.radGridView.Items.DescriptorsSynchronizationMode = SynchronizationMode.OneWayToSource;

			this.LoadDistinctValuesAsync();
        }

		private void LoadDistinctValuesAsync()
		{
			NorthwindDomainContext context = new NorthwindDomainContext();
			
			EntityQuery<DistinctValue> countriesQuery =
				context.GetDistinctValuesQuery("Country");
			context.Load<DistinctValue>(countriesQuery
				, LoadBehavior.RefreshCurrent
				, this.OnDistinctValuesLoaded
				, this.countries);
			
			EntityQuery<DistinctValue> citiesQuery =
				context.GetDistinctValuesQuery("City");
			context.Load<DistinctValue>(citiesQuery
				, LoadBehavior.RefreshCurrent
				, this.OnDistinctValuesLoaded
				, this.cities);
			
			EntityQuery<DistinctValue> contactTitlesQuery =
				context.GetDistinctValuesQuery("ContactTitle");
			context.Load<DistinctValue>(contactTitlesQuery
				, LoadBehavior.RefreshCurrent
				, this.OnDistinctValuesLoaded
				, this.contactTitles);
		}

		private void OnDistinctValuesLoaded(LoadOperation<DistinctValue> loadOperation)
		{
			IList<string> distinctValuesList = (IList<string>)loadOperation.UserState;
			
			if (loadOperation.HasError)
			{
				loadOperation.MarkErrorAsHandled();
				return;
			}

			foreach (DistinctValue dv in loadOperation.Entities)
			{
				distinctValuesList.Add(dv.Value);
			}
		}

		private void OnRadDataFilterEditorCreated(object sender, Controls.Data.DataFilter.EditorCreatedEventArgs e)
		{
			IList<string> distinctValuesList = null;

			switch (e.ItemPropertyDefinition.PropertyName)
			{
				case "ContactTitle":
					distinctValuesList = this.contactTitles;
					break;
				case "City":
					distinctValuesList = this.cities;
					break;
				case "Country":
					distinctValuesList = this.countries;
					break;
			}

			if (distinctValuesList != null)
			{
				RadComboBox radComboBox = (RadComboBox)e.Editor;
				radComboBox.ItemsSource = distinctValuesList;
			}
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
    }
}
