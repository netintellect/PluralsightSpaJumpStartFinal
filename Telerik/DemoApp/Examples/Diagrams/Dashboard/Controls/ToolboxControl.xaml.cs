using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.DragDrop;
using System.Windows.Media;
using Telerik.Windows.Media.Imaging;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// The panel presenting the toolbox.
	/// </summary>
	public partial class ToolboxControl
	{
		public ToolboxControl()
		{
			InitializeComponent();
			DragDropManager.AddDragInitializeHandler(this.ToolBox, OnDragInitialize);
		}

		private static void OnDragInitialize(object sender, DragInitializeEventArgs args)
		{
			var container = args.OriginalSource as RadListBoxItem;

			if (container != null)
			{
				var toolboxItem = container.Content as IToolboxItem;
				if (toolboxItem != null)
				{
					var shape = toolboxItem.CreateShape();
					if (shape != null)
					{
						var element = container.Content as FrameworkElement;
						if (element != null)
						{
							var shapeSize = new Size(element.ActualWidth, element.ActualHeight);
							var dragDropInfo = new DiagramDropInfo(shapeSize, SerializationService.Default.SerializeItems(new[] { shape }));
							args.Data = dragDropInfo;
							args.DragVisualOffset = new Point(args.RelativeStartPoint.X - (shapeSize.Width / 2), args.RelativeStartPoint.Y - (shapeSize.Height / 2));
							args.DragVisual = new Image { Source = new RadBitmap(element).Bitmap, Width = shapeSize.Width, Height = shapeSize.Height };
						}
					}
					args.AllowedEffects = DragDropEffects.All;
					args.Handled = true;
				}
			}
			else
			{
				args.Cancel = true;
			}
		}
	}
}