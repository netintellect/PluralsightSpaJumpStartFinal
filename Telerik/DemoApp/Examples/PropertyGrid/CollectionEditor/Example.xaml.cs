using System;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.PropertyGrid.CollectionEditor
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			var customer = Utilities.GenerateCustomer();	

			this.propertyGrid1.Item = customer;		 
		}
	}
}
