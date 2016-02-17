using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.Gallery.ViewModel
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
                    this._data = SeriesExtensions.GetUserRadialData();
                }

                return this._data;
            }
        }
    }
}
