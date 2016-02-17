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

namespace Examples.MediaPlayer.CS.Silverlight.Common
{
	public class Chapter : INotifyPropertyChanged
	{
		private bool isSelected;

		public string Title { get; set; }

		public TimeSpan Position { get; set; }

		public MediaItem Parent { get; set; }

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
					Parent.IsSelected = true;

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
