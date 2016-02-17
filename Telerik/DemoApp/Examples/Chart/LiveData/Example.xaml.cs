using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Telerik.Windows.Examples.Chart.LiveData
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            (this.DataContext as ExampleViewModel).StartTimer();
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            (this.DataContext as ExampleViewModel).StopTimer();
        }
    }
}
