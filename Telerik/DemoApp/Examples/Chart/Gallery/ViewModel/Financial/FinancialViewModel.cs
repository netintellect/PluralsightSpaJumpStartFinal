using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.Gallery.ViewModel
{
    public class FinancialViewModel
    {
        private List<UserDataPoint> _data;

        public List<UserDataPoint> Data
        {
            get
            {
                if (this._data == null)
                {
                    this._data = SeriesExtensions.GetUserFinancialData(20);
                }

                return this._data;
            }
        }
    }
}
