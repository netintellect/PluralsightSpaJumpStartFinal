using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.Programming.LockingFunctions
{
	public class ViewModel : ViewModelBase
	{
		private ObservableCollection<LockingTask> tasks;
		private DateRange visibleRange;
		private DelegateCommand lockDragDropCommand;
		private DelegateCommand lockDragReorderCommand;
		private DelegateCommand lockResizeCommand;
		private DelegateCommand lockDependenciesCommand;
		private DelegateCommand lockItemCommand;

		public ViewModel()
		{
			this.tasks = new SoftwarePlanning();
			var start = this.tasks.Min(t => t.Start).Date;
			var end = this.tasks.Max(t => t.End).Date;

			this.visibleRange = new DateRange(start.AddHours(-12), end.AddDays(12));

			this.InitializeCommands();
		}

		public DelegateCommand LockDragDropCommand
		{
			get
			{
				return this.lockDragDropCommand;
			}

			set
			{
				if (this.lockDragDropCommand != value)
				{
					this.lockDragDropCommand = value;
					this.OnPropertyChanged(() => this.LockDragDropCommand);
				}
			}
		}

		public DelegateCommand LockDragReorderCommand
		{
			get
			{
				return this.lockDragReorderCommand;
			}

			set
			{
				if (this.lockDragReorderCommand != value)
				{
					this.lockDragReorderCommand = value;
					this.OnPropertyChanged(() => this.LockDragReorderCommand);
				}
			}
		}

		public DelegateCommand LockResizeCommand
		{
			get
			{
				return this.lockResizeCommand;
			}

			set
			{
				if (this.lockResizeCommand != value)
				{
					this.lockResizeCommand = value;
					this.OnPropertyChanged(() => this.LockResizeCommand);
				}
			}
		}

		public DelegateCommand LockDependenciesCommand
		{
			get
			{
				return this.lockDependenciesCommand;
			}

			set
			{
				if (this.lockDependenciesCommand != value)
				{
					this.lockDependenciesCommand = value;
					this.OnPropertyChanged(() => this.LockDependenciesCommand);
				}
			}
		}

		public DelegateCommand LockItemCommand
		{
			get
			{
				return this.lockItemCommand;
			}

			set
			{
				if (this.lockItemCommand != value)
				{
					this.lockItemCommand = value;
					this.OnPropertyChanged(() => this.LockItemCommand);
				}
			}
		}

		public ObservableCollection<LockingTask> GanttTasks
		{
			get
			{
				return this.tasks;
			}
			set
			{
				this.tasks = value;
				this.OnPropertyChanged(() => this.GanttTasks);
			}
		}

		public DateRange VisibleRange
		{
			get
			{
				return this.visibleRange;
			}
			set
			{
				this.visibleRange = value;
				this.OnPropertyChanged(() => this.VisibleRange);
			}
		}

		private void InitializeCommands()
		{
			this.lockDragDropCommand = new DelegateCommand(OnLockDragDropCommandExecuted);
			this.lockDragReorderCommand = new DelegateCommand(OnLockDragReorderCommandExecuted);
			this.lockResizeCommand = new DelegateCommand(OnLockResizeCommandExecuted);
			this.lockDependenciesCommand = new DelegateCommand(OnLockDependenciesCommandExecuted);
			this.lockItemCommand = new DelegateCommand(OnLockItemCommandExecuted);
		}

		private void OnLockItemCommandExecuted(object obj)
		{
			var task = obj as LockingTask;
			var isLocked = !task.IsItemLocked;
			task.IsItemLocked = isLocked;
			task.IsDragDropLocked = isLocked;
			task.IsDragReorderLocked = isLocked;
			task.IsResizeLocked = isLocked;
			task.AreDependenciesLocked = isLocked;
		}

		private void OnLockDependenciesCommandExecuted(object obj)
		{
			var task = obj as LockingTask;
			if (!task.IsItemLocked)
			{
				task.AreDependenciesLocked = !task.AreDependenciesLocked;
			}
		}

		private void OnLockResizeCommandExecuted(object obj)
		{
			var task = obj as LockingTask;
			if (!task.IsItemLocked)
			{
				task.IsResizeLocked = !task.IsResizeLocked;
			}
		}

		private void OnLockDragReorderCommandExecuted(object obj)
		{
			var task = obj as LockingTask;
			if (!task.IsItemLocked)
			{
				task.IsDragReorderLocked = !task.IsDragReorderLocked;
			}
		}

		private void OnLockDragDropCommandExecuted(object obj)
		{
			var task = obj as LockingTask;
			if (!task.IsItemLocked)
			{
				task.IsDragDropLocked = !task.IsDragDropLocked;
			}
		}
	}
}
