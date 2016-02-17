using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.TileView.Common;
using Telerik.Windows.Examples.TileView.Common.FirstLook;
using Telerik.Windows.Controls.TileView;
using System;
namespace Telerik.Windows.Examples.TileView.Features.DifferentSizes
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{	
			InitializeComponent();

			this.dragMode.Items.Add(TileViewDragMode.Swap);
			this.dragMode.Items.Add(TileViewDragMode.Slide);

			this.DataContext = new MainViewModel();

			this.myCalandar.SelectedDate = DateTime.Now;
		}
	}
}