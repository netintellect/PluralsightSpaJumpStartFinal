using System.Windows;
using System.Windows.Controls;
using Telerik.Charting;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    public class RegionLabelTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RegionLabelTemplate { get; set; }
        public DataTemplate SubregionLabelTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            PieDataPoint dataPoint = (PieDataPoint)item;
            DataTemplate template = null;

            if (dataPoint.DataItem is Region)
            {
                template = this.RegionLabelTemplate;
            }
            else if (dataPoint.DataItem is Subregion)
            {
                template = this.SubregionLabelTemplate;
            }

            return template;
        }
    }
}
