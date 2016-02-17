using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Calendar;

namespace Telerik.Windows.Examples.Calendar.SelectionRangeConstraints
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
		}

		private void OnSelectionRangeLoaded(object sender, RoutedEventArgs e)
		{
			this.calendarConstraints.SelectableDateStart = DateTime.Today.AddDays(-20);
			this.calendarConstraints.SelectableDateEnd = DateTime.Today.AddDays(70);
			this.calendarConstraints.DisplayDateStart = DateTime.Today.AddDays(-160);
			this.calendarConstraints.DisplayDateEnd = DateTime.Today.AddDays(160);
		}

		private void OnEnabledRangeCalendar(object sender, RoutedEventArgs e)
		{
			this.calendarRange.IsEnabled = this.cbxEnabledRangeCalendar.IsChecked.Value;
		}
	}

	public class DisableWeekendsSelection : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			CalendarButtonContent content = item as CalendarButtonContent;

			if (content != null)
			{
				if (content.Date.DayOfWeek == DayOfWeek.Saturday 
					|| content.Date.DayOfWeek == DayOfWeek.Sunday
					|| content.Date.Month == DateTime.Now.Month
					|| content.Date.Month == DateTime.Now.Month + 2)
				{
					content.IsEnabled = false;
				}
			}
			return DefaultTemplate;
		}

		private DataTemplate defaultTemplate;
		public DataTemplate DefaultTemplate
		{
			get
			{
				return defaultTemplate;
			}
			set
			{
				this.defaultTemplate = value;
			}
		}
	}
}
