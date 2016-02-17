using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Sparklines.FirstLook
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            IEnumerable<ExchangeDataViewModel> data = CreateData();

            this.lineGridView.ItemsSource = data;
            this.areaGridView.ItemsSource = data;
            this.columnGridView.ItemsSource = data;
            this.winLossGridView.ItemsSource = data;

            if (StyleManager.ApplicationTheme.GetType() == typeof(Expression_DarkTheme))
                this.exampleTitle.Foreground = new SolidColorBrush(Color.FromArgb(255, 204, 204, 204)); 
        }

        private IEnumerable<ExchangeDataViewModel> CreateData()
        {
            ExchangeDataViewModel[] data = new ExchangeDataViewModel[]
            {
                CreateForexData("EUR/USD"),
                CreateForexData("EUR/GBP")
            };

            return data;
        }

        private ExchangeDataViewModel CreateForexData(string name)
        {
            DateTime now = DateTime.Now;

            ExchangeDataViewModel exchangeData = new ExchangeDataViewModel()
            {
                StartDate = now.Subtract(TimeSpan.FromDays(365d)),
                EndDate = now,
                Name = name
            };
            exchangeData.Data = CreateExchangeData(exchangeData.StartDate, exchangeData.EndDate);

            return exchangeData;
        }

        Random r = new Random();

        private IEnumerable<ExchangeData> CreateExchangeData(DateTime startDate, DateTime endDate)
        {
            List<ExchangeData> data = new List<ExchangeData>(12);

            for (DateTime date = startDate; date < endDate; date = date.AddMonths(1))
            {
                data.Add(new ExchangeData()
                {
                    TimeStamp = date,
                    Value = -0.5d + r.NextDouble()
                });
            }

            return data;
        }
    }
}
