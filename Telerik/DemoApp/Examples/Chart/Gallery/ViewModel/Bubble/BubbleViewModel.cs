using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.Gallery.ViewModel
{
    public class BubbleViewModel
    {
        private List<List<UserDataPoint>> _data;

        public List<List<UserDataPoint>> Data
        {
            get
            {
                if (this._data == null)
                {
                    this._data = new List<List<UserDataPoint>>();
                    this._data.Add(SeriesExtensions.GetUserBubbleData());
                    this._data.Add(SeriesExtensions.GetUserBubbleMixedData());
                }

                return this._data;
            }
        }
    }
}
