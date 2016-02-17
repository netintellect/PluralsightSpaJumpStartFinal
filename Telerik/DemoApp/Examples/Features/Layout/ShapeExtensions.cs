using System.Linq;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Diagrams.Features.Layout
{
	public static class ShapeExtensions
	{
        /// <summary>
        /// Determines whether the specified shape has children.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <returns>
        ///   <c>True</c> if the specified shape has children; otherwise, <c>false</c>.
        /// </returns>
		public static bool HasChildren(this RadDiagramShapeBase shape)
		{
			if (shape != null)
				return shape.OutgoingLinks.Count() > 0;
			return false;
		}

        /// <summary>
        /// Determines whether the specified shape has parents.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <returns>
        ///   <c>True</c> if the specified shape has parents; otherwise, <c>false</c>.
        /// </returns>
		public static bool HasParents(this RadDiagramShapeBase shape)
		{
			if (shape != null)
				return shape.IncomingLinks.Count() > 0;
			return false;
		}
	}
}
