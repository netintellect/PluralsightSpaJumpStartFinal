using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class GanttDeadlineViewModel : PropertyChangedBase
	{
		public GanttDeadlineViewModel()
		{
			this.tasks = new SoftwarePlanning();

			var start = this.tasks.Min(t => t.Start).Date;
			var end = this.tasks.Max(t => t.End).Date;

			this.visibleTime = new DateRange(start.AddHours(-12), end.AddDays(3));

			var projectDeadLine = end.AddHours(12);

			this.timeRulerDeadlineBehavior = new TimeRulerDeadlineBehavior();
			this.timeLineDeadlineBehavior = new TimeLineDeadlineBehavior(projectDeadLine);
		}
		private ObservableCollection<GanttDeadlineTask> tasks;
		public ObservableCollection<GanttDeadlineTask> Tasks { get { return this.tasks; } }
		
		private DateRange visibleTime;
		public DateRange VisibleTime
		{
			get { return this.visibleTime; }
			set
			{
				if (this.visibleTime != value)
				{
					this.visibleTime = value;
					this.OnPropertyChanged(() => this.VisibleTime);
				}
			}
		}

		private ITimeRulerVisualizationBehavior timeRulerDeadlineBehavior;
		public ITimeRulerVisualizationBehavior TimeRulerDeadlineBehavior
		{
			get
			{
				return timeRulerDeadlineBehavior;
			}
			set
			{
				timeRulerDeadlineBehavior = value;
				OnPropertyChanged(() => this.TimeRulerDeadlineBehavior);
			}
		}

		private ITimeLineVisualizationBehavior timeLineDeadlineBehavior;
		public ITimeLineVisualizationBehavior TimeLineDeadlineBehavior
		{
			get
			{
				return timeLineDeadlineBehavior;
			}
			set
			{
				timeLineDeadlineBehavior = value;
				this.OnPropertyChanged(() => this.TimeLineDeadlineBehavior);
			}
		}
	}
}
