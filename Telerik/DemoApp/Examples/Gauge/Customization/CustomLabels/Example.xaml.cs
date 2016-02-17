using System;
using System.Windows;
using System.Windows.Media;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Gauge.Customization.CustomLabels
{
	public partial class Example : DynamicBasePage
	{
		/// <summary>
		/// Randomizer
		/// </summary>
		private RealDataEmulator valueGenerator = new RealDataEmulator(0, 160, 50, 20, 20);

		public Example()
		{
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Customization/CustomLabels/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Customization/CustomLabels/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
			InitializeComponent();

			DataTemplateItemsSource labelSource = new DataTemplateItemsSource();
			labelSource.Add("Default", (DataTemplate)this.Resources["FontLabelTemplate"]);
			labelSource.Add("Image", (DataTemplate)this.Resources["ImageTextLabelAppearance"]);
			labelTemplate.ItemsSource = labelSource;

			SetupBinding(labelTemplate, RadComboBox.SelectedItemProperty,
				radialScale, GraphicScale.LabelTemplateProperty,
				labelSource);

			this.relative.IsChecked = true;
		}

        private void Labels_Loaded(object sender, RoutedEventArgs e)
        {
            labelTemplate.SelectedItem = "Default";
        }

        protected override void NewValue()
        {
            marker.Value = valueGenerator.GetNextValue();
        }

		private void OffsetModeChanged(object sender, RoutedEventArgs e)
		{
			if (this.relative != null && this.labelOffset != null)
			{
				if (this.relative.IsChecked == true)
				{
					this.labelOffset.Minimum = 0;
					this.labelOffset.Maximum = 0.4;
					this.labelOffset.SmallChange = 0.01;
					this.labelOffset.Value = 0;
				}
				else
				{
					this.labelOffset.Minimum = 0;
					this.labelOffset.Maximum = 50;
					this.labelOffset.SmallChange = 1;
					this.labelOffset.Value = 0;
				}
			}
		}

		private void OffsetChanged(object sender, RadRangeBaseValueChangedEventArgs e)
		{
			if (this.relative != null)
			{
				if (this.relative.IsChecked == true)
				{
					this.radialScale.LabelOffset = new GaugeMeasure(this.labelOffset.Value.Value, GridUnitType.Star);
				}
				else
				{
					this.radialScale.LabelOffset = new GaugeMeasure(this.labelOffset.Value.Value, GridUnitType.Pixel);
				}
			}
		}
	}
}
