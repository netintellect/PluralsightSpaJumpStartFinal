using System;
using System.Windows.Controls;
using System.Linq;
using QuickStart.DataBase;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PivotGrid.QueryableDataProvider
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

            try
            {
                (this.Resources["QueryableProvider"] as Telerik.Pivot.Queryable.QueryableDataProvider).Source = new NorthwindEntities().Orders;
            }
            catch(Exception e)
            {
                if (e.ToString().Contains("SQL"))
                {
                    MessageBox.Show("There are compatibility issues with the installed Microsoft SQL Server 2008 Express and the current OS. Please download and install the latest version of Microsoft SQL Server 2008 R2 Express and restart the example.", "SQL Server 2008 Express compatibility issues detected");
                }
            }

            this.Unloaded += this.OnExampleUnloaded;
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }
	}
}