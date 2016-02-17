using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Telerik.Windows.Controls;
using System;

namespace Telerik.Windows.Examples.Gauge.Weather
{
    public class ExampleViewModel : ViewModelBase
    {
        private string[] cityName = new string[] { "manila, philippines", "verkhoyansk, russia", "nairobi, kenya", "cherrapunji, india", "kuala lumpur, malaysia"};
        private string[] weatherStatus = new string[] { "SUNNY" , "SNOWY", "PARTLY CLOUDY", "RAINY", "THUNDERSTORM"};
        private int[] temperature = new int[] { 30, -21, 24, 29, 31 };
        private int[] temperatureFeelsLike = new int[] { 31, -22, 26, 30, 34 };
        private int[] minTemperature = new int[] { 25, -24, 17, 25, 25 };
        private int[] maxTemperature = new int[] { 32, -19, 26, 31, 33 };
        private double[] rainfall = new double[] { 0.1, 0.3, 0.1, 1352, 2.3 };
        private int[] humidity = new int[] { 75, 79, 53, 79, 75 };
        private int[] pressure = new int[] { 1011, 1021, 1019, 1000, 1009 };
        private double[] windSpeed = new double[] { 3.1, 8.7, 5.7, 2.6, 3.1 };  
        private DateTime[] allTimes = new DateTime[] {DateTime.UtcNow.AddHours(8), DateTime.UtcNow.AddHours(11), DateTime.UtcNow.AddHours(3), DateTime.UtcNow.AddHours(5).AddMinutes(30),DateTime.UtcNow.AddHours(8)};

        List<Data> _datailedInfoList;

        public List<Data> DetailedInfoList
        {
            get
            {
                return _datailedInfoList;
            }
            set
            {
                if (this._datailedInfoList != value)
                {
                    this._datailedInfoList = value;
                    this.OnPropertyChanged("DetailedInfoList");
                }
            }
        }

        private Data _selectedData;
        public Data SelectedData 
        {
            get
            {
                return _selectedData;
            }

            set
            {
                if (_selectedData != value)
                {
                    _selectedData = value;
                    OnPropertyChanged("SelectedData");
                }
            }
        }  
        
        private List<Data> GenerateData() 
        { 
            List<Data> source = new List<Data>();

            for (int i = 0; i < cityName.Length; i++)
            {
                source.Add(new Data(cityName[i],
                                    weatherStatus[i], 
                                    temperature[i], 
                                    temperatureFeelsLike[i], 
                                    minTemperature[i], 
                                    maxTemperature[i], 
                                    rainfall[i], 
                                    humidity[i],
                                    pressure[i], 
                                    windSpeed[i],
                                    allTimes[i].ToString("H:mm:ss"),
                                    allTimes[i].ToString("MMM dd, yyyy").ToUpper(),
                                    allTimes[i].DayOfWeek.ToString().ToUpper()));
            }
            return source;
        }

        public ExampleViewModel()
        {
            this.DetailedInfoList = GenerateData();
        }

        public void NextData()
        {
            if (SelectedData == null || DetailedInfoList.IndexOf(SelectedData) == DetailedInfoList.Count - 1)
                SelectedData = DetailedInfoList[0];
            else
                SelectedData = DetailedInfoList[DetailedInfoList.IndexOf(SelectedData) + 1];
        }
    }
}
