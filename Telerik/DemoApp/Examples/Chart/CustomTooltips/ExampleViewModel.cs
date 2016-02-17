using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.CustomTooltips
{
    public class ExampleViewModel : ViewModelBase
    {
        private IEnumerable<Data> _marketCapitalizationData;
        private ObservableCollection<IEnumerable<Data>> _totalRevenueData;
        private List<long[]> _totalRevenue;
        private string[] _companies = new string[] { "Apple", "Microsoft", "IBM", "Google", "Cisco", "Amazon", "HP" };
        private string[] _quarters = new string[] { "Q1, 2010", "Q2, 2010", "Q3, 2010", "Q4, 2010", "Q1, 2011" };
        private long[] _marketCapitalization = new long[] { 318310000000, 206010000000, 203130000000, 169380000000, 90090000000, 86970000000, 79260000000 };

        public ExampleViewModel()
        {
            this._totalRevenue = this.GenerateTotalRevenueValues();
        }

        public IEnumerable<Data> MarketCapitalizationData
        {
            get
            {
                if (this._marketCapitalizationData == null)
                {
                    List<Data> data = new List<Data>();

                    for (int i = 0; i < _companies.Length; i++)
                    {
                        data.Add(new Data(_marketCapitalization[i], _companies[i]));
                    }

                    this._marketCapitalizationData = data;
                }

                return this._marketCapitalizationData;
            }
        }

        public ObservableCollection<IEnumerable<Data>> TotalRevenueData 
        {
            get
            {
                if (this._totalRevenueData == null)
                {
                    this._totalRevenueData = new ObservableCollection<IEnumerable<Data>>();

                    for (int i = 0; i < _totalRevenue.Count; i++)
                    {
                        long[] volumes = _totalRevenue[i];

                        List<Data> data = new List<Data>();

                        for (int j = 0; j < volumes.Length; j++)
                        {
                            data.Add(new Data(volumes[j], _quarters[j]));
                        }

                        _totalRevenueData.Add(data);
                    }
                }

                return this._totalRevenueData;
            }
        }

        public Brush ApplicationThemeAwareForeground
        {
            get
            {
                if (StyleManager.ApplicationTheme is Expression_DarkTheme)
                    return new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));

                return new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            }
        }

        private List<long[]> GenerateTotalRevenueValues()
        {
            List<long[]> data = new List<long[]>();

            data.Add(new long[] { 24667000, 26741000, 20343000, 15700000, 13499000 });
            data.Add(new long[] { 16428000, 19953000, 16195000, 16039000, 14503000 });
            data.Add(new long[] { 24607000, 29018000, 24271000, 23724000, 22857000 });
            data.Add(new long[] { 8575000, 8440000, 7286000, 6820000, 6775000 });
            data.Add(new long[] { 10866000, 10407000, 10750000, 10836000, 10368000 });
            data.Add(new long[] { 9857000, 12948000, 7560000, 6566000, 7131000 });
            data.Add(new long[] { 31632000, 32302000, 33278000, 30729000, 30849000 });

            return data;
        }
    }
}