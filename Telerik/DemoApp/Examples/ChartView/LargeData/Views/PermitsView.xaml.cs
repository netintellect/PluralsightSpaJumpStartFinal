using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls;
using Telerik.Charting;
using Telerik.Windows.Examples.ChartView.LargeData;
using Telerik.Windows.Examples.ChartView.LargeData.ViewModels;

namespace Telerik.Windows.Examples.ChartView.LargeData.Views
{
    /// <summary>
    /// Interaction logic for PermitsView.xaml
    /// </summary>
    public partial class PermitsView : UserControl
    {
        public PermitsView()
        {
            InitializeComponent();
            this.permitsChart.MouseLeftButtonDown += Chart_MouseLeftButtonDown;
            this.permitsChart.MouseLeftButtonUp += Chart_MouseLeftButtonUp;
        }

        void Chart_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.crosshair.HorizontalLineVisibility = Visibility.Visible;
            this.crosshair.VerticalLineVisibility = Visibility.Visible;
        }

        void Chart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.crosshair.HorizontalLineVisibility = Visibility.Collapsed;
            this.crosshair.VerticalLineVisibility = Visibility.Collapsed;
        }

        private void crosshair_PositionChanged(object sender, ChartCrosshairPositionChangedEventArgs e)
        {
            PermitsViewModel viewModel = this.DataContext as PermitsViewModel;
            viewModel.X = e.Data.FirstValue != null ? (double)e.Data.FirstValue : 0;
            viewModel.Y = e.Data.SecondValue != null ? (double)e.Data.SecondValue : 0;
        }
    }
}
