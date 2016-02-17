using System;

namespace Telerik.Windows.Examples.HeatMap.CellLabels
{
    public class PlotInfo
    {
        public string District { get; set; }
        public string Month { get; set; }
        public double CallsNumber { get; set; }

        public PlotInfo(string district, string month, double calls)
        {
            this.District = district;
            this.Month = month;
            this.CallsNumber = calls;
        }
    }
}