using System.Linq;
using Telerik.Windows.Data;
using QuickStart.DataBase;

namespace Telerik.Windows.Examples.DataVirtualization.WPF.VariousControls
{
    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        VirtualQueryableCollectionView customerOrders;
        public VirtualQueryableCollectionView CustomerOrders
        {
            get
            {
                if (customerOrders == null)
                {
                    try
                    {
                        customerOrders = new VirtualQueryableCollectionView(from o in new NorthwindEntities().Orders.OrderBy(o => o.OrderID)
                                                                            where o.CustomerID == this.CustomerID
                                                                            select o) { LoadSize = 10 };
                    }
                    catch
                    {

                    }
                }
                return customerOrders;
            }
        }
    }
}
