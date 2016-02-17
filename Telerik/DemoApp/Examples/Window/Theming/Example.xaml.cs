using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;

#if SILVERLIGHT
using WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation;
#endif

namespace Telerik.Windows.Examples.Window.Theming
{
	public partial class Example : UserControl
	{
		RadWindow window = new RadWindow();
		DispatcherTimer dispatcherTimer = new DispatcherTimer();

		public Example()
		{
			InitializeComponent();

			window.Header = "New version available!";
#if WPF
			window.Owner = Application.Current.MainWindow;
#endif
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			window.ResizeMode = ResizeMode.CanMinimize;

			int contentWidth = 630;
			int contentHeight = 320;

			window.Content = new ThemingUserControl();
			window.Closed += new EventHandler<WindowClosedEventArgs>(window_Closed);

			window.Width = contentWidth + 14;
			window.Height = contentHeight + 34;

			this.Loaded += OnExampleLoaded;
			this.Unloaded += OnExampleUnloaded;

			dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
		}

		void OnExampleUnloaded(object sender, RoutedEventArgs e)
		{
			dispatcherTimer.Tick -= this.dispatcherTimer_Tick;
			window.Close();
		}

		void OnExampleLoaded(object sender, RoutedEventArgs e)
		{
			window.Show();
			dispatcherTimer.Tick += this.dispatcherTimer_Tick;
		}

		private void window_Closed(object sender, EventArgs e)
		{
			this.reopen.Visibility = Visibility.Visible;
			dispatcherTimer.Start();
		}

		private void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			dispatcherTimer.Stop();
			this.reopen.Visibility = Visibility.Collapsed;
			window.Show();
		}
	}
}