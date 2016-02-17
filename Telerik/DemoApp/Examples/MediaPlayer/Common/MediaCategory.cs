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

namespace Examples.MediaPlayer.CS.Silverlight.Common
{
	public class MediaCategory
	{
		public MediaCategory()
		{
			Items = new ObservableCollection<MediaItem>();
		}

		public string Name { get; set; }

		public string Color { get; set; }

		public ObservableCollection<MediaItem> Items { get; private set; }
	}
}
