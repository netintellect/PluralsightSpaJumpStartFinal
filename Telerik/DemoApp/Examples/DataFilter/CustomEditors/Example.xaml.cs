using System;
using System.Linq;
using Telerik.Windows.Controls;
using System.Windows.Data;

namespace Telerik.Windows.Examples.DataFilter.CustomEditors
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
        public Example()
        {
            InitializeComponent();
		}

		private void OnRadDataFilterEditorCreated(object sender, Controls.Data.DataFilter.EditorCreatedEventArgs e)
		{
			switch (e.ItemPropertyDefinition.PropertyName)
			{
				case "Name":
					// This is a custom editor specified through the EditorTemplateSelector.
					RadComboBox comboBoxEditor = (RadComboBox)e.Editor;
					comboBoxEditor.ItemsSource = MyBusinessObjects.Names;
					break;
				case "OrderTime":
					// This is a default editor.
					RadDateTimePicker dateTimePickerEditor = (RadDateTimePicker)e.Editor;
					dateTimePickerEditor.InputMode = Telerik.Windows.Controls.InputMode.TimePicker;
					break;
				case "Quantity":
					// This is a custom editor specified through the EditorTemplateSelector.
					RadSlider sliderEditor = (RadSlider)e.Editor;
					sliderEditor.Minimum = 0.0;
					sliderEditor.Maximum = 100.0;
					sliderEditor.TickFrequency = 25.0;
					break;
			}
		}
    }

	public class MyInvertedBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				return !((bool)value);
			}

			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				return !((bool)value);
			}

			return null;
		}
	}
}
