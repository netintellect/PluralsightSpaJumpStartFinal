using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.BulletGraph.Configurator
{
    public class ExampleViewModel : ViewModelBase
    {
        private double _comparativeMeasure;
        private double _featuredMeasures;
        private double _projectedMeasure;
        private double _range1Value;
        private double _range2Value;
        private ICommand _resetCommand;

        public ExampleViewModel()
        {
            Reset(null);
        }

        public double ComparativeMeasure
        {
            get
            {
                return _comparativeMeasure;
            }
            set
            {
                if (_comparativeMeasure == value)
                    return;

                _comparativeMeasure = value;
                OnPropertyChanged("ComparativeMeasure");
            }
        }

        public double FeaturedMeasure
        {
            get
            {
                return _featuredMeasures;
            }
            set
            {
                if (_featuredMeasures == value)
                    return;

                _featuredMeasures = value;
                OnPropertyChanged("FeaturedMeasure");
            }
        }

        public double ProjectedMeasure
        {
            get
            {
                return _projectedMeasure;
            }
            set
            {
                if (_projectedMeasure == value)
                    return;

                _projectedMeasure = value;
                OnPropertyChanged("ProjectedMeasure");
            }
        }

        public double Range1Value
        {
            get
            {
                return _range1Value;
            }
            set
            {
                if (_range1Value == value)
                    return;

                _range1Value = value;
                OnPropertyChanged("Range1Value");
            }
        }

        public double Range2Value
        {
            get
            {
                return _range2Value;
            }
            set
            {
                if (_range2Value == value)
                    return;

                _range2Value = value;
                OnPropertyChanged("Range2Value");
            }
        }

        public ICommand ResetCommand
        {
            get
            {
                if (this._resetCommand == null)
                {
                    this._resetCommand = new DelegateCommand(this.Reset);
                }

                return this._resetCommand;
            }
        }

        private void Reset(object parameter)
        {
            this.FeaturedMeasure = 60d;
            this.ComparativeMeasure = 65d;
            this.ProjectedMeasure = 75d;
            this.Range1Value = 50d;
            this.Range2Value = 70d;
        }
    }
}
