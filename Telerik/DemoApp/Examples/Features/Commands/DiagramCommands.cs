using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Diagrams.Features.Commands
{
	/// <summary>
	/// 
	/// </summary>
	public class DiagramCommands
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DiagramCommands"/> class.
		/// </summary>
		public DiagramCommands()
		{
			this.ClassDiagramLayout = new DelegateCommand(this.ExecuteLayout, this.CanExecuteLayout);
		}

		/// <summary>
		/// Gets the layout command.
		/// </summary>
		public DelegateCommand ClassDiagramLayout { get; private set; }

		/// <summary>
		/// Executes the layout algorithm on the current diagram.
		/// </summary>
		private void ExecuteLayout(object commandParameter)
		{
			this.LayoutDiagram(commandParameter);
		}

		/// <summary>
		/// Determines whether this layout can occur on the current state of the diagram.
		/// </summary>
		private bool CanExecuteLayout(object commandParameter)
		{
			if (commandParameter == null)
				return true;

			var diagram = commandParameter as RadDiagram;
			return diagram != null && diagram.Items.Count > 0;
		}

		private void LayoutDiagram(object sender)
		{
			var diagram = sender as RadDiagram;
			if (diagram == null) return;
			var settings = new SugiyamaSettings
			{
				// you can use the vertical direction though it'd result in a less conventional apperance
				Orientation = Telerik.Windows.Diagrams.Core.Orientation.Horizontal,

				// the horizontal distance or separation between item on the same layer
				HorizontalDistance = 50d
			};

			// if you don't call Layout with some settings then default will be used
			diagram.Layout(settings);

			// auto-size them again
			foreach (var shape in diagram.Shapes)
			{
				shape.Height = double.NaN;
				shape.Width = double.NaN;
			}
		}
	}
}
