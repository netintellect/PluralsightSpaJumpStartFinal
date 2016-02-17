using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;
using System.Text;

namespace Telerik.Windows.Diagrams.Features
{
    public class ShapesCollection : List<GalleryItem>
    {
		public ShapesCollection()
		{
			this.LoadData();
		}

        public IEnumerable<GalleryItem> GetItemsByType(string type)
        {
            return this.Where(i => i.ItemType.Equals(type));
        }

        private static string GetShapeName(string typeName)
        {
            typeName = typeName.Replace("Shape", string.Empty);
            StringBuilder builder = new StringBuilder(typeName);
            for (int i = 0; i < builder.Length; i++)
            {
                if (i != 0 && (char.IsUpper(builder[i]) || char.IsDigit(builder[i])))
                {
                    builder.Insert(i, " ");
                    i++;
                }
            }
            return builder.ToString();
        }

		private void LoadData()
		{
			Array commonShapeTypeValues = Utils.GetEnumValues<CommonShapeType>();
			foreach (CommonShapeType item in commonShapeTypeValues)
			{
				this.Add(new GalleryItem(GetShapeName(item.ToString()), new RadDiagramShape() { Geometry = ShapeFactory.GetShapeGeometry(item) }, ToolboxCategoryNames.BasicShapes));
			}

			Array flowChartShapeTypeValues = Utils.GetEnumValues<FlowChartShapeType>();
			foreach (FlowChartShapeType item in flowChartShapeTypeValues)
			{
				this.Add(new GalleryItem(GetShapeName(item.ToString()), new RadDiagramShape() { Geometry = ShapeFactory.GetShapeGeometry(item) }, ToolboxCategoryNames.FlowChart));
			}

			Array arrowShapeTypeValues = Utils.GetEnumValues<ArrowShapeType>();
			foreach (ArrowShapeType item in arrowShapeTypeValues)
			{
				this.Add(new GalleryItem(GetShapeName(item.ToString()), new RadDiagramShape() { Geometry = ShapeFactory.GetShapeGeometry(item) }, ToolboxCategoryNames.Arrows));
			}
		}
    }
}
