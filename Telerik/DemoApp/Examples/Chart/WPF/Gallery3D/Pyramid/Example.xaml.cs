using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.Gallery3D.Pyramid
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
        public Example()
        {
            InitializeComponent();
        }

		private void ExampleControl_Loaded(object sender, RoutedEventArgs e)
		{
            CameraExtension camera = this.Resources["camera"] as CameraExtension;
            camera.RotateX(10);
            camera.RotateY(10);
            this.RadChart1.DefaultView.ChartArea.Extensions.Add(camera);
		}
	}
}
