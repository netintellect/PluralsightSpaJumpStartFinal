using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Telerik.Windows.Examples.Wizard.Helpers
{
	/// <summary>
	/// Inheritable Image compatible with Silverlight.
	/// </summary>
	public class HyperlinkControl : ContentControl
	{
		public static readonly DependencyProperty UriProperty =
			DependencyProperty.Register("Uri", typeof(System.Uri), typeof(HyperlinkControl), new PropertyMetadata(OnPropertyChanged));

		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(HyperlinkControl), new PropertyMetadata(string.Empty, OnPropertyChanged));

		public static readonly DependencyProperty CommandProperty =
			DependencyProperty.Register("Command", typeof(ICommand), typeof(HyperlinkControl), new PropertyMetadata(OnPropertyChanged));

		public System.Uri Uri
		{
			get { return (System.Uri)GetValue(UriProperty); }
			set { SetValue(UriProperty, value); }
		}

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var hyperlink = d as HyperlinkControl;

			hyperlink.BuildContent();
		}

		private void BuildContent()
		{
#if !WPF
			this.Content = new HyperlinkButton()
			{
				NavigateUri = this.Uri,
				Content = this.Text,
				Command = this.Command
			};
#else
			var hyperlink = new System.Windows.Documents.Hyperlink
			{
				NavigateUri = this.Uri,
				Command = this.Command,
			};
			hyperlink.Inlines.Add(this.Text);

			var text = new TextBlock();
			text.Inlines.Add(hyperlink);
			this.Content = text;
#endif
		}
	}
}
