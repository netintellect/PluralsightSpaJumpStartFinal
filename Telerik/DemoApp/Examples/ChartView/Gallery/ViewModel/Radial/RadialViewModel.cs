using System.Collections.Generic;

namespace Telerik.Windows.Examples.ChartView
{
    public class RadialViewModel
    {
        private IEnumerable<double> _data;

        public IEnumerable<double> Data
        {
            get
            {
                if (this._data == null)
                {
                    this._data = ExampleData.GetUserRadialData();
                }

                return this._data;
            }
        }
    }
}
