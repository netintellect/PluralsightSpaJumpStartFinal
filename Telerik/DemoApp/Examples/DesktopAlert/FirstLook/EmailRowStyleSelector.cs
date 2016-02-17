using System.Windows;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.DesktopAlert.FirstLook
{
    public class EmailRowStyleSelector : StyleSelector
    {
        // Unread Email Style
        public Style BoldStyle { get; set; }

        // Read Email Style
        public Style NormalStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            var email = item as Email;
            if (email != null && email.Status == EmailStatus.Unread)
            {
                return this.BoldStyle;
            }

            return this.NormalStyle;
        }
    }
}
