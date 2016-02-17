using System;

namespace Telerik.Windows.Examples.ChartView.Annotations
{
    public class CompanyEvent
    {
        private string _eventDescription;
        private DateTime _timeOfEvent;
        private DateTime _eventEnd;
        private double _value;

        public CompanyEvent()
        {
        }

        public CompanyEvent(DateTime time, string description)
        {
            this._timeOfEvent = time;
            this._eventDescription = description;
        }

        public CompanyEvent(DateTime eventStart, DateTime eventEnd, string eventDescription)
        {
            this._timeOfEvent = eventStart;
            this._eventEnd = eventEnd;
            this._eventDescription = eventDescription;
        }

        public string EventDescription
        {
            get
            {
                return _eventDescription;
            }
            set 
            { 
                _eventDescription = value; 
            }
        }

        public DateTime EventStart
        {
            get
            {
                return _timeOfEvent;
            }
            set 
            {
                _timeOfEvent = value;
            }
        }

        public DateTime EventEnd
        {
            get
            {
                return this._eventEnd;
            }
            set
            {
                this._eventEnd = value;
            }
        }

        public double Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
}
