using System;
using Telerik.Windows.Controls.DataServices;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.DataServiceDataSource.RadDataFilterIntegration
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

			// Tell RadGridView not to listen for the descriptors of the RadDomainDataSource
			// It will be used solely to display the data on the client.
			this.radGridView.Items.DescriptorsSynchronizationMode = SynchronizationMode.OneWayToSource;
		}

		private void OnDataSourceLoadingData(object sender, LoadingDataEventArgs e)
		{
			this.startTime = DateTime.Now;
			if (e.Query != null)
			{
				this.debugTextBox.Text = string.Format("--> Requesting {0}\r\n", e.Query.ToString());
			}
		}

		private void OnDataSourceLoadedData(object sender, LoadedDataEventArgs e)
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
				this.debugTextBox.Text += string.Format("<-- Server replied in {0} ms\r\n"
					, elapsedTime.Milliseconds);
			}
		}
	}
}
