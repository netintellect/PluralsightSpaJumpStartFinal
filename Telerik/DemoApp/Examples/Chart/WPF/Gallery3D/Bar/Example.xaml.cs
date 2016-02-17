using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.Gallery3D.Bar
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

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
            this.RadChart1.DefaultView.ChartArea.Extensions.Add(this.Resources["camera"] as CameraExtension);
		}
	}
}
