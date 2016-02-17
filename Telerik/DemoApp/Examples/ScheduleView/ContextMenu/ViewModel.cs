using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.ContextMenu
{
	public class ViewModel : ExampleViewModel<Appointment>
	{
		private bool isGroupedByCategory;
		private DateTime currentDate = DateTime.Today;
		private IEditableCollectionView editableCollectionView;
		private GroupDescriptionCollection groupDescriptions = new GroupDescriptionCollection();

		private DelegateCommand gotoTodayCommand;
		private ICommand nextDateCommand;
		private ICommand prevDateCommand;
		private ICommand groupByRoomCommand;
		private DelegateCommand setFreeCommand;
		private DelegateCommand setBusyCommand;
		private DelegateCommand setOutOfOfficeCommand;
		private DelegateCommand setTentativeCommand;
		private DelegateCommand clearTimeMarkerCommand;
		private bool isContextMenuOpen;

		public ViewModel()
		{
			this.GotoTodayCommand = new DelegateCommand(this.GotoTodayCommandExecuted, this.GotoTodayCommandCanExecute);
			this.NextDateCommand = new DelegateCommand(this.NextDateCommandExecuted, this.NextDateCommandCanExecute);
			this.PrevDateCommand = new DelegateCommand(this.PrevDateCommandExecuted, this.PrevDateCommandCanExecute);

			this.SetFreeCommand = new DelegateCommand(this.SetFreeCommandExecuted, CanExecuteSetTimeMarker);
			this.SetBusyCommand = new DelegateCommand(this.SetBusyCommandExecuted, CanExecuteSetTimeMarker);
			this.SetOutOfOfficeCommand = new DelegateCommand(this.SetOutOfOfficeCommandExecuted, CanExecuteSetTimeMarker);
			this.SetTentativeCommand = new DelegateCommand(this.SetTentativeCommandExecuted, CanExecuteSetTimeMarker);
			this.ClearTimeMarkerCommand = new DelegateCommand(this.ClearTimeMarkerCommandExecuted, CanExecuteSetTimeMarker);
		}

		public DelegateCommand GotoTodayCommand
		{
			get
			{
				return this.gotoTodayCommand;
			}
			set
			{
				this.gotoTodayCommand = value;
			}
		}

		public ICommand NextDateCommand
		{
			get
			{
				return this.nextDateCommand;
			}
			set
			{
				this.nextDateCommand = value;
			}
		}

		public ICommand PrevDateCommand
		{
			get
			{
				return this.prevDateCommand;
			}
			set
			{
				this.prevDateCommand = value;
			}
		}

		public ICommand GroupByRoomCommand
		{
			get
			{
				return this.groupByRoomCommand;
			}
			set
			{
				this.groupByRoomCommand = value;
			}
		}

		public DelegateCommand SetFreeCommand
		{
			get
			{
				return this.setFreeCommand;
			}
			set
			{
				this.setFreeCommand = value;
			}
		}

		public DelegateCommand SetBusyCommand
		{
			get
			{
				return this.setBusyCommand;
			}
			set
			{
				this.setBusyCommand = value;
			}
		}

		public DelegateCommand SetOutOfOfficeCommand
		{
			get
			{
				return this.setOutOfOfficeCommand;
			}
			set
			{
				this.setOutOfOfficeCommand = value;
			}
		}

		public DelegateCommand SetTentativeCommand
		{
			get
			{
				return this.setTentativeCommand;
			}
			set
			{
				this.setTentativeCommand = value;
			}
		}

		public DelegateCommand ClearTimeMarkerCommand
		{
			get
			{
				return this.clearTimeMarkerCommand;
			}
			set
			{
				this.clearTimeMarkerCommand = value;
			}
		}

		public DateTime CurrentDate
		{
			get
			{
				return this.currentDate;
			}
			set
			{
				if (this.currentDate != value)
				{
					this.currentDate = value;
					this.OnPropertyChanged(() => this.CurrentDate);
				}
			}
		}

		public bool IsContextMenuOpen
		{
			get
			{
				return this.isContextMenuOpen;
			}
			set
			{
				this.isContextMenuOpen = value;

				this.CommandsInvalidateCanExecute();
			}
		}

		public bool IsGroupedByCategory
		{
			get
			{
				return this.isGroupedByCategory;
			}
			set
			{
				if (this.isGroupedByCategory != value)
				{
					this.isGroupedByCategory = value;
					this.OnPropertyChanged(() => this.IsGroupedByCategory);

					this.ToggleGroupBy("Category", false);
				}
			}
		}

		public GroupDescriptionCollection GroupDescriptions
		{
			get { return this.groupDescriptions; }
		}

		protected IEditableCollectionView EditableCollectionView
		{
			get
			{
				if (this.editableCollectionView == null)
				{
					CollectionViewSource collectionView = new CollectionViewSource();
					collectionView.Source = this.Appointments;
					this.editableCollectionView = collectionView.View as IEditableCollectionView;
				}
				return this.editableCollectionView;
			}
		}

		private static bool CanExecuteSetTimeMarker(object parameter)
		{
			IEnumerable appointments = parameter as IEnumerable;

			return appointments != null && appointments.OfType<Appointment>().Any();
		}

		private void CommandsInvalidateCanExecute()
		{
			this.SetFreeCommand.InvalidateCanExecute();
			this.SetBusyCommand.InvalidateCanExecute();
			this.SetOutOfOfficeCommand.InvalidateCanExecute();
			this.SetTentativeCommand.InvalidateCanExecute();
			this.ClearTimeMarkerCommand.InvalidateCanExecute();
			this.GotoTodayCommand.InvalidateCanExecute();
		}

		private void ToggleGroupBy(string resourceName, bool showNullGroup)
		{
			ResourceGroupDescription resourceGroupDescription = this.GroupDescriptions.OfType<ResourceGroupDescription>().FirstOrDefault((ResourceGroupDescription d) => d.ResourceType == resourceName);
			if (resourceGroupDescription != null)
			{
				this.GroupDescriptions.Remove(resourceGroupDescription);
			}
			else
			{
				this.GroupDescriptions.Add(new ResourceGroupDescription() { ResourceType = resourceName, ShowNullGroup = showNullGroup });
			}

			this.OnPropertyChanged(() => this.GroupDescriptions);
		}

		private void GotoTodayCommandExecuted(object parameter)
		{
			this.GoToDate(DateTime.Now);
		}

		private bool GotoTodayCommandCanExecute(object parameter)
		{
			return this.CurrentDate.Date != DateTime.Today;
		}

		private void NextDateCommandExecuted(object parameter)
		{
            this.MoveToDate(parameter, true);
		}

		private bool NextDateCommandCanExecute(object parameter)
		{
			return true;
		}

		private void PrevDateCommandExecuted(object parameter)
		{
            this.MoveToDate(parameter, false);
        }

		private bool PrevDateCommandCanExecute(object parameter)
		{
			return true;
		}

		private void SetFreeCommandExecuted(object parameter)
		{
			this.SetTimeMarker(parameter, TimeMarker.Free);
		}

		private void SetBusyCommandExecuted(object parameter)
		{
			this.SetTimeMarker(parameter, TimeMarker.Busy);
		}

		private void SetOutOfOfficeCommandExecuted(object parameter)
		{
			this.SetTimeMarker(parameter, TimeMarker.OutOfOffice);
		}

		private void SetTentativeCommandExecuted(object parameter)
		{
			this.SetTimeMarker(parameter, TimeMarker.Tentative);
		}

		private void ClearTimeMarkerCommandExecuted(object parameter)
		{
			this.SetTimeMarker(parameter, null);
		}

		private void SetTimeMarker(object parameter, TimeMarker timeMarker)
		{
			IEnumerable appointments = parameter as IEnumerable;
			if (appointments != null)
			{
				foreach (Appointment appointment in appointments.OfType<Appointment>())
				{
					this.EditableCollectionView.EditItem(appointment);
                    RadScheduleViewCommands.BeginEditAppointment.Execute(appointment, null);
					
                    appointment.TimeMarker = timeMarker;
					
                    this.EditableCollectionView.CommitEdit();
                    RadScheduleViewCommands.CommitEditAppointment.Execute(appointment, null);

				}
			}
		}

		private void GoToDate(DateTime date)
		{
			this.CurrentDate = date;
		}

        private void MoveToDate(object parameter, bool isMovingForward)
        {
            var direction = isMovingForward ? 1 : -1;
            var interval = (DateTimeInterval)parameter;

            if (interval.Months != 0)
            {
                this.GoToDate(this.CurrentDate.AddMonths(direction * interval.Months));
            }
            else
            {
                this.GoToDate(this.CurrentDate.AddDays(direction * interval.Days));
            }
        }
	}
}