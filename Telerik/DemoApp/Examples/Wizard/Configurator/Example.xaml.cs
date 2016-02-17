using System.Windows;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using System;
using System.Windows.Documents;
using System.Diagnostics;
using Telerik.Windows.Examples.Wizard.Helpers;

namespace Telerik.Windows.Examples.Wizard.Configurator
{
	public partial class Example : UserControl
	{
		public Example()
		{
#if SILVERLIGHT
		    this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Wizard;component/FlagEnumEditor_SL.xaml", UriKind.RelativeOrAbsolute) });			
#else
			this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Wizard;component/FlagEnumEditor_WPF.xaml", UriKind.RelativeOrAbsolute) });			
#endif
			this.InitializeComponent();
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			if (ConfigurationPanel != null)
			{
				ConfigurationPanel.DataContext = wizard;
			}
		}

		protected Panel ConfigurationPanel
		{
			get
			{
				return QuickStart.GetConfigurationPanel(this);
			}
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