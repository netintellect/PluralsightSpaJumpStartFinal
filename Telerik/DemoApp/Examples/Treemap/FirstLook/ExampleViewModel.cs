using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Globalization;
using System.Linq;

namespace Telerik.Windows.Examples.Treemap.FirstLook
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private List<MovieInfo> data;

        public List<MovieInfo> Data
        {
            get
            {
                return data;
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
            this.GetData("Movies_trimmed.csv");
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = (data as List<MovieInfo>).ToList();
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<MovieInfo> treemapData = new List<MovieInfo>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                MovieInfo dataItem = new MovieInfo();

                dataItem.Rank = int.Parse(data[0], CultureInfo.InvariantCulture);
                dataItem.Name = data[1];
                dataItem.ReleaseDate = DateTime.Parse(data[2], CultureInfo.InvariantCulture);
                dataItem.Distributor = data[3];
                dataItem.Genre = data[4];
                dataItem.TicketsSold = long.Parse(data[5], CultureInfo.InvariantCulture);
                dataItem.GrossSales = long.Parse(data[6], CultureInfo.InvariantCulture);
                dataItem.ImageName = data[7];

                treemapData.Add(dataItem);
            }

            return treemapData;
        }
    }
}
