using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.Chart.Aggregates
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private string[] _aggregateFunctions = new string[] { "Sum", "Min", "Average", "Max" };
        private string _aggregateFunction;
        private IEnumerable _chartData;
        private QueryableCollectionView _gridViewData;
        private string _selectedPeriod;
        private ICommand _selectedPeriodChangedCommand;
        private SeriesMappingCollection _seriesMappings;
        private bool _showbyLocation;

        public ExampleViewModel()
        {
            this.GetData("omega.csv");
        }

        protected override IEnumerable ParseData(System.IO.TextReader dataReader)
        {
            List<BusinessObject> data = new List<BusinessObject>();
            string line;

            while ((line = dataReader.ReadLine()) != null)
            {
                string[] lineData = line.Split(',');

                string location = lineData[0];
                string type = lineData[1];
                string quarter = lineData[2];
                int year = int.Parse(lineData[3].ToString(), CultureInfo.InvariantCulture);
                double sales = double.Parse(lineData[4], CultureInfo.InvariantCulture);

                BusinessObject obj = new BusinessObject(year, quarter, type, location, sales);

                data.Add(obj);
            }

            return data;
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            this.ChartData = data;
            this.GridViewData = new QueryableCollectionView(this._chartData);
            this.GridViewData.GroupDescriptors.CollectionChanged += GroupDescriptors_CollectionChanged;
            this.GridViewData.FilterDescriptors.CollectionChanged += FilterDescriptors_CollectionChanged;

            this.AggregateFunction = this._aggregateFunctions[1];
            this.SelectedPeriod = "Annual";
            this.SetTypeYearGroupDescriptors();
            this.BindChart();
        }

        public string AggregateFunction
        {
            get
            {
                return this._aggregateFunction;
            }
            set
            {
                if (this._aggregateFunction == value)
                    return;

                this._aggregateFunction = value;
                this.OnPropertyChanged("AggregateFunction");
            }
        }

        public IEnumerable<string> AggregateFunctions
        {
            get
            {
                return this._aggregateFunctions;
            }
        }

        public IEnumerable ChartData
        {
            get
            {
                return _chartData;
            }
            set
            {
                if (this._chartData == value)
                    return;

                this._chartData = value;
                this.OnPropertyChanged("ChartData");
            }
        }

        public QueryableCollectionView GridViewData
        {
            get
            {
                return _gridViewData;
            }
            set
            {
                if (this._gridViewData == value)
                    return;

                this._gridViewData = value;
                this.OnPropertyChanged("GridViewData");
            }
        }

        public string SelectedPeriod
        {
            get
            {
                return this._selectedPeriod;
            }
            set
            {
                if (this._selectedPeriod == value)
                    return;

                this._selectedPeriod = value;
                this.OnPropertyChanged("SelectedPeriod");
            }
        }

#if WPF
        public Brush ReportHeaderForeground
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(255, 121, 37, 107));
            }
        }
#else
        public Brush ReportHeaderForeground
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(255, 31, 163, 235));
            }
        }
