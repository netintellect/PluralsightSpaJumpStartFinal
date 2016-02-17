using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.Sparklines.LargeData
{
    public class LargeDataViewModel : ViewModelBase
    {
        private List<TemperatureData> _reports;
        private QueryableCollectionView _filteredReports;
        private SelectionRange<DateTime> _selection;

        public LargeDataViewModel()
        {
            this.GetData("temperatures.csv");
            this.Selection = new SelectionRange<DateTime>(new DateTime(1998, 4, 1), new DateTime(1998, 6, 1));
        }

        public Color ForegroundColor
        {
            get
            {
                return Color.FromArgb(255, 72, 72, 72);
            }
        }

        public Color HighlightColor
        {
            get
            {
                return Color.FromArgb(255, 0, 0, 0);
            }
        }

        public SelectionRange<DateTime> Selection
        {
            get
            {
                return this._selection;
            }
            set
            {
                if (this._selection == value)
                    return;

                this._selection = value;
                this.OnPropertyChanged("Selection");
                this.UpdateChartData(this._selection);
            }
        }

        public List<TemperatureData> TemperatureReports
        {
            get
            {           
                return this._reports;
            }
            private set
            {
                if (this._reports == value)
                    return;

                this._reports = value;
                this.OnPropertyChanged("TemperatureReports");
            }
        }

        public QueryableCollectionView FilteredTemperatureReports
        {
            get
            {
                return this._filteredReports;
            }
            private set
            {
                if (this._filteredReports == value)
                    return;

                this._filteredReports = value;
                this.OnPropertyChanged("FilteredTemperatureReports");
            }
        }

        protected void GetData(string fileName)
        {
#if WPF
            Uri uri = new Uri(string.Format("/Sparklines;component/DataSources/{0}", fileName), UriKind.RelativeOrAbsolute);
            System.Windows.Resources.StreamResourceInfo streamInfo = System.Windows.Application.GetResourceStream(uri);
            using (StreamReader fileReader = new StreamReader(streamInfo.Stream))
            {
                GetDataCompleted(this.ParseData(fileReader));
            }
#else
            Uri dataURI = new Uri(Telerik.Windows.Examples.Sparklines.URIHelper.CurrentApplicationURL, string.Format("DataSources/{0}", fileName));
            System.Net.WebClient dataRetriever = new System.Net.WebClient();
            dataRetriever.DownloadStringCompleted += DownloadStringCompleted;
            dataRetriever.DownloadStringAsync(dataURI);
#endif
        }

        private void DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            StringReader dataReader = new StringReader(e.Result);
            GetDataCompleted(this.ParseData(dataReader));
        }

        protected void GetDataCompleted(IEnumerable data)
        {
            this.TemperatureReports = data as List<TemperatureData>;

            QueryableCollectionView qcv = new QueryableCollectionView(data);
            this.UpdateChartData(qcv, this.Selection);
            this.FilteredTemperatureReports = qcv;
        }

        public void UpdateChartData(SelectionRange<DateTime> selection)
        {
            if (this.FilteredTemperatureReports != null)
            {
                this.UpdateChartData(this.FilteredTemperatureReports, selection);
            }
        }

        private void UpdateChartData(QueryableCollectionView qcv, SelectionRange<DateTime> selection)
        {
            qcv.FilterDescriptors.Clear();

            qcv.FilterDescriptors.Add(new FilterDescriptor("TimeStamp", FilterOperator.IsGreaterThanOrEqualTo, selection.Start));
            qcv.FilterDescriptors.Add(new FilterDescriptor("TimeStamp", FilterOperator.IsLessThanOrEqualTo, selection.End));
        }

        protected IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<TemperatureData> chartData = new List<TemperatureData>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                TemperatureData dataItem = new TemperatureData();
                DateTime result = DateTime.ParseExact(data[0], "d/MM/yyyy", CultureInfo.InvariantCulture);
                dataItem.TimeStamp = result;
                dataItem.MaxTemperature = double.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.MeanTemperature = double.Parse(data[2], CultureInfo.InvariantCulture);
                dataItem.MinTemperature = double.Parse(data[3], CultureInfo.InvariantCulture);

                chartData.Add(dataItem);
            }

            return chartData.Where(data => data.TimeStamp.Year >= 1990).ToList();
        }
    }
}
