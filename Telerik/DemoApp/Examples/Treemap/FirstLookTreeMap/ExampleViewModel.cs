using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Telerik.Windows.Examples.Treemap.FirstLookTreeMap
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private List<Category> data;

        public ExampleViewModel()
        {
            this.GetData("nwind.csv");
        }

        public List<Category> Data
        {
            get
            {
                return this.data;
            }
            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            List<Product> typedData = data as List<Product>;

            this.Data = typedData.GroupBy(product => product.CategoryName)
                .Select(productGroup => new Category(productGroup.Key, productGroup.ToList()))
                .ToList();
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<Product> treemapData = new List<Product>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                Product product = new Product();
                product.CategoryName = data[0];
                product.ProductName = data[1];
                product.UnitPrice = double.Parse(data[2], CultureInfo.InvariantCulture);
                product.UnitsInStock = int.Parse(data[3], CultureInfo.InvariantCulture);
                treemapData.Add(product);
            }

            return treemapData;
        }
    }
}
