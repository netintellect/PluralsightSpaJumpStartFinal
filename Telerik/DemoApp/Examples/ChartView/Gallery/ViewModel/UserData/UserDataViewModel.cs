using System.Collections.Generic;
using System.Windows.Controls;
using Telerik.Charting;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView
{
    public class UserDataViewModel : ViewModelBase
    {
        private IEnumerable<double> collection1, collection2;
        private IEnumerable<UserDataPoint> dataPointCollection1, dataPointCollection2;
        private ChartSeriesCombineMode _combineMode = ChartSeriesCombineMode.None;
        private ChartSeriesCombineMode _lineCombineMode = ChartSeriesCombineMode.None;
        private ChartSeriesCombineMode _barCombineMode = ChartSeriesCombineMode.Cluster;
        private Orientation _chartOrientation = Orientation.Vertical;
        private bool _isShowLabelsEnabled = true;
        private bool _showLabels = true;

        public IEnumerable<double> Collection1
        {
            get
            {
                if (this.collection1 == null)
                {
                    this.collection1 = ExampleData.GetUserData(10, 0);
                }
                return this.collection1;
            }
        }

        public IEnumerable<double> Collection2
        {
            get
            {
                if (this.collection2 == null)
                {
                    this.collection2 = ExampleData.GetUserData(10, 1);
                }
                return this.collection2;
            }
        }

        public IEnumerable<UserDataPoint> DataPointCollection1
        {
            get
            {
                if (this.dataPointCollection1 == null)
                {
                    this.dataPointCollection1 = ExampleData.GetUserDataPoints(10, 0);
                }
                return this.dataPointCollection1;
            }
        }

        public IEnumerable<UserDataPoint> DataPointCollection2
        {
            get
            {
                if (this.dataPointCollection2 == null)
                {
                    this.dataPointCollection2 = ExampleData.GetUserDataPoints(10, 1);
                }
                return this.dataPointCollection2;
            }
        }

        public ChartSeriesCombineMode CombineMode
        {
            get
            {
                return this._combineMode;
            }
            set
            {
                if (this._combineMode != value)
                {
                    this._combineMode = value;
                    this.OnPropertyChanged("CombineMode");

                    this.UpdateLabelsConfiguration(this._combineMode);
                }
            }
        }

        public ChartSeriesCombineMode BarCombineMode
        {
            get
            {
                return this._barCombineMode;
            }
            set
            {
                if (this._barCombineMode != value)
                {
                    this._barCombineMode = value;
                    this.OnPropertyChanged("BarCombineMode");

                    this.UpdateLabelsConfiguration(this._barCombineMode);
                }
            }
        }

        public ChartSeriesCombineMode LineCombineMode
        {
            get
            {
                return this._lineCombineMode;
            }
            set
            {
                if (this._lineCombineMode != value)
                {
                    this._lineCombineMode = value;
                    this.OnPropertyChanged("LineCombineMode");
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

        public Orientation ChartOrientation
        {
            get
            {
                return this._chartOrientation;
            }
            set
            {
                if (this._chartOrientation != value)
                {
                    this._chartOrientation = value;
                    this.OnPropertyChanged("ChartOrientation");
                }
            }
        }

        private void UpdateLabelsConfiguration(ChartSeriesCombineMode mode)
        {
            if (mode == ChartSeriesCombineMode.Stack || mode == ChartSeriesCombineMode.Stack100)
            {
                this.ShowLabels = false;
                this.IsShowLabelsEnabled = false;
            }
            else
            {
                this.ShowLabels = true;
                this.IsShowLabelsEnabled = true;
            }
        }

    }
}
