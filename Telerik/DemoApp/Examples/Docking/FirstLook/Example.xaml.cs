using System.Windows.Controls;

namespace Telerik.Windows.Examples.Docking.FirstLook
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			//// Need for downloading the grid assembly.
			Telerik.Windows.Controls.RadGridView fakeGrid = new Telerik.Windows.Controls.RadGridView();
		}
	}
}
