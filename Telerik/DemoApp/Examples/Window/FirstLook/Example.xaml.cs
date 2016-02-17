using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

#if SILVERLIGHT
using WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation;
#endif

namespace Telerik.Windows.Examples.Window.FirstLook
{
	public partial class Example : UserControl
	{

        ExampleWindow window = new ExampleWindow();

		public Example()
		{
			InitializeComponent();

            this.Loaded += OnExampleLoaded;
            this.Unloaded += OnExampleUnloaded;
        }

        void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            window.Close();
        }

        void OnExampleLoaded(object sender, RoutedEventArgs e)
        {
#if WPF
			window.Owner = Application.Current.MainWindow;
#endif
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			window.Width = 670;
			window.Height = 340;
			window.CanClose = false;
            window.Show();
        }		
	}
}
