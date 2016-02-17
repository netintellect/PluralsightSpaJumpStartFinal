using Telerik.Windows.Controls.GanttView;

namespace Telerik.Windows.Examples.GanttView.Programming.LockingFunctions
{
	public class LockingTask : GanttTask
	{
		private int id;
		public int Id
		{
			get { return id; }
			set
			{
				if (this.id != value)
				{
					id = value;
					this.OnPropertyChanged(() => this.Id);
				}
			}
		}

		private bool isDragDropLocked;
		public bool IsDragDropLocked
		{
			get
			{
				return isDragDropLocked;
			}
			set
			{
				if (this.isDragDropLocked != value)
				{
					this.isDragDropLocked = value;
					this.OnPropertyChanged(() => this.IsDragDropLocked);
				}
			}
		}

		private bool isDragReorderLocked;
		public bool IsDragReorderLocked
		{
			get
			{
				return isDragReorderLocked;
			}
			set
			{
				if (this.isDragReorderLocked != value)
				{
					this.isDragReorderLocked = value;
					this.OnPropertyChanged(() => this.IsDragReorderLocked);
				}
			}
		}

		private bool isResizeLocked;
		public bool IsResizeLocked
		{
			get
			{
				return isResizeLocked;
			}
			set
			{
				if (this.isResizeLocked != value)
				{
					this.isResizeLocked = value;
					this.OnPropertyChanged(() => this.IsResizeLocked);
				}
			}
		}

		private bool areDependenciesLocked;
		public bool AreDependenciesLocked
		{
			get
			{
				return areDependenciesLocked;
			}
			set
			{
				if (this.areDependenciesLocked != value)
				{
					this.areDependenciesLocked = value;
					this.OnPropertyChanged(() => this.AreDependenciesLocked);
				}

			}

		}

		private bool isItemLocked;
		public bool IsItemLocked
		{
			get
			{
				return isItemLocked;
			}
			set
			{
				if (this.isItemLocked != value)
				{
					this.isItemLocked = value;
					this.OnPropertyChanged(() => this.IsItemLocked);
				}
			}
		}
	}
}
