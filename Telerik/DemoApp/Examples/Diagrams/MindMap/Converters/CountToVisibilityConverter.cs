using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Diagrams.MindMap
{
	public class CountToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int childrenCount = (int)value;
			if (childrenCount > 0)
				return System.Windows.Visibility.Visible;

			return System.Windows.Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
