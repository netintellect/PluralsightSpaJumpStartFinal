using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Carousel.RadCarouselPanel
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		private static Thickness DefaultPathPadding = new Thickness(60.0,10.0,60.0,10.0);

		public Example()
		{
			InitializeComponent();

			this.CreateCarouselPanelBindings();
		}

		private void CreateCarouselPanelBindings()
		{
			this.isContinuousCheckBox.SetBinding(CheckBox.IsCheckedProperty, CreatePanelBinding("IsContinuous"));
			this.scalingCheckBox.SetBinding(CheckBox.IsCheckedProperty, CreatePanelBinding("IsScalingEnabled"));
			this.opacityCheckBox.SetBinding(CheckBox.IsCheckedProperty, CreatePanelBinding("IsOpacityEnabled"));
			this.skewAngleXCheckBox.SetBinding(CheckBox.IsCheckedProperty, CreatePanelBinding("IsSkewAngleXEnabled"));
			this.itemPerPageSlider.SetBinding(System.Windows.Controls.Slider.ValueProperty, CreatePanelBinding("ItemsPerPage"));
		}

		private Binding CreatePanelBinding(string panelPropertyName)
		{
			Binding binding = new Binding(panelPropertyName);
			binding.Mode = BindingMode.TwoWay;
			binding.Source = this.Panel;

			return binding;
		}

		protected override void OnInitialized(EventArgs e)
		{
			this.Panel.IsPathVisible = true;
			base.OnInitialized(e); 
		}

		private void MoveForward_Click(object sender, RoutedEventArgs e)
		{
			this.Panel.LineRight();
		}

		private void MoveBackward_Click(object sender, RoutedEventArgs e)
		{
			this.Panel.LineLeft();
		}

		private void NextPage_Click(object sender, RoutedEventArgs e)
		{
			this.Panel.PageRight();
		}

		private void PreviousPage_Click(object sender, RoutedEventArgs e)
		{
			this.Panel.PageLeft();
		}

        private void PathCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0)
                return;

            RadComboBoxItem item = e.AddedItems[0] as RadComboBoxItem;

            string pathKey = item.Content as string;
            if (pathKey == "Default")
            {
                this.SetPath(null, DefaultPathPadding);
                this.Panel.PathPadding = DefaultPathPadding;
                this.Panel.Path = null;
            }
            else if (pathKey == "SerpentinePath")
            {
                Path path = (Path)this.FindResource(pathKey);
                this.SetPath(path, new Thickness(150, 50, 0, 50));
            }
            else
            {
                SetPath((Path)this.FindResource(pathKey), DefaultPathPadding);
            }
        }

		private void SetPath(Path path, Thickness padding)
		{
			this.Panel.PathPadding = padding;
			this.Panel.Path = path;
		}
	}
}