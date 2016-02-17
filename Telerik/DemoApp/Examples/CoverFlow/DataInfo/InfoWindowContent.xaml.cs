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
using System.Windows.Shapes;

using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.CoverFlow.DataInfo
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindowContent : UserControl
    {
        public InfoWindowContent()
        {
            InitializeComponent();
        }

		private void OnButtonYesClicked(object sender, RoutedEventArgs e)
		{
			System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(link.Text, UriKind.Absolute), "_blank");
		}

		private void OnAuthorPageClicked(object sender, RoutedEventArgs e)
		{
			System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(page.Text, UriKind.Absolute), "_blank");
		}
    }
}
