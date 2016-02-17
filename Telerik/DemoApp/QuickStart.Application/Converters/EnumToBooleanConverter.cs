﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Telerik.Windows.QuickStart
{
    [ValueConversion(typeof(Enum), typeof(bool))]
	public class EnumToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool result = false;
			if (value == null || !(value is Enum))
			{
				result = false;
			}
			else if (parameter == null)
			{
				result = false;
			}
			else
			{
				foreach (Enum paramValue in EnumToBooleanConverter.ParseObjectToEnum(value.GetType(), parameter))
				{
					if (value.Equals(paramValue))
					{
						result = true;
						break;
					}
				}
			}

			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result = Binding.DoNothing;
			if ((bool)value)
			{
				Enum[] parsedValues = EnumToBooleanConverter.ParseObjectToEnum(targetType, parameter);
				if (parsedValues.Length > 0)
				{
					result = parsedValues[0];
				}
			}
            return result;
		}

		private static Enum[] ParseObjectToEnum(Type enumType, object value)
		{
			var enumValue = value as Enum;
			if (enumValue != null)
			{
				return new[] { enumValue };
			}

			var str = value as string;
			if (string.IsNullOrEmpty(str))
			{
				throw new ArgumentException("parameter");
			}

			string[] strArray = str.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
			var enumArray = new Enum[strArray.Length];
			for (int i = 0; i < strArray.Length; i++)
			{
				enumArray[i] = (Enum)Enum.Parse(enumType, strArray[i], true);
			}

			return enumArray;
		}
	}
}