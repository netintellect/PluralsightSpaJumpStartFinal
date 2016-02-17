using System;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Wizard;

namespace Telerik.Windows.Examples.Wizard.FirstLook
{
	public partial class Example : UserControl
	{
		ViewModel viewModel = new ViewModel();
		public Example()
		{
			InitializeComponent();
			this.DataContext = this.viewModel;
			this.AddHandler(RadToggleButton.ClickEvent, new RoutedEventHandler(OnClick));
		}

		private void OnClick(object sender, RoutedEventArgs e)
		{
#if SILVERLIGHT
			var toggleButton = (e as RadRoutedEventArgs).OriginalSource as RadToggleButton;
#else
			var toggleButton = e.OriginalSource as RadToggleButton;
#endif
			if (toggleButton != null)
			{
				if ((bool)toggleButton.IsChecked)
				{
					this.viewModel.ButtonClicksCount++;
				}
				else
				{
					this.viewModel.ButtonClicksCount--;
				}
			}
		}

		private void wizard_Completed(object sender, Controls.Wizard.WizardCompletedEventArgs e)
		{
			(sender as RadWizard).SelectedPageIndex = 0;
		}
	}
}