using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.ChartView
{
    public class ScatterViewModel
    {
        private IEnumerable<IEnumerable<UserDataPoint>> collection;

        public IEnumerable<UserDataPoint> Collection1
        {
            get
            {
                if (this.collection == null)
                {
                    this.collection = ExampleData.GetUserScatterData();
                }
                return this.collection.ElementAt(0);
            }
        }

        public IEnumerable<UserDataPoint> Collection2
        {
            get
            {
                if (this.collection == null)
                {
                    this.collection = ExampleData.GetUserScatterData();
                }
                return this.collection.ElementAt(1);
            }
        }

        public IEnumerable<UserDataPoint> Collection3
        {
            get
            {
                if (this.collection == null)
                {
                    this.collection = ExampleData.GetUserScatterData();
                }
                return this.collection.ElementAt(2);
            }
        }
    }
}
