using System;
using System.Linq;
using System.Windows;
using QuickStart.DataBase;

namespace Telerik.Windows.Examples.EntityFrameworkDataSource.FirstLook
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
		public Example()
        {
            InitializeComponent();
        }

		private void customersGrid_AddingNewDataItem(object sender, Controls.GridView.GridViewAddingNewEventArgs e)
		{
			Customer newCustomer = Customer.CreateCustomer(Guid.NewGuid().ToString().Substring(0, 5), "Telerik");
			e.NewObject = newCustomer;
		}

		private void SubmitChangesButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			try
			{
				this.customersDataSource.SubmitChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void LoadButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.customersDataSource.Load();
		}
    }
}
