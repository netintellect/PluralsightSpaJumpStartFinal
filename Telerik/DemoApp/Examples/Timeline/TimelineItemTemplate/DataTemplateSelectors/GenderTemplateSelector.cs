using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Timeline;

namespace Telerik.Windows.Examples.Timeline.TimelineItemTemplate
{
    public class GenderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MaleTemplate { get; set; }
        public DataTemplate FemaleTemplate { get; set; }
        public DataTemplate InstitutionTemplate { get; set; }

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

            switch (nobelPrizeItem.Gender)
            {
                case "M":
                    return this.MaleTemplate;
                case "F":
                    return this.FemaleTemplate;
                case "":
                    return this.InstitutionTemplate;
                default:
                    return base.SelectTemplate(item, container);
            }
        }
    }
}
