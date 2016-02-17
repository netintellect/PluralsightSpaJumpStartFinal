using System.Linq;
using Telerik.Windows.Data;
using QuickStart.DataBase;

namespace Telerik.Windows.Examples.DataVirtualization.WPF.FirstLook
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
                DataContext = new VirtualQueryableCollectionView(new NorthwindEntities().Order_Details.OrderBy(o => o.OrderID)) { LoadSize = 5 };
            }
            catch
            {

            }
        }
    }
}