#endif

        public ICommand SelectedPeriodChangedCommand
        {
            get
            {
                if (this._selectedPeriodChangedCommand == null)
                {
                    this._selectedPeriodChangedCommand = new DelegateCommand(OnSelectedPeriodChanged);
                }

                return this._selectedPeriodChangedCommand;
            }
        }

        public SeriesMappingCollection SeriesMappings
        {
            get
            {
                return this._seriesMappings;
            }
            set
            {
                if (this._seriesMappings == value)
                    return;

                this._seriesMappings = value;
                this.OnPropertyChanged("SeriesMappings");
            }
        }

        public bool ShowbyLocation
        {
            get
            {
                return this._showbyLocation;
            }
            set
            {
                if (this._showbyLocation == value)
                    return;

                this._showbyLocation = value;
                this.OnPropertyChanged("ShowbyLocation");
            }
        }

        protected virtual void OnAggregateFunctionChanged()
        {
            this.BindChart();
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case ("AggregateFunction") :
                    this.OnAggregateFunctionChanged();
                    break;
                case ("ShowbyLocation") :
                    this.OnShowbyLocationChanged();
                    break;
            }
        }

        protected virtual void OnSelectedPeriodChanged(object parameter)
        {
            this.SelectedPeriod = parameter.ToString();

            switch (this.SelectedPeriod)
            {
                case "Annual":
                    this.SetTypeYearGroupDescriptors();
                    break;
                case "Quarterly":
                    this.SetTypeQuarterGroupDescriptors();
                    break;
                default:
                    this.SetDefaultGroupDescriptors();
                    break;
            }

            if (this.ShowbyLocation)
                this.SetTypeLocationGroupDescriptors();

            this.BindChart();
        }

        protected virtual void OnShowbyLocationChanged()
        {
            if (this.ShowbyLocation)
            {
                this.SetTypeLocationGroupDescriptors();
            }
            else
            {
                switch (this.SelectedPeriod)
                {
                    case "Annual":
                        this.SetTypeYearGroupDescriptors();
                        break;
                    case "Quarterly":
                        this.SetTypeQuarterGroupDescriptors();
                        break;
                }
            }

            this.BindChart();
        }

        private void BindChart()
        {
            SeriesMapping mapping1 = new SeriesMapping();

            ChartAggregateFunction aggFunct = (ChartAggregateFunction)Enum.Parse(typeof(ChartAggregateFunction), this.AggregateFunction, true);

            mapping1.ItemMappings.Add(new ItemMapping("Sales", DataPointMember.YValue, aggFunct));

            SeriesDefinition definition = new BarSeriesDefinition();
            definition.ShowItemToolTips = true;

            if (this.ShowbyLocation && GridViewData.GroupDescriptors.Count > 2)
                definition.ShowItemLabels = false;

            mapping1.SeriesDefinition = definition;

            foreach (IGroupDescriptor descriptor in this.GridViewData.GroupDescriptors)
            {
                mapping1.GroupingSettings.GroupDescriptors.Add(new ChartGroupDescriptor(this.GetDataMemberName(descriptor)));
            }

            foreach (IFilterDescriptor descriptor in this.GridViewData.FilterDescriptors)
            {
                mapping1.FilterDescriptors.Add(new ChartFilterDescriptor(descriptor));
            }

            if (this.GridViewData.GroupDescriptors.Count > 1)
            {
                IGroupDescriptor lastGroupDescriptor = this.GridViewData.GroupDescriptors.Last();
                mapping1.ItemMappings.Add(new ItemMapping(this.GetDataMemberName(lastGroupDescriptor), DataPointMember.XCategory));
            }

            SeriesMappingCollection mappings = new SeriesMappingCollection();
            mappings.Add(mapping1);
            this.SeriesMappings = mappings;
        }

        private string GetDataMemberName(IGroupDescriptor descriptor)
        {
            if (descriptor is GroupDescriptor)
            {
                return (descriptor as GroupDescriptor).Member;
            }

            if (descriptor is ColumnGroupDescriptor)
            {
                GridViewDataColumn column = ((ColumnGroupDescriptor)descriptor).Column as GridViewDataColumn;
                return column.GetDataMemberName();
            }

            return null;
        }

        private string GetFilterDataMemberName(IFilterDescriptor descriptor)
        {
            if (descriptor is FilterDescriptor)
            {
                return (descriptor as GroupDescriptor).Member;
            }

            return null;
        }

        private void GroupDescriptors_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.BindChart();
        }

        private void FilterDescriptors_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.BindChart();
        }

        private void SetDefaultGroupDescriptors()
        {
            this.GridViewData.GroupDescriptors.SuspendNotifications();
            this.GridViewData.GroupDescriptors.Clear();

            GroupDescriptor groupDesc = new GroupDescriptor();
            groupDesc.Member = "Year";
            this.GridViewData.GroupDescriptors.Add(groupDesc);

            groupDesc = new GroupDescriptor();
            groupDesc.Member = "Quarter";
            this.GridViewData.GroupDescriptors.Add(groupDesc);
            this.GridViewData.GroupDescriptors.ResumeNotifications();
        }

        private void SetTypeQuarterGroupDescriptors()
        {
            this.GridViewData.GroupDescriptors.SuspendNotifications();
            this.GridViewData.GroupDescriptors.Clear();

            GroupDescriptor groupDesc = new GroupDescriptor();
            groupDesc.Member = "Type";
            this.GridViewData.GroupDescriptors.Add(groupDesc);

            groupDesc = new GroupDescriptor();
            groupDesc.Member = "Quarter";
            this.GridViewData.GroupDescriptors.Add(groupDesc);
            this.GridViewData.GroupDescriptors.ResumeNotifications();
        }

        private void SetTypeLocationGroupDescriptors()
        {
            this.GridViewData.GroupDescriptors.SuspendNotifications();
            this.GridViewData.GroupDescriptors.Clear();

            GroupDescriptor groupDesc = new GroupDescriptor();
            groupDesc.Member = "Type";
            this.GridViewData.GroupDescriptors.Add(groupDesc);

            groupDesc = new GroupDescriptor();
            groupDesc.Member = "Location";
            this.GridViewData.GroupDescriptors.Add(groupDesc);

            groupDesc = new GroupDescriptor();

            switch (this.SelectedPeriod)
            {
                case "Annual":
                    groupDesc.Member = "Year";
                    break;
                case "Quarterly":
                    groupDesc.Member = "Quarter";
                    break;
            }

            this.GridViewData.GroupDescriptors.Add(groupDesc);
            this.GridViewData.GroupDescriptors.ResumeNotifications();
        }

        private void SetTypeYearGroupDescriptors()
        {
            this.GridViewData.GroupDescriptors.SuspendNotifications();
            this.GridViewData.GroupDescriptors.Clear();
            
            GroupDescriptor groupDesc = new GroupDescriptor();
            groupDesc.Member = "Type";
            this.GridViewData.GroupDescriptors.Add(groupDesc);

            groupDesc = new GroupDescriptor();
            groupDesc.Member = "Year";
            this.GridViewData.GroupDescriptors.Add(groupDesc);
            this.GridViewData.GroupDescriptors.ResumeNotifications();
        }
    }
}
