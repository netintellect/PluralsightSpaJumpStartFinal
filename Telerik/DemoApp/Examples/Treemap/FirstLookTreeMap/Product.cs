
namespace Telerik.Windows.Examples.Treemap.FirstLookTreeMap
{
    public class Product
    {
        private string categoryName;
        private string productName;
        private double unitPrice;
        private int unitsInStock;

        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }
            set
            {
                this.categoryName = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                this.productName = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                this.unitPrice = value;
            }
        }

        public int UnitsInStock
        {
            get
            {
                return this.unitsInStock;
            }
            set
            {
                this.unitsInStock = value;
            }
        }

        public double ValueInStock
        {
            get
            {
                return this.UnitsInStock * this.UnitPrice;
            }
        }
    }
}
