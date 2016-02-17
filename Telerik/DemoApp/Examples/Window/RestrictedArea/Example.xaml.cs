using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Window.RestrictedArea
{
	public partial class Example : UserControl
	{
		ExampleWindow window = new ExampleWindow();
		WindowViewModel viewModel;

		public Example()
		{
			InitializeComponent();
			this.viewModel = new WindowViewModel();
			this.DataContext = window.DataContext = viewModel;
			this.configuratorStackPanel.DataContext = viewModel;
			Binding windowBinding = new Binding("IsRestricted") { Mode = BindingMode.TwoWay, Source = viewModel };
			window.SetBinding(ExampleWindow.IsRestrictedProperty, windowBinding);
			
			this.viewModel.IsRestricted = true;
			
			window.Header = "Restricted RadWindow";
			window.Width = 300;
			window.Height = 200;
			window.ResizeMode = Controls.ResizeMode.NoResize;

			this.Loaded += this.Example_Loaded;
			this.Unloaded += this.Example_Unloaded;

			((FrameworkElement)Application.Current.RootVisual).SizeChanged += this.Example_SizeChanged;

		}

		public void SetRestrictedAreaMarginToRadWindow()
		{
			GeneralTransform generalTransform1 = this.restrictedAreaRectangle.TransformToVisual(Application.Current.RootVisual);
			Point topLeftOffset = generalTransform1.Transform(new Point(0, 0));
			Point bottomRightOffset = generalTransform1.Transform(new Point(this.restrictedAreaRectangle.RenderSize.Width, this.restrictedAreaRectangle.RenderSize.Height));
			
			double right = ((FrameworkElement)Application.Current.RootVisual).ActualWidth - bottomRightOffset.X;
			double bottom = ((FrameworkElement)Application.Current.RootVisual).ActualHeight - bottomRightOffset.Y;
			
			window.RestrictedAreaMargin = new Thickness(topLeftOffset.X, topLeftOffset.Y, right, bottom);
		}

		void Example_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.SetRestrictedAreaMarginToRadWindow();
		}

		void Example_Unloaded(object sender, RoutedEventArgs e)
		{
			this.window.Close();
		}

		void Example_Loaded(object sender, RoutedEventArgs e)
		{
			window.WindowStartupLocation = Controls.WindowStartupLocation.CenterScreen;
			window.Show();
			this.SetRestrictedAreaMarginToRadWindow();
		}
	}
}