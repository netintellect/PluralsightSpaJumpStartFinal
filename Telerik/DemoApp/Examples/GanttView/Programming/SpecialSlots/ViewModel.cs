using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GanttView.Programming.SpecialSlots
{
	public class ViewModel : GanttViewModel
	{
		private IDateRange visibleRange;
		private IRangeGenerator specialSlotsGenerator;
		private DelegateCommand specialSlotsCommand;

		public ViewModel()
		{
            var start = new DateTime(DateTime.Today.Year, Math.Max(1, DateTime.Today.Month - 1), 1);
			var end = start.AddMonths(5);
			this.visibleRange = new DateRange(start, end);

			this.SpecialSlotsCommand = new DelegateCommand(this.SpecialSlotsExecuted);
		}

		public IRangeGenerator SpecialSlotsGenerator
		{
			get
			{
				return this.specialSlotsGenerator;
			}
			set
			{
				specialSlotsGenerator = value;
				OnPropertyChanged("SpecialSlotsGenerator");
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

		private void SpecialSlotsExecuted(object parameter)
		{
			switch (parameter.ToString())
			{
				case "NoSpecialSlots":
					this.SpecialSlotsGenerator = new EmptyRangeGenerator();
					break;
				case "WeekDays":
					this.SpecialSlotsGenerator = new WeekDaysGenerator();
					break;
				case "WeekEnds":
					this.SpecialSlotsGenerator = new WeekDaysGenerator() { DaysCount = 2, FirstDay = DayOfWeek.Saturday };
					break;
				case "Custom":
					this.SpecialSlotsGenerator = new CustomRangeGenerator();
					break;
				case "AllSpecialSlots":
					this.SpecialSlotsGenerator = new SingleRangeGenerator();
					break;
					
			}
		}

		public DelegateCommand SpecialSlotsCommand
		{
			get
			{
				return this.specialSlotsCommand;
			}
			set
			{
				this.specialSlotsCommand = value;
			}
		}
	}
}