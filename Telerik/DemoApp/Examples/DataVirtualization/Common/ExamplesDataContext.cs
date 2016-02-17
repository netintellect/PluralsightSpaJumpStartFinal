using Telerik.Windows.Data;
using Telerik.Windows.Controls;
using Examples.Web;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using Telerik.Windows.Controls.DomainServices;
using System.Windows.Input;
using System;

namespace Telerik.Windows.Examples
{
	public class ExamplesDataContext : ViewModelBase
	{
		NorthwindDomainContext context;
		public NorthwindDomainContext Context
		{
			get
			{
				if (context == null)
				{
					context = new NorthwindDomainContext();

				}

				return context;
			}
		}

		VirtualQueryableCollectionView customers;
		public VirtualQueryableCollectionView Customers
		{
			get
			{
				if (customers == null)
				{
					customers = new VirtualQueryableCollectionView();
					customers.VirtualItemCount = 100; // Force ItemsLoading to get the real total item count and data in a single request
					customers.LoadSize = 10;

					customers.ItemsLoading += Customers_ItemsLoading;
				}

				return customers;
			}
			private set
			{
				if (this.customers != value)
				{
					customers.ItemsLoading -= Customers_ItemsLoading;

					this.customers = value;
					this.OnPropertyChanged("Customers");
				}
			}
		}

        bool shouldLoadCustomers = true;

		void Customers_ItemsLoading(object sender, VirtualQueryableCollectionViewItemsLoadingEventArgs e)
		{
            if (!shouldLoadCustomers)
            {
                shouldLoadCustomers = true;
                return;
            }

			EntityQuery<Customer> query = this.Context.GetCustomersQuery();
			query.IncludeTotalCount = true;

			query = query
				.Sort(Customers.SortDescriptors)
				.Where(Customers.FilterDescriptors)
				.Skip(e.StartIndex)
				.Take(e.ItemCount);

			Context.Load<Customer>(query, LoadBehavior.RefreshCurrent, this.CustomersLoaded, e.StartIndex);
		}


		private void CustomersLoaded(LoadOperation lo)
		{
			if (lo.TotalEntityCount != Customers.VirtualItemCount)
			{
                shouldLoadCustomers = false;
				Customers.VirtualItemCount = lo.TotalEntityCount;
			}

			Customers.Load((int) lo.UserState, lo.Entities);
		}

		public void ClearLoadedCustomers()
		{
			this.Customers = null;
		}

		VirtualQueryableCollectionView selectedCustomers;
		public VirtualQueryableCollectionView SelectedCustomers
		{
			get
			{
				if (this.selectedCustomers == null)
				{
					this.selectedCustomers = new VirtualQueryableCollectionView();
					this.selectedCustomers.VirtualItemCount = 100; // Force ItemsLoading to get the real total item count and data in a single request
					this.selectedCustomers.LoadSize = 10;


					this.selectedCustomers.ItemsLoading += SelectedCustomers_ItemsLoading;
				}

				return this.selectedCustomers;
			}
			private set
			{
				if (this.selectedCustomers != value)
				{
					if (this.selectedCustomers != null)
					{
						selectedCustomers.ItemsLoading -= SelectedCustomers_ItemsLoading;
					}

					this.selectedCustomers = value;
					this.OnPropertyChanged("SelectedCustomers");
				}
			}
		}

		bool shouldLoadSelectedCustomers = true;

		void SelectedCustomers_ItemsLoading(object sender, VirtualQueryableCollectionViewItemsLoadingEventArgs e)
		{
			if (!shouldLoadSelectedCustomers)
			{
				shouldLoadSelectedCustomers = true;
				return;
			}

			EntityQuery<Customer> query = Context.GetCustomersQuery();
			query.IncludeTotalCount = true;

			query = query
				.Sort(this.SelectedCustomers.SortDescriptors)
				.Where(this.SelectedCustomers.FilterDescriptors)
				.Skip(e.StartIndex)
				.Take(e.ItemCount);

			Context.Load<Customer>(query, LoadBehavior.RefreshCurrent, SelectedCustomersLoaded, e.StartIndex);
		}


		private void SelectedCustomersLoaded(LoadOperation lo)
		{
			if (lo.TotalEntityCount != Customers.VirtualItemCount)
			{
				shouldLoadSelectedCustomers = false;
				this.SelectedCustomers.VirtualItemCount = lo.TotalEntityCount;
			}

			this.SelectedCustomers.Load((int)lo.UserState, lo.Entities);
		}

		private Customer selectedCustomer;
		public Customer SelectedCustomer
		{
			get
			{
				return this.selectedCustomer;
			}
			set
			{
				if (this.selectedCustomer != value)
				{
					this.selectedCustomer = value;
					this.UpdateSelectedCustomers();
				}
			}
		}

		private void UpdateSelectedCustomers()
		{
			if (this.SelectedCustomer != null)
			{
				var query = this.Context.Customers.Where(c => c.Country == this.SelectedCustomer.Country);
				this.SelectedCustomers = new VirtualQueryableCollectionView(query) { LoadSize = 10 };

				this.SelectedCustomers.Load(0, this.Context.Customers);
			}
			else
			{
				var query = this.Context.Customers;
				this.SelectedCustomers = new VirtualQueryableCollectionView(query) { LoadSize = 10 };

				this.SelectedCustomers.Load(0, this.Context.Customers);
			}
		}

        public ExamplesDataContext()
        {
            this.ClearCommand = new ClearCommand(this);
        }

        private ClearCommand _clearCommand = null;

        public ClearCommand ClearCommand
        {
            get
            {
                return this._clearCommand;
            }
            set
            {
                if (this._clearCommand != value)
                {
                    this._clearCommand = value;
                    OnPropertyChanged("ClearCommand");
                }
            }
        }
    }

    public class ClearCommand : ICommand
    {
        private readonly ExamplesDataContext context;

        public ClearCommand(ExamplesDataContext context)
        {
            this.context = context;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.context.ClearLoadedCustomers();
        }
    }
}