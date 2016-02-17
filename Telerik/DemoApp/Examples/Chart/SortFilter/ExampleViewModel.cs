using System.Collections.Generic;
using System.ComponentModel;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.Chart.SortFilter
{
    public class ExampleViewModel : ViewModelBase
    {
        private QueryableCollectionView _data;
        private bool _filterGreater;
        private bool _filterLess;
        private string _selectedSortingCategory;
        private string[] _sortingCategories = new string[] { "None", "Sort by Country Asc", "Sort by Country Desc", "Sort by GDP Asc", "Sort by GDP Desc" };
        private ChartFilterDescriptor filterGreaterThan;
        private ChartFilterDescriptor filterLessThan;

        public ExampleViewModel()
        {
            this._selectedSortingCategory = this._sortingCategories[0];
        }

        public QueryableCollectionView Data
        {
            get
            {
                if (this._data == null)
                {
                    this._data = new QueryableCollectionView(this.CreateData());
                }

                return this._data;
            }
        }

        public bool FilterGreater
        {
            get
            {
                return this._filterGreater;
            }
            set
            {
                if (this._filterGreater == value)
                    return;

                this._filterGreater = value;
                this.OnPropertyChanged("FilterGreater");
                this.OnFilterGreaterChanged();
            }
        }

        public bool FilterLess
        {
            get
            {
                return this._filterLess;
            }
            set
            {
                if (this._filterLess == value)
                    return;

                this._filterLess = value;
                this.OnPropertyChanged("FilterLess");
                this.OnFilterLessChanged();
            }
        }

        public string SelectedSortingCategory
        {
            get
            {
                return this._selectedSortingCategory;
            }
            set
            {
                if (this._selectedSortingCategory == value)
                    return;

                this._selectedSortingCategory = value;
                this.OnPropertyChanged("SelectedSortingCategory");
                this.OnSelectedSortingCategoryChanged();
            }
        }

        public IEnumerable<string> SortingCategories
        {
            get
            {
                return this._sortingCategories;
            }
        }

        public void SetSorting(string sortBy)
        {
            this.Data.SortDescriptors.Clear();

            switch (sortBy)
            {
                case "Sort by Country Asc":
                    this.ApplySorting("Asc", "Country");
                    break;
                case "Sort by Country Desc":
                    this.ApplySorting("Desc", "Country");
                    break;
                case "Sort by GDP Asc":
                    this.ApplySorting("Asc", "GDP");
                    break;
                case "Sort by GDP Desc":
                    this.ApplySorting("Desc", "GDP");
                    break;
            }
        }

        protected virtual void OnFilterGreaterChanged()
        {
            if (this.FilterGreater)
            {
                if (this.filterGreaterThan == null)
                    this.filterGreaterThan = new ChartFilterDescriptor("GDP", typeof(decimal), FilterOperator.IsGreaterThan, 2000000);

                this.Data.FilterDescriptors.Add(filterGreaterThan);
            }
            else
            {
                this.Data.FilterDescriptors.Remove(this.filterGreaterThan);
            }
        }

        protected virtual void OnFilterLessChanged()
        {
            if (this.FilterLess)
            {
                if (this.filterLessThan == null)
                    this.filterLessThan = new ChartFilterDescriptor("GDP", typeof(decimal), FilterOperator.IsLessThan, 4000000);

                this.Data.FilterDescriptors.Add(this.filterLessThan);
            }
            else
            {
                this.Data.FilterDescriptors.Remove(this.filterLessThan);
            }
        }

        protected virtual void OnSelectedSortingCategoryChanged()
        {
            SetSorting(this.SelectedSortingCategory);
        }

        private void ApplySorting(string sortDirection, string fieldName)
        {
            if (sortDirection.ToLower() != "none")
            {
                SortDescriptor sortDescriptor = new SortDescriptor();
                sortDescriptor.Member = fieldName;
                
                if (sortDirection.ToLower() == "asc")
                    sortDescriptor.SortDirection = ListSortDirection.Ascending;
                else
                    sortDescriptor.SortDirection = ListSortDirection.Descending;

                this.Data.SortDescriptors.Add(sortDescriptor);
            }
        }

        private IEnumerable<GDPData> CreateData()
        {
            List<GDPData> gdpData = new List<GDPData>();

            gdpData.Add(new GDPData("EU", 18387785M));
            gdpData.Add(new GDPData("Japan", 4910692M));
            gdpData.Add(new GDPData("Russia", 1676586M));
            gdpData.Add(new GDPData("Spain", 1601964M));
            gdpData.Add(new GDPData("France", 2866951M));
            gdpData.Add(new GDPData("USA", 14441425M));
            gdpData.Add(new GDPData("Germany", 3673105M));
            gdpData.Add(new GDPData("Italy", 2313893M));
            gdpData.Add(new GDPData("China", 4327448M));
            gdpData.Add(new GDPData("UK", 2680000M));

            return gdpData;
        }
    }
}
