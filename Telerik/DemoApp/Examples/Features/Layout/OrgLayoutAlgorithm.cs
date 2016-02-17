using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Diagrams.Features.Layout
{
	/// <summary>
	/// Single-root tree layout algorithm.
	/// </summary>
	public class OrgLayoutAlgorithm : ViewModelBase
	{
		private readonly Dictionary<string, Size> sizeCache = new Dictionary<string, Size>();

		private double horizontalLevelSeparation = 20.0;

		private double verticalLevelSeparation = 25.0;

		/// <summary>
		/// Gets or sets the horizontal pixel separation among shapes.
		/// </summary>
		/// <value>The horizontal level separation.</value>
		public double HorizontalLevelSeparation
		{
			get
			{
				return this.horizontalLevelSeparation;
			}
			set
			{
				if (this.horizontalLevelSeparation != value)
				{
					this.horizontalLevelSeparation = value;
					this.OnPropertyChanged("HorizontalLevelSeparation");
				}
			}
		}

		/// <summary>
		/// Gets or sets the vertical pixel separation among shapes.
		/// </summary>
		/// <value>The vertical level separation.</value>
		public double VerticalLevelSeparation
		{
			get
			{
				return this.verticalLevelSeparation;
			}
			set
			{
				if (this.verticalLevelSeparation != value)
				{
					this.verticalLevelSeparation = value;
					this.OnPropertyChanged("VerticalLevelSeparation");
				}
			}
		}

		/// <summary>
		/// Layouts all the shapes of a diagram in organizational manner.
		/// </summary>
		/// <param name="diagram">The diagram.</param>
		public void Layout(RadDiagram diagram)
		{
			if (diagram == null)
			{
				return;
			}

			var root = diagram.Shapes.FirstOrDefault(shape => !(shape as RadDiagramShape).HasParents()) as RadDiagramShape;

			if (root != null)
			{
				this.sizeCache.Clear();
				this.CalculateBoundingBoxes(root);
				this.LayoutShape(root, new Point(0, 0));
			}
		}

		private static IEnumerable<RadDiagramShape> GetChildren(RadDiagramShape node)
		{
			return node.OutgoingLinks.Select(child => child.Target as RadDiagramShape);
		}

		private Size CalculateBoundingBoxes(RadDiagramShape node)
		{
			if (!node.HasChildren())
			{
				var size = new Size(node.ActualBounds.Width, node.ActualBounds.Height);
				this.sizeCache.Add(node.Id, size);
				return size;
			}

			double width = 0;
			double height = 0;

			Size shapeBox;

			var children = GetChildren(node);

			foreach (var child in children)
			{
				shapeBox = this.CalculateBoundingBoxes(child);
				width += shapeBox.Width;
				height = Math.Max(height, shapeBox.Height);
			}

			width += (children.Count() - 1) * this.HorizontalLevelSeparation;
			height += this.HorizontalLevelSeparation + node.ActualBounds.Height;

			shapeBox = new Size(width, height);

			this.sizeCache.Add(node.Id, shapeBox);

			return shapeBox;
		}

		private void LayoutShape(RadDiagramShape node, Point point)
		{
			if (!node.HasChildren())
			{
				node.Position = new Point(point.X, point.Y);
			}
			else
			{
				double x, y;
				Point selfLocation;
				var boundingBox = this.sizeCache[node.Id];
				selfLocation = new Point(point.X + ((boundingBox.Width - node.ActualBounds.Width) / 2), point.Y);
				node.Position = selfLocation;

				if (Math.Abs(selfLocation.X - point.X) < Telerik.Windows.Diagrams.Core.Utils.Epsilon)
				{
					x = point.X + ((node.ActualBounds.Width - boundingBox.Width) / 2);
				}
				else
				{
					x = point.X;
				}

				var children = GetChildren(node);

				foreach (var childNode in children)
				{
					y = selfLocation.Y + this.VerticalLevelSeparation + node.ActualBounds.Height;
					var childPoint = new Point(x, y);
					this.LayoutShape(childNode, childPoint);
					var size = this.sizeCache[childNode.Id];
					x += size.Width + this.HorizontalLevelSeparation;
				}
			}
		}
	}
}
