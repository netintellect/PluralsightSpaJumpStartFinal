using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.TaskPlanner
{
	public class ViewModel : ViewModelBase
	{
		private DateTime today = DateTime.Today.AddHours(8);

		private ObservableCollection<CommonModel> tasks;
		public ObservableCollection<CommonModel> Tasks
		{
			get
			{
				return tasks;
			}
			set
			{
				tasks = value;
				OnPropertyChanged(() => Tasks);
			}
		}

		private ObservableCollection<CommonModel> appointments;
		public ObservableCollection<CommonModel> Appointments
		{
			get
			{
				return appointments;
			}
			set
			{
				appointments = value;
				OnPropertyChanged(() => Appointments);
			}
		}

		private IDateRange visibleRange;
		public IDateRange VisibleRange
		{
			get { return visibleRange; }
			set
			{
				visibleRange = value;
				OnPropertyChanged(() => this.VisibleRange);
			}
		}

		private CommonModel selectedItem;
		public CommonModel SelectedItem
		{
			get
			{
				return this.selectedItem;
			}
			set
			{
				if (this.selectedItem != value)
				{
					this.selectedItem = value;
					OnPropertyChanged(() => this.SelectedItem);
				}
			}
		}

		public IEnumerable<CommonModel> Parents
		{
			get
			{
                return this.tasks.FirstOrDefault().Children.OfType<CommonModel>();
			}
		}

		public DayOfWeek FirstDayOfWeek
		{
			get
			{
				return this.visibleRange.Start.DayOfWeek;
			}
		}

		public ViewModel()
		{
			this.visibleRange = new DateRange(this.today, this.today.AddDays(5));
			this.LoadData();
		}

		private void LoadData()
		{
			this.tasks = new ObservableCollection<CommonModel>();
			this.appointments = new ObservableCollection<CommonModel>();

            var commonModel14 = new CommonModel
			{
				Title = "GanttView",
				Start = this.today.AddMinutes(30),
				End = this.today.AddDays(20),
			};

			var commonModel15 = new CommonModel
			{
				Title = "ScheduleView",
				Start = this.today.AddMinutes(30),
				End = this.today.AddDays(10),
			};

			var commonModel1 = new CommonModel
			{
				Start = this.today.AddMinutes(30),
				End = this.today.AddHours(5),
				Title = "Highlighting of special slots",
				Member = "Diego Roel",
                Parent = commonModel14,
				Resources = { new EmployeeResource { ResourceName = "Diego Roel", DisplayName = "Diego Roel", ResourceType = "Employee" } }
			};

			var commonModel2 = new CommonModel
			{
				Start = this.today.AddHours(5),
				End = this.today.AddHours(7).AddMinutes(25),
				Title = "Drag & Drop of the appointments",
				Member = "Anabela Domingues",
                Parent = commonModel15,
				Resources = { new EmployeeResource { ResourceName = "Anabela Domingues", DisplayName = "Anabela Domingues", ResourceType = "Employee" } },
			};

			var commonModel3 = new CommonModel
			{
				Start = this.today.AddMinutes(30),
				End = this.today.AddHours(5),
				Title = "Add database example",
				Member = "Anabela Domingues",
                Parent = commonModel14,
				Resources = { new EmployeeResource { ResourceName = "Anabela Domingues", DisplayName = "Anabela Domingues", ResourceType = "Employee" } },
			};
			commonModel3.AddDependency(commonModel1, DependencyType.FinishStart);

			var commonModel4 = new CommonModel
			{
				Start = this.today.AddHours(7).AddMinutes(25),
				End = this.today.AddHours(5).AddDays(1),
				Title = "Dependencies column",
				Member = "Anabela Domingues",
                Parent = commonModel15,
				Resources = { new EmployeeResource { ResourceName = "Anabela Domingues", DisplayName = "Anabela Domingues", ResourceType = "Employee" } },
			};
			commonModel4.AddDependency(commonModel2, DependencyType.FinishStart);

			var commonModel5 = new CommonModel
			{
				Start = this.today.AddHours(5),
				End = this.today.AddHours(11).AddMinutes(30),
				Title = "Localization and cultures",
				Member = "Diego Roel",
                Parent = commonModel14,
				Resources = { new EmployeeResource { ResourceName = "Diego Roel", DisplayName = "Diego Roel", ResourceType = "Employee" } },
			};
			commonModel5.AddDependency(commonModel3, DependencyType.FinishStart);


			var commonModel6 = new CommonModel
			{
				Start = this.today.AddMinutes(30),
				End = this.today.AddHours(5),
				Title = "Special and Read - only slots",
				Member = "Dominique Perrier",
                Parent = commonModel15,
				Resources = { new EmployeeResource { ResourceName = "Dominique Perrier", DisplayName = "Dominique Perrier", ResourceType = "Employee" } },
			};
			commonModel6.AddDependency(commonModel4, DependencyType.FinishStart);


			var commonModel7 = new CommonModel
			{
				Start = this.today.AddHours(5),
				End = this.today.AddHours(7),
				Title = "Gantt & Timeline example",
				Member = "Dominique Perrier",
                Parent = commonModel14,
				Resources = { new EmployeeResource { ResourceName = "Dominique Perrier", DisplayName = "Dominique Perrier", ResourceType = "Employee" } },
			};
			commonModel7.AddDependency(commonModel5, DependencyType.FinishStart);

			var commonModel8 = new CommonModel
			{
				Start = this.today.AddHours(7),
				End = this.today.AddHours(12).AddMinutes(30),
				Title = "Filtering TimeRuler Items",
				Member = "Dominique Perrier",
                Parent = commonModel15,
				Resources = { new EmployeeResource { ResourceName = "Dominique Perrier", DisplayName = "Dominique Perrier", ResourceType = "Employee" } },
			};
			commonModel8.AddDependency(commonModel6, DependencyType.FinishStart);

			var commonModel9 = new CommonModel
			{
				Start = this.today.AddMinutes(30),
				End = this.today.AddDays(1),
				Title = "GanttView fixing themes bugs",
				Member = "Mary Baird",
                Parent = commonModel14,
				Resources = { new EmployeeResource { ResourceName = "Mary Baird", DisplayName = "Mary Baird", ResourceType = "Employee" } },
			};
			commonModel9.AddDependency(commonModel7, DependencyType.FinishStart);

			var commonModel10 = new CommonModel
			{
				Start = this.today.AddMinutes(30),
				End = this.today.AddHours(3),
				Title = "Filtering TimeRuler Items – data example research and discussion",
				Member = "Jaime Yorres",
                Parent = commonModel14,
				Resources = { new EmployeeResource { ResourceName = "Jaime Yorres", DisplayName = "Jaime Yorres", ResourceType = "Employee" } },
			};
			commonModel10.AddDependency(commonModel8, DependencyType.FinishStart);

			var commonModel11 = new CommonModel
			{
				Start = this.today.AddMinutes(30),
				End = this.today.AddHours(6),
				Title = "Resources View",
				Member = "Grace Becerra",
                Parent = commonModel14,
				Resources = { new EmployeeResource { ResourceName = "Grace Becerra", DisplayName = "Grace Becerra", ResourceType = "Employee" } },
			};
			commonModel11.AddDependency(commonModel9, DependencyType.FinishStart);

			var commonModel12 = new CommonModel
			{
				Start = this.today.AddHours(6),
				End = this.today.AddHours(12),
				Title = "Drag & Drop of the appointments",
				Member = "Grace Becerra",
                Parent = commonModel15,
				Resources = { new EmployeeResource { ResourceName = "Grace Becerra", DisplayName = "Grace Becerra", ResourceType = "Employee" } },
			};
			commonModel12.AddDependency(commonModel10, DependencyType.FinishStart);

			var commonModel13 = new CommonModel
			{
				Start = this.today.AddHours(3),
				End = this.today.AddHours(10),
				Title = "Filtering TimeRuler example - design sketches",
				Member = "Jaime Yorres",
                Parent = commonModel14,
				Resources = { new EmployeeResource { ResourceName = "Jaime Yorres", DisplayName = "Jaime Yorres", ResourceType = "Employee" } },
			};
			commonModel13.AddDependency(commonModel11, DependencyType.FinishStart);
			
			
			var commonModel16 = new CommonModel
			{
				Title = "All tasks for current sprint.",
				Start = this.today.AddMinutes(30),
				End = this.today.AddDays(10),
				Children = { commonModel14, commonModel15 }
			};

            commonModel14.Children.Add(commonModel1);
            commonModel14.Children.Add(commonModel3);
            commonModel14.Children.Add(commonModel7);
            commonModel14.Children.Add(commonModel5);
            commonModel14.Children.Add(commonModel9);
            commonModel14.Children.Add(commonModel10);
            commonModel14.Children.Add(commonModel11);
            commonModel14.Children.Add(commonModel13);

            commonModel15.Children.Add(commonModel2);
            commonModel15.Children.Add(commonModel4);
            commonModel15.Children.Add(commonModel6);
            commonModel15.Children.Add(commonModel8);
            commonModel15.Children.Add(commonModel12);

			this.tasks.Add(commonModel16);

			this.appointments.Add(commonModel1);
			this.appointments.Add(commonModel2);
			this.appointments.Add(commonModel3);
			this.appointments.Add(commonModel4);
			this.appointments.Add(commonModel5);
			this.appointments.Add(commonModel6);
			this.appointments.Add(commonModel7);
			this.appointments.Add(commonModel8);
			this.appointments.Add(commonModel9);
			this.appointments.Add(commonModel10);
			this.appointments.Add(commonModel11);
			this.appointments.Add(commonModel12);
			this.appointments.Add(commonModel13);
			this.appointments.Add(commonModel16);
		}

        public void UpdateParent(CommonModel oldParent, CommonModel newParent, CommonModel task)
        {
            if (oldParent != newParent)
            {
                if (oldParent != null)
                {
                    oldParent.Children.Remove(task);
                }
                if (newParent != null)
                {
                    newParent.Children.Add(task);
                }
            }
        }
    }
}
