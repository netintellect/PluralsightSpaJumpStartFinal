using System;
using System.Linq;
using Telerik.Windows.Data;
using QuickStart.DataBase;

namespace Telerik.Windows.Examples.EntityFrameworkDataSource.MVVM
{
	public class MyViewModel
	{
		private readonly QueryableEntityCollectionView<Customer> customersView;
		private readonly NorthwindEntities objectContext;

		public MyViewModel()
		{
            try
            {
                this.objectContext = new NorthwindEntities();
                this.customersView = new QueryableEntityCollectionView<Customer>(objectContext, "Customers");
            }
            catch
            {

            }
		}

		public QueryableEntityCollectionView<Customer> CustomersView
		{
			get { return this.customersView; }
		}
	}
}
