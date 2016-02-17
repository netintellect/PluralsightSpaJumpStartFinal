using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.TreeListView.TreeLines
{
	public class ColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Color? color = (Color?)value;

			if (color != null)
			{
				return new SolidColorBrush(color.Value);
			}

			return new SolidColorBrush(Colors.Black);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value;
		}
	}
}
