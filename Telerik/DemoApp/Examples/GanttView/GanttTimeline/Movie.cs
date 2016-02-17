using System;

namespace Telerik.Windows.Examples.GanttView.GanttTimeline
{
	public class Movie
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public string Genre { get; set; }

		public DateTime ReleaseDate { get; set; }

		public DateTime StartFilmingDate { get; set; }

		public string GenreIconWidth { get; set; }

		public string GenreIconHeight { get; set; }

		public string GenreIconRotation { get; set; }

		public string GenreIcon { get; set; }
		
		public TimeSpan FilmingDuration
		{
			get
			{
				return this.ReleaseDate.Subtract(this.StartFilmingDate);
			}
		}
	}
}
