using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Diagrams.Features
{
    public class HierarchicalItemsSourceCollection : ObservableCollection<Gallery>
    {
		public HierarchicalItemsSourceCollection()
		{
			this.LoadData();
		}

        private void LoadData()
        {
            var allItems = new ShapesCollection();

            var basicGallery = new Gallery { Header = "Basic Shapes" };
            foreach (var item in allItems.GetItemsByType(ToolboxCategoryNames.BasicShapes).ToArray())
            {
                basicGallery.Items.Add(item);
            }

            var flowChartGallery = new Gallery { Header = "Flowchart Shapes" };
            foreach (var item in allItems.GetItemsByType(ToolboxCategoryNames.FlowChart).ToArray())
            {
                flowChartGallery.Items.Add(item);
            }

            var arrowsGallery = new Gallery { Header = "Arrows" };
            foreach (var item in allItems.GetItemsByType(ToolboxCategoryNames.Arrows).ToArray())
            {
                arrowsGallery.Items.Add(item);
            }

            this.Add(basicGallery);
            this.Add(flowChartGallery);
            this.Add(arrowsGallery);
        }
    }
}
