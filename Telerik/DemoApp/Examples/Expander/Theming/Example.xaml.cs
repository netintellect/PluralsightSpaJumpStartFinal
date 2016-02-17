using System;
using System.Windows;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Expander.Theming
{
    public partial class Example : System.Windows.Controls.UserControl
    {
        public Example()
        {
            InitializeComponent();
        }
      

        private void EnableAnimation_Checked(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            if (this.radExpander == null)
            {
                return;
            }
            System.Windows.Controls.CheckBox checkbox = sender as System.Windows.Controls.CheckBox;
            if (checkbox != null)
            {
                bool isChecked = checkbox.IsChecked == true;
                Telerik.Windows.Controls.Animation.AnimationManager.SetIsAnimationEnabled(this.radExpander, isChecked);
            }
#endif
        }
    }
}
