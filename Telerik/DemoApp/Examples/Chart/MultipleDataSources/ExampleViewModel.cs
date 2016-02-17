using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Chart.MultipleDataSources
{
    public class ExampleViewModel : ViewModelBase
    {
        public IEnumerable<PopulationData> DataSource1
        {
            get
            {
                List<PopulationData> data = new List<PopulationData>();

                data.Add(new PopulationData(82500000, "Germany"));
                data.Add(new PopulationData(43400000, "Spain"));
                data.Add(new PopulationData(60500000, "France"));
                data.Add(new PopulationData(58100000, "Italy"));

                return data;
            }
        }

        public IEnumerable<VehicleData> DataSource2
        {
            get
            {
                List<VehicleData> data = new List<VehicleData>();

                data.Add(new VehicleData(54500000, "Germany"));
                data.Add(new VehicleData(27600000, "Spain"));
                data.Add(new VehicleData(37100000, "France"));
                data.Add(new VehicleData(43100000, "Italy"));

                return data;
            }
        }

        public IEnumerable<RoadNetworkData> DataSource3
        {
            get
            {
                List<RoadNetworkData> data = new List<RoadNetworkData>();

                data.Add(new RoadNetworkData(626981, "Germany"));
                data.Add(new RoadNetworkData(666204, "Spain"));
                data.Add(new RoadNetworkData(1002486, "France"));
                data.Add(new RoadNetworkData(305388, "Italy"));

                return data;
            }
        }
    }
}
