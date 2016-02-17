using System;
using System.Collections.Generic;
using System.Windows;
using Telerik.Windows.Controls.Timeline;

namespace Telerik.Windows.Examples.Timeline.Grouping
{
    public static class TimelineGroupStateSwitch
    {
        public static readonly DependencyProperty ExpandedGroupKeyProperty = DependencyProperty.RegisterAttached("ExpandedGroupKey",
            typeof(WorldWar2Event), typeof(TimelineGroupStateSwitch), new PropertyMetadata(OnExpandedGroupKeyChanged));

        public static WorldWar2Event GetExpandedGroupKey(DependencyObject obj)
        {
            return (WorldWar2Event)obj.GetValue(ExpandedGroupKeyProperty);
        }

        public static void SetExpandedGroupKey(DependencyObject obj, WorldWar2Event value)
        {
            obj.SetValue(ExpandedGroupKeyProperty, value);
        }

        private static void OnExpandedGroupKeyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TimelineItemGroupControl timelineGroup = sender as TimelineItemGroupControl;
            if (timelineGroup == null || e.NewValue == null)
                return;

            TimelineDataItemGroup groupData = timelineGroup.DataContext as TimelineDataItemGroup;
            timelineGroup.IsExpanded = string.Equals(groupData.GroupKey, ((WorldWar2Event)e.NewValue).Country);
        }
    }
}
