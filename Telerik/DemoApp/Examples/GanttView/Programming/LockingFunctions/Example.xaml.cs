using System.Windows.Controls;
using System.Windows.Input;

namespace Telerik.Windows.Examples.GanttView.Programming.LockingFunctions
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

		private void OnRadMenuItemMouseMove(object sender, MouseEventArgs e)
		{
			#if WPF
				e.Handled = true;
			#endif
		}
	}
}
