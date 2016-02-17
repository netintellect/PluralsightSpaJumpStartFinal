using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Map.DynamicLayer
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

			this.visualizationLayer.VirtualizationSource = new VirtualizationSource(this.LayoutRoot.DataContext as ExampleViewModel);
        }

		private void Store_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ExampleViewModel exampleViewModel = this.LayoutRoot.DataContext as ExampleViewModel;
			FrameworkElement control = sender as FrameworkElement;
			if (exampleViewModel != null && control != null)
			{
				StoreLocation storeLocation = control.DataContext as StoreLocation;
				if (storeLocation != null)
				{
					if (exampleViewModel.ZoomLevel == 19 &&
						exampleViewModel.Center == storeLocation.Location)
					{
						exampleViewModel.ZoomLevel = 10;
					}
					else
					{
						exampleViewModel.ZoomLevel = 19;
						exampleViewModel.Center = storeLocation.Location;
					}
				}
				e.Handled = true;
			}
		}

		private void Area_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			ExampleViewModel exampleViewModel = this.LayoutRoot.DataContext as ExampleViewModel;
			FrameworkElement control = sender as FrameworkElement;
			if (exampleViewModel != null && control != null)
			{
				StoreLocation storeLocation = control.DataContext as StoreLocation;
				if (storeLocation != null)
				{
					exampleViewModel.ZoomLevel = 11;
					exampleViewModel.Center = storeLocation.Location;
				}
				e.Handled = true;
			}
		}
    }
}
