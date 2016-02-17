using Telerik.Charting;

namespace Telerik.Windows.Examples.ChartView.Gallery.Bubble
{
    public class CustomBubbleSizeSelector : RelativeBubbleSizeSelector
    {
        public Example UserControl { get; set; }

        public RadSize SelectBubbleSize(double value)
        {
            return this.SelectBubbleSize(new DummyBubbleDataPoint { BubbleSize = value });
        }

        public override RadSize SelectBubbleSize(IBubbleDataPoint dataPoint)
        {
            if (!(dataPoint is DummyBubbleDataPoint))
            {
                this.UserControl.ScheduleLegendUpdate();
            }

            return base.SelectBubbleSize(dataPoint);
        }

        private class DummyBubbleDataPoint : IBubbleDataPoint
        {
            public double? BubbleSize { get; set; }
            public object DataItem { get; set; }
            public IChartElementPresenter Presenter { get; set; }
        }
    }
}
