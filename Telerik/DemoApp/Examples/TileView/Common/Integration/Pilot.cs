using System;
using System.ComponentModel;

namespace Telerik.Windows.Examples.TileView.Common.ViewModels
{
	public class Pilot : INotifyPropertyChanged
	{
		public string Name
		{
			get;
			set;
		}

		public string Nationality
		{
			get;
			set;
		}

		public int Age
		{
			get;
			set;
		}

		public int FirstGrandPrix
		{
			get;
			set;
		}

		public int Races
		{
			get;
			set;
		}

		public int Wins
		{
			get;
			set;
		}

		public int Championships
		{
			get;
			set;
		}

		public Uri ProfilePicture
		{
			get;
			set;
		}

		private int position;

		public int Position
		{
			get
			{
				return this.position;
			}
			set
			{
				if (this.position != value)
				{
					this.position = value;
					this.OnPropertyChanged("Position");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

	}
}
