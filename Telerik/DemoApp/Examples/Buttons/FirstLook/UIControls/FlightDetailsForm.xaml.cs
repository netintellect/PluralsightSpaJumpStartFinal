using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.Buttons.FirstLook.ViewModels;

namespace Telerik.Windows.Examples.Buttons.FirstLook.UIControls
{
    public partial class FlightDetailsForm : UserControl
    {
        public FlightDetailsForm()
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
#if SILVERLIGHT
        private void RadListBox_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
#else
        private void RadListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
#endif
        {
            ((MainViewModel)this.DataContext).FlightFormModel.CloseDropDownButtonCommand.Execute(((RadListBox)sender).SelectedItem);
            ((RadListBox)sender).SelectedIndex = -1;
        }
    }
}