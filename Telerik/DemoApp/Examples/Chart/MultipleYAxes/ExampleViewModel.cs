using System.Collections.Generic;
using Telerik.Windows.Controls;
using System.Windows.Media;
using System.Globalization;

namespace Telerik.Windows.Examples.Chart.MultipleYAxes
{
    public class ExampleViewModel : ViewModelBase
    {
        private List<ClimateData> _data;

        public ExampleViewModel()
        {
            List<ClimateData> data = new List<ClimateData>();

            string[] months = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;

            data.Add(new ClimateData(28, 5.3, -1, months[0]));
            data.Add(new ClimateData(31, 6.9, 1, months[1]));
            data.Add(new ClimateData(38, 6.2, 5, months[2]));
            data.Add(new ClimateData(51, 4.5, 10, months[3]));
            data.Add(new ClimateData(73, 4, 14, months[4]));
            data.Add(new ClimateData(75, 3.9, 17, months[5]));
            data.Add(new ClimateData(63, 3.9, 20, months[6]));
            data.Add(new ClimateData(51, 4, 20, months[7]));
            data.Add(new ClimateData(38, 4, 16, months[8]));
            data.Add(new ClimateData(35, 6.6, 11, months[9]));
            data.Add(new ClimateData(48, 5.1, 4, months[10]));
            data.Add(new ClimateData(40, 5.6, 1, months[11]));

            this._data = data;
        }

        public List<ClimateData> Data
        {
            get
            {
                return this._data;
            }
        }
    }
}
