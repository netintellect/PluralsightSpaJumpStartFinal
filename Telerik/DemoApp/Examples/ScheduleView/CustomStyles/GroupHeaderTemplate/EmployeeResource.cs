using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.CustomStyles.GroupHeaderTemplate
{
	public class EmployeeResource : Resource
	{
		private string name;
		private string photo;
		private string title;
		private string phone;
		private string city;
		private Brush brush;

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		public string Photo
		{
			get
			{
				return this.photo;
			}
			set
			{
				this.photo = value;
			}
		}

		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				this.title = value;
			}
		}

		public string Phone
		{
			get
			{
				return this.phone;
			}
			set
			{
				this.phone = value;
			}
		}

		public string City
		{
			get
			{
				return this.city;
			}
			set
			{
				this.city = value;
			}
		}

		public Brush Brush
		{
			get
			{
				return this.brush;
			}
			set
			{
				this.brush = value;
			}
		}
	}
}