using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.DataBar.Theming
{
    public class StoreInfo
    {
        public StoreInfo(string name, string areaName, double q1Revenue, double q2Revenue, double q3Revenue, double q4Revenue)
        {
            this.Name = name;
            this.AreaName = areaName;
            this.RevenueByQuarters = new List<double>() { q1Revenue, q2Revenue, q3Revenue, q4Revenue, };
        }

        public string Name { get; set; }
        public string AreaName { get; set; }

        public IEnumerable<double> RevenueByQuarters { get; private set; }
        public double TotalRevenue 
        {
            get { return this.RevenueByQuarters.Sum(); }
        }
    }
}
