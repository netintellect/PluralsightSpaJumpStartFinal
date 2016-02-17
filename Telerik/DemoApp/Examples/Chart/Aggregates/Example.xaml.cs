using System.Windows.Controls;
#if SILVERLIGHT
using SelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangedEventArgs;
#else
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
#endif

namespace Telerik.Windows.Examples.Chart.Aggregates
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

        private void RadGridView1_Grouping(object sender, Controls.GridViewGroupingEventArgs e)
        {
            RadChart1.DefaultView.ChartArea.StartTransitionAnimation();
        }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (RadChart1 == null)
                return;

            RadChart1.DefaultView.ChartArea.StartTransitionAnimation();
        }

        private void RadComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RadChart1 == null)
                return;

            RadChart1.DefaultView.ChartArea.StartTransitionAnimation();
        }
    }
}
