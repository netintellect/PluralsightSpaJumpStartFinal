using System;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.TimeBar
{
	public class CategoryToIconConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Category c = value as Category;
			if (c != null)
			{
				if (c.CategoryName == "Not Started")
				{
					return "/ScheduleView;component/Images/ScheduleView/TimeBar/NotStarted.png";
				}
				else if (c.CategoryName == "In Progress")
				{
					return "/ScheduleView;component/Images/ScheduleView/TimeBar/InProgress.png";
				}
				else if (c.CategoryName == "Completed")
				{
					return "/ScheduleView;component/Images/ScheduleView/TimeBar/Completed.png";
				}
			}
			return null;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
