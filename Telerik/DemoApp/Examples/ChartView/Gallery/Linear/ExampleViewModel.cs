using System.Collections.Generic;
using Telerik.Charting;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.Gallery.Linear
{
    public class ExampleViewModel : ViewModelBase
    {
        private List<SalesRevenue> collection1, collection2;
        private List<string> _chartTypes;
        private List<ChartSeriesCombineMode> _combineModes;
        private ChartSeriesCombineMode _selectedCombineMode;
        private bool _isShowLabelsEnabled = true;
        private bool _showLabels = true;
        private string _selectedChartType;

        public ExampleViewModel()
        {
            this.InitializeChartTypes();
            this.SelectedChartType = this.ChartTypes[0];
        }

        public List<string> ChartTypes
        {
            get { return this._chartTypes; }
        }

        public string SelectedChartType
        {
            get
            {
                return this._selectedChartType;
            }
            set
            {
                if (this._selectedChartType == value)
                    return;

                this._selectedChartType = value;
                this.OnPropertyChanged("SelectedChartType");
                this.OnSelectedChartTypeChanged();
            }
        }

        public List<SalesRevenue> Collection1
        {
            get
            {
                if (this.collection1 == null)
                {
                    this.collection1 = new List<SalesRevenue>();
                    this.collection1.Add(new SalesRevenue("January", 3.5));
                    this.collection1.Add(new SalesRevenue("February", 2.8));
                    this.collection1.Add(new SalesRevenue("March", 3.4));
                    this.collection1.Add(new SalesRevenue("April", 3.2));
                    this.collection1.Add(new SalesRevenue("May", 3.4));
                    this.collection1.Add(new SalesRevenue("June", 3.7));
                    this.collection1.Add(new SalesRevenue("July", 3.1));
                    this.collection1.Add(new SalesRevenue("August", 2.9));
                    this.collection1.Add(new SalesRevenue("September", 3.3));
                    this.collection1.Add(new SalesRevenue("October", 3.1));
                    this.collection1.Add(new SalesRevenue("November", 3.6));
                    this.collection1.Add(new SalesRevenue("December", 3.7));
                }
                return this.collection1;
            }
        }

        public List<SalesRevenue> Collection2
        {
            get
            {
                if (this.collection2 == null)
                {
                    this.collection2 = new List<SalesRevenue>();
                    this.collection2.Add(new SalesRevenue("January", 1.5));
                    this.collection2.Add(new SalesRevenue("February", 1.7));
                    this.collection2.Add(new SalesRevenue("March", 1.6));
                    this.collection2.Add(new SalesRevenue("April", 1.6));
                    this.collection2.Add(new SalesRevenue("May", 1.7));
                    this.collection2.Add(new SalesRevenue("June", 1.5));
                    this.collection2.Add(new SalesRevenue("July", 1.5));
                    this.collection2.Add(new SalesRevenue("August", 1.7));
                    this.collection2.Add(new SalesRevenue("September", 2.1));
                    this.collection2.Add(new SalesRevenue("October", 1.6));
                    this.collection2.Add(new SalesRevenue("November", 2));
                    this.collection2.Add(new SalesRevenue("December", 1.6));
                }
                return this.collection2;
            }
        }

        public List<ChartSeriesCombineMode> CombineModes
        {
            get
            {
                return this._combineModes;
            }
            private set
            {
                if (this._combineModes == value)
                    return;

                this._combineModes = value;
                this.OnPropertyChanged("CombineModes");
            }
        }

        public ChartSeriesCombineMode SelectedCombineMode
        {
            get
            {
                return this._selectedCombineMode;
            }
            set
            {
                if (this._selectedCombineMode != value)
                {
                    this._selectedCombineMode = value;
                    this.OnPropertyChanged("SelectedCombineMode");
                }
            }
        }

        public bool ShowLabels
        {
            get
            {
                return this._showLabels;
            }
            set
            {
                if (this._showLabels != value)
                {
                    this._showLabels = value;
                    this.OnPropertyChanged("ShowLabels");
                }
            }
        }

        public bool IsShowLabelsEnabled
        {
            get
            {
                return this._isShowLabelsEnabled;
            }
            set
            {
                if (this._isShowLabelsEnabled != value)
                {
                    this._isShowLabelsEnabled = value;
                    this.OnPropertyChanged("IsShowLabelsEnabled");
                }
            }
        }

        private void InitializeChartTypes()
        {
            this._chartTypes = new List<string>();
            this._chartTypes.Add("Line");
            this._chartTypes.Add("Spline");
            this._chartTypes.Add("Area");
            this._chartTypes.Add("Spline Area");
            this._chartTypes.Add("Step Line");
            this._chartTypes.Add("Step Area");
        }

        private void OnSelectedChartTypeChanged()
        {
            List<ChartSeriesCombineMode> combineModes = new List<ChartSeriesCombineMode>();
            if (this.SelectedChartType == "Line" || this.SelectedChartType == "Spline" || this.SelectedChartType == "Step Line")
            {
                combineModes.Add(ChartSeriesCombineMode.None);
                combineModes.Add(ChartSeriesCombineMode.Stack);
                this.ShowLabels = true;
                this.IsShowLabelsEnabled = true;
            }
            else if (this.SelectedChartType == "Area" || this.SelectedChartType == "Spline Area" || this.SelectedChartType == "Step Area")
            {
                combineModes.Add(ChartSeriesCombineMode.Stack);
                combineModes.Add(ChartSeriesCombineMode.Stack100);
                this.ShowLabels = false;
                this.IsShowLabelsEnabled = false;
            }

            this.CombineModes = combineModes;
            if (!this.CombineModes.Contains(this.SelectedCombineMode))
            {
                this.SelectedCombineMode = this.CombineModes[0];
            }
        }
    }
}
