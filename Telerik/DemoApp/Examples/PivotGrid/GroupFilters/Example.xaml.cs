using System.Windows.Controls;
using Telerik.Pivot.Core;
using Telerik.Windows.Examples.PivotGrid.Common.Filtering;

namespace Telerik.Windows.Examples.PivotGrid.GroupFilters
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void FiltersSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LocalDataSourceProvider dataProvider = this.Resources["DataProvider"] as LocalDataSourceProvider;
            if (dataProvider != null)
            {
                FilterItem filter = this.FiltersSelection.SelectedItem as FilterItem;
                dataProvider.ColumnGroupDescriptions[0].GroupFilter = filter.GroupFilter;
                dataProvider.Refresh();
            }
        }
    }
}
