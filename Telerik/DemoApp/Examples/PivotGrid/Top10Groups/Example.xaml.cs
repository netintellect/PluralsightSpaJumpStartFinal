using System.Windows;
using System.Windows.Controls;
using Telerik.Pivot.Core;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.PivotGrid.Common.Filtering;

namespace Telerik.Windows.Examples.PivotGrid.Top10Groups
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
            this.Unloaded += this.OnExampleUnloaded;
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }

        private void FiltersSelection_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            LocalDataSourceProvider dataProvider = this.Resources["DataProvider"] as LocalDataSourceProvider;
            if (dataProvider != null)
            {
                FilterItem filter = this.FiltersSelection.SelectedItem as FilterItem;
                dataProvider.RowGroupDescriptions[1].GroupFilter = filter.GroupFilter;
                dataProvider.Refresh();
            }
        }
    }
}
