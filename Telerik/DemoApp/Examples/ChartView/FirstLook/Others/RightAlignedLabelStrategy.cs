using System.Windows;
using Telerik.Charting;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.FirstLook
{
    public class RightAlignedLabelStrategy : Telerik.Windows.Controls.ChartView.ChartSeriesLabelStrategy
    {
        public double Offset { get; set; }

        public override Controls.ChartView.LabelStrategyOptions Options
        {
            get { return Telerik.Windows.Controls.ChartView.LabelStrategyOptions.Arrange; }
        }

        public override Charting.RadRect GetLabelLayoutSlot(Charting.DataPoint point, System.Windows.FrameworkElement visual, int labelIndex)
        {

#if SILVERLIGHT
            Size size = new Size(visual.ActualWidth + visual.Margin.Left + visual.Margin.Right, visual.ActualHeight + visual.Margin.Top + visual.Margin.Bottom);
#else
            Size size = visual.DesiredSize;
#endif

            var series = (ChartSeries)point.Presenter;
            double top = point.LayoutSlot.Center.Y - (size.Height / 2);
            double left = series.Chart.PlotAreaClip.Right - size.Width + this.Offset;

            return new RadRect(left, top, size.Width, size.Height);
        }
    }
}
