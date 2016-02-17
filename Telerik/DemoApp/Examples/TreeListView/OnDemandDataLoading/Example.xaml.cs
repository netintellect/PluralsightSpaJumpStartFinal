using System;
using System.Linq;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.TreeListView.OnDemandDataLoading
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            DataContext = new MyDataContext();
        }
    }
}
