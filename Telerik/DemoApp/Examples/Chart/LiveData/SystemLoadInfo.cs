using System;

namespace Telerik.Windows.Examples.Chart.LiveData
{
    public class SystemLoadInfo
    {
        private DateTime _time;
        private double _cpuLoad;
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
        public double CPULoad
        {
            get
            {
                return this._cpuLoad;
            }
            set
            {
                this._cpuLoad = value;
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
