using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.DateTimePicker.Clock
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
            this.clock.ItemsSource = this.LoadNextDataObjects();
        }

        public ObservableCollection<TimeSpan> LoadDataObjects()
        {
            ObservableCollection<TimeSpan> times = new ObservableCollection<TimeSpan>();
            times.Add(new TimeSpan(6, 0, 0));
            times.Add(new TimeSpan(6, 30 ,0));
            times.Add(new TimeSpan(7, 0, 0));
            times.Add(new TimeSpan(7, 30, 0));
            times.Add(new TimeSpan(8, 0, 0));
            times.Add(new TimeSpan(8, 30, 0));
            times.Add(new TimeSpan(9, 0, 0));
            times.Add(new TimeSpan(9, 30, 0));
            times.Add(new TimeSpan(10, 0, 0));
            times.Add(new TimeSpan(10, 30, 0));
            times.Add(new TimeSpan(11, 0, 0));
            times.Add(new TimeSpan(11, 30, 0));
            times.Add(new TimeSpan(12, 0, 0));
            times.Add(new TimeSpan(12, 30, 0));
            times.Add(new TimeSpan(13, 0, 0));
            times.Add(new TimeSpan(13, 30, 0));
            times.Add(new TimeSpan(14, 0, 0));
            times.Add(new TimeSpan(14, 30, 0));
            times.Add(new TimeSpan(15, 0, 0));
            times.Add(new TimeSpan(15, 30, 0));
            times.Add(new TimeSpan(16, 0, 0));
            times.Add(new TimeSpan(16, 30, 0));
            times.Add(new TimeSpan(17, 0, 0));
            times.Add(new TimeSpan(17, 30, 0));
            times.Add(new TimeSpan(18, 0, 0));
            times.Add(new TimeSpan(18, 30, 0));
            times.Add(new TimeSpan(19, 0, 0));
            times.Add(new TimeSpan(19, 30, 0));
            times.Add(new TimeSpan(20, 0, 0));
            times.Add(new TimeSpan(20, 30, 0));
            times.Add(new TimeSpan(21, 0, 0));
            times.Add(new TimeSpan(21, 30, 0));

            return times;
        }

        public ObservableCollection<TimeSpan> LoadNextDataObjects()
        {
            ObservableCollection<TimeSpan> times = new ObservableCollection<TimeSpan>();
            times.Add(new TimeSpan(9, 0, 0));
            times.Add(new TimeSpan(9, 15, 0));
            times.Add(new TimeSpan(9, 30, 0));
            times.Add(new TimeSpan(9, 45, 0));

            times.Add(new TimeSpan(10, 0, 0));
            times.Add(new TimeSpan(10, 15, 0));
            times.Add(new TimeSpan(10, 30, 0));
            times.Add(new TimeSpan(10, 45, 0));

            times.Add(new TimeSpan(11, 0, 0));
            times.Add(new TimeSpan(11, 15, 0));
            times.Add(new TimeSpan(11, 30, 0));
            times.Add(new TimeSpan(11, 45, 0));

            times.Add(new TimeSpan(12, 0, 0));
            times.Add(new TimeSpan(12, 15, 0));
            times.Add(new TimeSpan(12, 30, 0));
            times.Add(new TimeSpan(12, 45, 0));

            times.Add(new TimeSpan(13, 0, 0));
            times.Add(new TimeSpan(13, 15, 0));
            times.Add(new TimeSpan(13, 30, 0));
            times.Add(new TimeSpan(13, 45, 0));

            times.Add(new TimeSpan(14, 0, 0));
            times.Add(new TimeSpan(14, 15, 0));
            times.Add(new TimeSpan(14, 30, 0));
            times.Add(new TimeSpan(14, 45, 0));

            times.Add(new TimeSpan(15, 0, 0));
            times.Add(new TimeSpan(15, 15, 0));
            times.Add(new TimeSpan(15, 30, 0));
            times.Add(new TimeSpan(15, 45, 0));

            times.Add(new TimeSpan(16, 0, 0));
            times.Add(new TimeSpan(16, 15, 0));
            times.Add(new TimeSpan(16, 30, 0));
            times.Add(new TimeSpan(16, 45, 0));

            return times;
        }

        private void all_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.clock.ItemsSource = this.LoadDataObjects();
        }

        private void working_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.clock.ItemsSource = this.LoadNextDataObjects();
        }
    }
}
