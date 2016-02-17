using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Markup;
using System.Windows;

namespace Telerik.Windows.Examples.GanttView.Programming.LockingFunctions
{
	public class BoolToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Image retVal = new Image { Width = 16, Height = 16 };

			var isLocked = (bool)value;
			if (isLocked)
			{
				retVal.Source = new BitmapImage(new Uri("../../Images/GanttView/LockingFunctions/padlock.png", UriKind.Relative));

				if(parameter != null)
				{
					return retVal.Source;
				}
			}
			else
			{
				retVal.Source = new BitmapImage(new Uri("../../Images/GanttView/LockingFunctions/padlock_open.png", UriKind.Relative));

				if(parameter != null)
				{
					return retVal.Source;
				}
			}
			return retVal;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}


	}
}
