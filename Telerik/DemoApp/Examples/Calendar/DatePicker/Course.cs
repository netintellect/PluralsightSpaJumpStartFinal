using System;

namespace Telerik.Windows.Examples.Calendar.DatePicker
{
	public class Course
	{
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string room;
		public string Room
		{
			get { return room; }
			set { room = value; }
		}

		private DateTime date;
		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		private Lecturer lecturer;
		public Lecturer Lecturer
		{
			get { return lecturer; }
			set { lecturer = value; }
		}
	}
}
