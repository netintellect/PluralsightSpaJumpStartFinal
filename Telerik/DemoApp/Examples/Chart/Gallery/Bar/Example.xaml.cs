using System.Windows.Controls;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.Gallery.Bar
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

        private void SetHorizontalOrientationCheckbox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.RadChart1 == null)
                return;
             
            this.RadChart1.DefaultSeriesDefinition = new HorizontalBarSeriesDefinition();
            this.RadChart1.Rebind();
        }

        private void SetHorizontalOrientationCheckbox_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.RadChart1.DefaultSeriesDefinition = new BarSeriesDefinition();
            this.RadChart1.Rebind();
        }
	}
}
