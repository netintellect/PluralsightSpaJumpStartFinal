using System.Windows;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Map.Theatre
{
    public static class ColorizationHelper
    {
        public static Brush ReservedBrush = new SolidColorBrush(Color.FromArgb(255, 204, 0, 0));
        public static Brush SelectedBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        public static Brush NotAvailableBrush = new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));
        public static Brush SoldBrush = new SolidColorBrush(Color.FromArgb(255, 96, 57, 19));
    }
}
