using System;

namespace Telerik.Windows.Examples.DesktopAlert.Customization
{
    public class Shipment
    {
        private int id;
        private DeliveryType deliveryType;
        private int numberOfItems;
        private CityDetails cityFrom;
        private CityDetails cityTo;
        private DateTime dateOfArrival;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public int NumberOfItems
        {
            get
            {
                return numberOfItems;
            }
            set
            {
                numberOfItems = value;
            }
        }

        public CityDetails CityFrom
        {
            get
            {
                return cityFrom;
            }
            set
            {
                cityFrom = value;
            }
        }

        public CityDetails CityTo
        {
            get
            {
                return cityTo;
            }
            set
            {
                cityTo = value;
            }
        }

        public DateTime DateOfArrival
        {
            get
            {
                return dateOfArrival;
            }
            set
            {
                dateOfArrival = value;
            }
        }

        public DeliveryType DeliveryType
        {
            get 
            { 
                return deliveryType; 
            }
            set 
            { 
                deliveryType = value; 
            }
        }
    }
}
