using System;
using System.Windows;
using System.Windows.Browser;
using Telerik.Windows.Controls;
namespace Telerik.Windows.Examples.HtmlPlaceholder.WindowIntegration
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		private RadWindow window;

		public Example()
		{
			InitializeComponent();

			this.Loaded += new RoutedEventHandler(Example_Loaded);
			this.Unloaded += new RoutedEventHandler(Example_Unloaded);
		}

		private void Example_Loaded(object sender, RoutedEventArgs e)
		{
			if (Application.Current.Host.Settings.Windowless)
			{
				this.window = new RadWindow();
				RadHtmlPlaceholder htmlPlaceholder = new RadHtmlPlaceholder();
				Uri uri = new Uri("http://www.bing.com", UriKind.RelativeOrAbsolute);
				htmlPlaceholder.SourceUrl = uri;
				this.window.Content = htmlPlaceholder;
				this.window.Width = 800;
				this.window.Height = 600;
				this.window.Top = 210;
				this.window.Left = 330;
				this.window.Show();
				this.previewPanel.Visibility = System.Windows.Visibility.Collapsed;
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

		private void Example_Unloaded(object sender, System.Windows.RoutedEventArgs e)
		{
			if (this.window != null)
				this.window.Close();
		}
	}
}
