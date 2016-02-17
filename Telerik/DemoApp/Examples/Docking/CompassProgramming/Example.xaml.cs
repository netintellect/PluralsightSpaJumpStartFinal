using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace Telerik.Windows.Examples.Docking.CompassProgramming
{
	public partial class Example : UserControl
	{
		private enum PaneType
		{
			Green,
			OceanBlue,
			Purple,
			Transparent
		}

		public Example()
		{
			InitializeComponent();
		}

		private static bool CompassNeedsToShow(Telerik.Windows.Controls.Docking.Compass compass)
		{
			return compass.IsLeftIndicatorVisible || compass.IsTopIndicatorVisible || compass.IsRightIndicatorVisible || compass.IsBottomIndicatorVisible || compass.IsCenterIndicatorVisible;
		}

		private void RadDocking_PreviewShowCompass(object sender, Telerik.Windows.Controls.Docking.PreviewShowCompassEventArgs e)
		{
			if (e.TargetGroup != null)
			{
                e.Compass.IsCenterIndicatorVisible = CanDockIn((RadSplitContainer)e.DraggedElement, e.TargetGroup, DockPosition.Center);
                e.Compass.IsLeftIndicatorVisible = CanDockIn((RadSplitContainer)e.DraggedElement, e.TargetGroup, DockPosition.Left);
                e.Compass.IsTopIndicatorVisible = CanDockIn((RadSplitContainer)e.DraggedElement, e.TargetGroup, DockPosition.Top);
                e.Compass.IsRightIndicatorVisible = CanDockIn((RadSplitContainer)e.DraggedElement, e.TargetGroup, DockPosition.Right);
                e.Compass.IsBottomIndicatorVisible = CanDockIn((RadSplitContainer)e.DraggedElement, e.TargetGroup, DockPosition.Bottom);
			}
			else
			{
                e.Compass.IsLeftIndicatorVisible = CanDock((RadSplitContainer)e.DraggedElement, DockPosition.Left);
                e.Compass.IsTopIndicatorVisible = CanDock((RadSplitContainer)e.DraggedElement, DockPosition.Top);
                e.Compass.IsRightIndicatorVisible = CanDock((RadSplitContainer)e.DraggedElement, DockPosition.Right);
                e.Compass.IsBottomIndicatorVisible = CanDock((RadSplitContainer)e.DraggedElement, DockPosition.Bottom);
			}
			e.Canceled = !(CompassNeedsToShow(e.Compass));
		}

		private PaneType GetPaneType(RadPane pane)
		{
			Panel c = pane.Content as Panel;
			if (c != null)
			{
				if (c.Background.Equals(this.Resources["GreenBrush"]))
				{
					return PaneType.Green;
				}
				else if (c.Background.Equals(this.Resources["OceanBlueBrush"]))
				{
					return PaneType.OceanBlue;
				}
				else
				{
					return PaneType.Purple;
				}
			}

			return PaneType.Purple;
		}

		private bool CanDockIn(RadPane paneToDock, RadPane paneInTargetGroup, DockPosition position)
		{
			PaneType paneToDockType = GetPaneType(paneToDock);
			PaneType paneInTargetGroupType = GetPaneType(paneInTargetGroup);

			switch (paneToDockType)
			{
				case PaneType.Green:
					switch (paneInTargetGroupType)
					{

						case PaneType.Green:
							return true;
						case PaneType.OceanBlue:
							return position != DockPosition.Top && position != DockPosition.Bottom;
						case PaneType.Purple:
							return position != DockPosition.Top && position != DockPosition.Bottom;
					}
					break;
				case PaneType.OceanBlue:
					switch (paneInTargetGroupType)
					{

						case PaneType.Green:
							return position != DockPosition.Left && position != DockPosition.Right;
						case PaneType.OceanBlue:
							return true;
						case PaneType.Purple:
							return position != DockPosition.Left && position != DockPosition.Right;
					}
					break;
				case PaneType.Purple:
					switch (paneInTargetGroupType)
					{

						case PaneType.Green:
							return position != DockPosition.Center;
						case PaneType.OceanBlue:
							return position != DockPosition.Center;
						case PaneType.Purple:
							return true;
					}
					break;
			}

			return false;
		}

		private bool CanDock(RadPane paneToDock, DockPosition position)
		{
			PaneType paneToDockType = GetPaneType(paneToDock);

			switch (paneToDockType)
			{
				case PaneType.Green:
					return position != DockPosition.Left;
				case PaneType.OceanBlue:
					return false;
				case PaneType.Purple:
					return true;
			}

			return false;
		}

		private bool CanDockIn(ISplitItem dragged, ISplitItem target, DockPosition position)
		{
			// If there is a pane that cannot be dropped in any of the targeted panes.
			return !dragged.EnumeratePanes().Any((RadPane p) => target.EnumeratePanes().Any((RadPane p1) => !CanDockIn(p, p1, position)));
		}

		private bool CanDock(ISplitItem dragged, DockPosition position)
		{
			return !dragged.EnumeratePanes().Any((RadPane p) => !CanDock(p, position));
		}
	}
}
