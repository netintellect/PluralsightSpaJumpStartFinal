using System;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.Chart.EmptyValues
{
    public class ExampleViewModel
    {
        DateTime baseDate = DateTime.Today.AddDays(-15);
        public const int min = 0;
        public const int max = 79;
        Random r = new Random();

        private ObservableCollection<MyDateObject> _chartData;
        public ObservableCollection<MyDateObject> ChartData
        {
            get
            {
                return this._chartData;
            }
            set
            {
                this._chartData = value;
            }
        }

        public ExampleViewModel()
        {
            this.ChartData = new ObservableCollection<MyDateObject>();
            for (int i = 0; i < 15; i++)
            {
                ChartData.Add(new MyDateObject(r.Next(min, max), r.Next(min, max), r.Next(min, max), baseDate.AddDays(i)));
                if ((ChartData[i].Date.DayOfWeek == DayOfWeek.Saturday) || (ChartData[i].Date.DayOfWeek == DayOfWeek.Sunday))
                {
                    ChartData[i].Value1 = null;
                    ChartData[i].Value2 = null;
                    ChartData[i].Value3 = null;
                }
            }
        }
    }
}
