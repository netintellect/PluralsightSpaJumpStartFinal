using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.HtmlPlaceholder.FirstLook
{
    public partial class HtmlPlaceholder1UserControl : UserControl
    {
        public HtmlPlaceholder1UserControl()
        {
            InitializeComponent();
			this.Loaded += new RoutedEventHandler(HtmlPlaceholder1_Loaded);
			this.Unloaded += new RoutedEventHandler(HtmlPlaceholder1_Unloaded);
        }

		private void HtmlPlaceholder1_Loaded(object sender, RoutedEventArgs e)
		{
			this.htmlPlaceholder1.Visibility = System.Windows.Visibility.Visible;
		}

		private void HtmlPlaceholder1_Unloaded(object sender, RoutedEventArgs e)
		{
			this.htmlPlaceholder1.Visibility = System.Windows.Visibility.Collapsed;
		}
    }
}
