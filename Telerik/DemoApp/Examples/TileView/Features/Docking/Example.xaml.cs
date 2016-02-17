using Telerik.Windows.Examples.TileView.Common;
using Telerik.Windows.Controls;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.TileView.Features.Docking
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.dockPosition.Items.Add(Dock.Right);
			this.dockPosition.Items.Add(Dock.Left);
			this.dockPosition.Items.Add(Dock.Top);
			this.dockPosition.Items.Add(Dock.Bottom);

			DataContext = SimpleItem.Generate(50);
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.DialogBox.Visibility = System.Windows.Visibility.Collapsed;
		}
	}
}