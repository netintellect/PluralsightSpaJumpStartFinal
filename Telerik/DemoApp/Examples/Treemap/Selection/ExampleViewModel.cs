
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Globalization;
namespace Telerik.Windows.Examples.Treemap.Selection
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private List<OilProducingInfo> data;

        public List<OilProducingInfo> Data
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
            this.GetData("OilProducingCountries.csv");
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<OilProducingInfo>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<OilProducingInfo> treemapData = new List<OilProducingInfo>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                OilProducingInfo dataItem = new OilProducingInfo();

                dataItem.Country = data[0];
                dataItem.Oil = double.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.Text = data[2];
                dataItem.ImageName = data[3];

                treemapData.Add(dataItem);
            }

            return treemapData;
        }
    }
}
