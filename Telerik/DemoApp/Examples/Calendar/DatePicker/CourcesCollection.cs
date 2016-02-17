using System;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.Calendar.DatePicker
{
	public class CourcesCollection : ObservableCollection<Course>
	{
		public CourcesCollection()
		{
#if WPF
			var uri = "../Images/DatePicker/";
#else
			var uri = "../../Images/DatePicker/";
#endif

			this.Add(new Course { Name = "Cloud Development course", Room = "Room 3", Lecturer = new Lecturer { Name = "Michael Holz", Photo = new Uri(uri + "Michael Holz.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 08, 10, 0, 0) });
			this.Add(new Course { Name = "JavaScript Training Course", Room = "Room 3", Lecturer = new Lecturer { Name = "Philip Bennett", Photo = new Uri(uri + "Philip Bennett.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 07, 10, 0, 0) });
			this.Add(new Course { Name = "The Hardware/Software Interface Training Course", Room = "Room 3", Lecturer = new Lecturer { Name = "Peter Franken", Photo = new Uri(uri + "Peter Franken.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 07, 13, 30, 0) });
			this.Add(new Course { Name = "Windows Phone 7 Programming", Room = "Room 6A", Lecturer = new Lecturer { Name = "Hari Kumar", Photo = new Uri(uri + "Hari Kumar.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 07, 13, 30, 0) });
			this.Add(new Course { Name = "Visual C# Training Course - Introducing Web Forms", Room = "Room 6", Lecturer = new Lecturer { Name = "Howard Snyder", Photo = new Uri(uri + "Howard Snyder.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 07, 18, 30, 0) });
			this.Add(new Course { Name = "HTML and XAML Training Course", Room = "Room 6A", Lecturer = new Lecturer { Name = "Karl Jablonski", Photo = new Uri(uri + "Karl Jablonski.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 07, 18, 30, 0) });
			this.Add(new Course { Name = "The Hardware/Software Interface", Room = "Room 6B", Lecturer = new Lecturer { Name = "Martine Rance", Photo = new Uri(uri + "Martine Rance.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 07, 18, 30, 0) });

			this.Add(new Course { Name = "Web Development course", Room = "Room 3", Lecturer = new Lecturer { Name = "Peter Franken", Photo = new Uri(uri + "Peter Franken.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 08, 13, 30, 0) });
			this.Add(new Course { Name = "Windows 8 и XAML Training Course", Room = "Room 6", Lecturer = new Lecturer { Name = "Howard Snyder", Photo = new Uri(uri + "Howard Snyder.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 08, 18, 30, 0) });
			this.Add(new Course { Name = "Windows 8 HTML Training Course", Room = "Room 6A", Lecturer = new Lecturer { Name = "Alexander Feuer", Photo = new Uri(uri + "Alexander Feuer.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 08, 18, 30, 0) });
			this.Add(new Course { Name = "ASP.NET MVC  Training Course", Room = "Room 6B", Lecturer = new Lecturer { Name = "Ryan Giggs", Photo = new Uri(uri + "Ryan Giggs.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 08, 18, 30, 0) });

			this.Add(new Course { Name = "JavaScript Training Course", Room = "Room 3", Lecturer = new Lecturer { Name = "Philip Bennett", Photo = new Uri(uri + "Philip Bennett.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 09, 10, 0, 0) });
			this.Add(new Course { Name = "The Hardware/Software Interface Training Course", Room = "Room 3", Lecturer = new Lecturer { Name = "Peter Franken", Photo = new Uri(uri + "Peter Franken.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 09, 13, 30, 0) });
			this.Add(new Course { Name = "Windows Phone 7 Programming", Room = "Room 6A", Lecturer = new Lecturer { Name = "Hari Kumar", Photo = new Uri(uri + "Hari Kumar.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 09, 13, 30, 0) });
			this.Add(new Course { Name = "Visual C# Training Course - Introducing Web Forms", Room = "Room 6", Lecturer = new Lecturer { Name = "Howard Snyder", Photo = new Uri(uri + "Howard Snyder.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 09, 18, 30, 0) });
			this.Add(new Course { Name = "HTML and XAML Training Course", Room = "Room 6A", Lecturer = new Lecturer { Name = "Karl Jablonski", Photo = new Uri(uri + "Karl Jablonski.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 09, 18, 30, 0) });
			this.Add(new Course { Name = "The Hardware/Software Interface", Room = "Room 6B", Lecturer = new Lecturer { Name = "Martine Rance", Photo = new Uri(uri + "Martine Rance.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 09, 18, 30, 0) });

			this.Add(new Course { Name = "Cloud Development course", Room = "Room 3", Lecturer = new Lecturer { Name = "Michael Holz", Photo = new Uri(uri + "Michael Holz.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 10, 10, 0, 0) });
			this.Add(new Course { Name = "Web Development course", Room = "Room 3", Lecturer = new Lecturer { Name = "Peter Franken", Photo = new Uri(uri + "Peter Franken.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 10, 13, 30, 0) });
			this.Add(new Course { Name = "Windows 8 и XAML Training Course", Room = "Room 6", Lecturer = new Lecturer { Name = "Howard Snyder", Photo = new Uri(uri + "Howard Snyder.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 10, 18, 30, 0) });
			this.Add(new Course { Name = "Windows 8 HTML Training Course", Room = "Room 6A", Lecturer = new Lecturer { Name = "Alexander Feuer", Photo = new Uri(uri + "Alexander Feuer.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 10, 18, 30, 0) });
			this.Add(new Course { Name = "ASP.NET MVC  Training Course", Room = "Room 6B", Lecturer = new Lecturer { Name = "Ryan Giggs", Photo = new Uri(uri + "Ryan Giggs.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 10, 18, 30, 0) });

			this.Add(new Course { Name = "JavaScript Training Course", Room = "Room 3", Lecturer = new Lecturer { Name = "Philip Bennett", Photo = new Uri(uri + "Philip Bennett.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 11, 10, 0, 0) });
			this.Add(new Course { Name = "The Hardware/Software Interface Training Course", Room = "Room 3", Lecturer = new Lecturer { Name = "Peter Franken", Photo = new Uri(uri + "Peter Franken.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 11, 13, 30, 0) });
			this.Add(new Course { Name = "Windows Phone 7 Programming", Room = "Room 6A", Lecturer = new Lecturer { Name = "Hari Kumar", Photo = new Uri(uri + "Hari Kumar.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 11, 13, 30, 0) });
			this.Add(new Course { Name = "Visual C# Training Course - Introducing Web Forms", Room = "Room 6", Lecturer = new Lecturer { Name = "Howard Snyder", Photo = new Uri(uri + "Howard Snyder.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 11, 18, 30, 0) });
			this.Add(new Course { Name = "HTML and XAML Training Course", Room = "Room 6A", Lecturer = new Lecturer { Name = "Karl Jablonski", Photo = new Uri(uri + "Karl Jablonski.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 11, 18, 30, 0) });
			this.Add(new Course { Name = "The Hardware/Software Interface", Room = "Room 6B", Lecturer = new Lecturer { Name = "Martine Rance", Photo = new Uri(uri + "Martine Rance.png", UriKind.Relative) }, Date = new DateTime(2013, 01, 11, 18, 30, 0) });
		}
	}
}
