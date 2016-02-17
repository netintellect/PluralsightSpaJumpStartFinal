using Examples.MediaPlayer.CS.Silverlight.Common;

namespace Telerik.Windows.Examples.MediaPlayer.DataBinding
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
			player.ItemsSource = ItemsFactory.GetItems();
		}
	}
}
