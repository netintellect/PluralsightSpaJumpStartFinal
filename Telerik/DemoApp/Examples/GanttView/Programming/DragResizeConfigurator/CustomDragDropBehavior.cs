using System.Windows;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;
using System;

namespace Telerik.Windows.Examples.GanttView.Programming.DragResizeConfigurator
{
    public class CustomDragDropBehavior : GanttDragDropBehavior
	{
		
		// Using a DependencyProperty as the backing store for CanDragSummaries.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CanDragSummariesProperty =
			DependencyProperty.Register("CanDragSummaries", typeof(bool), typeof(CustomDragDropBehavior), new PropertyMetadata(true));

		// Using a DependencyProperty as the backing store for CanDragMilestones.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CanDragMilestonesProperty =
			DependencyProperty.Register("CanDragMilestones", typeof(bool), typeof(CustomDragDropBehavior), new PropertyMetadata(true));

	
		// Using a DependencyProperty as the backing store for CanDragTasks.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CanDragTasksProperty =
			DependencyProperty.Register("CanDragTasks", typeof(bool), typeof(CustomDragDropBehavior), new PropertyMetadata(true));

		// Using a DependencyProperty as the backing store for AllowModificationsInThePast.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty AllowModificationsInThePastProperty =
			DependencyProperty.Register("AllowModificationsInThePast", typeof(bool), typeof(CustomDragDropBehavior), new PropertyMetadata(true));

		// Using a DependencyProperty as the backing store for SnapToDates.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SnapToDatesProperty =
			DependencyProperty.Register("SnapToDates", typeof(bool), typeof(CustomDragDropBehavior), new PropertyMetadata(true));

		public bool CanDragSummaries
		{
			get { return (bool)GetValue(CanDragSummariesProperty); }
			set { SetValue(CanDragSummariesProperty, value); }
		}

		public bool CanDragMilestones
		{
			get { return (bool)GetValue(CanDragMilestonesProperty); }
			set { SetValue(CanDragMilestonesProperty, value); }
		}

		public bool CanDragTasks
		{
			get { return (bool)GetValue(CanDragTasksProperty); }
			set { SetValue(CanDragTasksProperty, value); }
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

		protected override bool CanStartDrag(SchedulingDragDropState state)
		{
			if (!base.CanStartDrag(state))
			{
				return false;
			}

			var task = state.DraggedItem as GanttTask;

			if (!this.AllowModificationsInThePast && task.Start <= DateTime.Now)
			{
				return false;
			}
			
			if (task.IsMilestone)
			{
				return this.CanDragMilestones;
			}
			if (task.IsSummary)
			{
				return this.CanDragSummaries;
			}

			return this.CanDragTasks;
		}

		protected override bool CanDrop(SchedulingDragDropState state)
		{
			if (base.CanDrop(state) && this.AllowModificationsInThePast || state.DestinationSlot.Start.Date > DateTime.Now)
			{
				if (this.SnapToDates)
				{
					var length = state.DestinationSlot.End - state.DestinationSlot.Start;
					var start = state.DestinationSlot.Start.Date;
					var end = start + TimeSpan.FromDays(Math.Ceiling(length.TotalDays));

					state.DestinationSlot.Start = start;
					state.DestinationSlot.End = end;
				}

				return true;
			}
			return false;
		}
	}
}