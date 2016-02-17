using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.LogarithmicScale
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

        private void ToggleLogModeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (this.RadChart1 != null)
                RadChart1.DefaultView.ChartArea.AxisY.IsLogarithmic = (bool)((CheckBox)sender).IsChecked;
        }
    }
}
