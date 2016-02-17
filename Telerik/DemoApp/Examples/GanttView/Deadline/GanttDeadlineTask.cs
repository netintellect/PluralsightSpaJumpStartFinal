using System;
using Telerik.Windows.Controls.GanttView;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class GanttDeadlineTask : GanttTask
	{
		public GanttDeadlineTask(DateTime start, DateTime end, string title)
			: base(start, end, title)
		{
           
		}

        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            if (args.PropertyName == "End")
            {
                this.Refresh();
            }
        }

		private DateTime? ganttDeadLine;
		public DateTime? GanttDeadLine
		{
			get
			{
				return this.ganttDeadLine;
			}
			set
			{
				this.ganttDeadLine = value;
				this.OnPropertyChanged(() => this.GanttDeadLine);
			}
		}

		public bool IsExpired
		{
			get
			{
				return this.ganttDeadLine < this.End;
			}
		}

		public double Overdue
		{
			get
			{
				if (this.ganttDeadLine.HasValue)
				{
					return this.ganttDeadLine.Value.Subtract(this.End).TotalHours;
				}
				return double.NaN;
			}
		}

		public string ToolTipText
		{
			get
			{
				if (this.IsExpired)
				{
					return string.Format("Overdue: {0}h", this.Overdue);
				}
				return "On Time";
			}
		}

		public void Refresh()
		{
			this.OnPropertyChanged(() => this.GanttDeadLine);
			this.OnPropertyChanged(() => this.IsExpired);
			this.OnPropertyChanged(() => this.Overdue);
			this.OnPropertyChanged(() => this.ToolTipText);
		}
	}
}
