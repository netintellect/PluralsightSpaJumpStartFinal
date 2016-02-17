using System;
using System.ComponentModel;

namespace Telerik.Windows.Examples.Sparklines.LiveData
{
    public class Call : INotifyPropertyChanged
    {
        private TimeSpan _duration;
        private TimeSpan _holdTime;
        private int _ticksDuration;
        private int _ticksHoldTime;
        private double _issueResolved;
        private DateTime _timeInterval;
        private int _abandonments;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public int Abandonments
        {
            get
            {
                return this._abandonments;
            }
            set
            {
                this._abandonments = value;
            }
        }

        public int TicksDuration
        {
            get
            {
                return this._ticksDuration;
            }
            set
            {
                this._ticksDuration = value;
                OnPropertyChanged("TicksDuration");
            }
        }

        public DateTime TimeInverval
        {
            get
            {
                return this._timeInterval;
            }
            set
            {
                this._timeInterval = value;
                OnPropertyChanged("TimeInverval");
            }
        }

        public int TicksHoldTime
        {
            get
            {
                return this._ticksHoldTime;
            }
            set
            {
                this._ticksHoldTime = value;
                OnPropertyChanged("TicksHoldTime");
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return this._duration;
            }
            set
            {
                this._duration = value;
                OnPropertyChanged("Duration");
            }
        }

        public TimeSpan HoldTime
        {
            get
            {
                return this._holdTime;
            }
            set
            {
                this._holdTime = value;
                OnPropertyChanged("HoldTime");
            }
        }

        public double IssueResolved
        {
            get
            {
                return this._issueResolved;
            }
            set
            {
                this._issueResolved = value;
                OnPropertyChanged("IssueResolved");
            }
        }

    }
}




