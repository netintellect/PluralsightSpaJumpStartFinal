using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TimeSpanPicker.FirstLook
{
    public class ViewModel : ViewModelBase
    {
        private CollectionViewSource filteredMovies;
        private ObservableCollection<CinemaMovieInfo> movies;
        private ObservableCollection<string> durations;
        private TimeSpan? selectedMinStartTime;
        private TimeSpan? selectedDuration;
        private Visibility notMovieFoundVisibility;
        private string cinemaProgramHeader;

        public ViewModel()
        {
            this.filteredMovies = new CollectionViewSource();
            this.FilteredMovies.Source = this.Movies;
            this.FilteredMovies.Filter += FilteredMovies_Filter;
            this.EmptyScreenVisibility = Visibility.Collapsed;
            this.CinemaProgramHeader = "All movies screening today";
        }

        public TimeSpan? SelectedMinStartTime
        {
            get
            {
                return this.selectedMinStartTime;
            }

            set
            {
                if (this.selectedMinStartTime != value)
                {
                    this.selectedMinStartTime = value;
                    this.OnPropertyChanged(() => this.SelectedMinStartTime);
                    this.FilteredMovies.View.Refresh();
                    this.SetEmptyScreenImageVisibility();
                    this.GenerateCinemaHeader();
                }
            }
        }

        public TimeSpan? SelectedDuration
        {
            get
            {
                return this.selectedDuration;
            }

            set
            {
                if (this.selectedDuration != value)
                {
                    this.selectedDuration = value;
                    this.OnPropertyChanged(() => this.SelectedDuration);
                    this.FilteredMovies.View.Refresh();
                    this.SetEmptyScreenImageVisibility();
                    this.GenerateCinemaHeader();
                }
            }
        }

        public CollectionViewSource FilteredMovies
        {
            get
            {
                return this.filteredMovies;
            }
        }

        public ObservableCollection<CinemaMovieInfo> Movies
        {
            get
            {
                if (this.movies == null)
                {
                    this.movies = new ObservableCollection<CinemaMovieInfo>();
                    this.movies = CinemaMovieRepository.LoadMovies();
                }
                return this.movies;
            }
        }

        public ObservableCollection<string> Durations
        {
            get
            {
                if (this.durations == null)
                {
                    this.durations = new ObservableCollection<string>();

                    int minutes = 30;
                    for (int i = 0; i <= 10; i++)
                    {
                        this.durations.Add(minutes + " minutes");
                        if (minutes >= 90 && minutes < 180)
                        {
                            minutes += 15;
                        }
                        else
                        {
                            minutes += 30;
                            if (minutes > 240)
                            {
                                minutes = 240;
                            }
                        }
                    }
                }
                return this.durations;
            }
        }

        public Visibility EmptyScreenVisibility
        {
            get
            {
                return this.notMovieFoundVisibility;
            }
            set
            {
                if(this.notMovieFoundVisibility != value)
                {
                    this.notMovieFoundVisibility = value;
                    this.OnPropertyChanged(() => this.EmptyScreenVisibility);
                }
            }
        }

        public string CinemaProgramHeader
        {
            get
            {
                return this.cinemaProgramHeader;
            }
            set
            {
                if(this.cinemaProgramHeader != value)
                {
                    this.cinemaProgramHeader = value;
                    this.OnPropertyChanged(() => this.CinemaProgramHeader);
                }
            }
        }

        private void FilteredMovies_Filter(object sender, FilterEventArgs e)
        {
            var movie = e.Item as CinemaMovieInfo;

            if (movie != null)
            {
                if(this.SelectedMinStartTime != null)
                {
                    e.Accepted = (DateTime.Now.TimeOfDay + this.SelectedMinStartTime) <= movie.StartTime.TimeOfDay
                        && (this.SelectedDuration == null || this.SelectedDuration <= movie.Duration);
                }
                else
                {
                    e.Accepted = this.SelectedDuration == null || this.SelectedDuration <= movie.Duration;
                }
            }
        }

        private void SetEmptyScreenImageVisibility()
        {
            if (this.FilteredMovies.View.IsEmpty)
            {
                this.EmptyScreenVisibility = Visibility.Visible;
            }
            else
            {
                if (this.EmptyScreenVisibility == Visibility.Visible)
                {
                    this.EmptyScreenVisibility = Visibility.Collapsed;
                }
            }
        }

        private void GenerateCinemaHeader()
        {
            if(this.SelectedMinStartTime == null && this.SelectedDuration == null)
            {
                this.CinemaProgramHeader = "All movies screening today";
            }
            else
            {
                if(this.SelectedMinStartTime != null && this.SelectedDuration == null)
                {
                    if (DateTime.Now.AddMinutes(this.SelectedMinStartTime.Value.TotalMinutes).Date.CompareTo(DateTime.Now.Date) == 0)
                    {
                        this.CinemaProgramHeader = "Movies starting today after " + DateTime.Now.AddMinutes(this.SelectedMinStartTime.Value.TotalMinutes).ToString("hh:mm tt");
                    }
                    else
                    {
                        this.CinemaProgramHeader = "The program for " + DateTime.Now.AddMinutes(this.SelectedMinStartTime.Value.TotalMinutes).ToString("d") + " is not available yet!";
                    }
                }
                else
                {
                    if (this.SelectedMinStartTime == null)
                    {
                        this.CinemaProgramHeader = "Movies with minimum duration of " + this.SelectedDuration.Value.TotalMinutes + " minutes";
                    }
                    else
                    {
                        if (DateTime.Now.AddMinutes(this.SelectedMinStartTime.Value.TotalMinutes).Date.CompareTo(DateTime.Now.Date) == 0)
                        {
                            this.CinemaProgramHeader = "Movies starting today after " + DateTime.Now.AddMinutes(this.SelectedMinStartTime.Value.TotalMinutes).ToString("hh:mm tt") + " with minimum duration " + this.SelectedDuration.Value.TotalMinutes + " minutes";
                        }
                        else
                        {
                            this.CinemaProgramHeader = "The program for " + DateTime.Now.AddMinutes(this.SelectedMinStartTime.Value.TotalMinutes).ToString("d") + " is not available yet!";
                        }
                    }
                }
            }
        }
    }
}
