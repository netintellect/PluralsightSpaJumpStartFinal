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
using System.Collections.Generic;

namespace Examples.MediaPlayer.CS.Silverlight.Common
{
	public class MediaItem : INotifyPropertyChanged
	{
		private bool isSelected;

		public Stretch VideoStretch { get; set; }

		public string Image { get; set; }

		public double VideoWidth { get; set; }

		public string Source { get; set; }

		public string Title { get; set; }

		public List<Chapter> Chapters { get; set; }

		public bool IsSelected
		{
			get
			{
				return this.isSelected;
			}
			set
			{
				if (this.isSelected != value)
				{
					this.isSelected = value;
					OnPropertyChanged("IsSelected");
				}
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
