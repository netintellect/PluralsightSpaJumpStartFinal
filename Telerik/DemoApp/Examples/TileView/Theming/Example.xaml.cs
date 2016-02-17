using Telerik.Windows.Examples.TileView.Common;
using Telerik.Windows.Controls;
namespace Telerik.Windows.Examples.TileView.Theming
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.DataContext = new Countries();
		}

		private void tileView1_TileStateChanged(object sender, RadRoutedEventArgs e)
		{
			RadTileViewItem item = e.OriginalSource as RadTileViewItem;
			if (item != null)
			{
				Country country = item.DataContext as Country;
				if (country != null)
				{
					country.State = item.TileState;
				}
			}
		}
	}
}