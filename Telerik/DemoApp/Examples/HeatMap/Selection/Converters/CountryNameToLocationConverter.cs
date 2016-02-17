using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.HeatMap.Selection.Converters
{
    public class CountryNameToLocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string countryName = value as string;

            switch (countryName)
            {
                case "Austria": return new Location(47.3333, 13.3333);
                case "Belgium": return new Location(50.8333, 4);
                case "Czech Republic": return new Location(49.75, 15.5);
                case "Denmark": return new Location(56, 10);
                case "Finland": return new Location(64, 26);
                case "France": return new Location(46, 2);
                case "Germany": return new Location(51, 9);
                case "Greece": return new Location(39, 22);
                case "Hungary": return new Location(47, 20);
                case "Italy": return new Location(42.8333, 12.8333);
                case "Luxembourg": return new Location(49.75, 6.1667);
                case "Netherlands": return new Location(52.5, 5.75);
                case "Poland": return new Location(52, 20);
                case "Portugal": return new Location(39.5, -8);
                case "Spain": return new Location(40, -4);
                case "Sweden": return new Location(62, 15);
                case "Switzerland": return new Location(47, 8);
                case "United Kingdom": return new Location(54, -2);

                default:
                    break;
            }

            return new Location(46, 2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
