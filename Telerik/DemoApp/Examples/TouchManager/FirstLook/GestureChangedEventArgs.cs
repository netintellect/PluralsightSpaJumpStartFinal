using Telerik.Windows.Input.Touch;
#if WPF
using System.Windows;
#endif

namespace Telerik.Windows.Examples.TouchManager.FirstLook
{
    public class GestureChangedEventArgs :
#if WPF
 RoutedEventArgs
#elif SILVERLIGHT
        RadRoutedEventArgs
#endif
    {
        private string gestureName;

        public GestureChangedEventArgs(string gestureName)
            : base(TouchGallery.GestureChangedEvent)
        {
            this.gestureName = gestureName;
        }

        public string GestureName
        {
            get
            {
                return this.gestureName;
            }
        }
    }
}
