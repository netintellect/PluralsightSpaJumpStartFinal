using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.ScheduleView;
using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.TaskPlanner
{
	public class CommonModel : ViewModelBase, IGanttTask, IAppointment, IMilestone, ISummary, IEditableHierarchical, IDependant
	{
		private DateTime? dealine;
		private string description;
		private TimeSpan duration;
		private double progress;
		private string title;
        private CommonModel parent;
		private DateTime end;
		private DateTime start;
		private IList resources;
		private string member;
		private bool isAllDayEvent;
		private TimeZoneInfo timeZone;
		private IRecurrenceRule recurrneceRule;
		private bool isMilestone;
		private CommonModel backUp;

		private ObservableCollection<IDependency> dependencies;
		private ObservableCollection<CommonModel> children;

		public event EventHandler RecurrenceRuleChanged;

		public CommonModel()
		{
			this.dependencies = new ObservableCollection<IDependency>();
			this.children = new ObservableCollection<CommonModel>();
		}

		IEnumerable IGanttTask.Dependencies
		{
			get { return this.dependencies; }
		}

		IEnumerable IDependant.Dependencies
		{
			get { return this.dependencies; }
		}

		IEnumerable IHierarchical.Children
		{
			get { return this.children; }
		}

		IList Telerik.Windows.Controls.Scheduling.IResourceContainer.Resources
		{
			get { return this.Resources; }
		}

		public IList<IDependency> Dependencies
		{
			get
			{
				return this.dependencies;
			}
		}

		public IList<CommonModel> Children
		{
			get
			{
				return this.children;
			}
		}

		public DateTime? Deadline
		{
			get
			{
				return this.dealine;
			}
			set
			{
				if (this.dealine != value)
				{
					this.dealine = value;
					OnPropertyChanged(() => this.Deadline);
				}
			}
		}

		public string Description
		{
			get
			{
				return this.description;
			}
			set
			{
				if (this.description != value)
				{
					this.description = value;
					OnPropertyChanged(() => this.Description);
				}
			}
		}

		public TimeSpan Duration
		{
			get
			{
				return this.duration;
			}
			set
			{
				if (this.duration != value)
				{
					this.duration = value;
					OnPropertyChanged(() => this.Duration);
				}
			}
		}

		public double Progress
		{
			get
			{
				return this.progress;
			}
			set
			{
				if (this.progress != value)
				{
					this.progress = value;
					OnPropertyChanged(() => this.Progress);
				}
			}
		}

		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				if (this.title != value)
				{
					this.title = value;
					OnPropertyChanged(() => this.Title);
					OnPropertyChanged(() => this.Subject);
				}
			}
		}

        public CommonModel Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                if (this.parent != value)
                {
                    this.parent = value;
                    OnPropertyChanged(() => this.Parent);
                }
            }
        }

		public string Subject
		{
			get
			{
				return this.title;
			}
			set
			{
				if (this.title != value)
				{
					this.title = value;
					OnPropertyChanged(() => this.Subject);
				}
			}
		}

		public DateTime End
		{
			get
			{
				return this.end;
			}
			set
			{
				if (this.end != value)
				{
					this.end = value;
					OnPropertyChanged(() => this.End);
				}
			}
		}

		public DateTime Start
		{
			get
			{
				return this.start;
			}
			set
			{
				if (this.start != value)
				{
					this.start = value;
					OnPropertyChanged(() => this.Start);
				}
			}
		}

		public IList Resources
		{
			get
			{
				if (resources == null)
				{
					this.resources = new List<object>();
				}
				return this.resources;
			}
			set
			{
				if (value != this.resources)
				{
					resources = value;
					OnPropertyChanged(() => this.Member);
					OnPropertyChanged(() => this.Resources);				
				}
			}
		}

		public string Member
		{
			get
			{
				if (this.resources != null)
				{
					var resource = this.resources.OfType<EmployeeResource>().FirstOrDefault();
					if (resource == null)
					{
						return string.Empty;
					}
					this.member = resource.DisplayName;
					return member;
				}
				return string.Empty;
			}
			set
			{
				if (this.member != value)
				{
					this.member = value;
					OnPropertyChanged(() => this.Member);
				}
			}
		}

		public void LoadState(object state)
		{
		}

		public object SaveState()
		{
			return null;
		}

		public bool IsAllDayEvent
		{
			get
			{
				return this.isAllDayEvent;
			}
			set
			{
				if (this.isAllDayEvent != value)
				{
					this.isAllDayEvent = value;
				}
			}
		}

		public IRecurrenceRule RecurrenceRule
		{
			get
			{
				return this.recurrneceRule;
			}
			set
			{
				if (this.recurrneceRule != value)
				{
					this.recurrneceRule = value;
					OnPropertyChanged(() => this.RecurrenceRule);
				}
			}
		}

		public TimeZoneInfo TimeZone
		{
			get
			{
				if (this.timeZone == null)
				{
					return TimeZoneInfo.Local;
				}

				return this.timeZone;
			}
			set
			{
				if (this.timeZone != value)
				{
					this.timeZone = value;
					OnPropertyChanged(() => this.TimeZone);
				}
			}
		}

		public bool IsMilestone
		{
			get
			{
				this.isMilestone = this.start == this.end;
				return this.isMilestone;
			}
			set
			{
				if (this.isMilestone != value)
				{
					this.isMilestone = value;
					OnPropertyChanged(() => this.IsMilestone);
				}
			}
		}

		public bool IsSummary
		{
			get
			{
				if (this.children == null || !this.children.OfType<IGanttTask>().Any())
				{
					return false;
				}
				return this.children.OfType<IGanttTask>().Count() > 0;
			}
		}

		public override string ToString()
		{
			return this.title;
		}

		public void BeginEdit()
		{
			this.BackUp(this);
		}

		public void CancelEdit()
		{
			this.RollBack();
		}

		public void EndEdit()
		{
			this.backUp = null;
		}
		public bool Equals(IAppointment other)
		{
			var otherAppointment = other as IAppointment;
			return otherAppointment != null &&
				other.Start == this.Start &&
				other.End == this.End &&
				other.Subject == this.Subject &&
				this.TimeZone == otherAppointment.TimeZone &&
				this.IsAllDayEvent == other.IsAllDayEvent &&
				this.RecurrenceRule == other.RecurrenceRule &&
				this.Resources == other.Resources;
		}

		public IAppointment Copy()
		{
            var newCommonModel = new CommonModel();
            newCommonModel.CopyFrom(this);
            return newCommonModel;
		}

        public void CopyFrom(IAppointment other)
		{
            var original = other as CommonModel;
            if (original != null)
            {
                this.children = new ObservableCollection<CommonModel>(original.children);
                this.Deadline = original.Deadline;
                this.dependencies = new ObservableCollection<IDependency>(original.dependencies);
                this.Description = original.Description;
                this.Duration = original.Duration;
                this.Parent = original.Parent;
                this.End = original.End;
                this.IsAllDayEvent = original.IsAllDayEvent;
                this.IsMilestone = original.IsMilestone;
                this.Progress = original.Progress;
                this.RecurrenceRule = original.RecurrenceRule;
                this.Resources = original.Resources;
                this.Start = original.Start;
                this.Subject = original.Subject;
                this.TimeZone = original.TimeZone;
            }
		}

		public void InsertChildAtIndex(object item, int index)
		{
			var ganttTask = item as CommonModel;
			if (ganttTask != null)
			{
				this.Children.Insert(index, ganttTask);
			}
		}

		public void Remove(object item)
		{
			var ganttItem = item as CommonModel;
			if (ganttItem != null)
			{
				this.Children.Remove(ganttItem);
			}
		}

        public IDependency AddDependency(IGanttTask fromTask, DependencyType type)
		{
			var dependency = new Dependency() { FromTask = fromTask, Type = type };
			this.Dependencies.Add(dependency);
			return dependency;
		}

        bool IDependant.RemoveDependency(IDependency dependency)
		{
			if (this.dependencies.Contains(dependency))
			{
				this.Dependencies.Remove(dependency);
				return true;
			}
			return false;
		}

		private void BackUp(CommonModel model)
		{
            this.backUp = this.Copy() as CommonModel;
		}

		private void RollBack()
		{
            this.CopyFrom(this.backUp);
		}

        public CommonModel GetOldParent()
        {
            if (this.backUp != null)
            {
                return this.backUp.Parent;
            }
            return this.parent;
        }
    }
}
