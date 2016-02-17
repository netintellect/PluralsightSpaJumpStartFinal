using System;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.GanttTimeline
{
	public class ViewModel : ViewModelBase
	{

		public ViewModel()
		{
			this.movies = MovieRepository.LoadMovies();

			foreach (var movie in this.movies)
			{
				this.Tasks.Add(MovieRepository.LoadTaskByMovie(movie));
			}

			this.InitializeData();

			this.Refresh();
		}

		#region Properties		

		private ObservableCollection<GanttTask> tasks;
		public ObservableCollection<GanttTask> Tasks
		{
			get
			{
				if (this.tasks == null)
				{
					this.tasks = new ObservableCollection<GanttTask>();
				}
				return this.tasks;
			}
			set
			{
				if (this.tasks != value)
				{
					this.tasks = value;
				}
				OnPropertyChanged(() => Tasks);
			}
		}

		private ObservableCollection<Movie> movies;
		public ObservableCollection<Movie> Movies
		{
			get
			{
				return movies;
			}
			set
			{
				movies = value;
				OnPropertyChanged(() => Movies);
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

		private DateTime startDate;
		public DateTime StartDate
		{
			get
			{
				return startDate;
			}
			set
			{

				if (this.startDate == value)
					return;

				this.startDate = value;
				OnPropertyChanged(() => this.StartDate);
			}
		}

		private DateTime endDate;
		public DateTime EndDate
		{
			get
			{
				return endDate;
			}
			set
			{
				if (this.endDate == value)
					return;

				this.endDate = value;
				OnPropertyChanged(() => this.EndDate);
			}
		}
		
		private Movie selectedMovie;
		public Movie SelectedMovie
		{
			get { return selectedMovie; }
			set
			{
				selectedMovie = value;
				OnPropertyChanged(() => this.SelectedMovie);
			}
		}

		private GanttTask selectedTask;
		public GanttTask SelectedTask
		{
			get { return selectedTask; }
			set 
			{
				if (this.selectedTask != value)
				{
					this.selectedTask = value;

					var index = this.tasks.IndexOf(selectedTask);
                    if (index >= 0)
                    {
                        this.SelectedMovie = this.Movies[index];
                    }

					OnPropertyChanged(() => this.SelectedTask);
				}				 
			}
		}

		#endregion

		public int IndexOf(Movie movie)
		{
			return this.Movies.IndexOf(movie);
		}

		private void Refresh()
		{
			OnPropertyChanged(() => this.VisibleRange);
			OnPropertyChanged(() => this.Tasks);
		}

		private void InitializeData()
		{
			this.startDate = new DateTime(1970, 1, 1);
			this.endDate = DateTime.Today;
			this.selectedMovie = this.movies.First();
			this.visibleRange = new DateRange(selectedMovie.StartFilmingDate, DateTime.Today);
		}
	}
}
