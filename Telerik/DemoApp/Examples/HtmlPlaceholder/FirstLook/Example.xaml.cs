using System;
using System.Windows;
using System.Windows.Browser;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.HtmlPlaceholder.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.Loaded += new RoutedEventHandler(Example_Loaded);
		}

		private void Example_Loaded(object sender, RoutedEventArgs e)
		{
			if (Application.Current.Host.Settings.Windowless)
			{
				this.CreateHtmlPlacehoders();
				this.previewPanel.Visibility = System.Windows.Visibility.Collapsed;
				this.examplePanel.Visibility = System.Windows.Visibility.Visible;
			}
		}

		private void WindowlessMode_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (!Application.Current.Host.Settings.Windowless)
			{
				string newUrl;

				newUrl = HtmlPage.Document.DocumentUri.AbsoluteUri.Replace(HtmlPage.Document.DocumentUri.Fragment, string.Empty);
				newUrl = string.Format("{0}?windowless=true{1}", newUrl, HtmlPage.Document.DocumentUri.Fragment);

				HtmlPage.Window.Navigate(new Uri(newUrl, UriKind.Absolute));
			}
		}

		private void CreateHtmlPlacehoders()
		{
			this.htmlPlaceholder1Host.Content = new HtmlPlaceholder1UserControl();
			this.htmlPlaceholder2Host.Content = new HtmlPlaceholder2UserControl();
		}
	}
}
