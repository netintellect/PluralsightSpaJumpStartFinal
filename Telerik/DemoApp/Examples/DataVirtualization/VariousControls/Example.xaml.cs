using Examples.Web;

namespace Telerik.Windows.Examples.DataVirtualization.VariousControls
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
        public Example()
        {
			this.InitializeComponent();

            DataContext = new ExamplesDataContext();
 		}

		private void OnTreeViewSelectionChanged(object sender, Controls.SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count > 0 && e.AddedItems[0] is Order)
			{
				var order = e.AddedItems[0] as Order;
				foreach (Customer customer in this.coverFlow.Items)
				{
					if (customer.CustomerID == order.CustomerID)
					{
						this.coverFlow.SelectedItem = customer;
						return;
					}
				}
			}
		}
    }
}
