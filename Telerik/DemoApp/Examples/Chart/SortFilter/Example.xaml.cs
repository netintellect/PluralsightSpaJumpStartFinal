using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.SortFilter
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void RadContextMenu_ItemClick(object sender, RadRoutedEventArgs e)
        {
            string menuItem = (e.OriginalSource as RadMenuItem).Header as string;

            if (RadChart1 == null || string.IsNullOrEmpty(menuItem))
                return;

            (this.Resources["dataContext"] as ExampleViewModel).SelectedSortingCategory = menuItem;
        }
    }
}
