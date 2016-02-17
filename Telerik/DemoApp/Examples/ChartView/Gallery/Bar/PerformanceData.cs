using System.Collections.Generic;
using System.Windows.Controls;
using Telerik.Charting;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.Gallery.Bar
{
    public class PerformanceData
    {
        private string _quarter;
        private string _name;
        private double _performance;

        public PerformanceData(string name, string quarter, double performance)
        {
            this._name = name;
            this._quarter = quarter;
            this._performance = performance;
        }

        public string QuarterName
        {
            get
            {
                return this._quarter;
            }
        }

        public string RepresentativeName
        {
            get
            {
                return this._name;
            }
        }

        public double Performance
        {
            get
            {
                return this._performance;
            }
        }
    }
}
