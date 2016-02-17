using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.MarkedZones
{
    public class ExampleViewModel : ViewModelBase
    {
        private List<TestData> data;

        public List<TestData> Data
        {
            get
            {
                return this.data;
            }
            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }

        public ExampleViewModel()
        {
            DateTime startTime = new DateTime(2011, 1, 1, 0, 0, 0);
            this.Data = GenerateData(startTime);
        }

        private static List<TestData> GenerateData(DateTime startTime)
        {
            List<TestData> data = new List<TestData>();

            Random rand = new Random();

            data.Add(new TestData(startTime, 800));
            for (int i = 1; i < 101; i++)
            {
                if ((i < 20) || (i > 30 && i < 50) || i > 70)
                    data.Add(new TestData(startTime.AddSeconds(i * 2), rand.Next(6400, 8800)));
                else
                    data.Add(new TestData(startTime.AddSeconds(i * 2), rand.Next(4000, 6800)));
            }

            return data;
        }

        public class TestData
        {
            private DateTime _time;
            private int _rpm;

            public TestData(DateTime time, int rpm)
            {
                this.Time = time;
                this.RPM = rpm;
            }
            public DateTime Time
            {
                get
                {
                    return _time;
                }
                set
                {
                    _time = value;
                }
            }
            public int RPM
            {
                get
                {
                    return _rpm;
                }
                set
                {
                    _rpm = value;
                }
            }
        }
    }
}
