using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.GanttView.Programming.LockingFunctions
{
	public class BoolToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var isLocked = (bool)value;
			var parameterValues = parameter.ToString().Split(',');
			if (isLocked)
			{
				return parameterValues[1] + " " + parameterValues[2];
			}
			return parameterValues[0] + " " + parameterValues[2];
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
