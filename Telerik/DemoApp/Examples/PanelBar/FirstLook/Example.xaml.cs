namespace Telerik.Windows.Examples.PanelBar.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.radPanelBar.SetValue(System.Windows.Controls.ScrollViewer.HorizontalScrollBarVisibilityProperty, System.Windows.Controls.ScrollBarVisibility.Hidden);
		}

		private void OnRadioButtonClick(object sender, System.Windows.RoutedEventArgs e)
		{
			System.Windows.Controls.RadioButton checkBox = sender as System.Windows.Controls.RadioButton;

			if (this.radPanelBar != null)
			{
				this.radPanelBar.ExpandMode = checkBox.IsChecked.Value ? Telerik.Windows.Controls.ExpandMode.Single : Telerik.Windows.Controls.ExpandMode.Multiple;
			}
		}
#if WPF
		private void radPanelBar_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			MainPageViewModel viewModel = this.Resources["myViewModel"] as MainPageViewModel;
			if (viewModel != null)
			{
				viewModel.CategoryChanged();
			}
		}
#endif

#if SILVERLIGHT
		private void radPanelBar_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
		{
			MainPageViewModel viewModel = this.Resources["myViewModel"] as MainPageViewModel;
			if (viewModel != null)
			{
				viewModel.CategoryChanged();
			}
		}
#endif
	}
}
