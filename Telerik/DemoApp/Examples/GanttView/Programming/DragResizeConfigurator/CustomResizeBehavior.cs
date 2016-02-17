using System.Windows;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;
using System;

namespace Telerik.Windows.Examples.GanttView.Programming.DragResizeConfigurator
{
	public class CustomResizeBehavior : SchedulingResizeBehavior
	{
		// Using a DependencyProperty as the backing store for ResizeSummaries.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CanResizeSummariesProperty =
			DependencyProperty.Register("CanResizeSummaries", typeof(bool), typeof(CustomResizeBehavior), new PropertyMetadata(true));

		// Using a DependencyProperty as the backing store for ResizeMilestones.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CanResizeMilestonesProperty =
			DependencyProperty.Register("CanResizeMilestones", typeof(bool), typeof(CustomResizeBehavior), new PropertyMetadata(true));

		// Using a DependencyProperty as the backing store for ResizeTasks.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CanResizeTasksProperty =
			DependencyProperty.Register("CanResizeTasks", typeof(bool), typeof(CustomResizeBehavior), new PropertyMetadata(true));

		// Using a DependencyProperty as the backing store for AllowModificationsInThePast. This enables animation, styling, binding, etc...
		public static readonly DependencyProperty AllowModificationsInThePastProperty =
			DependencyProperty.Register("AllowModificationsInThePast", typeof(bool), typeof(CustomResizeBehavior), new PropertyMetadata(true));

		// Using a DependencyProperty as the backing store for SnapToDates.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SnapToDatesProperty =
			DependencyProperty.Register("SnapToDates", typeof(bool), typeof(CustomResizeBehavior), new PropertyMetadata(true));
				
		public bool CanResizeSummaries
		{
			get { return (bool)GetValue(CanResizeSummariesProperty); }
			set { SetValue(CanResizeSummariesProperty, value); }
		}

		public bool CanResizeMilestones
		{
			get { return (bool)GetValue(CanResizeMilestonesProperty); }
			set { SetValue(CanResizeMilestonesProperty, value); }
		}

		public bool CanResizeTasks
		{
			get { return (bool)GetValue(CanResizeTasksProperty); }
			set { SetValue(CanResizeTasksProperty, value); }
		}

		public bool AllowModificationsInThePast
		{
			get { return (bool)this.GetValue(AllowModificationsInThePastProperty); }
			set { this.SetValue(AllowModificationsInThePastProperty, value); }
		}

		public bool SnapToDates
		{
			get { return (bool)this.GetValue(SnapToDatesProperty); }
			set { this.SetValue(SnapToDatesProperty, value); }
		}

		protected override bool CanStartResize(SchedulingResizeState state)
		{
			if (!base.CanStartResize(state))
			{
				return false;
			}

			var task = state.ResizedItem as GanttTask;
			var now = DateTime.Now;

			if (!this.AllowModificationsInThePast && (!state.IsResizeFromEnd && task.Start <= now || state.IsResizeFromEnd && task.End <= now))
			{
				return false;
			}
			
			if (task.IsMilestone)
			{
				return this.CanResizeMilestones;
			}
			if (task.IsSummary)
			{
				return this.CanResizeSummaries;
			}

			return this.CanResizeTasks;
		}

		protected override bool CanResize(SchedulingResizeState state)
		{
			var now = DateTime.Now;

			if (base.CanResize(state) && 
					(this.AllowModificationsInThePast || 
					!state.IsResizeFromEnd && state.DestinationSlot.Start > now || 
					state.IsResizeFromEnd && state.DestinationSlot.End > now))
			{
				if (this.SnapToDates)
				{
					if (state.IsResizeFromEnd)
					{
						var difference = state.DestinationSlot.End - state.DestinationSlot.End.Date;
						state.DestinationSlot.End = state.DestinationSlot.End.Date + TimeSpan.FromDays(Math.Round(difference.TotalDays));
					}
					else
					{
						var difference = state.DestinationSlot.Start - state.DestinationSlot.Start.Date;
						state.DestinationSlot.Start = state.DestinationSlot.Start.Date + TimeSpan.FromDays(Math.Round(difference.TotalDays));
					}
				}

				return true;
			}

			return false;
		}
	}
}