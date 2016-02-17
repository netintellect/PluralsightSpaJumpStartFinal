using Telerik.Windows.Examples.TileView.Common;

namespace Telerik.Windows.Examples.TileView.Features.Animations
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();

			DataContext = SimpleItem.Generate(30);
			EasingComboBox.ItemsSource = EasingItem.GetEasings();
			EasingModeComboBox.ItemsSource = EasingItem.GetEasingModes();
		}
	}
}