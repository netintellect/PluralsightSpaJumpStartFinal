using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Animations;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.ChartView.MultipleAxes
{
    public partial class Example : UserControl
    {
        private Ellipse selectedShape;

        public Example()
        {
            InitializeComponent();
        }

        private void RadMap1_Loaded(object sender, RoutedEventArgs e)
        {
            var ellipses = this.AdornerLayer.ChildrenOfType<Ellipse>();
            if (ellipses.Count() == 0)
                return;

            var ukShape = ellipses.Single(item => (string)item.Tag == "United Kingdom");
            this.UpdateSelection(ukShape);

            this.virtualizationSource.ReadAsync();
        }

        private void GdpEllipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var shape = sender as Ellipse;
            if (this.selectedShape == shape)
                return;

            this.UpdateSelection(shape);
        }

        private void MapVirtualizationSource_ReadShapeDataCompleted(object sender, ReadShapeDataCompletedEventArgs e)
        {
            this.EnableChartAnimations();
        }

        private void UpdateSelection(Ellipse shape)
        {
            if (this.selectedShape != null)
                this.selectedShape.Fill = new SolidColorBrush(Color.FromArgb(255, 142, 196, 65));

            this.selectedShape = shape;
            this.selectedShape.Fill = new SolidColorBrush(Color.FromArgb(255, 235, 122, 42));

            (this.DataContext as ExampleViewModel).SelectedCountryName = this.selectedShape.Tag.ToString();
        }

        private void EnableChartAnimations()
        {
            foreach (CartesianSeries series in this.chart.Series)
            {
                BarSeries barSeries = series as BarSeries;
                if (barSeries != null)
                {
                    ChartAnimationUtilities.SetCartesianAnimation(barSeries, CartesianAnimation.Rise);
                    continue;
                }

                LineSeries lineSeries = series as LineSeries;
                if (lineSeries != null)
                {
                    ChartAnimationUtilities.SetCartesianAnimation(lineSeries, CartesianAnimation.Stretch);
                    continue;
                }
            }
        }
    }
}
