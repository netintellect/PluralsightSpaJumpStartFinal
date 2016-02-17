using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;

namespace Telerik.Windows.Examples.DesktopAlert.Customization
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        private RadDesktopAlertManager manager;

        public Example()
        {
            InitializeComponent();

            var model = this.DataContext as ViewModel;
            model.ActivateDesktopAlertAction = new Action<Shipment>(this.ActivateDesktopAlert);

            this.manager = new RadDesktopAlertManager();
            this.manager.ShowAnimation = new SlideAnimation { Direction = AnimationDirection.In, SlideMode = SlideMode.Bottom, Orientation = Orientation.Horizontal, SpeedRatio = 0.3d, PixelsToAnimate = 360 };
            this.manager.HideAnimation = new SlideAnimation { Direction = AnimationDirection.Out, SlideMode = SlideMode.Bottom, Orientation = Orientation.Horizontal, SpeedRatio = 0.18d, PixelsToAnimate = 360 };
        }

        private void ActivateDesktopAlert(Shipment shipment)
        {
            RadDesktopAlert alert = new RadDesktopAlert();

            var closedEventBinding = new EventBinding() { EventName = "Closed", RaiseOnHandledEvents = true};
            BindingOperations.SetBinding( closedEventBinding, EventBinding.CommandProperty, new Binding() { Source = (this.DataContext as ViewModel).AlertClosedCommand });

            var eventBindings = EventToCommandBehavior.GetEventBindings(alert);
            eventBindings.Add(closedEventBinding);

            alert.CanMove = false;

            switch (shipment.DeliveryType)
            {
                case DeliveryType.Truck:
                    alert.Style = this.Resources["TruckStyle"] as Style;
                    break;
                case DeliveryType.Train:
                    alert.Style = this.Resources["TrainStyle"] as Style;
                    break;
                case DeliveryType.Ship:
                    alert.Style = this.Resources["ShipStyle"] as Style;
                    break;
            }

            alert.DataContext = shipment;
            
            this.manager.ShowAlert(alert);
        }
    }
}
