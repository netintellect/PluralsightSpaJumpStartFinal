using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Browser;

namespace Telerik.Windows.Examples.RibbonView.RibbonWindow
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri("RibbonWindowPage.aspx", UriKind.Relative), "_blank");
        }
    }
}
