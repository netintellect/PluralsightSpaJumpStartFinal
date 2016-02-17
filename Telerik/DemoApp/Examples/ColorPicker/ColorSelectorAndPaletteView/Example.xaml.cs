using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ColorPicker.ColorSelectorAndPaletteView
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		private ObservableCollection<ColorPreset> OfficeColorPalettes;
		public Example()
		{
			InitializeComponent();
			this.BindConfigurationCombos();
		}

		private void BindConfigurationCombos()
		{
			this.OfficeColorPalettes = new ObservableCollection<ColorPreset>()
			{
				ColorPreset.Apex, ColorPreset.Aspect, ColorPreset.Civic, ColorPreset.Concourse, ColorPreset.Equity,
				ColorPreset.Flow, ColorPreset.Foundry, ColorPreset.Median, ColorPreset.Metro, ColorPreset.Module,
				ColorPreset.Office, ColorPreset.Opulent, ColorPreset.Oriel, ColorPreset.Origin, ColorPreset.Paper,
				ColorPreset.Solstice, ColorPreset.Standard, ColorPreset.Technique, ColorPreset.Trek, ColorPreset.Urban, ColorPreset.Verve
			};

			this.mainPalettesCombo.ItemsSource = this.OfficeColorPalettes;
			this.headerPalettesCombo.ItemsSource = this.OfficeColorPalettes;
			this.standardPalettesCombo.ItemsSource = this.OfficeColorPalettes;

			this.allPalettesCombo.ItemsSource = Enum.GetValues(typeof(ColorPreset));
		}
	}
}
