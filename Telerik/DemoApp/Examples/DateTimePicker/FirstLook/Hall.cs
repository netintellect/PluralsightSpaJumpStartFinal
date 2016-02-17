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
using System.ComponentModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.DateTimePicker.FirstLook
{
	public class Hall : ViewModelBase
	{
		private string _hallName;
		public string HallName
		{
			get
			{
				return this._hallName;
			}
			set
			{
				if (this.HallName != value)
				{
					this._hallName = value;
					this.OnPropertyChanged("HallName");
				}
			}			
		}

		private string _hallDimensionsX;
		public string HallDimensionsX
		{
			get
			{
				return this._hallDimensionsX;
			}
			set
			{
				if (this.HallDimensionsX != value)
				{
					this._hallDimensionsX = value;
					this.OnPropertyChanged("HallDimensionsX");
				}
			}
		}

		private string _hallDimensionsY;
		public string HallDimensionsY
		{
			get
			{
				return this._hallDimensionsY;
			}
			set
			{
				if (this.HallDimensionsY != value)
				{
					this._hallDimensionsY = value;
					this.OnPropertyChanged("HallDimensionsY");
				}
			}
		}

		private string _doorDimensionsX;
		public string DoorDimensionsX
		{
			get
			{
				return this._doorDimensionsX;
			}
			set
			{
				if (this.DoorDimensionsX != value)
				{
					this._doorDimensionsX = value;
					this.OnPropertyChanged("DoorDimensionsX");
				}
			}
		}

		private string _doorDimensionsY;
		public string DoorDimensionsY
		{
			get
			{
				return this._doorDimensionsY;
			}
			set
			{
				if (this.DoorDimensionsY != value)
				{
					this._doorDimensionsY = value;
					this.OnPropertyChanged("DoorDimensionsY");
				}
			}
		}

		private int _area;
		public int Area
		{
			get
			{
				return this._area;
			}
			set
			{
				if (this.Area != value)
				{
					this._area = value;
					this.OnPropertyChanged("Area");
				}
			}
		}

		private int _capacity;
		public int Capacity
		{
			get
			{
				return this._capacity;
			}
			set
			{
				if (this.Capacity != value)
				{
					this._capacity = value;
					this.OnPropertyChanged("Capacity");
				}
			}
		}

		private int _floor;
		public int Floor
		{
			get
			{
				return this._floor;
			}
			set
			{
				if (this.Floor != value)
				{
					this._floor = value;
					this.OnPropertyChanged("Floor");
				}
			}
		}
		
	}
}
