using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.TileView.Common;
using Telerik.Windows.Examples.TileView.Common.FirstLook;
namespace Telerik.Windows.Examples.TileView.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.DataContext = new MainViewModel();
		}

		private void tileView1_TileStateChanged(object sender, RadRoutedEventArgs e)
		{
			RadTileViewItem item = e.OriginalSource as RadTileViewItem;
			if (item != null)
			{
				RadFluidContentControl fluid = item.ChildrenOfType<RadFluidContentControl>().FirstOrDefault();
				if (fluid != null)
				{
					switch (item.TileState)
					{
						case TileViewItemState.Maximized:
							fluid.State = FluidContentControlState.Large;
							break;
						case TileViewItemState.Minimized:
							fluid.State = FluidContentControlState.Normal;
							break;
						case TileViewItemState.Restored:
							fluid.State = FluidContentControlState.Normal;
							break;
						default:
							break;
					}
				}
			}
		}
	}
}