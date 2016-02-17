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
}
