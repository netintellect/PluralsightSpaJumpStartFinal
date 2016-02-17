using System;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
#if WPF
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
#else
using System.ServiceModel;
using Telerik.Windows.Examples.Map.DataService;
#endif


namespace Telerik.Windows.Examples.Map.SalesDashboard
{
    public class ExampleViewModel : ViewModelBase
    {
        private AreaSelection selection;
        private ObservableCollection<Area> areas;
        private ObservableCollection<ISalesData> stores;

        public AreaSelection Selection
        {
            get
            {
                return this.selection;
            }
            set
            {
                if (this.selection != value)
                {
                    this.selection = value;
                    this.OnPropertyChanged("Selection");
                }
            }
        }

        public ObservableCollection<Area> Areas
        {
            get
            {
                return this.areas;
            }
            set
            {
                if (this.areas != value)
                {
                    this.areas = value;
                    this.OnPropertyChanged("Areas");
                }
            }
        }

        public ObservableCollection<ISalesData> Stores
        {
            get
            {
                return this.stores;
            }
            set
            {
                if (this.stores != value)
                {
                    this.stores = value;
                    this.OnPropertyChanged("Stores");
                }
            }
        }

        public ExampleViewModel()
        {
#if SILVERLIGHT
            Uri serviceUri = new Uri(URIHelper.CurrentApplicationURL, "RadMapDataService.svc");
            EndpointAddress address = new EndpointAddress(serviceUri);

            BasicHttpBinding binding = new BasicHttpBinding()
            {
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue
            };

            RadMapDataServiceClient client = new RadMapDataServiceClient(binding, address);

            client.GetSalesAreasCompleted += ServiceClient_GetSalesAreasCompleted;
            client.GetSalesAreasAsync();
#else
            GetSalesAreas();
#endif
        }

#if SILVERLIGHT
        private void ServiceClient_GetSalesAreasCompleted(object sender, GetSalesAreasCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var areas = new ObservableCollection<Area>();
                foreach (RadMapDataServiceSalesArea salesAreaData in e.Result)
                {
                    areas.Add(new Area(salesAreaData));
                }

                this.Areas = areas;
                this.Stores = new ObservableCollection<ISalesData>(this.Areas.SelectMany(area => area.Stores));

                this.SetupInitialSelectionState();
            }
        }
#else
        private void GetSalesAreas()
        {
            List<SalesArea> list = this.GetSalesAreasXML();

            var areas = new ObservableCollection<Area>();

            foreach (SalesArea salesAreaData in list)
            {
                areas.Add(new Area(salesAreaData));
            }

            this.Areas = areas;
            this.Stores = new ObservableCollection<ISalesData>(this.Areas.SelectMany(area => area.Stores));

            this.SetupInitialSelectionState();
        }

        private List<SalesArea> GetSalesAreasXML()
        {
            List<SalesArea> list = new List<SalesArea>();

            StreamResourceInfo streamInfo = Application.GetResourceStream(
                new Uri("/Map;component/SalesDashboard/AtlantaAreas.xml", UriKind.Relative));

            XmlDocument document = new XmlDocument();
            document.Load(streamInfo.Stream);

            XmlNodeList nodeList = document.SelectNodes("/SalesArea/Area");
            foreach (XmlNode node in nodeList)
            {
                XmlElement element = (XmlElement)node;

                SalesArea area = new SalesArea(
                    Convert.ToDouble(element.GetAttribute("Latitude"), CultureInfo.InvariantCulture),
                    Convert.ToDouble(element.GetAttribute("Longitude"), CultureInfo.InvariantCulture),
                    element.GetAttribute("Name"));

                XmlElement polygon = (XmlElement)element.SelectSingleNode("Polygon");
                if (polygon != null)
                {
                    string[] locations = element.InnerText.Trim().Split(' ', '\n', '\r', '\t');
                    List<Location> pointList = new List<Location>();
                    foreach (string locationString in locations)
                    {
                        if (locationString == string.Empty)
                        {
                            continue;
                        }

                        string[] points = locationString.Trim().Split(',');
                        pointList.Add(new Location(
                            double.Parse(points[0], CultureInfo.InvariantCulture),
                            double.Parse(points[1], CultureInfo.InvariantCulture)));
                    }

                    area.Fill = polygon.GetAttribute("Fill");
                    area.Stroke = polygon.GetAttribute("Stroke");

                    area.Area = pointList;
                }

                List<StoreData> stores = new List<StoreData>();
                XmlNodeList storeNodes = element.SelectNodes("StoreList/Store");
                foreach (XmlNode storeNode in storeNodes)
                {
                    XmlElement store = (XmlElement)storeNode;

                    StoreData storeData = new StoreData(
                        Convert.ToDouble(store.GetAttribute("Latitude"), CultureInfo.InvariantCulture),
                        Convert.ToDouble(store.GetAttribute("Longitude"), CultureInfo.InvariantCulture),
                        store.GetAttribute("Name"),
                        Convert.ToDecimal(store.GetAttribute("SalesTotal"), CultureInfo.InvariantCulture),
                        Convert.ToDecimal(store.GetAttribute("SalesTarget"), CultureInfo.InvariantCulture),
                        int.Parse(store.GetAttribute("Managers")));

                    stores.Add(storeData);
                }

                area.Stores = stores;

                list.Add(area);
            }

            return list;
        }
#endif

        private void SetupInitialSelectionState()
        {
            // no selection is applied initially (i.e. all areas are selected).

            AreaSelection selection = new AreaSelection();
            foreach (var area in this.Areas)
            {
                selection.Data.Add(area);
            }

            this.Selection = selection;
        }
    }
}
