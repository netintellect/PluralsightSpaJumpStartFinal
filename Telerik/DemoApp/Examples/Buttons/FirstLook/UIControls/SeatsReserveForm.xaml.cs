using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.Buttons.FirstLook.ViewModels;

namespace Telerik.Windows.Examples.Buttons.FirstLook.UIControls
{
    public partial class SeatsReserveForm : UserControl
    {
        public SeatsReserveForm()
        {
            if (Telerik.Windows.Controls.QuickStart.Common.Helpers.ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Buttons;component/FirstLook/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Buttons;component/FirstLook/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }

            InitializeComponent();
        }

        private void RadToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var toggle = (sender as RadToggleButton);
            var viewModel = (this.DataContext as MainViewModel).SeatsFormModel;

            if (viewModel != null && toggle != null && toggle.IsChecked == true)
            {
                if (viewModel.RemainingSeats > 0)
                {
                    viewModel.RemainingSeats--;
                }
                else
                {
                    toggle.IsChecked = false;
                }
            }
            else
            {
                viewModel.RemainingSeats++;
            }

        }
    }
}