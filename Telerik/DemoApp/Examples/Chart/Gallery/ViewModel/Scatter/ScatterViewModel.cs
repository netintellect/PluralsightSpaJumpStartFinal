using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.Gallery.ViewModel
{
    public class ScatterViewModel
    {
        private List<List<UserDataPoint>> _data;

        public List<List<UserDataPoint>> Data
        {
            get
            {
                if (this._data == null)
                {
                    this._data = SeriesExtensions.GetUserScatterData();
                }

                return this._data;
            }
        }
    }
}
