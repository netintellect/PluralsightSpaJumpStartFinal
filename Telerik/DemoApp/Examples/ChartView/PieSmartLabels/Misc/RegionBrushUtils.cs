using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    public static class RegionBrushUtils
    {
        public static Brush GetBrush(string regionName)
        {
            Color color = Colors.Transparent;

            switch (regionName)
            {
                case "Latin America":
                    color = new Color { A = 255, R = 27, G = 157, B = 222, };
                    break;
                case "North America":
                    color = new Color { A = 255, R = 212, G = 223, B = 50, };
                    break;
                case "Eurasia & Africa":
                    color = new Color { A = 255, R = 245, G = 151, B = 0, };
                    break;
                case "Pacific":
                    color = new Color { A = 255, R = 142, G = 196, B = 65, };
                    break;
                case "Europe":
                    color = new Color { A = 255, R = 51, G = 153, B = 51, };
                    break;
                
                default:
                    color = Colors.Transparent;
                    break;
            }

            return new SolidColorBrush(color);
        }
    }
}
