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
using System.Collections.Generic;

namespace Telerik.Windows.Examples.TileView.Common.FirstLook
{
	public class MainViewModel
	{
		private ObservableCollection<Trip> items;

		public MainViewModel()
		{
			Random rand = new Random();
			List<Trip> itemsSource = new List<Trip>();
			for (int i = 0; i < 12; i++)
			{
				int duration = rand.Next(4, 8);
				itemsSource.Add(new Trip()
				{
					Image = this.images[i % 12],
					Destination = this.cities[i % 12],
					Duration = duration.ToString() + " days",
					Price = (duration * 65).ToString() + " USD",
					Icon = this.icons[rand.Next(0, 3)],
					Rating = rand.Next(4, 9)
				});
			}

			this.items = new ObservableCollection<Trip>(itemsSource);
		}

		public ObservableCollection<Trip> Items
		{
			get
			{
				return items;
			}
		}

		private List<string> images = new List<string>
		{
#if SILVERLIGHT
			"../../Images/TileView/FirstLook/Amsterdam.png",
			"../../Images/TileView/FirstLook/Athens.png",
			"../../Images/TileView/FirstLook/Barcelona.png",
			"../../Images/TileView/FirstLook/Berlin.png",
			"../../Images/TileView/FirstLook/Budapest.png",
			"../../Images/TileView/FirstLook/London.png",
			"../../Images/TileView/FirstLook/Paris.png",
			"../../Images/TileView/FirstLook/Prague.png",
			"../../Images/TileView/FirstLook/Roma.png",
			"../../Images/TileView/FirstLook/Stockholm.png",
			"../../Images/TileView/FirstLook/Vienna.png",
			"../../Images/TileView/FirstLook/Berlin.png"
#else
			"/TileView;component/Images/TileView/FirstLook/Amsterdam.png",
			"/TileView;component/Images/TileView/FirstLook/Athens.png",
			"/TileView;component/Images/TileView/FirstLook/Barcelona.png",
			"/TileView;component/Images/TileView/FirstLook/Berlin.png",
			"/TileView;component/Images/TileView/FirstLook/Budapest.png",
			"/TileView;component/Images/TileView/FirstLook/London.png",
			"/TileView;component/Images/TileView/FirstLook/Paris.png",
			"/TileView;component/Images/TileView/FirstLook/Prague.png",
			"/TileView;component/Images/TileView/FirstLook/Roma.png",
			"/TileView;component/Images/TileView/FirstLook/Stockholm.png",
			"/TileView;component/Images/TileView/FirstLook/Vienna.png",
			"/TileView;component/Images/TileView/FirstLook/Berlin.png"
#endif
		};

		private List<string> cities = new List<string>
		{
			"Amsterdam",
			"Athens",
			"Barcelona",
			"Berlin",
			"Budapest",
			"London",
			"Paris",
			"Prague",
			"Roma",
			"Stockholm",
			"Vienna",
			"Berlin"
		};

		private List<string> icons = new List<string>
		{
#if SILVERLIGHT
			"../../Images/TileView/FirstLook/new.png",
			"../../Images/TileView/FirstLook/topprice.png",
			"../../Images/TileView/FirstLook/none"
#else
			"/TileView;component/Images/TileView/FirstLook/new.png",
			"/TileView;component/Images/TileView/FirstLook/topprice.png",
			"/TileView;component/Images/TileView/FirstLook/none"
#endif
		};
	}
}
