using System;
using System.Windows.Controls;
using Telerik.Charting;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.Annotations
{
    public partial class AppleChart : UserControl
    {
        public AppleChart()
        {
            InitializeComponent();
        }

        public event EventHandler<DataPointEventArgs> ClosestDataPointChanged;

        private void OnClosestDataPointChanged(CategoricalDataPoint dataPoint)
        {
            if (this.ClosestDataPointChanged != null)
            {
                this.ClosestDataPointChanged(this, new DataPointEventArgs(dataPoint));
            }
        }

        private void ChartTrackBallBehavior_TrackInfoUpdated(object sender, TrackBallInfoEventArgs e)
        {
            CategoricalDataPoint closestDataPoint = e.Context.ClosestDataPoint == null ? null : e.Context.ClosestDataPoint.DataPoint as CategoricalDataPoint;
            this.OnClosestDataPointChanged(closestDataPoint);
        }
    }
}
