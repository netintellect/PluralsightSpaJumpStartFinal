using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.ScheduleView.ScheduleViewConfigurator
{
	public class ViewDefinitionToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string activeViewDefinitionName = value.GetType().Name;
			if (parameter.ToString().Contains(activeViewDefinitionName))
			{
				return false;
			}
			return true;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
