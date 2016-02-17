using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Controls;
#if WPF
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
#elif SILVERLIGHT
using SelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangedEventArgs;
#endif

namespace Telerik.Windows.Examples.Chart.EmptyValues
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

#if SILVERLIGHT
            this.UpdateSeriesDefinition();
#endif
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (this.chartarea != null)
            {
                for (int i = 0; i < this.chartarea.DataSeries.Count; i++)
                {
                    this.chartarea.DataSeries[i].Definition.EmptyPointBehavior = EmptyPointBehavior.Zero;
                }
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.chartarea != null)
            {
                for (int i = 0; i < this.chartarea.DataSeries.Count; i++)
                {
                    this.chartarea.DataSeries[i].Definition.EmptyPointBehavior = EmptyPointBehavior.Gap;
                }
            }
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            if (this.chartarea != null)
            {
                for (int i = 0; i < this.chartarea.DataSeries.Count; i++)
                {
                    this.chartarea.DataSeries[i].Definition.EmptyPointBehavior = EmptyPointBehavior.Drop;
                }
            }
        }

        private void ChartSeriesDefinitionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.UpdateSeriesDefinition();
        }

        private void UpdateSeriesDefinition()
        {
            if (this.RadChart1 == null)
                return;

            RadChart1.DefaultSeriesDefinition = (ISeriesDefinition)ChartSeriesDefinitionComboBox.SelectedItem;
            if (Radio1.IsChecked == true)
                this.RadChart1.DefaultSeriesDefinition.EmptyPointBehavior = EmptyPointBehavior.Zero;

            else if (Radio2.IsChecked == true)
                this.RadChart1.DefaultSeriesDefinition.EmptyPointBehavior = EmptyPointBehavior.Gap;

            else if (Radio3.IsChecked == true)
                this.RadChart1.DefaultSeriesDefinition.EmptyPointBehavior = EmptyPointBehavior.Drop;

            RadChart1.Rebind();
        }
    }
}
