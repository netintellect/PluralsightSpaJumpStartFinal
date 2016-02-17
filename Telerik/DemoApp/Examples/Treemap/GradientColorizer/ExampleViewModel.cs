
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Globalization;
namespace Telerik.Windows.Examples.Treemap.GradientColorizer
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private List<GdpInfo> data;

        public List<GdpInfo> Data
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
            this.GetData("GDP.csv");
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<GdpInfo>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<GdpInfo> treemapData = new List<GdpInfo>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                GdpInfo dataItem = new GdpInfo();

                dataItem.Country = data[0];
                dataItem.Gdp = double.Parse(data[1], CultureInfo.InvariantCulture);

                treemapData.Add(dataItem);
            }

            return treemapData;
        }
    }
}
