using System;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Examples.CloudUpload.Common;

namespace Telerik.Windows.Examples.CloudUpload.FirstLook
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
			uploadedItemsList.ItemsSource = DummyStorage.StorageFiles;
		}

		public string CurrentTheme
		{
			get
			{
				return ApplicationThemeManager.GetInstance().CurrentTheme;
			}
		}

		private void cloudUpload_Unloaded(object sender, System.Windows.RoutedEventArgs e)
		{
			this.cloudUpload.RequestCancel();
		}

		private void userControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
		}

		private void ApplyThemeSpecificSettings()
		{
			if (this.CurrentTheme == "Windows8Touch")
			{
				rootElement.Width = 900;
			}
			else
			{
				rootElement.Width = 714;
			}
		}

		private void Example_ThemeChanged(object sender, System.EventArgs e)
		{
			this.ApplyThemeSpecificSettings();
		}

		private void userControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
		{
			ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
		}
	}
}
