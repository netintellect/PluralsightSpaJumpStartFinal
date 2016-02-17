using System.Windows.Controls;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.Gallery.RangeBar
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

            this.RadChart1.SeriesMappings[0].SeriesDefinition = new HorizontalRangeBarSeriesDefinition();
            this.RadChart1.Rebind();
        }

        private void SetHorizontalOrientationCheckbox_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.RadChart1.SeriesMappings[0].SeriesDefinition = new RangeBarSeriesDefinition();
            this.RadChart1.Rebind();
        }
	}
}
