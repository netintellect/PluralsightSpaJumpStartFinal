using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TileView.Common
{
	public class Country : ViewModelBase
	{
		private TileViewItemState state;

		public Country(string name, int subDirCount)
		{
			this.Name = name;
			string dirs = string.Empty;
			for (int i = 0; i < subDirCount; i++)
			{
				dirs += "../";
			}

			this.SmallFlag = string.Format("{0}Images/TileView/Flags/Small/{1}.png", dirs, name);
			this.LargeFlag = string.Format("{0}Images/TileView/Flags/Large/{1}.png", dirs, name);
		}

		public string SmallFlag { get; set; }
		public string LargeFlag { get; set; }
		public string Name { get; set; }
		public string PoliticalSystem { get; set; }
		public string CapitalCity { get; set; }
		public string TotalArea { get; set; }
		public string Population { get; set; }
		public string Currency { get; set; }
		public string OfficialLanguage { get; set; }
		public string Description { get; set; }

		public TileViewItemState State
		{
			get
			{
				return state;
			}
			set
			{
				if (state != value)
				{
					state = value;
					OnPropertyChanged("State");
				}
			}
		}
	}
}