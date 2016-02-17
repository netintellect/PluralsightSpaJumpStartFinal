using System.Windows;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.ZoomScroll
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {

            InitializeComponent();

            ExampleViewModel model = this.DataContext as ExampleViewModel;
            this.RadChart1.DataBound += model.ChartDataBound;
            model.ChartArea = this.chartArea;
        }
    }
}
