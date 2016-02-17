using System.Windows;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.DesktopAlert.Customization
{
    public class DeliveryTypeStyleSelector : StyleSelector
    {
        private Style shipStyle;
        private Style truckStyle;
        private Style trainStyle;

        public Style ShipStyle
        {
            get
            {
                return shipStyle;
            }
            set
            {
                shipStyle = value;
            }
        }

        public Style TruckStyle
        {
            get
            {
                return truckStyle;
            }
            set
            {
                truckStyle = value;
            }
        }

        public Style TrainStyle
        {
            get
            {
                return trainStyle;
            }
            set
            {
                trainStyle = value;
            }
        }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            DeliveryType place = (DeliveryType)item;

            switch (place)
            {
                case DeliveryType.Truck:
                    return this.truckStyle;
                case DeliveryType.Train:
                    return this.trainStyle;
                case DeliveryType.Ship:
                    return this.shipStyle;
                default:
                    return base.SelectStyle(item, container);
            }
        }
    }
}
