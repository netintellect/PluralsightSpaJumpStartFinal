using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Telerik.Windows.Examples.TreeListView.IsExpanded
{
    public class MyDataContext
    {
        ObservableCollection<WarehouseItem> warehouseData;
        public ObservableCollection<WarehouseItem> WarehouseData
        {
            get
            {
                if (warehouseData == null)
                {
                    warehouseData = new ObservableCollection<WarehouseItem>();
                    var drinks = new WarehouseItem("Drinks", 35);
                    drinks.Items.Add(new WarehouseItem("Water", 10));
                    var tea = new WarehouseItem("Tea", 20);
                    tea.Items.Add(new WarehouseItem("Black", 10));
                    tea.Items.Add(new WarehouseItem("Green", 10));
                    drinks.Items.Add(tea);
                    drinks.Items.Add(new WarehouseItem("Coffee", 5));
                    warehouseData.Add(drinks);

                    var vegetables = new WarehouseItem("Vegetables", 75);
                    vegetables.Items.Add(new WarehouseItem("Tomato", 40));
                    vegetables.Items.Add(new WarehouseItem("Carrot", 25));
                    vegetables.Items.Add(new WarehouseItem("Onion", 10));
                    warehouseData.Add(vegetables);

                    var fruits = new WarehouseItem("Fruits", 55);
                    fruits.Items.Add(new WarehouseItem("Cherry", 30));
                    fruits.Items.Add(new WarehouseItem("Apple", 20));
                    fruits.Items.Add(new WarehouseItem("Melon", 5));
                    warehouseData.Add(fruits);
                }

                return warehouseData;
            }
        }
    }
}
