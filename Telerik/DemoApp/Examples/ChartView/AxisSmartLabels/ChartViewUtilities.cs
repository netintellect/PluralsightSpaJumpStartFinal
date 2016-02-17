using System;
using System.Collections.Generic;
using System.Windows;
using Telerik.Charting;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;
using System.Windows.Media;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.AxisSmartLabels
{
    public static class ChartViewUtilities
    {
        public static readonly DependencyProperty ShouldPositionTrackBallCloseToDataPointProperty = DependencyProperty.RegisterAttached(
            "ShouldPositionTrackBallCloseToDataPoint",
            typeof(bool),
            typeof(ChartViewUtilities),
            new PropertyMetadata(ShouldPositionTrackBallCloseToDataPointChanged));

        public static readonly DependencyProperty TrackedPointFillProperty = DependencyProperty.RegisterAttached(
            "TrackedPointFill",
            typeof(Brush),
            typeof(ChartViewUtilities),
            new PropertyMetadata(TrackedPointFillChanged));

        public static readonly DependencyProperty TrackBallGroupProperty = DependencyProperty.RegisterAttached(
            "TrackBallGroup",
            typeof(string),
            typeof(ChartViewUtilities),
            new PropertyMetadata(TrackBallGroupChanged));

        public static readonly DependencyProperty ChartAlignmentGroupProperty = DependencyProperty.RegisterAttached(
            "ChartAlignmentGroup",
            typeof(string),
            typeof(ChartViewUtilities),
            new PropertyMetadata(ChartAlignmentGroupChanged));

        private static readonly DependencyProperty LastTrackedDataPointProperty = DependencyProperty.RegisterAttached(
            "LastTrackedDataPoint",
            typeof(DataPoint),
            typeof(ChartViewUtilities),
            new PropertyMetadata());

        private static Dictionary<string, List<WeakReference>> alignmentGroupsDict = new Dictionary<string, List<WeakReference>>();
        private static Dictionary<string, List<WeakReference>> trackBallGroupToBehaviorsDict = new Dictionary<string, List<WeakReference>>();
        private static bool isAlignmentUpdateScheduled;
        private static int moveTrackBallsCallsCount;

        public static bool GetShouldPositionTrackBallCloseToDataPoint(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShouldPositionTrackBallCloseToDataPointProperty);
        }

        public static void SetShouldPositionTrackBallCloseToDataPoint(DependencyObject obj, bool value)
        {
            obj.SetValue(ShouldPositionTrackBallCloseToDataPointProperty, value);
        }

        public static Brush GetTrackedPointFill(DependencyObject obj)
        {
            return (Brush)obj.GetValue(TrackedPointFillProperty);
        }

        public static void SetTrackedPointFill(DependencyObject obj, Brush value)
        {
            obj.SetValue(TrackedPointFillProperty, value);
        }

        public static string GetTrackBallGroup(DependencyObject obj)
        {
            return (string)obj.GetValue(TrackBallGroupProperty);
        }

        public static void SetTrackBallGroup(DependencyObject obj, string value)
        {
            obj.SetValue(TrackBallGroupProperty, value);
        }

        public static string GetChartAlignmentGroup(DependencyObject obj)
        {
            return (string)obj.GetValue(ChartAlignmentGroupProperty);
        }

        public static void SetChartAlignmentGroup(DependencyObject obj, string value)
        {
            obj.SetValue(ChartAlignmentGroupProperty, value);
        }

        private static DataPoint GetLastTrackedDataPoint(DependencyObject obj)
        {
            return (DataPoint)obj.GetValue(LastTrackedDataPointProperty);
        }

        private static void SetLastTrackedDataPointProperty(DependencyObject obj, DataPoint value)
        {
            obj.SetValue(LastTrackedDataPointProperty, value);
        }

        private static void ShouldPositionTrackBallCloseToDataPointChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var behavior = (ChartTrackBallBehavior)target;
            var positionNextToDP = (bool)args.NewValue;

            if (positionNextToDP)
            {
                behavior.TrackInfoUpdated += TrackBallBehavior_TrackInfoUpdated;
            }
            else
            {
                behavior.TrackInfoUpdated -= TrackBallBehavior_TrackInfoUpdated;
            }
        }

        private static void TrackedPointFillChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var behavior = (ChartTrackBallBehavior)target;

            var oldFill = (Brush)args.OldValue;
            if (oldFill != null)
            {
                behavior.TrackInfoUpdated -= TrackBallBehavior_TrackInfoUpdated;
            }

            var newFill = (Brush)args.NewValue;
            if (newFill != null)
            {
                behavior.TrackInfoUpdated += TrackBallBehavior_TrackInfoUpdated;
            }
        }

        private static void TrackBallGroupChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            ChartTrackBallBehavior behavior = (ChartTrackBallBehavior)target;

            string oldGroup = (string)args.OldValue;
            if (oldGroup != null)
            {
                behavior.TrackInfoUpdated -= TrackBallBehavior_TrackInfoUpdated;
                RemoveReference(trackBallGroupToBehaviorsDict[oldGroup], behavior);
                if (trackBallGroupToBehaviorsDict[oldGroup].Count == 0)
                {
                    trackBallGroupToBehaviorsDict.Remove(oldGroup);
                }
            }

            string newGroup = (string)args.NewValue;
            if (newGroup != null)
            {
                if (!trackBallGroupToBehaviorsDict.ContainsKey(newGroup))
                {
                    trackBallGroupToBehaviorsDict[newGroup] = new List<WeakReference>();
                }
                trackBallGroupToBehaviorsDict[newGroup].Add(new WeakReference(behavior));
                behavior.TrackInfoUpdated += TrackBallBehavior_TrackInfoUpdated;
            }
        }

        private static void ChartAlignmentGroupChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var chart = (RadCartesianChart)target;

            var group = (string)args.OldValue;
            if (group != null)
            {
                RemoveReference(alignmentGroupsDict[group], chart);
                if (alignmentGroupsDict[group].Count == 0)
                {
                    alignmentGroupsDict.Remove(group);
                }
                chart.LayoutUpdated -= Chart_LayoutUpdated;
            }

            group = (string)args.NewValue;
            if (group != null)
            {
                if (!alignmentGroupsDict.ContainsKey(group))
                {
                    alignmentGroupsDict[group] = new List<WeakReference>();
                }
                alignmentGroupsDict[group].Add(new WeakReference(chart));
                chart.LayoutUpdated += Chart_LayoutUpdated;
            }
        }

        private static void TrackBallBehavior_TrackInfoUpdated(object sender, TrackBallInfoEventArgs e)
        {
            var behavior = (ChartTrackBallBehavior)sender;
            HandleTrackInfoPositioning(behavior, e.Context.ClosestDataPoint);
            HandleTrackedPointFill(behavior, e.Context.DataPointInfos);
            HandleSyncedTrackBalls(behavior, e.Context.DataPointInfos);
        }

        private static void HandleTrackInfoPositioning(ChartTrackBallBehavior behavior, DataPointInfo closestDataPoint)
        {
            if (closestDataPoint == null || !GetShouldPositionTrackBallCloseToDataPoint(behavior))
            {
                return;
            }

            var infoControl = Telerik.Windows.Controls.ChildrenOfTypeExtensions.FindChildByType<TrackBallInfoControl>(behavior.Chart);
            double top = closestDataPoint.DataPoint.LayoutSlot.Y - behavior.Chart.PlotAreaClip.Y - 25;
            infoControl.Margin = new Thickness(0, top, 0, 0);

        }

        private static void HandleTrackedPointFill(ChartTrackBallBehavior behavior, List<DataPointInfo> dataPointInfos)
        {
            Brush fill = GetTrackedPointFill(behavior);
            if (fill == null)
            {
                return;
            }

            DataPoint lastTrackedPoint = GetLastTrackedDataPoint(behavior);
            UIElement visual = TryGetDataPointVisual(lastTrackedPoint);
            Border border = visual as Border;
            if (border != null)
            {
                border.ClearValue(Border.BackgroundProperty);
            }

            DataPoint newDataPoint = (dataPointInfos.Count > 0) ? dataPointInfos[0].DataPoint : null;
            SetLastTrackedDataPointProperty(behavior, newDataPoint);
            visual = TryGetDataPointVisual(newDataPoint);
            border = visual as Border;
            if (border != null)
            {
                border.Background = fill;
            }
        }

        private static void HandleSyncedTrackBalls(ChartTrackBallBehavior behavior, List<DataPointInfo> dataPointInfos)
        {
            string trackBallGroup = GetTrackBallGroup(behavior);
            if (trackBallGroup == null)
            {
                return;
            }

            var chart = (RadCartesianChart)behavior.Chart;
            object xCategory = null;
            if (dataPointInfos.Count != 0)
            {
                var center = dataPointInfos[0].DataPoint.LayoutSlot.Center;
                var dataTuple = chart.ConvertPointToData(new Point(center.X, center.Y));
                xCategory = dataTuple.FirstValue;
            }
            MoveTrackBallsSafe(GetTrackBallGroup(behavior), xCategory, behavior);
        }

        private static void MoveTrackBallsSafe(string p, object xCategory, ChartTrackBallBehavior behavior)
        {
            moveTrackBallsCallsCount++;

            // Avoid a cycle when different categories are found due to precision.
            if (moveTrackBallsCallsCount < 20)
            {
                MoveTrackBalls(GetTrackBallGroup(behavior), xCategory, behavior);
            }

            moveTrackBallsCallsCount--;
        }

        private static void MoveTrackBalls(string group, object xCategory, ChartTrackBallBehavior behaviorOriginator)
        {
            foreach (var behav in GetLiveInstances<ChartTrackBallBehavior>(trackBallGroupToBehaviorsDict[group]))
            {
                if (behav != behaviorOriginator)
                {
                    var chart = (RadCartesianChart)behav.Chart;
                    var position = chart.ConvertDataToPoint(new DataTuple(xCategory, null));
                    position.Y = chart.ActualHeight / 2;

                    behav.Position = position;
                }
            }
        }

        private static UIElement TryGetDataPointVisual(Telerik.Charting.DataPoint dataPoint)
        {
            UIElement visual = null;

            if (dataPoint != null)
            {
                var series = dataPoint.Presenter as PointTemplateSeries;
                if (series != null)
                {
                    visual = series.GetDataPointVisual(dataPoint);
                }
            }

            return visual;
        }

        private static void Chart_LayoutUpdated(object sender, EventArgs e)
        {
            if (!isAlignmentUpdateScheduled)
            {
                RadCartesianChart chart = TryGetChart();
                if (chart == null)
                {
                    return;
                }

                isAlignmentUpdateScheduled = true;
                chart.Dispatcher.BeginInvoke((Action)(() =>
                {
                    isAlignmentUpdateScheduled = false;
                    AlignCharts();
                }));
            }
        }

        private static void AlignCharts()
        {
            foreach (string group in alignmentGroupsDict.Keys)
            {
                double maxLeftMargin = 0;
                double maxRightMargin = 0;

                foreach (var chart in GetLiveInstances<RadCartesianChart>(alignmentGroupsDict[group]))
                {
                    maxLeftMargin = Math.Max(maxLeftMargin, (chart.PlotAreaClip.X + chart.PanOffset.X));
                    maxRightMargin = Math.Max(maxRightMargin, chart.ActualWidth - (chart.PlotAreaClip.Right + chart.PanOffset.X));
                }

                foreach (var chart in GetLiveInstances<RadCartesianChart>(alignmentGroupsDict[group]))
                {
                    double chartRightMargin = chart.ActualWidth - (chart.PlotAreaClip.Right + chart.PanOffset.X);
                    double actualWidth = chart.ActualWidth + chart.Margin.Left + chart.Margin.Right;
                    chart.Margin = new Thickness(maxLeftMargin - (chart.PlotAreaClip.X + chart.PanOffset.X), chart.Margin.Top, Math.Round(maxRightMargin - chartRightMargin), chart.Margin.Bottom);
                }
            }
        }

        private static RadCartesianChart TryGetChart()
        {
            foreach (var group in alignmentGroupsDict)
            {
                foreach (var wr in group.Value)
                {
                    var chart = (RadCartesianChart)wr.Target;
                    if (chart != null)
                    {
                        return chart;
                    }
                }
            }

            return null;
        }

        private static IEnumerable<T> GetLiveInstances<T>(List<WeakReference> list)
        {
            foreach (var wr in list.ToArray())
            {
                var instance = (T)wr.Target;
                if (instance != null)
                {
                    yield return instance;
                }
            }

            RemoveReference(list, null);
        }

        private static void RemoveReference(List<WeakReference> list, object reference)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var wr = list[i];
                if (reference == wr.Target)
                {
                    list.RemoveAt(i);
                }
            }
        }
    }
}
