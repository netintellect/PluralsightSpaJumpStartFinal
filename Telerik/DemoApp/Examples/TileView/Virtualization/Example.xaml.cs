using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using System.Linq;

namespace Telerik.Windows.Examples.TileView.Virtualization
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		Dictionary<int, ToggleButton> toggleButtons = new Dictionary<int, ToggleButton>();

		public Example()
		{
			InitializeComponent();

			this.DataContext = Enumerable.Range(0, 100000);
		}
	}
}