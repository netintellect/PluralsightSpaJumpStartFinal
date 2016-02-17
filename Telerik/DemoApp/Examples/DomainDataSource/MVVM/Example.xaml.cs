using System;
using System.Linq;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.DomainDataSource.MVVM
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
		public Example()
        {
            InitializeComponent();

			this.radGridView.Items.DescriptorsSynchronizationMode = SynchronizationMode.OneWayToSource;
			
			CustomersViewModel viewModel = new CustomersViewModel();

			this.mainGrid.DataContext = viewModel;
			this.ConfigurationPanel.DataContext = viewModel;
		}
    }
}
