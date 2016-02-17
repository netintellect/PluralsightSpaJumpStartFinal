using System;

namespace Telerik.Windows.Examples.Chart.CustomGridLines
{
    public class SystemLoadInfo
    {
        private DateTime _time;
        private double _memUsage;

        public DateTime Time
        {
            get
            {
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }
        public double MemUsage
        {
            get
            {
                return this._memUsage;
            }
            set
            {
                this._memUsage = value;
            }
        }
    }
}
