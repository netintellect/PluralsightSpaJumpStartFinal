using System.Windows.Controls;
using Telerik.Windows.Examples.RibbonView.MVVM.ViewModels;

namespace Telerik.Windows.Examples.RibbonView.MVVM
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.DataContext = this.configurationPanel.DataContext = new MainViewModel();
		}
	}
#if WPF
	public class HierarchicalDataTemplate : System.Windows.HierarchicalDataTemplate
	{
	}
#else
	public class HierarchicalDataTemplate : Telerik.Windows.Controls.HierarchicalDataTemplate
	{
	}
#endif
}
