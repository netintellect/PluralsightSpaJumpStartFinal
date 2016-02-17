using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class KingNameToAbbreviatedNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            string kingName = (string)value;
            string abbreviatedKingName;

            if (kingName.Equals("William III and Mary II"))
            {
                abbreviatedKingName = "WIII MII";
            }
            else if (kingName.Equals("Harold I Harefoot"))
            {
                abbreviatedKingName = "Harold I";
            }
            else if (kingName.Equals("Edward the Confessor"))
            {
                abbreviatedKingName = "Edward";
            }
            else if (kingName.Equals("Edward IV"))
            {
                abbreviatedKingName = "E IV";
            }
            else if (kingName.Equals("Edward VII"))
            {
                abbreviatedKingName = "E VII";
            }
            else
            {
                abbreviatedKingName = kingName;
            }

            return abbreviatedKingName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
