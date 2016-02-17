using System;
using System.Windows.Controls;
using System.Linq;
using Telerik.Windows.Examples.Buttons.FirstLook.ViewModels;
using System.Windows;
using Telerik.Windows.Controls;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Buttons.FirstLook
{
	public partial class Example : UserControl
	{
		public Example()
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

            this.DataContext = new MainViewModel();
		}

        private void RadPathButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RadWindow.Alert(new DialogParameters()
            {
                Content = "You have successfully booked your tickets!",
                Header = "Finished",
                ModalBackground = new SolidColorBrush(Color.FromArgb(125,231,232,236)),
                OkButtonContent = "OK",
                IconContent = null,
                Closed = new EventHandler<WindowClosedEventArgs>(this.ResetSession)
            });
        }

        private void ResetSession(object sender, WindowClosedEventArgs args)
        {
            ((MainViewModel)this.DataContext).ResetSession();
        }
    }
}