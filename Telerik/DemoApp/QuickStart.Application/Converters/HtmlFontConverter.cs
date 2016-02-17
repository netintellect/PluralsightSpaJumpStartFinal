using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Telerik.Windows.QuickStart
{
	public class HtmlFontConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value != null)
			{

                if (parameter !=null && parameter.ToString() == "touchMode")
                {
                    return String.Format("<p  style=\" font-family: Myriad Pro; font-size:13px; line-height:25px\" color=\"#999999\">{0}</p>", value);
                }
                return String.Format("<font face=\"Arial\" style=\"font-size:12px\" color=\"#3D4350\">{0}</font>", value);
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
