using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.TileView.Common;
using Telerik.Windows.Examples.TileView.Common.FirstLook;
using Telerik.Windows.Controls.TileView;
using System;
using System.Windows;
using System.Windows.Input;
namespace Telerik.Windows.Examples.TileView.Features.DifferentSizes
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{	
			InitializeComponent();

			this.dragMode.Items.Add(TileViewDragMode.Swap);
			this.dragMode.Items.Add(TileViewDragMode.Slide);

			this.DataContext = new MainViewModel();

			this.myCalandar.SelectedDate = DateTime.Now;
		}

		private void OnMouseDownPlayMedia(object sender, MouseButtonEventArgs args)
        {
            this.PauseMediaButton.Visibility = Visibility.Visible; 
            this.PlayMediaButton.Visibility = Visibility.Collapsed; 
            this.myMediaElement.Play();

			InitializePropertyValues();
		}

		private void OnMouseDownPauseMedia(object sender, MouseButtonEventArgs args)
        {
            this.PlayMediaButton.Visibility = Visibility.Visible;
            this.PauseMediaButton.Visibility = Visibility.Collapsed;
			this.myMediaElement.Pause();
		}

		private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
		{
			this.myMediaElement.Volume = volumeSlider.Value;
		}

		private void Element_MediaEnded(object sender, EventArgs e)
		{
			this.myMediaElement.Stop();
		}

		private void InitializePropertyValues()
		{
			this.myMediaElement.Volume = volumeSlider.Value;
		}
	}
}