using System.Collections.Generic;

namespace Telerik.Windows.Examples.ChartView
{
    public class FinancialViewModel
    {
        private IEnumerable<UserDataPoint> _data;

        public IEnumerable<UserDataPoint> Data
        {
            get
            {
                if (this._data == null)
                {
                    this._data = ExampleData.GetUserFinancialData(20);
                }

                return this._data;
            }
        }
    }
}
