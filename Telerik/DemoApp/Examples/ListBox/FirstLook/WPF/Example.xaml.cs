using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Telerik.Windows.Examples.ListBox.FirstLook 
{
	public partial class Example : UserControl
	{
		private ScrollViewer myScrollViewer;

		public Example()
		{
			InitializeComponent();
		}

		private void ScrollViewer_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{	
			myScrollViewer = (sender as ScrollViewer);
			ScrollBar verticalScrollBar = myScrollViewer.Template.FindName("PART_VerticalScrollBar", myScrollViewer) as ScrollBar;
			verticalScrollBar.SmallChange = 5;
		}
	
		private void LeftArrow_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			myScrollViewer.LineLeft();
		}

		private void RightArrow_Click(object sender, System.Windows.RoutedEventArgs e)
		{		
			myScrollViewer.LineRight();
		}
	}
}