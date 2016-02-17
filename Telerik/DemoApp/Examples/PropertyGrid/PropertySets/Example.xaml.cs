using System;
using System.Collections.Generic;
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
using System.Resources;
using PropertyGrid;
using System.Collections.ObjectModel;
using Telerik.Windows.Data;
using Telerik.Windows.Controls.Data.PropertyGrid;

namespace Telerik.Windows.Examples.PropertyGrid.PropertySets
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        List<string> propertyNames;
        public Example()
        {                                 
            InitializeComponent();
            radComboBox.ItemsSource = EnumDataSource.FromType(typeof(PropertySetOperation));            
        }

        private void OnAutoGeneratingPropertyDefinition(object sender, Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs e)
        {
            if (!(LayoutRoot.DataContext as MyViewModel).PropertyNames.Contains(e.PropertyDefinition.DisplayName))
            {
                e.Cancel = true;
            }
            if (e.PropertyDefinition.DisplayName == "Stroke")
            {
                e.PropertyDefinition.EditorTemplate = this.Resources["strokeTemplate"] as DataTemplate;
            }
            if (e.PropertyDefinition.DisplayName == "Fill")
            {
                e.PropertyDefinition.EditorTemplate = this.Resources["fillTemplate"] as DataTemplate;
            }
        }
    }

    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value as SolidColorBrush != null ? (value as SolidColorBrush).Color : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }
    }

    public class MyViewModel
    {
        private List<string> propertyNames;

        public List<string> PropertyNames
        {
            get 
            {
                if (propertyNames == null)
                {
                    propertyNames = new List<string>()
                    {
                        "Height",  
                        "Fill",
                        "ArrowHeadAngle",
                        "ArrowBodySize",
                        "FlowDirection",
                        "Orientation",
                        "Stroke",
                        "StrokeEndLineCap",
                        "StrokeLineJoin",
                        "StrokeThickness",
                        "EndAngle",
                        "StartAngle",
                        "ArcThickness",
                        "ArcThicknessUnit",
                        "PointCount"
                    };
                }
                return propertyNames; 
            }            
        }

        public ObservableCollection<FrameworkElement> EditedElements { get; set; }

        public MyViewModel()
        {
            EditedElements = new ObservableCollection<FrameworkElement>();
        }
    }
}
