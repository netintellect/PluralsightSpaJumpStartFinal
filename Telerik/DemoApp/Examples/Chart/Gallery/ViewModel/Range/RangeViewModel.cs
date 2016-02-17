using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.Gallery.ViewModel
{
    public class RangeViewModel
    {
        private List<UserDataPoint> _data;

        public List<UserDataPoint> Data
        {
            get
            {
                if (this._data == null)
                {
                    this._data = SeriesExtensions.GetUserRangeData(12);
                }

                return this._data;
            }
        }
    }
}
