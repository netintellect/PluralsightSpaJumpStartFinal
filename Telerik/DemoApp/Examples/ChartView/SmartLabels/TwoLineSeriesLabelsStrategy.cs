using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls.ChartView;
using System.Collections.ObjectModel;
using Telerik.Charting;

namespace Telerik.Windows.Examples.ChartView.SmartLabels
{
    public class TwoLineSeriesLabelsStrategy : ChartSmartLabelsStrategyBase
    {
        protected override void CalculateLabelsPositions(Charting.RadRect plotAreaClip, ReadOnlyCollection<ChartSeriesLabelPositionInfo> labelPositionInfos)
        {
            if (labelPositionInfos.Count == 0)
            {
                return;
            }

            LineSeries firstSeries = labelPositionInfos[0].DataPoint.Presenter as LineSeries;
            LineSeries secondSeries = null;

            foreach (var labelPositionInfo in labelPositionInfos)
            {
                if (labelPositionInfo.DataPoint.Presenter != firstSeries)
                {
                    secondSeries = labelPositionInfo.DataPoint.Presenter as LineSeries;
                    break;
                }
            }

            for (int i = 0; i < labelPositionInfos.Count; i++)
            {
                var label = labelPositionInfos[i];
                int index = label.DataPoint.CollectionIndex;
                LineSeries otherSeries = label.DataPoint.Presenter == firstSeries ? secondSeries : firstSeries;
                int sign = -1;
                if (otherSeries != null && ((CategoricalDataPoint)label.DataPoint).Value < otherSeries.DataPoints[index].Value)
                {
                    sign = 1;
                }

                RadRect finalSlot = label.DefaultLayoutSlot;
                foreach (RadRect slot in GetSlots(label.DataPoint.LayoutSlot, label.DefaultLayoutSlot, sign, plotAreaClip))
                {
                    finalSlot = AlignToPlotArea(slot, plotAreaClip);
                    if (!IntersectsPreviousLabels(finalSlot, labelPositionInfos, i) &&
                        !IntersectsPointMarks(finalSlot, labelPositionInfos))
                    {
                        break;
                    }
                }
                labelPositionInfos[i].FinalLayoutSlot = finalSlot;
            }
        }

        private static RadRect AlignToPlotArea(RadRect slot, RadRect plotAreaClip)
        {
            slot.X = Math.Min(slot.X, plotAreaClip.Right - slot.Width);
            slot.X = Math.Max(slot.X, plotAreaClip.X);
            slot.Y = Math.Min(slot.Y, plotAreaClip.Bottom - slot.Height);
            slot.Y = Math.Max(slot.Y, plotAreaClip.Y);

            return slot;
        }

        private bool IntersectsPreviousLabels(RadRect slot, ReadOnlyCollection<ChartSeriesLabelPositionInfo> labelPositionInfos, int index)
        {
            for (int i = index - 1; i >= 0; i--)
            {
                if (slot.IntersectsWith(labelPositionInfos[i].FinalLayoutSlot))
                    return true;
            }

            return false;
        }

        private bool IntersectsPointMarks(RadRect slot, ReadOnlyCollection<ChartSeriesLabelPositionInfo> labelPositionInfos)
        {
            for (int i = 0; i < labelPositionInfos.Count; i++)
            {
                RadRect pointMark = labelPositionInfos[i].DataPoint.LayoutSlot;
                pointMark.Width = Math.Max(1, pointMark.Width);
                pointMark.Height = Math.Max(1, pointMark.Width);

                if (slot.IntersectsWith(pointMark))
                    return true;
            }

            return false;
        }

        private IEnumerable<RadRect> GetSlots(RadRect pointMark, RadRect label, int sign, RadRect plotAreaClip)
        {
            double offset = sign > 0 ? 5 : (-label.Height - 3);
            int step = 1;

            for (int i = 0; ; i++)
            {
                double top = pointMark.Center.Y + offset + (sign * i * step);
                if (top > plotAreaClip.Bottom || top < plotAreaClip.Y)
                {
                    break;
                }

                yield return new RadRect(pointMark.Center.X - (label.Width / 2), top, label.Width, label.Height);
            }

            for (int i = 0; ; i++)
            {
                double top = pointMark.Center.Y + offset - (sign * i * step);
                if (top > plotAreaClip.Bottom || top < plotAreaClip.Y)
                {
                    break;
                }

                yield return new RadRect(pointMark.Center.X - (label.Width / 2), top, label.Width, label.Height);
            }

            yield return label;
        }
    }
}
