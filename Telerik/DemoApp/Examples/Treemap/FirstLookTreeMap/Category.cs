using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.Treemap.FirstLookTreeMap
{
    public class Category
    {
        private string categoryName;
        private List<Product> products;

        public Category(string categoryName)
        {
            this.categoryName = categoryName;
        }

        public Category(string categoryName, List<Product> products)
            : this(categoryName)
        {
            this.products = products;
        }

        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }
        }

        public double CategoryValue
        {
            get
            {
                return this.Products.Sum(product => product.ValueInStock);
            }
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
        }
    }
}
