using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.PrintAndExportWithRadDocument
{
    public class ExampleViewModel : ViewModelBase
    {
        List<MyBusinessObject> _products;
        public List<MyBusinessObject> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = this.GetData();
                }

                return _products;
            }
        }

        private List<MyBusinessObject> GetData()
        {
            List<MyBusinessObject> data = new List<MyBusinessObject>();

            data.Add(new MyBusinessObject(1, "Chai", 18.00));
            data.Add(new MyBusinessObject(2, "Chang", 19.00));
            data.Add(new MyBusinessObject(3, "Aniseed Syrup", 10.00));
            data.Add(new MyBusinessObject(4, "Chef Anton's Cajun Seasoning", 22.00));
            data.Add(new MyBusinessObject(5, "Chef Anton's Gumbo Mix", 21.35));
            data.Add(new MyBusinessObject(6, "Grandma's Boysenberry Spread", 25.00));
            data.Add(new MyBusinessObject(7, "Uncle Bob's Organic Dried Pears", 30.00));
            data.Add(new MyBusinessObject(8, "Northwoods Cranberry Sauce", 40.00));
            data.Add(new MyBusinessObject(9, "Mishi Kobe Niku", 97.00));
            data.Add(new MyBusinessObject(10, "Ikura", 31.00));
            data.Add(new MyBusinessObject(11, "Queso Cabrales", 21.00));
            data.Add(new MyBusinessObject(12, "Queso Manchego La Pastora", 38.00));
            data.Add(new MyBusinessObject(13, "Konbu", 6.00));
            data.Add(new MyBusinessObject(14, "Tofu", 23.25));
            data.Add(new MyBusinessObject(15, "Genen Shouyu", 15.50));
            data.Add(new MyBusinessObject(16, "Pavlova", 17.45));
            data.Add(new MyBusinessObject(17, "Alice Mutton", 39.00));
            data.Add(new MyBusinessObject(18, "Carnarvon Tigers", 62.50));
            data.Add(new MyBusinessObject(19, "Teatime Chocolate Biscuits", 9.20));
            data.Add(new MyBusinessObject(20, "Sir Rodney's Marmalade", 81.00));
            data.Add(new MyBusinessObject(21, "Sir Rodney's Scones", 10.00));
            data.Add(new MyBusinessObject(22, "Gustaf's Knäckebröd", 21.00));
            data.Add(new MyBusinessObject(23, "Tunnbröd", 9.00));
            data.Add(new MyBusinessObject(24, "Guaraná Fantástica", 4.50));
            data.Add(new MyBusinessObject(25, "NuNuCa Nuß-Nougat-Creme", 14.00));

            return data;
        }
    }
}
