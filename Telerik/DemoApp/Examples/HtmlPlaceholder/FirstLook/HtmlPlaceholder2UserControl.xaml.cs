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
	public partial class HtmlPlaceholder2UserControl : UserControl
	{
		public HtmlPlaceholder2UserControl()
		{
			InitializeComponent();
			this.Loaded += new RoutedEventHandler(HtmlPlaceholder2_Loaded);
			this.Unloaded += new RoutedEventHandler(HtmlPlaceholder2_Unloaded);
		}

		private void HtmlPlaceholder2_Loaded(object sender, RoutedEventArgs e)
		{
			this.htmlPlaceholder2.Visibility = System.Windows.Visibility.Visible;
			this.htmlPlaceholder2.HtmlSource = @"<div style=""background-color:#333333; height=100%; color=#a5a5a5; padding=13px""> You can display any valid html content.<br/> 
				It will be displayed as part of the <a href=""http://silverlight.net"" target=""_blank"">Silverlight</a> page layout and will be rendered from the browser.</div>";
		}

		private void HtmlPlaceholder2_Unloaded(object sender, RoutedEventArgs e)
		{
			this.htmlPlaceholder2.Visibility = System.Windows.Visibility.Collapsed;
		}
	}
}
