using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.Gallery.ViewModel
{
    public class UserDataViewModel
    {
        private IList<IEnumerable<double>> _data;
        private int _itemsCount;
        private int _seriesCount;

        public IList<IEnumerable<double>> CollectionData
        {
            get
            {
                if (this._data == null)
                {
                    this._data = this.FillSampleChartData(this.SeriesCount, this.ItemsCount);
                }

                return this._data;
            }
        }

        public IEnumerable<double> Data
        {
            get
            {
                return this.CollectionData[0];
            }
        }

        public int ItemsCount
        {
            get
            {
                return _itemsCount;
            }
            set
            {
                _itemsCount = value;
            }
        }

        public int SeriesCount
        {
            get
            {
                return _seriesCount;
            }
            set
            {
                _seriesCount = value;
            }
        }

        protected virtual IList<IEnumerable<double>> FillSampleChartData(int seriesCount, int numbOfItems)
        {
            List<IEnumerable<double>> itemsSource = new List<IEnumerable<double>>();

            for (int i = 0; i < seriesCount; i++)
            {
                itemsSource.Add(SeriesExtensions.GetUserData(numbOfItems, i));
            }

            return itemsSource;
        }
    }
}

