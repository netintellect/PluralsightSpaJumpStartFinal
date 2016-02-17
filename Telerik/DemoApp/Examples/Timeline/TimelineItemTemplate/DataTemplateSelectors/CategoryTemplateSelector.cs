using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Timeline;

namespace Telerik.Windows.Examples.Timeline.TimelineItemTemplate
{
    public class CategoryTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PhysicsTemplate { get; set; }
        public DataTemplate ChemistryTemplate { get; set; }
        public DataTemplate MedicineTemplate { get; set; }
        public DataTemplate LiteratureTemplate { get; set; }
        public DataTemplate PeaceTemplate { get; set; }
        public DataTemplate EconomyTemplate { get; set; }

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

            switch (nobelPrizeItem.Category)
            {
                case "Physics":
                    return this.PhysicsTemplate;
                case "Chemistry":
                    return this.ChemistryTemplate;
                case "Medicine":
                    return this.MedicineTemplate;
                case "Literature":
                    return this.LiteratureTemplate;
                case "Peace":
                    return this.PeaceTemplate;
                case "Economics":
                    return this.EconomyTemplate;
                default:
                    return base.SelectTemplate(item, container);
            }
        }
    }
}
