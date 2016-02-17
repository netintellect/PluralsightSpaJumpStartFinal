using System;
using System.Collections;
using System.Collections.Generic;
using Telerik.Windows.Controls.GanttView;

namespace Telerik.Windows.Examples.GanttView.Programming.DragResizeConfigurator
{
	public class ViewModel : GanttViewModel
	{
		public ViewModel()
		{
			this.ResizeMilestones = true;
			this.ResizeSummaries = true;
			this.ResizeTasks = true;
			this.DragMilestones = true;
			this.DragSummaries = true;
			this.DragTasks = true;
			this.AllowModificationsInThePast = true;
			this.SnapToDates = true;
		}

		private bool resizeSummaries;
		public bool ResizeSummaries
		{
			get
			{
				return resizeSummaries;
			}
			set
			{
				resizeSummaries = value;
				OnPropertyChanged(() => ResizeSummaries);
			}

		}

		private bool resizeMilestones;
		public bool ResizeMilestones
		{
			get
			{
				return resizeMilestones;
			}
			set
			{
				resizeMilestones = value;
				OnPropertyChanged(() => ResizeMilestones);
			}

		}

		private bool resizeTasks;
		public bool ResizeTasks
		{
			get
			{
				return resizeTasks;
			}
			set
			{
				resizeTasks = value;
				OnPropertyChanged(() => ResizeTasks);
			}
		}

		private bool dragSummaries;
		public bool DragSummaries
		{
			get
			{
				return dragSummaries;
			}
			set
			{
				dragSummaries = value;
				OnPropertyChanged(() => DragSummaries);
			}

		}

		private bool dragMilestones;
		public bool DragMilestones
		{
			get
			{
				return dragMilestones;
			}
			set
			{
				dragMilestones = value;
				OnPropertyChanged(() => DragMilestones);
			}

		}

		private bool dragTasks;
		public bool DragTasks
		{
			get
			{
				return dragTasks;
			}
			set
			{
				dragTasks = value;
				OnPropertyChanged(() => DragTasks);
			}

		}

		private bool allowModificationsInThePast;
		public bool AllowModificationsInThePast
		{
			get { return this.allowModificationsInThePast; }
			set
			{
				if (this.allowModificationsInThePast != value)
				{
					this.allowModificationsInThePast = value;
					this.OnPropertyChanged(() => this.AllowModificationsInThePast);
				}
			}
		}

		private bool snapToDates;
		public bool SnapToDates
		{
			get { return this.snapToDates; }
			set
			{
				if (this.snapToDates != value)
				{
					this.snapToDates = value;
					this.OnPropertyChanged(() => this.SnapToDates);
				}
			}
		}

		public static GanttTask FindParent(IList<IGanttTask> items, IGanttTask task)
		{
			GanttTask parent = null;
			foreach (GanttTask item in items)
			{
				if (!item.IsSummary)
				{
					break;
				}
				if (item.Children.Contains(task))
				{
					parent = item;
					break;
				}
				else
				{
					parent = FindParent(item.Children, task);
				}
			}
			return parent;
		}
	}
}
