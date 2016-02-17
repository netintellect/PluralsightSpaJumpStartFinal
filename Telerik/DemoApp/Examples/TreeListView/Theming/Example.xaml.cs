using System;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.TreeListView.Theming
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