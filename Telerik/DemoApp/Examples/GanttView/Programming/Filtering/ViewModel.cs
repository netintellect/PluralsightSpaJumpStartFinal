using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GanttView.Programming.Filtering
{
	public class ViewModel : GanttViewModel
	{
		private IDateRange visibleRange;
		private IRangeGenerator filterBehavior;
		private DelegateCommand filteringCommand;

		public ViewModel()
		{
            var start = new DateTime(DateTime.Today.Year, Math.Max(1, DateTime.Today.Month - 1), 1);
			var end = start.AddMonths(5);
			this.visibleRange = new DateRange(start, end);

			this.FilteringCommand = new DelegateCommand(this.FilteringExecuted);
		}

		public IRangeGenerator FilterBehavior
		{
			get
			{
				return this.filterBehavior;
			}
			set
			{
				filterBehavior = value;
				OnPropertyChanged("FilterBehavior");
			}
		}

		public IDateRange VisibleRange
		{
			get { return this.visibleRange; }
			set
			{
				if (this.visibleRange != value)
				{
					this.visibleRange = value;
					this.OnPropertyChanged(() => this.VisibleRange);
				}
			}
		}

		private void FilteringExecuted(object parameter)
		{
			switch (parameter.ToString())
			{
				case "NoFilter":
					this.FilterBehavior = new SingleRangeGenerator();
					break;
				case "WeekDays":
					this.FilterBehavior = new WeekDaysGenerator();
					break;
				case "WeekEnds":
					this.FilterBehavior = new WeekDaysGenerator() { DaysCount = 2, FirstDay = DayOfWeek.Saturday };
					break;
				case "Custom":
					this.FilterBehavior = new CustomRangeGenerator();
					break;
			}
		}

		public DelegateCommand FilteringCommand
		{
			get
			{
				return this.filteringCommand;
			}
			set
			{
				this.filteringCommand = value;
			}
		}
	}
}