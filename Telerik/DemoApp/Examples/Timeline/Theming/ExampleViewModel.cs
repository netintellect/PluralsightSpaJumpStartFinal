using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Timeline.Theming
{
    public class ExampleViewModel : ViewModelBase
    {
        private List<ExampleData> data;
        private DateTime startDate, endDate;

        public ExampleViewModel()
        {
            this.StartDate = new DateTime(2010, 1, 1);
            this.EndDate = new DateTime(2012, 2, 1);

            this.GenerateData();
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
                this.OnPropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
                this.OnPropertyChanged("EndDate");
            }
        }

        public List<ExampleData> Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                if (this.data == value)
                    return;

                this.data = value;
                this.OnPropertyChanged("Data");
            }
        }

        private void GenerateData()
        {
            Random r = new Random();
            var randomData = new List<ExampleData>();

            for (DateTime i = this.StartDate; i < this.EndDate; i = i.AddMonths(1))
            {
                randomData.Add(new ExampleData() { Date = i.AddDays(15), Details = i.ToString("{0:d}") });
                randomData.Add(new ExampleData() { Date = i, Duration = TimeSpan.FromDays(r.Next(50, 100)), Details = i.ToString("{0:d}") });
                randomData.Add(new ExampleData() { Date = i.AddDays(r.Next(5, 15)), Duration = TimeSpan.FromDays(r.Next(15, 50)), Details = i.ToString("{0:d}") });
                randomData.Add(new ExampleData() { Date = i.AddDays(r.Next(5, 15)), Duration = TimeSpan.FromDays(r.Next(5, 15)), Details = i.ToString("{0:d}") });
            }

            for (int i = 0; i < 15; i++)
            {
                randomData.Add(new ExampleData()
                {
                    Date = this.StartDate.AddMonths(r.Next(0, 25)).AddDays(15),
                    Details = i.ToString("{0:d}")
                });
            }

            for (int i = 0; i < 20; i++)
            {
                randomData.Add(new ExampleData()
                {
                    Date = this.StartDate.AddMonths(r.Next(0, 25)).AddDays(r.Next(0,15)),
                    Details = i.ToString("{0:d}")
                });
            }

            this.Data = randomData;
        }
    }
}
