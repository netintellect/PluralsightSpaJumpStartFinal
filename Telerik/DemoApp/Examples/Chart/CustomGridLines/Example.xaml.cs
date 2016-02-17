using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Threading;
using Telerik.Windows.Controls.Charting;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
using System.Globalization;
using Telerik.Windows.Controls;
#if WPF
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
#elif SILVERLIGHT
using SelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangedEventArgs;
#endif

namespace Telerik.Windows.Examples.Chart.CustomGridLines
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

        private CustomGridLine customGridLine
        {
            get
            {
                if (this.RadChart1 == null)
                    return null;

                return this.RadChart1.DefaultView.ChartArea.Annotations[0] as CustomGridLine;
            }
        }

        private void StrokeThicknessCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.customGridLine != null)
                this.customGridLine.StrokeThickness = Convert.ToDouble(StrokeThicknessCombo.SelectedValue, CultureInfo.InvariantCulture);
        }

        private void RadColorSelector_SelectedColorChanged(object sender, EventArgs e)
        {
            SolidColorBrush selectedBrush = new SolidColorBrush(((RadColorSelector)sender).SelectedColor);
            if (this.customGridLine != null)
                this.customGridLine.Stroke = selectedBrush; 
        }

        private void CustomLineStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                RadComboBoxItem item = e.AddedItems[0] as RadComboBoxItem;
                if (this.customGridLine != null)
                    this.customGridLine.ElementStyle = this.Resources[item.Tag] as Style;
            }
        }

        private void EnableCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            if (this.customGridLine != null)
                this.customGridLine.Visibility = Visibility.Visible; 
            if(this.customGridLinePanel != null)
                this.customGridLinePanel.Visibility = Visibility.Visible; 
        }

        private void EnableCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.customGridLine != null)
                this.customGridLine.Visibility = Visibility.Collapsed;
            if(this.customGridLinePanel != null)
                this.customGridLinePanel.Visibility = Visibility.Collapsed; 
        }

        private void YInterceptValue_ValueChanged(object sender, RadRangeBaseValueChangedEventArgs e)
        {
            if (this.customGridLine != null)
                this.customGridLine.YIntercept = (double)e.NewValue;
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