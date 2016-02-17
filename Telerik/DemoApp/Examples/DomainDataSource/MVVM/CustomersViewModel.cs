using Examples.Web;
using System.Collections;
using System.ComponentModel;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Input;
using Telerik.Windows.Controls;
using System.Collections.Generic;
using Telerik.Windows.Data;
using System.Linq;

namespace Telerik.Windows.Examples.DomainDataSource.MVVM
{
	public class CustomersViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly QueryableDomainServiceCollectionView<Customer> view;
		private readonly DelegateCommand loadCommand;

		private readonly SortDescriptor countrySortDescriptor; 
		private readonly SortDescriptor citySortDescriptor;

		private readonly FilterDescriptor contactTitleFilterDescriptor;
		private readonly RadObservableCollection<string> contactTitles;

		private const string ClearSelectionString = "Clear Selection";

		public IEnumerable View
		{
			get
			{
				return this.view;
			}	
		}

		public bool AutoLoad
		{
			get
			{
				return this.view.AutoLoad;
			}
			set
			{
				if (this.view.AutoLoad != value)
				{
					this.view.AutoLoad = value;
					this.OnPropertyChanged("AutoLoad");					
				}
			}
		}

		public bool IsBusy
		{
			get
			{
				return this.view.IsBusy;
			}
		}

		public bool CanLoad
		{
			get
			{
				return this.view.CanLoad;
			}
		}

		public int PageSize
		{
			get
			{
				return this.view.PageSize;
			}
			set
			{
				if (this.view.PageSize != value)
				{
					this.view.PageSize = value;
					this.OnPropertyChanged("PageSize");
				}
			}
		}

		public ICommand LoadCommand
		{
			get
			{
				return this.loadCommand;
			}
		}

		public bool IsCountryAscendingChecked
		{
			get
			{
				return this.view.SortDescriptors.Contains(this.countrySortDescriptor)
					&& this.countrySortDescriptor.SortDirection == ListSortDirection.Ascending;
			}	
			set
			{
				if (value)
				{
					this.countrySortDescriptor.SortDirection = ListSortDirection.Ascending;
					if (!this.view.SortDescriptors.Contains(this.countrySortDescriptor))
					{
						this.view.SortDescriptors.Insert(0, this.countrySortDescriptor);
					}
				}
			}
		}

		public bool IsCountryDescendingChecked
		{
			get
			{
				return this.view.SortDescriptors.Contains(this.countrySortDescriptor)
					&& this.countrySortDescriptor.SortDirection == ListSortDirection.Descending;
			}
			set
			{
				if (value)
				{
					this.countrySortDescriptor.SortDirection = ListSortDirection.Descending;
					if (!this.view.SortDescriptors.Contains(this.countrySortDescriptor))
					{
						this.view.SortDescriptors.Insert(0, this.countrySortDescriptor);
					}
				}
			}
		}

		public bool IsCountryNoneChecked
		{
			get
			{
				return !this.view.SortDescriptors.Contains(this.countrySortDescriptor);
			}
			set
			{
				if (value)
				{
					if (this.view.SortDescriptors.Contains(this.countrySortDescriptor))
					{
						this.view.SortDescriptors.Remove(this.countrySortDescriptor);
					}
				}
			}
		}

		public bool IsCityAscendingChecked
		{
			get
			{
				return this.view.SortDescriptors.Contains(this.citySortDescriptor)
					&& this.citySortDescriptor.SortDirection == ListSortDirection.Ascending;
			}
			set
			{
				if (value)
				{
					this.citySortDescriptor.SortDirection = ListSortDirection.Ascending;
					if (!this.view.SortDescriptors.Contains(this.citySortDescriptor))
					{
						this.view.SortDescriptors.Add(this.citySortDescriptor);
					}
				}
			}
		}

