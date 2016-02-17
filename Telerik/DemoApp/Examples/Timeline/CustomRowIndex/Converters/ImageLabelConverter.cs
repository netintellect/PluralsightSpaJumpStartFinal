using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class ImageLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            King king = king = (King)value;
            string kingName = king.Name;

            if (kingName.Contains("Elizabeth") || kingName.Contains("Victoria") || kingName.Contains("Anne") || kingName.Contains("Mary"))
            {
                if (kingName.Contains("Mary") && kingName.Contains("William"))
                {
                    kingName = "King William III and Queen Mary II";
                }
                else
                {
                    kingName = kingName.Insert(0, "Queen ");
                }
            }
            else
            {
                kingName = kingName.Insert(0, "King ");
            }

            return kingName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
