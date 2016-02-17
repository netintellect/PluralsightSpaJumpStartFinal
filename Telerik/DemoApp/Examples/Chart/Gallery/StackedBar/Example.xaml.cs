using System.Windows.Controls;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.Gallery.StackedBar
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void SetHorizontalOrientationCheckbox_Changed(object sender, System.Windows.RoutedEventArgs e)
        {
            string mappingsKey = (bool)((sender as CheckBox).IsChecked) ? "HorizontalMappings" : "VerticalMappings";
            this.RadChart1.SeriesMappings = this.Resources[mappingsKey] as SeriesMappingCollection;
        }
    }
}
