using Examples.Web;
using Telerik.Windows.Data;
using System.ServiceModel.DomainServices.Client;
using Telerik.Windows.Examples.DataVirtualization;
using System.ComponentModel.DataAnnotations;

namespace Examples.Web
{
    public partial class Customer
    {
        NorthwindDomainContext cntext;

        [Display(AutoGenerateField=false)]
        public NorthwindDomainContext Context
        {
            get
            {
                if (cntext == null)
                {
                    cntext = new NorthwindDomainContext();

                }

                return cntext;
            }
        }

        VirtualQueryableCollectionView customerOrders;

        [Display(AutoGenerateField = false)]
        public VirtualQueryableCollectionView CustomerOrders
        {
            get
            {
                if (customerOrders == null)
                {
                    customerOrders = new VirtualQueryableCollectionView();
                    customerOrders.VirtualItemCount = 1; // Force ItemsLoading to get the real total item count and data in a single request
                    customerOrders.LoadSize = 10;

                    customerOrders.ItemsLoading += CustomerOrders_ItemsLoading;
                }

                return customerOrders;
            }
        }

        void CustomerOrders_ItemsLoading(object sender, VirtualQueryableCollectionViewItemsLoadingEventArgs e)
        {
            EntityQuery<Order> query = Context.GetOrdersQuery();
            query.IncludeTotalCount = true;

            query = from o in query
                    where o.CustomerID == this.CustomerID
                        select o;

            Context.Load<Order>(query.Skip(e.StartIndex).Take(e.ItemCount),
                LoadBehavior.RefreshCurrent, CustomersLoaded, e.StartIndex);
        }

        private void CustomersLoaded(LoadOperation lo)
        {
            if (lo.TotalEntityCount != CustomerOrders.VirtualItemCount)
            {
                CustomerOrders.VirtualItemCount = lo.TotalEntityCount;
            }

            CustomerOrders.Load((int)lo.UserState, lo.Entities);
        }
    }
}
