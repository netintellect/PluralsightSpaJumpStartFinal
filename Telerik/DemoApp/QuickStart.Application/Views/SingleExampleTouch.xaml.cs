using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
	/// <summary>
	/// Interaction logic for SingleControl.xaml
	/// </summary>
	public partial class SingleExampleTouch : ViewBase
	{
		private ResourceDictionary configuratorResources = new ResourceDictionary();
		private SingleExampleViewModel viewModel;

		public SingleExampleTouch()
		{
			this.DataContext = this.ViewModel;

			this.InitializeComponent();
			ApplicationThemeManager.GetInstance().ThemeChanged += this.OnSingleExampleTouchThemeChanged;
		}

		public SingleExampleViewModel ViewModel
		{
			get
			{
				if (this.viewModel == null)
				{
					this.viewModel = (SingleExampleViewModel)ViewModelLocator.GetViewModel(this);
				}

				return this.viewModel;
			}
		}

		public override void OnNavigatedFrom(object parameter)
		{
			base.OnNavigatedFrom(parameter);

			this.ExampleArea.ClearValue(ContentControl.ContentProperty);
			this.Configurator.ClearValue(ContentControl.ContentProperty);
		}

		public override void OnNavigatedTo(object parameter)
		{
			base.OnNavigatedTo(parameter);

			this.ViewModel.Initialize(parameter as IExampleInfo, () =>
			{
				// Ensure proper screen mode
				this.ToggleFullscreenMode(this.ViewModel.IsFullscreen);
				
				// Start label animation if we are in fullscreen
				if (this.ViewModel.IsFullscreen)
				{
					Storyboard storyboard = this.Resources["FullScreenLabelAnimation"] as Storyboard;

					if (storyboard != null)
					{
						storyboard.Begin();
					}
				}
			});
		}

		private void OnFullscreenButtonClick(object sender, RoutedEventArgs e)
		{
			this.ViewModel.IsFullscreen = true;
			this.ToggleFullscreenMode(true);
		}
		
		private void OnNormalScreenButtonClick(object sender, RoutedEventArgs e)
		{
			this.ViewModel.IsFullscreen = false;
			this.ToggleFullscreenMode(false);
		}

		private void OnSingleExampleTouchThemeChanged(object sender, System.EventArgs e)
		{
			string defaultThemeName = ApplicationThemeManager.GetDefaultThemeName(true);
			ApplicationThemeManager.EnsureFrameworkElementResourcesForTheme(this.themesList, defaultThemeName);
			ApplicationThemeManager.EnsureFrameworkElementResourcesForTheme(this.ResourcesList, defaultThemeName);
		}

		private void ToggleFullscreenMode(bool isFullscreen)
		{
			if (isFullscreen)
			{
				this.FullscreenPanel.Visibility = System.Windows.Visibility.Visible;

				this.ExampleArea.ClearValue(ContentControl.ContentProperty);
				this.Configurator.ClearValue(ContentControl.ContentProperty);
				this.FullscreenExampleArea.SetBinding(ContentControl.ContentProperty, new Binding("CurrentExampleInstance"));
				this.FullscreenConfigurator.SetBinding(ContentControl.ContentProperty, new Binding("(ContentControl.Content).(telerikQuickStart:QuickStart.ConfigurationPanel)") { ElementName = "FullscreenExampleArea" });
			}
			else
			{
				this.FullscreenPanel.Visibility = System.Windows.Visibility.Collapsed;

				this.FullscreenExampleArea.ClearValue(ContentControl.ContentProperty);
				this.FullscreenConfigurator.ClearValue(ContentControl.ContentProperty);
				this.ExampleArea.SetBinding(ContentControl.ContentProperty, new Binding("CurrentExampleInstance"));
				this.Configurator.SetBinding(ContentControl.ContentProperty, new Binding("(ContentControl.Content).(telerikQuickStart:QuickStart.ConfigurationPanel)") { ElementName = "ExampleArea" });
			}
		}
	}
}