using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.CloudUpload.Theming
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary()
			{
				Source = new Uri("/CloudUpload;component/CloudUploadListItemStyle.xaml", UriKind.RelativeOrAbsolute)
			});    
		}

		private void cloudUpload_Unloaded(object sender, RoutedEventArgs e)
		{
			this.cloudUpload.RequestCancel();
		}

		private void userControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
		}
  
		private void Example_ThemeChanged(object sender, EventArgs e)
		{
			this.Resources.MergedDictionaries.Clear();
			this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() 
			{
				Source = new Uri("/CloudUpload;component/CloudUploadListItemStyle.xaml", UriKind.RelativeOrAbsolute) 
			});           
		}

		private void userControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
		{
			ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
		}
	}
}
