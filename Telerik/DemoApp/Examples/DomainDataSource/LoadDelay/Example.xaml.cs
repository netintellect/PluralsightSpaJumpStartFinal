using System;
using System.Linq;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.DomainDataSource.LoadDelay
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
		private readonly DispatcherTimer progressBarTimer = new DispatcherTimer();
		private const int ProgressBarUpdateInterval = 200;

		public Example()
        {
            InitializeComponent();
			StyleManager.SetTheme(this.searchTextBox, StyleManager.ApplicationTheme);
			this.progressBarTimer.Interval = TimeSpan.FromMilliseconds(ProgressBarUpdateInterval);
			this.progressBarTimer.Tick += this.OnProgeressBarTimerTick;
        }

		private DateTime start;
		private void OnSearchTextBoxTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			this.progressBar.Maximum = this.customersDataSource.LoadDelay.TotalMilliseconds;
			this.progressBar.Value = this.progressBar.Maximum;
			this.progressBarTimer.Start();
		}

		private void OnProgeressBarTimerTick(object sender, EventArgs e)
		{
			this.progressBar.Value -= ProgressBarUpdateInterval;
		}

		private void OnCustomersDataSourceLoadingData(object sender, Telerik.Windows.Controls.DomainServices.LoadingDataEventArgs e)
		{
			this.progressBarTimer.Stop();
			this.progressBar.Value = 0;
		}

		private void OnCustomersDataSourceLoadedData(object sender, Telerik.Windows.Controls.DomainServices.LoadedDataEventArgs e)
		{
			if (e.HasError)
			{
				e.MarkErrorAsHandled();
			}
		}

		private void OnRadGridViewAutoGeneratingColumn(object sender, Controls.GridViewAutoGeneratingColumnEventArgs e)
		{
			e.Column.ShowDistinctFilters = false;
		}
    }
}
