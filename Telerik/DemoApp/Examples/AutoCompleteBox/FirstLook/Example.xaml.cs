using System.Windows.Controls;
using Telerik.Windows.Controls;
using System;
#if !SILVERLIGHT
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
#endif
#if SILVERLIGHT
using SelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangedEventArgs;
#endif

namespace Telerik.Windows.Examples.AutoCompleteBox.FirstLook
{
	public partial class Example : UserControl
	{
		private ExampleViewModel viewModel = new ExampleViewModel();
		public Example()
		{
			InitializeComponent();

			this.viewModel = new ExampleViewModel();
			this.DataContext = viewModel;
		}

		private void songsAutoCompleteBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var autoCompleteBox = sender as RadAutoCompleteBox;
			if (autoCompleteBox.SelectedItem != null)
			{
				this.songInfoStackPanel.Visibility = System.Windows.Visibility.Visible;
				this.viewModel.CurrentDate = DateTime.Now;
			}
			else
			{
				this.songInfoStackPanel.Visibility = System.Windows.Visibility.Collapsed;
			}
		}

		private void movieAutoCompleteBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var autoCompleteBox = sender as RadAutoCompleteBox;
			if (autoCompleteBox.SelectedItem != null)
			{
				this.movieInfoStackPanel.Visibility = System.Windows.Visibility.Visible;
				this.viewModel.CurrentDate = DateTime.Now;
			}
			else
			{
				this.movieInfoStackPanel.Visibility = System.Windows.Visibility.Collapsed;
			}
		}

		private void RadAutoCompleteBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var autoCompleteBox = sender as RadAutoCompleteBox;
			if (autoCompleteBox.SelectedItem != null)
			{
				this.restInfoStackPanel.Visibility = System.Windows.Visibility.Visible;
				this.viewModel.CurrentDate = DateTime.Now;
			}
			else
			{
				this.restInfoStackPanel.Visibility = System.Windows.Visibility.Collapsed;
			}
		}
	}
}