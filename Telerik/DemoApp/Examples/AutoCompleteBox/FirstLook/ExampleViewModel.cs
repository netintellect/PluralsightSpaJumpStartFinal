using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.AutoCompleteBox.FirstLook
{
	public class ExampleViewModel : ViewModelBase
    {
        private Data source = new Data();
        private ObservableCollection<Song> songsList = new ObservableCollection<Song>();
        private ObservableCollection<Movie> moviesList = new ObservableCollection<Movie>();
        private ObservableCollection<FoodPlace> foodPlacesList = new ObservableCollection<FoodPlace>();
		private DateTime currentDate = new DateTime();

        public ExampleViewModel()
        {
            LoadSongs();
            LoadMovies();
            LoadFoodPlaces();
			this.currentDate = DateTime.Now;
        }

        private void LoadMovies()
        {
            foreach (var movie in source.GetMovies())
            {
                moviesList.Add(movie);
            }
        }

        private void LoadSongs()
        {
            foreach (var song in source.GetSongs())
            {
                songsList.Add(song);
            }
        }

        private void LoadFoodPlaces()
        {
            foreach (var fp in source.GetFoodPlaces())
            {
                foodPlacesList.Add(fp);
            }
        }

        public ObservableCollection<Song> SongsList
        {
            get
            {
                return this.songsList;
            }
        }

        public ObservableCollection<Movie> MoviesList
        {
            get
            {
                return this.moviesList;
            }
        }

        public ObservableCollection<FoodPlace> FoodPlacesList
        {
            get
            {
                return this.foodPlacesList;
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
				this.currentDate = value;
				OnPropertyChanged(()=> this.CurrentDate);
			}
		}
    }
}
