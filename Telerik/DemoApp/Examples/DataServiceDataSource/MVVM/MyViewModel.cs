using System;
using System.Collections.Generic;
using System.ComponentModel;
using Telerik.Windows.Data;
using Telerik.Windows.Examples.DataServiceDataSource.OData;
using Telerik.Windows.Controls.DataServices;
using System.Data.Services.Client;

namespace Telerik.Windows.Examples.DataServiceDataSource.MVVM
{
	public class MyViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly NorthwindEntities ordersContext;
		private readonly QueryableDataServiceCollectionView<Order> ordersView;
		private readonly NorthwindEntities orderDetailsContext;
		private readonly QueryableDataServiceCollectionView<Order_Detail> orderDetailsView;
		private readonly FilterDescriptor orderDetailsFilter;

		private bool areOrdersBusy;
		private bool areOrderDetailsBusy;
		private bool canUserSelectOrders;

		private Order selectedOrder;

		public Order SelectedOrder
		{
			get { return this.selectedOrder; }
			set
			{
				if (value != this.selectedOrder)
				{
					this.selectedOrder = value;

					if (this.selectedOrder != null)
					{
						this.orderDetailsFilter.Value = this.selectedOrder.OrderID;
					}
					else
					{
						this.orderDetailsFilter.Value = -1;
					}
					
					if (!this.orderDetailsView.AutoLoad)
					{
						this.orderDetailsView.AutoLoad = true;
					}

					this.OnPropertyChanged("SelectedOrder");
				}
			}
		}

		public IEnumerable<Order> Orders
		{
			get
			{
				return this.ordersView;
			}
		}

		public IEnumerable<Order_Detail> OrderDetails
		{
			get
			{
				return this.orderDetailsView;
			}
		}

		public bool AreOrdersBusy
		{
			get
			{
				return this.areOrdersBusy;
			}
			set
			{
				if (this.areOrdersBusy != value)
				{
					this.areOrdersBusy = value;
					this.OnPropertyChanged("AreOrdersBusy");
				}
			}
		}

		public bool AreOrderDetailsBusy
		{
			get
			{
				return this.areOrderDetailsBusy;
			}
			set
			{
				if (this.areOrderDetailsBusy != value)
				{
					this.areOrderDetailsBusy = value;
					this.OnPropertyChanged("AreOrderDetailsBusy");
				}
			}
		}

		public bool CanUserSelectOrders
		{
			get
			{
				return this.canUserSelectOrders;
			}
			set
			{
				if (this.canUserSelectOrders != value)
				{
					this.canUserSelectOrders = value;
					this.OnPropertyChanged("CanUserSelectOrders");
				}
			}
		}

		public MyViewModel()
		{
			this.ordersContext = new NorthwindEntities();
			DataServiceQuery<Order> ordersQuery = this.ordersContext.Orders;
			this.ordersView = new QueryableDataServiceCollectionView<Order>(this.ordersContext, ordersQuery);
			this.ordersView.PropertyChanged += this.OnOrdersViewPropertyChanged;
			this.ordersView.LoadedData += this.OnOrdersViewLoadedData;
			this.ordersView.PageSize = 10;
			this.ordersView.AutoLoad = true;

			this.orderDetailsContext = new NorthwindEntities();
			DataServiceQuery<Order_Detail> orderDetailsQuery = this.orderDetailsContext.Order_Details.Expand("Product");
			this.orderDetailsView = new QueryableDataServiceCollectionView<Order_Detail>(this.orderDetailsContext, orderDetailsQuery);
			this.orderDetailsFilter = new FilterDescriptor("OrderID", FilterOperator.IsEqualTo, -1);
			this.orderDetailsView.FilterDescriptors.Add(this.orderDetailsFilter);
			this.orderDetailsView.PropertyChanged += this.OnOrderDetailsViewPropertyChanged;
			this.orderDetailsView.LoadedData += this.OnOrderDetailsViewLoadedData;
		}

		private void OnOrdersViewPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsBusy")
			{
				this.AreOrdersBusy = this.ordersView.IsBusy;
			}
		}

		private void OnOrdersViewLoadedData(object sender, LoadedDataEventArgs e)
		{
			if (e.HasError)
			{
				e.MarkErrorAsHandled();
			}
		}

		private void OnOrderDetailsViewPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsBusy")
			{
				this.CanUserSelectOrders = !this.orderDetailsView.IsBusy;
				this.AreOrderDetailsBusy = this.orderDetailsView.IsBusy;
			}
		}

		private void OnOrderDetailsViewLoadedData(object sender, LoadedDataEventArgs e)
		{
			if (e.HasError)
			{
				e.MarkErrorAsHandled();
			}
		}

		protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, args);
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
	}
}
