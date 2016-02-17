using System.Windows;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.DataBinding
{
    public class WayPointTemplateSelector : MapDataTemplateSelector
    {
        private DataTemplate leftTemplate;
        private DataTemplate centerTemplate;
        private DataTemplate rightTemplate;

        public WayPointTemplateSelector(
            DataTemplate leftTemplate,
            DataTemplate centerTemplate,
            DataTemplate rightTemplate)
        {
            this.leftTemplate = leftTemplate;
            this.centerTemplate = centerTemplate;
            this.rightTemplate = rightTemplate;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Location mapItem = (Location)item;
            if (mapItem != null)
            {
                if (mapItem.Longitude > 2.36)
                {
                    return this.rightTemplate;
                }
                else if (mapItem.Longitude < 2.35)
                {
                    return this.leftTemplate;
                }
                else
                {
                    return this.centerTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
}
