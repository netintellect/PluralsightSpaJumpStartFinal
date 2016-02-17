using System.Collections.ObjectModel;
using System.Windows.Controls;
using Telerik.Windows.Input.Touch;
#if WPF
using System.Windows;
#endif

namespace Telerik.Windows.Examples.TouchManager.FirstLook
{
    public partial class Example : UserControl
    {
        private int gesturesCount;
        private ObservableCollection<string> gestures;

        public Example()
        {
            InitializeComponent();

            this.gestures = new ObservableCollection<string>();
            this.listBoxGestures.ItemsSource = this.gestures;
            Telerik.Windows.Input.Touch.TouchManager.AddTapEventHandler(this.gridGoToHome, this.GridGoToHome_Tap);
            Telerik.Windows.Input.Touch.TouchManager.AddTouchDownEventHandler(this.gridTouchToStart, this.GridTouchToStart_TouchDown);            
            EventManager.RegisterClassHandler(typeof(Example), TouchGallery.GestureChangedEvent, new GestureChangedEventHandler(this.Example_GestureChanged));
        }

        private void GridTouchToStart_TouchDown(object sender, TouchEventArgs args)
        {
            args.Handled = true;

            this.gridTouchToStart.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void GridGoToHome_Tap(object sender, TapEventArgs args)
        {
            args.Handled = true;

            this.touchGallery.GoToHome();
            this.RaiseGestureChanged("Tap");
        }

        private void Example_GestureChanged(object sender, GestureChangedEventArgs args)
        {
            this.gesturesCount++;
            string newEntry = string.Format("{0}. {1}", this.gesturesCount, args.GestureName);
            this.gestures.Add(newEntry);

            while (this.gestures.Count > 20)
            {
                this.gestures.RemoveAt(0);
            }

            this.listBoxGestures.ScrollIntoView(newEntry);
        }

        private void RaiseGestureChanged(string gestureName)
        {
            GestureChangedEventArgs newEventArgs = new GestureChangedEventArgs(gestureName);
            this.RaiseEvent(newEventArgs);
        }
    }
}
