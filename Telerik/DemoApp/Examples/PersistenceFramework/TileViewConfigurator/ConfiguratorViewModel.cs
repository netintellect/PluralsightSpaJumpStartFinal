using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Telerik.Windows.Examples.PersistenceFramework.TileViewConfigurator
{
	public class ConfiguratorViewModel
	{
		public ConfiguratorViewModel()
		{
			this.ColumnWidthsList = new List<GridLength>()
			{
				new GridLength(1, GridUnitType.Star),
				GridLength.Auto,
				new GridLength(110),
				new GridLength(250),
				new GridLength(350),
				new GridLength(450),
			};

			this.RowHeightsList = new List<GridLength>()
			{
				new GridLength(1, GridUnitType.Star),
				GridLength.Auto,
				new GridLength(140),
				new GridLength(210),
				new GridLength(300),
				new GridLength(400),
			};

			this.MinColumnWidths = new List<GridLength>()
			{
				new GridLength(1, GridUnitType.Star),
				new GridLength(110),
				new GridLength(250),
				new GridLength(350),
				new GridLength(450),
			};

			this.MinRowHeights = new List<GridLength>()
			{
				new GridLength(1, GridUnitType.Star),
				new GridLength(140),
				new GridLength(210),
				new GridLength(350),
				new GridLength(450),
			};
		}
		public List<GridLength> ColumnWidthsList;
		public List<GridLength> RowHeightsList;
		public List<GridLength> MinColumnWidths;
		public List<GridLength> MinRowHeights;
	}
}
