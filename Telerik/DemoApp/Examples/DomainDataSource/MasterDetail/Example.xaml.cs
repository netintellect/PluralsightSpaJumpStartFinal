using System;
using System.Linq;

namespace Telerik.Windows.Examples.DomainDataSource.MasterDetail
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
		public Example()
        {
            InitializeComponent();
        }

		private void OnRadGridViewAutoGeneratingColumn(object sender, Controls.GridViewAutoGeneratingColumnEventArgs e)
		{
			e.Column.ShowDistinctFilters = false;
		}

		private void OnMasterGridViewSelectionChanged(object sender, Controls.SelectionChangeEventArgs e)
		{
			this.detailOrdersDataSource.AutoLoad = true;
		}

		private void OnCustomersDataSourceLoadedData(object sender, Controls.DomainServices.LoadedDataEventArgs e)
		{
			if (e.HasError)
			{
				e.MarkErrorAsHandled();
				return;
			}
			
			this.masterGridView.SelectedItem = this.masterGridView.Items[0];
		}
    }
}
