using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using System.Windows.Input;
using System;
using System.Linq;
using QuickStart.DataBase;

namespace Telerik.Windows.Examples.DataVirtualization.WPF.VariousControls
{
    public class ExamplesDataContext : ViewModelBase
    {
		private readonly NorthwindEntities northwindEntities = new NorthwindEntities();

        private VirtualQueryableCollectionView customers;
        public VirtualQueryableCollectionView Customers
        {
            get
            {
                if (customers == null)
                {
                    try
                    {
						var query = this.northwindEntities.Customers.OrderBy(c => c.CustomerID);

                        this.customers = new VirtualQueryableCollectionView(query) { LoadSize = 10 };
                    }
                    catch
                    {
                    }
                }
                return this.customers;
            }
        }

		private VirtualQueryableCollectionView selectedCustomers;
		public VirtualQueryableCollectionView SelectedCustomers
		{
			get
			{
				if (selectedCustomers == null)
				{
					try
					{
						var query = this.northwindEntities.Customers.OrderBy(c => c.CustomerID);

						this.selectedCustomers = new VirtualQueryableCollectionView(query) { LoadSize = 10 };
					}
					catch
					{
					}

				}

				return selectedCustomers;
			}

			set
			{
				if (this.selectedCustomers != value)
				{
					this.selectedCustomers = value;
					OnPropertyChanged("SelectedCustomers");
				}
			}
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
				var query = this.northwindEntities.Customers.Include("Orders").Where(c => c.Country == this.SelectedCustomer.Country);

				this.SelectedCustomers = new VirtualQueryableCollectionView(query)
				{
					LoadSize = 10
				};

				this.SelectedCustomers.Load(0, this.northwindEntities.Customers);
			}
			else
			{
				var query = this.northwindEntities.Customers;

				this.SelectedCustomers = new VirtualQueryableCollectionView(query)
				{
					LoadSize = 10
				};
				this.SelectedCustomers.Load(0, this.northwindEntities.Customers);
			}
		}

        public void ClearLoadedCustomers()
        {
            this.customers = null;

            this.OnPropertyChanged("Customers");
        }

        public ExamplesDataContext()
        {
            this.ClearCommand = new ClearCommand(this);
        }

        private ClearCommand clearCommand = null;

        public ClearCommand ClearCommand
        {
            get
            {
                return this.clearCommand;
            }
            set
            {
                if (this.clearCommand != value)
                {
                    this.clearCommand = value;
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
