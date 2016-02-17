using System.Windows.Controls;

namespace Telerik.Windows.Examples.GanttView.Utils
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			InitializeComponent();
			this.DataContext = new ExamplesViewModel();
		}
	}
}