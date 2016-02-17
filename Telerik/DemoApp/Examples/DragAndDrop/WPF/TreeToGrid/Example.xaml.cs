using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.TreeView;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.DragAndDrop.WPF.TreeToGrid
{
    public partial class Example : System.Windows.Controls.UserControl
    {
        public Example()
        {

            InitializeComponent();

            // Set the items source of the controls:
            allProductsView.ItemsSource = CategoryViewModel.Generate();

            IList orderSource = new ObservableCollection<ProductViewModel>();
            foreach (ProductViewModel product in ProductViewModel.Generate(4))
            {
                orderSource.Add(product);
            }
            orderView.ItemsSource = orderSource;

            IList wishlistSource = new ObservableCollection<ProductViewModel>();
            foreach (ProductViewModel product in ProductViewModel.Generate(6))
            {
                wishlistSource.Add(product);
            }
            wishlistView.ItemsSource = wishlistSource;
        }
    }

    public class ExampleTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ProductViewModel)
            {
                return ProductTemplate;
            }
            else if (item is CategoryViewModel)
            {
                return CategoryTemplate;
            }
            return null;
        }

        public DataTemplate ProductTemplate { get; set; }
        public DataTemplate CategoryTemplate { get; set; }
    }

    public class CategoryViewModel
    {
        public static IList Generate()
        {
            CategoryViewModel latest = new CategoryViewModel();
            latest.Name = "Latest Additions";
            foreach (ProductViewModel item in ProductViewModel.Generate(4))
            {
                latest.Items.Add(item);
            }

            CategoryViewModel highestRated = new CategoryViewModel();
            highestRated.Name = "Highest Rated";
            foreach (ProductViewModel item in ProductViewModel.Generate(5))
            {
                highestRated.Items.Add(item);
            }

            CategoryViewModel onSale = new CategoryViewModel();
            onSale.Name = "On Sale";
            foreach (ProductViewModel item in ProductViewModel.Generate(6))
            {
                onSale.Items.Add(item);
            }

            CategoryViewModel value = new CategoryViewModel();
            value.Name = "Instant Deal";
            value.Items.Add(onSale);
            foreach (ProductViewModel item in ProductViewModel.Generate(3))
            {
                value.Items.Add(item);
            }

            IList result = new List<object>();

            result.Add(latest);
            result.Add(highestRated);
            result.Add(value);

            return result;
        }

        public CategoryViewModel()
        {
            Items = new ObservableCollection<object>();
        }

        public string Name { get; set; }
        public IList Items { get; set; }
    }

    public class ProductViewModel
    {
        // Data generation.
        private static Random generator = new Random(1676545846);
        private static string[] adjectives = "Fabulous,Amazing,New,Classic,Modern,Durable,Outstanding,Excellent,Premium".Split(',');
        private static string[] owner = "Alaska,Jonhn,Ray,Ruby,Stone,Lilly,Scott,Barney,Dorian,Neo,Sarah".Split(',');
        private static string[] objects = "Pen,Manual,Bicycle,Umbrella,Mouse,Vase,Keyboard".Split(',');
        private static decimal[] prices = { 12.99M, 13.15M, 24.99M, 33.99M, 9.99M, 15.99M, 16.99M, 12.50M };

        public static List<ProductViewModel> Generate(int count)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            for (int i = 0; i < count; i++)
            {
                string product = objects[generator.Next(objects.Length)];
                ProductViewModel result = new ProductViewModel();
                result.Name = String.Format("{0}'s {1} {2}",
                        owner[generator.Next(owner.Length)],
                        adjectives[generator.Next(adjectives.Length)],
                        product);
                result.UnitPrice = prices[generator.Next(prices.Length)];
                result.Description = String.Format("Exquisite handcrafted {0}.", product.ToLower());
                products.Add(result);
            }
            return products;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
