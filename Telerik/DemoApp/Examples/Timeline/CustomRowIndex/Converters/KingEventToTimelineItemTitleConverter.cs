using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class KingEventToTimelineItemTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            King king = king = (King)value;
            string endYear = king.End.Year == 2013 ? "..." : king.End.Year.ToString();

            return String.Format("{0} ({1} - {2})", king.Name, king.Begin.Year, endYear);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
