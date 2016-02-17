using System.Windows.Controls;

namespace Telerik.Windows.Examples.Sparklines.LiveData
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as ExampleViewModel).StartTimer();
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as ExampleViewModel).StopTimer();
        }
    }
}
