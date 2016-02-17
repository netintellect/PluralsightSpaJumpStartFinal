using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using Telerik.Windows.Controls.TileView;

namespace Telerik.Windows.Examples.ChartView.Gallery.Range
{
	public partial class Example : UserControl
	{
		protected Panel ConfigurationPanel
		{
			get
			{
				return QuickStart.GetConfigurationPanel(this);
			}
		}

		public Example()
		{
			InitializeComponent();
			this.BindConfigurationPanel();
		}

		private void BindConfigurationPanel()
		{
			if (this.ConfigurationPanel.DataContext == null)
			{
				this.ConfigurationPanel.DataContext = this.DataContext;
			}
		}

		private void RadTileView_TileStateChanged(object sender, RadRoutedEventArgs e)
		{
			var eventArgs = e as TileStateChangedEventArgs;
			var tile = (RadTileViewItem)e.OriginalSource;
			var chart = tile.ChildrenOfType<RadCartesianChart>().FirstOrDefault();
			if (chart != null)
			{
				chart.HorizontalAxis.TickThickness = eventArgs.TileState == TileViewItemState.Maximized ? 1 : 0;
			}
		}
	}
}
