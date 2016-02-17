using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.Gauge.Weather
{
    public class Data
    {
        private string _city;
        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                this._city = value;
            }
        }

        private string _status;
        public string Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        private int _temperature;
        public int Temperature
        {
            get
            {
                return this._temperature;
            }
            set
            {
                this._temperature = value;
            }
        } 
        
        private int _temperatureLike;
        public int TemperatureLike
        {
            get
            {
                return this._temperatureLike;
            }
            set
            {
                this._temperatureLike = value;
            }
        }

        private int _minDayTemperature;
        public int MinDayTemperature
        {
            get
            {
                return this._minDayTemperature;
            }
            set
            {
                this._minDayTemperature = value;
            }
        }

        private int _maxDayTemperature;
        public int MaxDayTemperature
        {
            get
            {
                return this._maxDayTemperature;
            }
            set
            {
                this._maxDayTemperature = value;
            }
        }

        private double _rainfall;
        public double RainFall
        {
            get
            {
                return this._rainfall;
            }
            set
            {
                this._rainfall = value;
            }
        }

        private int _humidity;
        public int Humidity
        {
            get
            {
                return this._humidity;
            }
            set
            {
                this._humidity = value;
            }
        }

        private int _pressure;
        public int Pressure
        {
            get
            {
                return this._pressure;
            }
            set
            {
                this._pressure = value;
            }
        }

        private double _windSpeed;
        public double WindSpeed
        {
            get
            {
                return this._windSpeed;
            }
            set
            {
                this._windSpeed = value;
            }
        }

        private string _time;
        public string Time
        {
            get
            {
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }

        private string _date;
        public string Date
        {
            get
            {
                return this._date;
            }
            set
            {
                this._date = value;
            }
        }

        private string _day;
        public string Day
        {
            get
            {
                return this._day;
            }
            set
            {
                this._day = value;
            }
        }
         
        public int MinTemperature
        {
            get
            {
                return Math.Min(MinDayTemperature - 5, 0);
            }
        }

        public int MaxTemperature
        {
            get
            {
                return Math.Max(MaxDayTemperature + 5, 0);
            }
        }

        public double MiddleTemperature
        {
            get
            {
                if (MinTemperature>0)
                    return (double)(MaxTemperature - MinTemperature) / 2;
                else
                    return (double)(MaxTemperature + MinTemperature) / 2;
            }
        }
         
        public double MinRainFall
        {
            get
            {
                return Math.Min(0, RainFall);
            }
        }
        public double MaxRainFall
        {
            get
            {
                if (RainFall < 2)
                    return 2;
                else if (RainFall >= 2 && RainFall < 4)
                    return 4; 
                else 
                    return 1400; 
            }
        }

        public double MiddleRainFall
        {
            get
            {
                return (double)(MaxRainFall - MinRainFall) / 2; 
            }
        }

        public Data(string city, string status, int temperature, int temperatureLike, int minDayTemperature, int maxDayTemperature, double rainfall, int humidity, int pressure, double windSpeed, string time, string date, string day)
        {
            _city = city;
            _status = status;
            _temperature = temperature;
            _temperatureLike = temperatureLike;
            _minDayTemperature = minDayTemperature;
            _maxDayTemperature = maxDayTemperature;
            _rainfall = rainfall;
            _humidity = humidity;
            _pressure = pressure;
            _windSpeed = windSpeed;
            _time = time;
            _date = date;
            _day = day; 
        }
    }
}
