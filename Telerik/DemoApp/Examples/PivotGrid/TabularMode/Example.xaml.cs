using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PivotGrid.TabularMode
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
    }
}
