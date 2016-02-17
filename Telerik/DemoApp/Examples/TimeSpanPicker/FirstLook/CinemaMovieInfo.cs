using System;

namespace Telerik.Windows.Examples.TimeSpanPicker.FirstLook
{
    public class CinemaMovieInfo
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime StartFilmingDate { get; set; }

        public string GenreIconWidth { get; set; }

        public string GenreIconHeight { get; set; }

        public string GenreIconRotation { get; set; }

        public string GenreIcon { get; set; }

        public string GenreIconColor { get; set; }

        public TimeSpan FilmingDuration
        {
            get
            {
                return this.ReleaseDate.Subtract(this.StartFilmingDate);
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return this.EndTime.Subtract(this.StartTime);
            }
        }       
    }
}
