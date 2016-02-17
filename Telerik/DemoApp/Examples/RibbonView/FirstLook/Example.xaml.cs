using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RibbonView.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{	
		public Example()
		{
			StyleManager.ApplicationTheme = new Windows8Theme();
			InitializeComponent();
		}

		private void RibbonGroup_LaunchDialog(object sender, RadRoutedEventArgs e)
		{
			RadWindow.Alert("Show Group Options");
		}
		
		private void TextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			this.ChartTools.IsActive = false;
		}

		private void ChartImage_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			this.ChartTools.IsActive = true;
		}
	}
}
