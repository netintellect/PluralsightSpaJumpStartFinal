using System.Windows;
#if WPF
using System.Windows.Controls;
#endif
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.TileView.Common.ViewModels;

namespace Telerik.Windows.Examples.TileView.Integration
{
    public partial class Example : System.Windows.Controls.UserControl
    {
        private MainViewModel viewModel = new MainViewModel();

        public Example()
        {
            InitializeComponent();
            this.DataContext = this.viewModel;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.StartRace();
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.StopRace();
        }

        private void speedRatioCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RadComboBox combo = sender as RadComboBox;
            this.viewModel.SpeedRatio = combo.SelectedIndex == 0 ? SpeedRatio.Normal : SpeedRatio.Fast;
        }
    }
}
