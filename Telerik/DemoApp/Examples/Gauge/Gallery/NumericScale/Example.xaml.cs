using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Gauge.Gallery.NumericScale
{
	public partial class Example : DynamicBasePage
	{
		/// <summary>
		/// Randomizer
		/// </summary>
		private RealDataEmulator valueGenerator = new RealDataEmulator(0, 999, 500, 100, 100);

		public Example()
		{
			InitializeComponent();
			
			fontFamilyCombo.ItemsSource = new FontFamilyItemsSource();

			StringListItemsSource styleSource = new StringListItemsSource();
			styleSource.Add("Default", "SevenSegs");
			styleSource.Add("Hexagonal", "HexagonalSevenSegs");

			numericIndicatorStyle.ItemsSource = styleSource;
		}

		void NumericTypeIndicator_Loaded(object sender, RoutedEventArgs e)
		{
			foregroundCombo.SelectedItem = "White";
			ComboBox_SelectionChanged(null, null);

			numericIndicatorForegroundCombo.SelectedItem = "DarkBlue";
			IndicatorForeground_SelectionChanged(null, null);

			numericIndicatorBackgroundCombo.SelectedItem = "Blue";
			IndicatorBackground_SelectionChanged(null, null);

			numericIndicatorStyle.SelectedItem = "Hexagonal";

			fontFamilyCombo.SelectedItem = "Arial";
		}

		protected override void NewValue()
		{
			double value = valueGenerator.GetNextValue();
			numericIndicator.Value = value;
			bottomNumericIndicator.Value = value;
		}

		private SolidColorBrush GetBrushFromCombo(RadComboBox comboBox)
		{
			ColorStringConverter converter = new ColorStringConverter();
			SolidColorBrush brush = converter.Convert(comboBox.SelectedItem,
				typeof(SolidColorBrush),
				null,
				System.Globalization.CultureInfo.CurrentUICulture) as SolidColorBrush;

			return brush;
		}

		private void IndicatorForeground_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
		{
			SolidColorBrush brush = this.GetBrushFromCombo(numericIndicatorForegroundCombo);
			numericIndicator.Foreground = brush;
		}

		private void IndicatorStyle_SelectionChanged(object sender, Controls.SelectionChangedEventArgs e)
		{
			string style = this.numericIndicatorStyle.SelectedItem as string;
			if (!string.IsNullOrEmpty(style))
			{
				SolidColorBrush brush = this.GetBrushFromCombo(numericIndicatorBackgroundCombo);
				
				this.numericIndicator.Positions.RemoveAll();
				for (int pos = 0; pos < 6; pos++)
				{
					NumberPosition position = null;
					switch (style)
					{
						case "Default":
							position = new SevenSegsNumberPosition();
							break;

						case "Hexagonal":
							position = new HexagonalNumberPosition();
							break;

						default:
							break;
					}

					if (position != null)
					{
						position.Background = brush;
						position.CornerRadius = new CornerRadius(0);
						if (pos == 3)
						{
							ScaleObject.SetRelativeWidth(position, new GaugeMeasure(0.03, GridUnitType.Star));
						}
						this.numericIndicator.Positions.Add(position);
					}
				}
			}
		}

		private void IndicatorBackground_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
		{
			SolidColorBrush brush = this.GetBrushFromCombo(numericIndicatorBackgroundCombo);

			for (int i = 0; i < numericIndicator.Positions.Count; i++)
			{
				(numericIndicator.Positions[i] as NumberPosition).Background = brush;
			}
		}

		private void ComboBox_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
		{
			SolidColorBrush brush = this.GetBrushFromCombo(foregroundCombo);
			bottomNumericIndicator.Foreground = brush;
		}

		private void FontFamilyComboBox_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
		{
			bottomNumericIndicator.FontFamily = new FontFamily(
					(sender as RadComboBox).SelectedItem.ToString());
		}
	}
}
