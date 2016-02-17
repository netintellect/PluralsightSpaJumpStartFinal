using System;

namespace Telerik.Windows.Examples.TimeBar.SmallIntervals
{
    public class SpeedData
    {
        private DateTime _timeStamp;
        private double _speeed;

        public SpeedData(DateTime timeStamp, double speed)
        {
            this._timeStamp = timeStamp;
            this._speeed = speed;
        }

        public DateTime TimeStamp
        {
            get
            {
                return this._timeStamp;
            }
            set
            {
                this._timeStamp = value;
            }
        }

        public double Speed
        {
            get
            {
                return this._speeed;
            }
            private set
            {
                this._speeed = value;
            }
        }
    }
}
