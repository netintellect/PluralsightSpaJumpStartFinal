using System.Windows;
using System.Windows.Controls;
using Telerik.Pivot.Xmla;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PivotGrid.Olap.WPF
{
    public partial class Example : UserControl
    {
        private XmlaDataProvider dataProvider;

        public Example()
        {
            InitializeComponent();
            this.Unloaded += this.OnExampleUnloaded;
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }
    }
}
