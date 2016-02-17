using System;
using System.Linq;
using QuickStart.DataBase;

namespace Telerik.Windows.Examples.DataVirtualization.WPF.VariousControls
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example
	{
		public Example()
		{
			this.InitializeComponent();			
		}

		private void OnTreeViewSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count > 0 && e.AddedItems[0] is Order)
			{
				var order = e.AddedItems[0] as Order;
				foreach (Customer customer in this.customersCarousel.Items)
				{
					if (customer.CustomerID == order.Customer.CustomerID)
					{
						this.customersCarousel.BringDataItemIntoView(customer);
						return;
					}
				}					
			}
		}
	}
}
