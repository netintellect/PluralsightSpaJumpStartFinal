using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.ColorPicker.FirstLook
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.LoadCustomPalettes();
			this.SetColorViewModels();
		}

		private void SetColorViewModels()
		{
			this.headerForegroundPicker.DataContext = new CustomColorViewModel(Color.FromArgb(255, 111, 186, 255));
			this.textForegroundPicker.DataContext = new CustomColorViewModel(Colors.Black);
			this.titleBackgroundPicker.DataContext = new CustomColorViewModel(Color.FromArgb(255, 27, 162, 237));
			this.titleBorderBrushPicker.DataContext = new CustomColorViewModel(Color.FromArgb(255, 27, 162, 237));
			this.titleForegroundPicker.DataContext = new CustomColorViewModel(Color.FromArgb(255, 254, 254, 254));
		}
		private void LoadCustomPalettes()
		{
			Collection<Color> colors = new Collection<Color>();
			colors.Add(Color.FromArgb(255, 253, 253, 0));
			colors.Add(Color.FromArgb(255, 0, 253, 0));
			colors.Add(Color.FromArgb(255, 0, 253, 253));
			colors.Add(Color.FromArgb(255, 253, 0, 253));
			colors.Add(Color.FromArgb(255, 0, 0 , 253 ));
			colors.Add(Color.FromArgb(255, 253, 0 ,0));
			colors.Add(Color.FromArgb(255, 0 , 0, 126));
			colors.Add(Color.FromArgb(255, 0, 126, 126));
			colors.Add(Color.FromArgb(255, 0, 126, 0));
			colors.Add(Color.FromArgb(255, 126, 0, 126));
			colors.Add(Color.FromArgb(255, 126, 0, 0));
			colors.Add(Color.FromArgb(255, 126, 126, 0));
			colors.Add(Color.FromArgb(255, 126, 126, 126));
			colors.Add(Color.FromArgb(255, 190, 190, 190));
			colors.Add(Color.FromArgb(255, 0 , 1 , 1));			
			this.headersBackGroundPicker.MainPaletteItemsSource = colors;
		}
	}
}
