using System;
using System.Windows.Media;

namespace Telerik.Windows.Examples.TreeListView.TreeLines
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