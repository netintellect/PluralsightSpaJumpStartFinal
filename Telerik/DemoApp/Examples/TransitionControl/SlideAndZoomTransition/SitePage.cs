using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TransitionControl.SlideAndZoomTransition
{
	public class SitePage : ViewModelBase
	{
		private string _DisplayName;
		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				if (this._DisplayName != value)
				{
					this._DisplayName = value;
					this.OnPropertyChanged("DisplayName");
				}
			}
		}

		private string _DisplayMinTemperature;
		public string DisplayMinTemperature
		{
			get
			{
				return this._DisplayMinTemperature;
			}
			set
			{
				if (this._DisplayMinTemperature != value)
				{
					this._DisplayMinTemperature = value;
					this.OnPropertyChanged("DisplayMinTemperature");
				}
			}
		}

		private string _DisplayMaxTemperature;
		public string DisplayMaxTemperature
		{
			get
			{
				return this._DisplayMaxTemperature;
			}
			set
			{
				if (this._DisplayMaxTemperature != value)
				{
					this._DisplayMaxTemperature = value;
					this.OnPropertyChanged("DisplayMaxTemperature");
				}
			}
		}

		private string _DisplayPath;
		public string DisplayPath
		{
			get
			{
				return this._DisplayPath;
			}
			set
			{
				if (this._DisplayPath != value)
				{
					this._DisplayPath = value;
					this.OnPropertyChanged("DisplayPath");
				}
			}
		}

		private int _DisplayPathWidth;
		public int DisplayPathWidth
		{
			get
			{
				return this._DisplayPathWidth;
			}
			set
			{
				if (this._DisplayPathWidth != value)
				{
					this._DisplayPathWidth = value;
					this.OnPropertyChanged("DisplayPathWidth");
				}
			}
		}

		private int _DisplayPathHeight;
		public int DisplayPathHeight
		{
			get
			{
				return this._DisplayPathHeight;
			}
			set
			{
				if (this._DisplayPathHeight != value)
				{
					this._DisplayPathHeight = value;
					this.OnPropertyChanged("DisplayPathHeight");
				}
			}
		}

		private string _PageUri;
		public string PageUri
		{
			get
			{
				return this._PageUri;
			}
			set
			{
				if (this._PageUri != value)
				{
					this._PageUri = value;
					this.OnPropertyChanged("PageUri");
				}
			}
		}
	}
}
