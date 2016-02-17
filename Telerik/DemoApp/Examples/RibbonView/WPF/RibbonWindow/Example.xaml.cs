using System.Windows;
using Telerik.Windows.Controls;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.RibbonView.WPF.RibbonWindow
{
	public partial class Example : UserControl
	{
		private RadRibbonWindow ribbonWindow;

		static Example()
		{
			RadRibbonWindow.IsWindowsThemeEnabled = false;
		}

		public Example()
		{
			StyleManager.ApplicationTheme = new Windows8Theme();
			InitializeComponent();
		}

		private void ShowRibbonWindow(object sender, RoutedEventArgs e)
		{
			ribbonWindow = new RadRibbonWindow();
			ribbonWindow.Content = new FirstLook.Example();
			ribbonWindow.Width = 800;
			ribbonWindow.Height = 600;
			ribbonWindow.Show();

			showButton.Content = "Please reload the example";
			showButton.IsEnabled = false;
		}

		private void UserControl_Unloaded(object sender, RoutedEventArgs e)
		{
			if (ribbonWindow != null)
			{
				ribbonWindow.Close();
			}
		}
	}
}
