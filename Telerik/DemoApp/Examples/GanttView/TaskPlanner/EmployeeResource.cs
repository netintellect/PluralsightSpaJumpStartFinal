using System;
using System.Windows.Media;

namespace Telerik.Windows.Examples.GanttView.TaskPlanner
{
	public class EmployeeResource : Telerik.Windows.Controls.IResource, IEquatable<Telerik.Windows.Controls.IResource>,
		Telerik.Windows.Controls.Scheduling.IResource
	{
		private string name;
		private string photo;
		private string title;
		private string phone;
		private string city;
		private Brush brush;

		private string displayName;
		private string resourceName;
		private string resourceType;
		private object typeKey;

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

		public string DisplayName
		{
			get
			{
				return this.displayName;
			}
			set
			{
				if (this.displayName != value)
				{
					this.displayName = value;
				}
			}
		}

		public string ResourceName
		{
			get
			{
				return this.resourceName;
			}
			set
			{
				if (this.resourceName != value)
				{
					this.resourceName = value;
				}
			}
		}

		public string ResourceType
		{
			get
			{
				return this.resourceType;
			}
			set
			{
				if (this.resourceType != value)
				{
					this.resourceType = value;
				}
			}
		}

		public bool Equals(Telerik.Windows.Controls.IResource other)
		{
			var otherResource = other as Telerik.Windows.Controls.IResource;

			return otherResource != null &&
					otherResource.DisplayName == this.DisplayName &&
					otherResource.ResourceName == this.ResourceName &&
					otherResource.ResourceType == this.ResourceType;
		}

		public object TypeKey
		{
			get { return this.typeKey; }
		}

		public override bool Equals(object obj)
		{
			return this.Equals(obj as Telerik.Windows.Controls.IResource);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
