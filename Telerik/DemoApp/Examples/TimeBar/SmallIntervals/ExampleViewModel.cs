using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using Telerik.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace Telerik.Windows.Examples.TimeBar.SmallIntervals
{
    public class ExampleViewModel : FrameworkElement, INotifyPropertyChanged
    {
        Random r = new Random();
        private DateTime _startTime, _endTime;

        private List<SpeedData> _speedForTrack;
        private double _averageSpeedForSelection;
        private double _maximumSpeedForSelection;
        private double _minimumSpeedForSelection;

        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly DependencyProperty SelectionStartProperty = DependencyProperty.Register("SelectionStart",
            typeof(DateTime),
            typeof(ExampleViewModel),
            new PropertyMetadata(DateTime.MinValue, SelectionStartPropertyChanged));

        public static readonly DependencyProperty SelectionEndProperty = DependencyProperty.Register("SelectionEnd",
            typeof(DateTime),
            typeof(ExampleViewModel),
            new PropertyMetadata(DateTime.MinValue, SelectionEndPropertyChanged));

        [TypeConverter(typeof(DateTimeTypeConverter))]
        public DateTime StartTime
        {
            get
            {
                return this._startTime;
            }
            set
            {
                this._startTime = value;
            }
        }

        [TypeConverter(typeof(DateTimeTypeConverter))]
        public DateTime EndTime
        {
            get
            {
                return this._endTime;
            }
            set
            {
                this._endTime = value;
            }
        }

        public DateTime SelectionStart
        {
            get
            {
                return (DateTime)this.GetValue(SelectionStartProperty);
            }
            set
            {
                this.SetValue(SelectionStartProperty, value);
            }
        }

        public DateTime SelectionEnd
        {
            get
            {
                return (DateTime)this.GetValue(SelectionEndProperty);
            }
            set
            {
                this.SetValue(SelectionEndProperty, value);
            }
        }

        public List<SpeedData> SpeedForTrack
        {
            get
            {
                if (this._speedForTrack == null)
                {
                    List<SpeedData> speed = new List<SpeedData>();
                    for (DateTime time = this._startTime; time < this._endTime; time = time.AddSeconds(1))
                    {
                        speed.Add(new SpeedData(time, r.Next(50, 300)));
                    }

                    this._speedForTrack = speed;
                }

                return this._speedForTrack;
            }
        }

        public double AverageSpeedForSelection
        {
            get
            {
                return this._averageSpeedForSelection;
            }
            set
            {
                this._averageSpeedForSelection = value;
                OnPropertyChanged("AverageSpeedForSelection");
            }
        }

        public double MaximumSpeedForSelection
        {
            get
            {
                return this._maximumSpeedForSelection;
            }
            set
            {
                this._maximumSpeedForSelection = value;
                OnPropertyChanged("MaximumSpeedForSelection");
            }
        }

        public double MinimumSpeedForSelection
        {
            get
            {
                return this._minimumSpeedForSelection;
            }
            set
            {
                this._minimumSpeedForSelection = value;
                OnPropertyChanged("MinimumSpeedForSelection");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateSpeedForCurrentInterval()
        {
            IEnumerable<SpeedData> recordedSpeed = this.SpeedForTrack.Where(speed => SelectionStart <= speed.TimeStamp && speed.TimeStamp <= SelectionEnd);

            if (recordedSpeed.Count() > 0)
            {
                this.AverageSpeedForSelection = Math.Round(recordedSpeed.Average(speed => speed.Speed), 2);
                this.MaximumSpeedForSelection = recordedSpeed.Max(speed => speed.Speed);
                this.MinimumSpeedForSelection = recordedSpeed.Min(speed => speed.Speed);
            }
        }

        private static void SelectionStartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ExampleViewModel).UpdateSpeedForCurrentInterval();
        }

        private static void SelectionEndPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ExampleViewModel).UpdateSpeedForCurrentInterval();
        }
    }
}
