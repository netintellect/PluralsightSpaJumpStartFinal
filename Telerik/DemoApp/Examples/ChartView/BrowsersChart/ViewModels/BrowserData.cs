using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.ChartView.BrowsersChart.ViewModels
{
    public class BrowserData
    {
        public string Name { get; set; }
        public IEnumerable<BrowserYearlySummary> Data { get; set; }
    }
}
