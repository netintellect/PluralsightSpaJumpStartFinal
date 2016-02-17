using Telerik.Windows.Examples.TileView.Common;

namespace Telerik.Windows.Examples.TileView.Features.AutomaticScrolling
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();

			DataContext = SimpleItem.Generate(50);
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.DialogBox.Visibility = System.Windows.Visibility.Collapsed;
		}
	}
}