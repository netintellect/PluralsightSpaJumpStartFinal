using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Text;

namespace Telerik.Windows.Examples.PanelBar.FirstLook
{
	public class Employee : ViewModelBase
	{
		private ObservableCollection<Publication> publications;
		private ObservableCollection<Lecture> lectures;
		//private string additionalInfo;

		public Employee()
		{
			this.publications = new ObservableCollection<Publication>();
			this.lectures = new ObservableCollection<Lecture>();
		}

		public string Name { get; set; }
		public string Department { get; set; }
		public string Position { get; set; }
		public string PositionAdditionalInfo { get; set; }
		public string Office { get; set; }
		public string Goals { get; set; }
		public string SmallImagePath { get; set; }
		public string LargeImagePath { get; set; }

		public ObservableCollection<Publication> Publications
		{
			get
			{
				return this.publications;
			}
		}

		public ObservableCollection<Lecture> Lectures
		{
			get
			{
				return this.lectures;
			}
		}

		public string GetLecturesByDay(string day)
		{
			StringBuilder sb = new StringBuilder();
			foreach (Lecture lecture in this.Lectures)
			{
				if (lecture.DayOfTheWeek == day)
				{
					sb.Append(lecture.ToString());
				}
			}

			return sb.ToString();
		}

		public string GetPublicationsByYear(int year)
		{
			StringBuilder sb = new StringBuilder();
			foreach (Publication publication in this.Publications)
			{
				if (publication.Year == year)
				{
					sb.Append(publication.ToString());
				}
			}

			return sb.ToString();
		}
	}
}
