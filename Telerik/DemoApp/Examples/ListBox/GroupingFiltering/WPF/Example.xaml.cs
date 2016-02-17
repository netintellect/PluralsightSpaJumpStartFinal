using System.Windows.Controls;

namespace Telerik.Windows.Examples.ListBox.GroupingFiltering
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
		}

		private void OnFilterBoxTextChanged(object sender, TextChangedEventArgs e)
		{
			var viewModel = this.DataContext as ViewModel;

			viewModel.FilterText = (sender as TextBox).Text;
		}
	}
}
