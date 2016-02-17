using QuickStart.DataBase;
using System.Linq;

namespace Telerik.Windows.Examples.GridView.WPF.IQueryable
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
        public Example()
        {
            this.InitializeComponent();

            try
            {
                this.DataContext = new NorthwindEntities().Customers.OrderBy(c => c.CustomerID);
            }
            catch
            {

            }
        }
    }
}