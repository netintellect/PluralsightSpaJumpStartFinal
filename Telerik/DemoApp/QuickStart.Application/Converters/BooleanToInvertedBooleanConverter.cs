﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Telerik.Windows.QuickStart
{
	public class BooleanToInvertedBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				return !(bool)value;
			}
			return false;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return this.Convert(value, targetType, parameter, culture);
		}
	}
}
