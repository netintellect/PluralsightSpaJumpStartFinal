using System;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Controls.QuickStart.Infrastructure;
using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
	public class ApplicationModule
	{
		public void Initialize()
		{
			ViewModelLocator.RegisterAssociation(typeof(AllControls), typeof(QuickStartViewModelBase));
			ViewModelLocator.RegisterAssociation(typeof(AllControlsTouch), typeof(AllControlsTouchViewModel));
			ViewModelLocator.RegisterAssociation(typeof(Home), typeof(HomeViewModel));
			ViewModelLocator.RegisterAssociation(typeof(SingleControlExamplesTouch), typeof(SingleControlExamplesViewModel));
			ViewModelLocator.RegisterAssociation(typeof(SingleExample), typeof(SingleExampleViewModel), true);
			ViewModelLocator.RegisterAssociation(typeof(SingleExampleTouch), typeof(SingleExampleViewModel), true);

			Windows8Palette.Palette.AccentColor = Color.FromArgb(0xFF, 0x79, 0x25, 0x6B);
			Windows8TouchPalette.Palette.AccentColor = Color.FromArgb(0xFF, 0x79, 0x25, 0x6B);
			ApplicationThemeManager.GetInstance().EnsureResourcesForTheme(ApplicationThemeManager.DefaultThemeName);

			Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("/Application;component/Resources.xaml", UriKind.RelativeOrAbsolute) });

			NavigationService.Instance.AssociateViewWithType(ApplicationView.Home, typeof(Home));
			NavigationService.Instance.AssociateViewWithType(ApplicationView.AllControls, typeof(AllControls));
			NavigationService.Instance.AssociateViewWithType(ApplicationView.SingleExample, typeof(SingleExample));

			// Views for touch mode
			NavigationService.Instance.AssociateViewWithType(ApplicationView.AllControlsTouch, typeof(AllControlsTouch));
			NavigationService.Instance.AssociateViewWithType(ApplicationView.SingleControlExamplesTouch, typeof(SingleControlExamplesTouch));
			NavigationService.Instance.AssociateViewWithType(ApplicationView.SingleExampleTouch, typeof(SingleExampleTouch));
		}
	}
}