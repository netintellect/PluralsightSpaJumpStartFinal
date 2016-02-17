using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using System.Collections;
using System.IO;
using Telerik.Windows.Examples.ChartView.RadarAnnotations.Models;
using System.Globalization;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.ChartView.RadarAnnotations.ViewModels
{
    public class RadarAnnotationsViewModel : DataSourceViewModelBase
    {
        private List<RadarSeriesData> _data;

        public List<RadarSeriesData> Data
        {
            get { return this._data; }
            set
            {
                if (this._data != value)
                {
                    this._data = value;
                    this.OnPropertyChanged(() => this.Data);
                }
            }
        }

        public ObservableCollection<AnnotationsData> SolsticesAndEquinoxesData
        {
            get
            {
                return new ObservableCollection<AnnotationsData>()
                {
                    new SolsticesAndEquinoxesData(){ Event="Northward Equinox", Month = "March" , DateOfOccurance= new DateTime(2012,3,20)},
                    new SolsticesAndEquinoxesData(){ Event="Nortern Solstice", Month = "June" , DateOfOccurance= new DateTime(2012,6,20)},
                    new SolsticesAndEquinoxesData(){ Event="Southward Equinox", Month = "September" , DateOfOccurance= new DateTime(2012,9,22)},
                    new SolsticesAndEquinoxesData(){ Event="Southern Solstice", Month = "December" , DateOfOccurance= new DateTime(2012,12,21)}
                };
            }
        }

        public ObservableCollection<AnnotationsData> SeasonsData
        {
            get
            {
                return new ObservableCollection<AnnotationsData>()
                {
                    new SeasonsData(){ Event="Spring", StartMonth="March", EndMonth="June"},
                    new SeasonsData(){ Event="Summer", StartMonth="June", EndMonth="September"},
                    new SeasonsData(){ Event="Autumn", StartMonth="September", EndMonth="December"},
                    new SeasonsData(){ Event="Winter", StartMonth="December", EndMonth="March"}
                };
            }
        }

        public RadarAnnotationsViewModel()
        {
            this.GetData("RadarAnnotations.csv");
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<RadarSeriesData> chartData = new List<RadarSeriesData>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                RadarSeriesData dataItem = new RadarSeriesData();
                dataItem.Month = data[0].ToString();
                dataItem.SixtySouthHoursLight = double.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.ThirtySouthHoursLight = double.Parse(data[2], CultureInfo.InvariantCulture);
                dataItem.ThirtyNorthHoursLight = double.Parse(data[3], CultureInfo.InvariantCulture);
                dataItem.SixtyNorthHoursLight = double.Parse(data[4], CultureInfo.InvariantCulture);

                chartData.Add(dataItem);
            }

            return chartData;
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<RadarSeriesData>;
        }
    }
}
