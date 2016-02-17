using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.Grouping.TimeZoneGrouping
{
	public class ViewModel : ExampleViewModel<Appointment>
	{
		private ObservableCollection<TimeZoneInfo> timeZonesSource;

		public ViewModel()
		{
			var timeZones = new List<TimeZoneInfo>()
			{
				TimeZoneInfo.Utc,
				TimeZoneInfo.Local,
			};
			this.TimeZonesSource = new ObservableCollection<TimeZoneInfo>(timeZones);
		}

		public ObservableCollection<TimeZoneInfo> TimeZonesSource
		{
			get
			{
				return this.timeZonesSource;
			}
			set
			{
				this.timeZonesSource = value;
				this.OnPropertyChanged(() => this.timeZonesSource);
			}
		}
	}
}
