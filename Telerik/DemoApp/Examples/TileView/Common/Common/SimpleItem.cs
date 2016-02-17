using Telerik.Windows.Controls;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.TileView.Common
{
	public class SimpleItem : ViewModelBase
	{
		public string Name
		{
			get;
			set;
		}

		public string Image
		{
			get;
			set;
		}

		public static IEnumerable<SimpleItem> Generate(int count)
		{
			List<SimpleItem> items = new List<SimpleItem>();

			for (int i = 0; i < count; i++)
			{
				items.Add(new SimpleItem()
				{
					Name = i.ToString(),
					Image = images[i % 25]
				});
			}

			return items;
		}

		private static List<string> images = new List<string>
		{
			"/TileView;component/Images/TileView/Flags/Large/Austria.png",
			"/TileView;component/Images/TileView/Flags/Large/Belgium.png",
			"/TileView;component/Images/TileView/Flags/Large/Bulgaria.png",
			"/TileView;component/Images/TileView/Flags/Large/Cyprus.png",
			"/TileView;component/Images/TileView/Flags/Large/CzechRepublic.png",
			"/TileView;component/Images/TileView/Flags/Large/Denmark.png",
			"/TileView;component/Images/TileView/Flags/Large/Estonia.png",
			"/TileView;component/Images/TileView/Flags/Large/Finland.png",
			"/TileView;component/Images/TileView/Flags/Large/France.png",
			"/TileView;component/Images/TileView/Flags/Large/Germany.png",
			"/TileView;component/Images/TileView/Flags/Large/Greece.png",
			"/TileView;component/Images/TileView/Flags/Large/Hungary.png",
			"/TileView;component/Images/TileView/Flags/Large/Ireland.png",
			"/TileView;component/Images/TileView/Flags/Large/Italy.png",
			"/TileView;component/Images/TileView/Flags/Large/Latvia.png",
			"/TileView;component/Images/TileView/Flags/Large/Lithuania.png",
			"/TileView;component/Images/TileView/Flags/Large/Luxemburg.png",
			"/TileView;component/Images/TileView/Flags/Large/Netherlands.png",
			"/TileView;component/Images/TileView/Flags/Large/Poland.png",
			"/TileView;component/Images/TileView/Flags/Large/Romania.png",
			"/TileView;component/Images/TileView/Flags/Large/Slovakia.png",
			"/TileView;component/Images/TileView/Flags/Large/Slovenia.png",
			"/TileView;component/Images/TileView/Flags/Large/Spain.png",
			"/TileView;component/Images/TileView/Flags/Large/Sweden.png",
			"/TileView;component/Images/TileView/Flags/Large/UK.png",
		};
	}
}