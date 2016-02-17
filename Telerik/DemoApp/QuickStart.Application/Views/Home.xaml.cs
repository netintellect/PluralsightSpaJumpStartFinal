using System;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
	public partial class Home : ViewBase
	{
		public Home()
		{
			HomeViewModel viewModel = (HomeViewModel)ViewModelLocator.GetViewModel(this);
			this.DataContext = viewModel;

			InitializeComponent();
			this.Loaded += this.OnHomeLoaded;
		}

		private void OnHomeLoaded(object sender, RoutedEventArgs e)
		{
			this.Loaded -= this.OnHomeLoaded;
			this.SampleApps.SelectedItem = this.SampleApps.CurrentItem;
            this.SampleApps.FindCarouselPanel().IsAnimatingChanged -= this.OnSampleAppsIsAnimatingChanged;
            this.SampleApps.FindCarouselPanel().IsAnimatingChanged += this.OnSampleAppsIsAnimatingChanged;
			(this.DataContext as HomeViewModel).TryOpenStartupDialog();
		}

		private void OnSampleAppsIsAnimatingChanged(object sender, RoutedEventArgs e)
		{
			var carouselPanel = this.SampleApps.FindCarouselPanel();
			if (carouselPanel != null && !carouselPanel.IsAnimating)
			{
				(carouselPanel.TopContainer as CarouselItem).IsSelected = true;
			}
		}

		public override void Notify(object param)
		{
			base.Notify(param);
			MessageBox.Show(param.ToString());
		}

		public override void OnNavigatedTo(object parameter)
		{
			base.OnNavigatedTo(parameter);
			(this.DataContext as HomeViewModel).ToggleApplicationTouchMode(false);
		}
	}
}
