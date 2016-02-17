using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
#if SILVERLIGHT
using WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation;
#endif

namespace Telerik.Windows.Examples.Window.UserControlExample
{
	public partial class Example : UserControl
	{
		RadWindow window = new RadWindow();

		public Example()
		{
			InitializeComponent();

			this.Loaded += OnExampleLoaded;
			this.Unloaded += OnExampleUnloaded;
		}

		void OnExampleUnloaded(object sender, RoutedEventArgs e)
		{
			this.window.Close();
		}

		void OnExampleLoaded(object sender, RoutedEventArgs e)
		{
			window.Width = 360;
			window.Height = 260;

			window.Content = new DatePickerUserControl();
#if WPF
			window.Owner = Application.Current.MainWindow;
#endif
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			window.Header = "Daily Report";
			window.CanClose = false;
			window.Show();
		}
	}
}