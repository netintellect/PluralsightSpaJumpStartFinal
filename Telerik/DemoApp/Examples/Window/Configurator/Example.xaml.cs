using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using System.Globalization;

#if SILVERLIGHT
using WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation;
#endif


namespace Telerik.Windows.Examples.Window.Configurator
{
	public partial class Example : UserControl
	{
		WindowConfigurationViewModel viewModel;

		public Example()
		{
			this.DataContext = this.viewModel = new WindowConfigurationViewModel();

			InitializeComponent();

			GetNames<ResizeMode>(resizeModeComboBox);
			GetNames<WindowStartupLocation>(windowStartupLocationComboBox);
			GetNames<WindowState>(windowStateComboBox);

			NumberFormatInfo nfi = new NumberFormatInfo();
			nfi.NumberDecimalDigits = 0;

			numHeight.NumberFormatInfo = nfi;
			numWidth.NumberFormatInfo = nfi;
			numLeft.NumberFormatInfo = nfi;
			numTop.NumberFormatInfo = nfi;

            this.viewModel.CanClose = true;
			this.viewModel.CanMove = true;
			this.viewModel.RestoreMinimizedLocation = false;
			this.viewModel.Height = 230;
			this.viewModel.Width = 390;
			this.viewModel.ResizeMode = ResizeMode.CanResize;
			this.viewModel.StartupLocation = WindowStartupLocation.CenterScreen;
			this.viewModel.State = WindowState.Normal;

#if WPF
            var primaryScreenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            var primaryScreenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.viewModel.Left = (primaryScreenWidth / 2) - ((double)this.viewModel.Width / 2);
            this.viewModel.Top = (primaryScreenHeight / 2) - ((double)this.viewModel.Height / 2);
#endif

			this.Loaded += OnExampleLoaded;
			this.Unloaded += OnExampleUnloaded;
		}

		void OnExampleLoaded(object sender, RoutedEventArgs e)
		{
			if (!this.Window.IsOpen)
			{
				this.Window.Show();
			}
		}

		void OnExampleUnloaded(object sender, RoutedEventArgs e)
		{
			if (window != null)
			{
				window.Close();
			}
		}

		private RadWindow window;

		public RadWindow Window
		{
			get
			{
				if (this.window == null)
				{
					this.window = this.CreateWindow();

				}

				return this.window;
			}
		}

		private void GetNames<T>(RadComboBox combo)
		{
			Type type = typeof(T);
			IEnumerable<string> names = type
				.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
				.Select((FieldInfo x) => x.Name)
				.Where((string n) => (n != "CanMaximize" && n != "CenterParent"));

			foreach (string name in names)
			{
				combo.Items.Add((T)Enum.Parse(type, name, true));
			}
		}


		private void OnShowModalClicked(object sender, RoutedEventArgs e)
		{
			if (!this.Window.IsOpen)
			{
				this.Window.ShowDialog();
			}
		}

		private void OnShowClicked(object sender, RoutedEventArgs e)
		{
			if (!this.Window.IsOpen)
			{
				this.Window.Show();
			}
		}

		private RadWindow CreateWindow()
		{
			window = new ExampleWindow
			{
				DataContext = this.DataContext
			};

#if WPF
			window.Owner = Application.Current.MainWindow;
#endif
			window.Closed += new EventHandler<WindowClosedEventArgs>(window_Closed);
			window.Loaded += new RoutedEventHandler(window_Loaded);
			return window;
		}

		void window_Loaded(object sender, RoutedEventArgs e)
		{
			this.viewModel.IsOpen = true;
		}

		void window_Closed(object sender, WindowClosedEventArgs e)
		{
			this.viewModel.IsOpen = false;
		}
	}
}
