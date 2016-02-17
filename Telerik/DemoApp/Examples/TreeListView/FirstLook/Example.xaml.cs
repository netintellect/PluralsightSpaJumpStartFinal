using System;

namespace Telerik.Windows.Examples.TreeListView.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
    {
        public Example()
        {
            InitializeComponent();

            DataContext = new MyDataContext();
        }        
    }
}