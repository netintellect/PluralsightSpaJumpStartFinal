using System.Collections.Generic;
using System.Collections.ObjectModel;
using Telerik.Charting;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    public class CustomSpiderLabelsStrategy : PieChartSmartLabelsStrategy
    {
        protected override void CalculateLabelsPositions(Charting.RadRect plotAreaClip, ReadOnlyCollection<ChartSeriesLabelPositionInfo> labelPositionInfos)
        {
            PieChartSmartLabelsStrategyProxy proxy = new PieChartSmartLabelsStrategyProxy();

            proxy.DisplayMode = PieChartLabelsDisplayMode.Outside;
            proxy.CalculatePositions(plotAreaClip, labelPositionInfos);

            List<RadRect> regionLabelSlots = new List<RadRect>();
            foreach (ChartSeriesLabelPositionInfo info in labelPositionInfos)
            {
                if (info.DataPoint.DataItem is Region)
                {
                    regionLabelSlots.Add(info.FinalLayoutSlot);
                }
            }

            proxy.DisplayMode = PieChartLabelsDisplayMode.Spider;
            proxy.CalculatePositions(plotAreaClip, labelPositionInfos);

            int i = 0;
            foreach (ChartSeriesLabelPositionInfo info in labelPositionInfos)
            {
                if (info.DataPoint.DataItem is Region)
                {
                    info.FinalLayoutSlot = regionLabelSlots[i];
                    i++;
                }
            }
        }

        private class PieChartSmartLabelsStrategyProxy : PieChartSmartLabelsStrategy
        {
            public void CalculatePositions(Charting.RadRect plotAreaClip, ReadOnlyCollection<ChartSeriesLabelPositionInfo> labelPositionInfos)
            {
                this.CalculateLabelsPositions(plotAreaClip, labelPositionInfos);
            }
        }
    }
}
