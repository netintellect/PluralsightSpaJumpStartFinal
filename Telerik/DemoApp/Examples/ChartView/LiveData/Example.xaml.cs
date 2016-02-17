using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples.ChartView.LiveData
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            Panel configurationPanel = QuickStart.GetConfigurationPanel(this);
            configurationPanel.DataContext = this.DataContext;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LiveDataViewModel).StartTimer();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LiveDataViewModel).StopTimer();
        }
    }
}
