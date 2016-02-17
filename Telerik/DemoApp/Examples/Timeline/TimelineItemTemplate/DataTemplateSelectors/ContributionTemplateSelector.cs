using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Timeline;

namespace Telerik.Windows.Examples.Timeline.TimelineItemTemplate
{
    public class ContributionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WholeTemplate { get; set; }
        public DataTemplate HalfTemplate { get; set; }
        public DataTemplate OneThirdTemplate { get; set; }
        public DataTemplate QuarterTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            TimelineDataItem data = item as TimelineDataItem;
            NobelPrize nobelPrizeItem;

            if (data == null)
                nobelPrizeItem = item as NobelPrize;
            else
                nobelPrizeItem = data.DataItem as NobelPrize;

            if (nobelPrizeItem == null)
                return base.SelectTemplate(item, container);

            if (nobelPrizeItem.Contribution == 100)
                return this.WholeTemplate;
            else if (nobelPrizeItem.Contribution == 50)
                return this.HalfTemplate;
            else if (nobelPrizeItem.Contribution == 25)
                return this.QuarterTemplate;
            else
                return this.OneThirdTemplate;
        }
    }
}
