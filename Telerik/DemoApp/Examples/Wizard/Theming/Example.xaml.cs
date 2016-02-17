using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Examples.Wizard.Helpers;

namespace Telerik.Windows.Examples.Wizard.Theming
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.ApplyThemeSpecificSettings();
		}

		public string CurrentTheme
		{
			get
			{
				return ApplicationThemeManager.GetInstance().CurrentTheme;
			}
		}

		private void ApplyThemeSpecificSettings()
		{
			if (this.CurrentTheme == "Expression_Dark" || this.CurrentTheme == "VisualStudio2013_Dark")
			{
				foreach (var page in this.wizard.WizardPages)
				{
					page.HeaderTemplate = this.LayoutRoot.Resources["whiteHeaderTemplate"] as DataTemplate;
				}
			}
			else
			{
				foreach (var page in this.wizard.WizardPages)
				{
					page.HeaderTemplate = this.LayoutRoot.Resources["blackHeaderTemplate"] as DataTemplate;
				}
			}
		}

		private void Example_ThemeChanged(object sender, System.EventArgs e)
		{
			this.ApplyThemeSpecificSettings();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
		}

		private void UserControl_Unloaded(object sender, RoutedEventArgs e)
		{
			ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
		}

		private void wizard_Completed(object sender, Controls.Wizard.WizardCompletedEventArgs e)
		{
			(sender as RadWizard).SelectedPageIndex = 0;
		}

		private void wizard_Help(object sender, NavigationButtonsEventArgs e)
		{
			string documentationUrlWPF = "http://docs.telerik.com/devtools/wpf/introduction.html";
			string documentationUrlSL = "http://docs.telerik.com/devtools/silverlight/introduction.html";
			ViewModel vm = new ViewModel();
			var hyperlinkControl = new HyperlinkControl();
#if SILVERLIGHT
			hyperlinkControl.Text = "Telerik UI for Silverlight Documentation";
			vm.Url = documentationUrlSL;
#else
			hyperlinkControl.Text = "Telerik UI for WPF Documentation";
			vm.Url = documentationUrlWPF;
#endif
			hyperlinkControl.Command = vm.NavigateCommand;
			var alertContent = new StackPanel();
			alertContent.Children.Add(new TextBlock() { Text = "You can view our documentation here:" });
			alertContent.Children.Add(hyperlinkControl);
			RadWindow.Alert(new DialogParameters()
			{
				Header = "Help",
				Content = alertContent
			});
		}
	}
}