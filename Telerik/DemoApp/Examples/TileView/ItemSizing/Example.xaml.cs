using Telerik.Windows.Examples.TileView.Common;

namespace Telerik.Windows.Examples.TileView.ItemSizing
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.DataContext = new MainViewModel();
		}
	}
}