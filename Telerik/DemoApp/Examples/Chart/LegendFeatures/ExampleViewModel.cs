using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using System.Windows.Controls;
using System.Windows;

namespace Telerik.Windows.Examples.Chart.LegendFeatures
{
    public class ExampleViewModel : DependencyObject
    {
        public static readonly DependencyProperty ChartLegendItemMarkerShapeProperty = DependencyProperty.Register("ChartLegendItemMarkerShape",
            typeof(MarkerShape),
            typeof(ExampleViewModel),
            new PropertyMetadata(MarkerShape.Square));

        public static readonly DependencyProperty LegendPositionProperty = DependencyProperty.Register("LegendPosition",
            typeof(Dock),
            typeof(ExampleViewModel),
            new PropertyMetadata(Dock.Right));
        
        public List<GDPData> Data
        {
            get
            {
                List<GDPData> result = new List<GDPData>();
                result.Add(new GDPData("USA", 14100));
                result.Add(new GDPData("Japan", 4911));
                result.Add(new GDPData("China", 4327));
                result.Add(new GDPData("Germany", 3649));
                result.Add(new GDPData("France", 2857));
                result.Add(new GDPData("UK", 2666));
                result.Add(new GDPData("Italy", 2303));
                result.Add(new GDPData("Russia", 1677));
                result.Add(new GDPData("Spain", 1604));
                result.Add(new GDPData("Brazil", 1595));
                return result;
            }
        }

        public object[] LegendPositions
        {
            get
            {
                return EnumHelper.GetValues(typeof(Dock));
            }
        }

        public object[] LegendItemMarkerShapes
        {
            get
            {
                return EnumHelper.GetValues(typeof(MarkerShape));
            }
        }

        public MarkerShape ChartLegendItemMarkerShape
        {
            get
            {
                return (MarkerShape)this.GetValue(ChartLegendItemMarkerShapeProperty);
            }
            set
            {
                this.SetValue(ChartLegendItemMarkerShapeProperty, value);
            }
        }

        public Dock LegendPosition
        {
            get
            {
                return (Dock)this.GetValue(LegendPositionProperty);
            }
            set
            {
                this.SetValue(LegendPositionProperty, value);
            }
        }
    }
}
