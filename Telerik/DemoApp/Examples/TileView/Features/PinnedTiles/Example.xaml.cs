namespace Telerik.Windows.Examples.TileView.Features.PinnedTiles
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
		}

		private void RadTileViewItem_PreviewPositionChanged(object sender, RadRoutedEventArgs e)
		{
			e.Handled = true;
		}
	}
}