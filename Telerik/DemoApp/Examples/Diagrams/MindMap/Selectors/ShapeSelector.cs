
namespace Telerik.Windows.Examples.Diagrams.MindMap
{
	public static class ShapeSelector
	{
		public static MindmapShapeBase GetShape(object item)
		{
			var node = item as Node;
			if(node != null)
			{
				if(node.ShapeType == MindmapItemType.Root)
					return new MindmapRootShape();
				else if (node.ShapeType == MindmapItemType.FirstLevelItem)
					return new MindmapFirstLevelShape();
				else if (node.ShapeType == MindmapItemType.SubItem)
					return new MindmapOuterShape();
			}

			return new MindmapRootShape();
		}
	}
}
