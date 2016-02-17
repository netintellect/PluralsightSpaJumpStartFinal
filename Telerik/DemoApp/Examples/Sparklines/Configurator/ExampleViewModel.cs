using System;
using System.Collections.Generic;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Sparklines.Configurator
{
    public class ExampleViewModel : ViewModelBase
    {
        private int _columns;
        private Brush _firstPointBursh;
        private int _numberOfItemsPerSparkline;
        private Random _r = new Random();
        private int _rows;
        private bool _showAxis;
        private bool _showNormalRange;
        private bool _showFirstPointIndicator;
        private bool _showHighPointIndicators;
        private bool _showLastPointIndicator;
        private bool _showLowPointIndicators;
        private bool _showMarkers;
        private bool _showNegativePointIndicators;

        public int Columns
        {
            get
            {
                return this._columns;
            }
            set
            {
                if (this._columns == value)
                    return;

                this._columns = value;
                this.OnPropertyChanged("Columns");
            }
        }

        public IEnumerable<int> Data
        {
            get
            {
                return this.CreateData();
            }
        }

        public Brush FirstPointBursh
        {
            get
            {
                return this._firstPointBursh;
            }
            set
            {
                if (object.Equals(this._firstPointBursh, value))
                    return;

                this._firstPointBursh = value;
                this.OnPropertyChanged("FirstPointBursh");
            }
        }

        public int NumberOfItemsPerSparkline
        {
            get
            {
                return this._numberOfItemsPerSparkline;
            }
            set
            {
                if (this._numberOfItemsPerSparkline == value)
                    return;

                this._numberOfItemsPerSparkline = value;
                this.OnPropertyChanged("NumberOfItemsPerSparkline");
                this.CreateData();
            }
        }

        public int Rows
        {
            get
            {
                return this._rows;
            }
            set
            {
                if (this._rows == value)
                    return;

                this._rows = value;
                this.OnPropertyChanged("Rows");
            }
        }

        public bool ShowAxis
        {
            get
            {
                return this._showAxis;
            }
            set
            {
                if (this._showAxis == value)
                    return;

                this._showAxis = value;
                this.OnPropertyChanged("ShowAxis");
            }
        }

        public bool ShowNormalRange
        {
            get
            {
                return this._showNormalRange;
            }
            set
            {
                if (this._showNormalRange == value)
                    return;

                this._showNormalRange = value;
                this.OnPropertyChanged("ShowNormalRange");
            }
        }

        public bool ShowFirstPointIndicator
        {
            get
            {
                return this._showFirstPointIndicator;
            }
            set
            {
                if (this._showFirstPointIndicator == value)
                    return;

                this._showFirstPointIndicator = value;
                this.OnPropertyChanged("ShowFirstPointIndicator");
            }
        }

        public bool ShowHighPointIndicators
        {
            get
            {
                return this._showHighPointIndicators;
            }
            set
            {
                if (this._showHighPointIndicators == value)
                    return;

                this._showHighPointIndicators = value;
                this.OnPropertyChanged("ShowHighPointIndicators");
            }
        }

        public bool ShowLastPointIndicator
        {
            get
            {
                return this._showLastPointIndicator;
            }
            set
            {
                if (this._showLastPointIndicator == value)
                    return;

                this._showLastPointIndicator = value;
                this.OnPropertyChanged("ShowLastPointIndicator");
            }
        }

        public bool ShowLowPointIndicators
        {
            get
            {
                return this._showLowPointIndicators;
            }
            set
            {
                if (this._showLowPointIndicators == value)
                    return;

                this._showLowPointIndicators = value;
                this.OnPropertyChanged("ShowLowPointIndicators");
            }
        }

        public bool ShowMarkers
        {
            get
            {
                return this._showMarkers;
            }
            set
            {
                if (this._showMarkers == value)
                    return;

                this._showMarkers = value;
                this.OnPropertyChanged("ShowMarkers");
            }
        }

        public bool ShowNegativePointIndicators
        {
            get
            {
                return this._showNegativePointIndicators;
            }
            set
            {
                if (this._showNegativePointIndicators == value)
                    return;

                this._showNegativePointIndicators = value;
                this.OnPropertyChanged("ShowNegativePointIndicators");
            }
        }

        private IEnumerable<int> CreateData()
        {
            List<int> data = new List<int>();

            for (int i = 0; i < this.NumberOfItemsPerSparkline; i++)
            {
                data.Add(_r.Next(-60, 60));
            }

            return data;
        }
    }
}
