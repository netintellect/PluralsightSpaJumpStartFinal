using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Sparklines.Gallery
{
    public class ExampleViewModel : ViewModelBase
    {
        private IEnumerable<ExchangeDataViewModel> _data;
        Random r = new Random();

        public IEnumerable<ExchangeDataViewModel> Data
        {
            get
            {
                if (this._data == null)
                {
                    this._data = this.CreateData();
                }

                return this._data;
            }
        }

        private IEnumerable<ExchangeDataViewModel> CreateData()
        {
            ExchangeDataViewModel[] data = new ExchangeDataViewModel[2];
            data[0] = CreateForexData("EUR/USD");
            data[1] = CreateForexData("EUR/GBP");

            return data;
        }

        private IEnumerable<ExchangeData> CreateExchangeData(DateTime startDate, DateTime endDate)
        {
            List<ExchangeData> data = new List<ExchangeData>(12);

            for (DateTime date = startDate; date < endDate; date = date.AddMonths(1))
            {
                ExchangeData newData = new ExchangeData();
                newData.TimeStamp = date;
                newData.Value = -0.5d + r.NextDouble();
                data.Add(newData);
            }

            return data;
        }

        private ExchangeDataViewModel CreateForexData(string name)
        {
            DateTime now = DateTime.Now;

            ExchangeDataViewModel exchangeData = new ExchangeDataViewModel();
            exchangeData.StartDate = now.Subtract(TimeSpan.FromDays(365d));
            exchangeData.EndDate = now;
            exchangeData.Name = name;
            exchangeData.Data = CreateExchangeData(exchangeData.StartDate, exchangeData.EndDate);

            return exchangeData;
        }
    }
}
