using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Telerik.Windows.QuickStart
{
	public class IntProgressToNormalizedDouble : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is int)
			{
				return (double)value / (double)100;
			}
			else if (value != null)
			{
				int v = 0;
				if (int.TryParse(value.ToString(), out v))
				{
					return (double)v / (double)100;
				}
			}
			return 0;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
