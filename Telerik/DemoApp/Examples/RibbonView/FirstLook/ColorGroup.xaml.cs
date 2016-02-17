using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RibbonView.FirstLook
{
	public partial class ColorGroup : UserControl
	{
		public ColorGroup()
		{
			InitializeComponent();

			this.customPaletteView.PaletteColumnsCount = 10;
			this.customPaletteView.ItemsSource = GetColors();
		}

		private List<Color> GetColors()
		{
			List<Color> colors = new List<Color>();
			colors.Add(ColorPaletteBase.HexStringToColor("#FF000000"));
			colors.Add(ColorPaletteBase.HexStringToColor("#FFFFFFFF"));
			colors.Add(ColorPaletteBase.HexStringToColor("#00FFFFFF"));

			colors.Add(ColorPaletteBase.HexStringToColor("#FF7F7F7F"));
			colors.Add(ColorPaletteBase.HexStringToColor("#FFC3C3C3"));
			colors.Add(ColorPaletteBase.HexStringToColor("#00FFFFFF"));

			colors.Add(ColorPaletteBase.HexStringToColor("#FF880015"));
			colors.Add(ColorPaletteBase.HexStringToColor("#FFB97A57"));
			colors.Add(ColorPaletteBase.HexStringToColor("#00FFFFFF"));

			colors.Add(ColorPaletteBase.HexStringToColor("#FFED1C24"));
			colors.Add(ColorPaletteBase.HexStringToColor("#FFFFAEC9"));
			colors.Add(ColorPaletteBase.HexStringToColor("#00FFFFFF"));

			colors.Add(ColorPaletteBase.HexStringToColor("#FFFF7F27"));
			colors.Add(ColorPaletteBase.HexStringToColor("#FFFFC90E"));
			colors.Add(ColorPaletteBase.HexStringToColor("#00FFFFFF"));

			colors.Add(ColorPaletteBase.HexStringToColor("#FFFFF200"));
			colors.Add(ColorPaletteBase.HexStringToColor("#FFEFE4B0"));
			colors.Add(ColorPaletteBase.HexStringToColor("#00FFFFFF"));


			colors.Add(ColorPaletteBase.HexStringToColor("#FF22B14C"));
			colors.Add(ColorPaletteBase.HexStringToColor("#FFB5E61D"));
			colors.Add(ColorPaletteBase.HexStringToColor("#00FFFFFF"));

			colors.Add(ColorPaletteBase.HexStringToColor("#FF00A2E8"));
			colors.Add(ColorPaletteBase.HexStringToColor("#FF99D9EA"));
			colors.Add(ColorPaletteBase.HexStringToColor("#00FFFFFF"));

			colors.Add(ColorPaletteBase.HexStringToColor("#FF3F48CC"));
			colors.Add(ColorPaletteBase.HexStringToColor("#FF7092BE"));
			colors.Add(ColorPaletteBase.HexStringToColor("#00FFFFFF"));

			colors.Add(ColorPaletteBase.HexStringToColor("#FFA349A4"));
			colors.Add(ColorPaletteBase.HexStringToColor("#FFC8BFE7"));
			colors.Add(ColorPaletteBase.HexStringToColor("#00FFFFFF"));


			return colors;
		}
	}
}
