using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls.Map;

#if SILVERLIGHT
using System.ServiceModel;
using Telerik.Windows.Examples.Map.DataService;
#endif

namespace Telerik.Windows.Examples.Map.DynamicLayer
{
	public class VirtualizationSource : IMapItemsVirtualizationSource
	{
		private ExampleViewModel dataContext;

#if SILVERLIGHT
		private Uri serviceUri;
#endif

		public VirtualizationSource(ExampleViewModel dataContext)
        {
			this.dataContext = dataContext;

#if SILVERLIGHT
			this.serviceUri = new Uri(URIHelper.CurrentApplicationURL, "RadMapDataService.svc");
#endif
        }

		public void MapItemsRequest(object sender, MapItemsRequestEventArgs eventArgs)
		{
			double minZoom = eventArgs.MinZoom;
			Location upperLeft = eventArgs.UpperLeft;
			Location lowerRight = eventArgs.LowerRight;

			if (this.dataContext == null)
				return;

#if WPF
			if (minZoom == 3)
			{
				// request areas
				List<StoreLocation> list = this.dataContext.GetStores(
					upperLeft.Latitude, 
					upperLeft.Longitude,
					lowerRight.Latitude, 
					lowerRight.Longitude, 
					StoreType.Area);

				dataContext.SetStores(list, eventArgs);
			}

			if (minZoom == 9)
			{
				// request areas
				List<StoreLocation> list = this.dataContext.GetStores(
					upperLeft.Latitude, 
					upperLeft.Longitude,
					lowerRight.Latitude, 
					lowerRight.Longitude, 
					StoreType.Store);

				this.dataContext.SetStores(list, eventArgs);
			}

#elif SILVERLIGHT
            const string exceptionFormat = "Store Service Exception: {0}";

			EndpointAddress address = new EndpointAddress(this.serviceUri);

            BasicHttpBinding binding = new BasicHttpBinding()
            {
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue
            };

            RadMapDataServiceClient client = new RadMapDataServiceClient(binding, address);

            client.GetStoresCompleted += this.dataContext.DataServiceGetStoresCompleted;

            if (minZoom == 3)
            {
                // request areas
                try
                {
                    client.GetStoresAsync(
						upperLeft.Latitude, 
						upperLeft.Longitude,
                        lowerRight.Latitude, 
						lowerRight.Longitude, 
						RadMapDataServiceStoreType.Area, 
						eventArgs);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format(exceptionFormat, ex.Message));
                }
            }

            if (minZoom == 9)
            {
                // request stores
                try
                {
                    client.GetStoresAsync(
						upperLeft.Latitude, 
						upperLeft.Longitude,
                        lowerRight.Latitude, 
						lowerRight.Longitude, 
						RadMapDataServiceStoreType.Store, 
						eventArgs);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format(exceptionFormat, ex.Message));
                }
            }
#endif
		}
	}
}