		public bool IsCityDescendingChecked
		{
			get
			{
				return this.view.SortDescriptors.Contains(this.citySortDescriptor)
					&& this.citySortDescriptor.SortDirection == ListSortDirection.Descending;
			}
			set
			{
				if (value)
				{
					this.citySortDescriptor.SortDirection = ListSortDirection.Descending;
					if (!this.view.SortDescriptors.Contains(this.citySortDescriptor))
					{
						this.view.SortDescriptors.Add(this.citySortDescriptor);
					}
				}
			}
		}

		public bool IsCityNoneChecked
		{
			get
			{
				return !this.view.SortDescriptors.Contains(this.citySortDescriptor);
			}
			set
			{
				if (value)
				{
					if (this.view.SortDescriptors.Contains(this.citySortDescriptor))
					{
						this.view.SortDescriptors.Remove(this.citySortDescriptor);
					}
				}
			}
		}

		public string SelectedContactTitle
		{
			get
			{
				if (this.contactTitleFilterDescriptor.Value == FilterDescriptor.UnsetValue)
				{
					return CustomersViewModel.ClearSelectionString;
				}

				return this.contactTitleFilterDescriptor.Value as string;
			}	
			set
			{
				if (value == CustomersViewModel.ClearSelectionString)
				{
					this.contactTitleFilterDescriptor.Value = FilterDescriptor.UnsetValue;
				}
				else
				{
					this.contactTitleFilterDescriptor.Value = value;
				}
			}
		}

		public IEnumerable<string> ContactTitles
		{
			get
			{
				return this.contactTitles;
			}	
		}

		public CustomersViewModel()
		{
			NorthwindDomainContext context = new NorthwindDomainContext();
			EntityQuery<DistinctValue> contactTitlesQuery = context.GetDistinctValuesQuery("ContactTitle");
			context.Load<DistinctValue>(contactTitlesQuery
				, LoadBehavior.RefreshCurrent
				, this.OnDistinctContactTitlesLoaded
				, this.contactTitles);
			
			EntityQuery<Customer> getCustomersQuery = context.GetCustomersQuery();
			this.view = new QueryableDomainServiceCollectionView<Customer>(context, getCustomersQuery);
			
			this.view.PageSize = 10;
			this.view.AutoLoad = true;
			this.view.PropertyChanged += this.OnViewPropertyChanged;
			this.view.LoadedData += this.OnViewLoadedData;

			this.loadCommand = new DelegateCommand(this.ExecuteLoadCommand, this.LoadCommandCanExecute);

			this.countrySortDescriptor = new SortDescriptor() { Member = "Country" };
			this.citySortDescriptor = new SortDescriptor() { Member = "City" };

			this.contactTitles = new RadObservableCollection<string>();
			this.contactTitles.Add(CustomersViewModel.ClearSelectionString);
			
			this.contactTitleFilterDescriptor = new FilterDescriptor("ContactTitle", FilterOperator.IsEqualTo, FilterDescriptor.UnsetValue);
			this.view.FilterDescriptors.Add(this.contactTitleFilterDescriptor);
		}

		private void OnViewLoadedData(object sender, Controls.DomainServices.LoadedDataEventArgs e)
		{
			if (e.HasError)
			{
				e.MarkErrorAsHandled();
				return;
			}
		}

		private void OnDistinctContactTitlesLoaded(LoadOperation<DistinctValue> loadOperation)
		{
			if (loadOperation.HasError)
			{
				loadOperation.MarkErrorAsHandled();
				return;
			}

			foreach (DistinctValue dv in loadOperation.Entities.ToList())
			{
				this.contactTitles.Add(dv.Value);
			}
		}

		private void ExecuteLoadCommand(object o)
		{
			this.view.Load();
		}

		private bool LoadCommandCanExecute(object o)
		{
			return this.view.CanLoad && !this.AutoLoad;
		}

		private void OnViewPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "CanLoad":
					this.loadCommand.InvalidateCanExecute();
					break;
				case "IsBusy":
				case "PageSize":
					this.OnPropertyChanged(e.PropertyName);
					break;
				case "AutoLoad":
					this.OnPropertyChanged(e.PropertyName);
					this.loadCommand.InvalidateCanExecute();
					break;
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
