using System.Windows.Controls;

namespace Telerik.Windows.Examples.PropertyGrid.EditRowDetailsWithPropertyGrid
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.DataContext = new Northwind(); 				
		}
	}
}
