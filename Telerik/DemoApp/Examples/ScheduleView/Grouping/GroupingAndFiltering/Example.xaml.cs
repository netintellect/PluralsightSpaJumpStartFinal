using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.Grouping.GroupingAndFiltering
{
	public partial class Example : UserControl
	{
		public Example()
		{
			this.InitializeComponent();
		}

		private void OnGroupingListBoxLoaded(object sender, System.Windows.RoutedEventArgs e)
		{
			RadListBox.SelectAllCommand.Execute(null, sender as RadListBox);
		}
	}
}