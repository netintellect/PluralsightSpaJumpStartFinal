using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;
using System.ComponentModel;

namespace Telerik.Windows.Examples.GanttView.ScrollingPerformance
{
	public class ViewModel : ViewModelBase
	{
		private ObservableCollection<GanttTask> ganttTasks;
		private TimeSpan pixelLength;
		private VisibleRange visibleRange;
		private bool isBusy;

		public ViewModel()
		{
			this.GanttTasks = new ObservableCollection<GanttTask>();
			this.pixelLength = new TimeSpan(0, 10, 0);
			this.VisibleRange = new VisibleRange(DateTime.Today, DateTime.Today.AddDays(9));
		}

		public ObservableCollection<GanttTask> GanttTasks
		{
			get
			{
				return this.ganttTasks;
			}
			set
			{
				this.ganttTasks = value;
				this.OnPropertyChanged(() => this.GanttTasks);
			}
		}

		public TimeSpan PixelLength
		{
			get
			{
				return this.pixelLength;
			}
			set
			{
				this.pixelLength = value;
				this.OnPropertyChanged(() => this.PixelLength);
			}
		}

		public VisibleRange VisibleRange
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

		public bool IsBusy
		{
			get
			{
				return this.isBusy;
			}
			set
			{
				if (this.isBusy != value)
				{
					this.isBusy = value;
					this.OnPropertyChanged(() => this.IsBusy);

					if (this.IsBusy)
					{
						var backgroundWorker = new BackgroundWorker();
						backgroundWorker.DoWork += OnBackgroundWorkerDoWork;
						backgroundWorker.RunWorkerCompleted += OnBackgroundWorkerRunWorkerCompleted;
						backgroundWorker.RunWorkerAsync();
					}
				}
			}
		}

		void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			var backgroundWorker = sender as BackgroundWorker;
			backgroundWorker.DoWork -= this.OnBackgroundWorkerDoWork;
			backgroundWorker.RunWorkerCompleted -= OnBackgroundWorkerRunWorkerCompleted;

			InvokeOnUIThread(() =>
			{
				this.GanttTasks = new ObservableCollection<GanttTask>((IEnumerable<GanttTask>)e.Result);
				this.IsBusy = false;
			});

		}

		private void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			var ganttTasks = this.GenerateTasks();
			e.Result = ganttTasks;
		}

		private IEnumerable<GanttTask> GenerateTasks()
		{
			List<GanttTask> ganttTasks = new List<GanttTask>();

			int ganttTasksCount = 0;

			for (int index = 0; index < 3000; index++)
			{
				var start = DateTime.Today.AddDays(1);
				var end = start.AddDays(1);

				var ganttTask = new GanttTask { Title = string.Format("Task{0}", ganttTasksCount), Start = start.AddDays(-0.5), End = end.AddDays(6.5), UniqueId = index.ToString() };

				ganttTasks.Add(ganttTask);
				ganttTasksCount++;

				for (int children = 0; children < 16; children++)
				{
					double startAdd = children / 2 + (children % 2) * 0.5 -0.5;
					double endAdd = startAdd + 0.43;
					var child = new GanttTask { Title = string.Format("Task{0}", ganttTasksCount), Start = start.AddDays(startAdd), End = start.AddDays(endAdd) };
					if (children != 0)
					{
						child.Dependencies.Add(new Dependency {FromTask = ganttTask.Children[children - 1], Type = DependencyType.FinishStart });
					}
					ganttTask.Children.Add(child);
					ganttTasksCount++;
				}
			}

			return ganttTasks;
		}
	}
}
