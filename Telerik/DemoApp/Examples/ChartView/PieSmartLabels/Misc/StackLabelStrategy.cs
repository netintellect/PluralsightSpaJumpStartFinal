using Telerik.Charting;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    public class StackLabelStrategy : ChartSeriesLabelStrategy
    {
        public override LabelStrategyOptions Options
        {
            get { return LabelStrategyOptions.Content; }
        }

        public override object GetLabelContent(Charting.DataPoint point, int labelIndex)
        {
            CategoricalDataPoint dataPoint = (CategoricalDataPoint)point;
            ChartSeries series = (ChartSeries)point.Presenter;
            RadCartesianChart chart = (RadCartesianChart)series.Chart;
            if (chart.Series[chart.Series.Count - 1] != series)
            {
                return string.Empty;
            }

            double sum = 0;
            foreach (BarSeries barSeries in chart.Series)
            {
                foreach (CategoricalDataPoint dp in barSeries.DataPoints)
                {
                    if (object.Equals(dp.Category, dataPoint.Category))
                    {
                        sum += dp.Value.Value;
                        break;
                    }
                }
            }

            return string.Format("{0:C0}", sum);
        }
    }
}
