using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace Telerik.Windows.Examples.Window.Customization
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		CustomizationWindow window = new CustomizationWindow();
		DispatcherTimer dispatcherTimer = new DispatcherTimer();

		public Example()
		{
			InitializeComponent();

			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
#if WPF
			window.Owner = Application.Current.MainWindow;
#endif
			window.ResizeMode = ResizeMode.CanMinimize;
			window.Style = this.Resources["RadWindowStyle"] as Style;
			window.Closed += new EventHandler<WindowClosedEventArgs>(window_Closed);

			window.Width = 486;
			window.Height = 358;

			this.Loaded += OnExampleLoaded;
			this.Unloaded += OnExampleUnloaded;

			dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
			dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

		}
		void OnExampleUnloaded(object sender, RoutedEventArgs e)
		{
			window.Close();
			dispatcherTimer.Tick -= new EventHandler(dispatcherTimer_Tick);
		}

		void OnExampleLoaded(object sender, RoutedEventArgs e)
		{
			window.Show();

			Storyboard sb = window.Resources["ShowDetailsAnimation"] as Storyboard;
			sb.Begin();
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
