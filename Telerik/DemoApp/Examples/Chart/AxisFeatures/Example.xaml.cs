using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
#if WPF
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
#elif SILVERLIGHT
using SelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangedEventArgs;
#endif


namespace Telerik.Windows.Examples.Chart.AxisFeatures
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

        private void AutoRangeChecked(object sender, RoutedEventArgs e)
        {
            if (this.AxisRangePanel != null)
                this.AxisRangePanel.Visibility = Visibility.Collapsed;

            if (this.TicksDistancePanel != null)
                this.TicksDistancePanel.Visibility = Visibility.Visible;

            if (this.RadChart1 != null)
                this.RadChart1.DefaultView.ChartArea.AxisX.AutoRange = true;
        }

        private void AutoRangeUnchecked(object sender, RoutedEventArgs e)
        {
            if (this.AxisRangePanel != null)
                this.AxisRangePanel.Visibility = Visibility.Visible;

            if (this.TicksDistancePanel != null)
                this.TicksDistancePanel.Visibility = Visibility.Collapsed;

            if (this.RadChart1 != null)
            {
                this.RadChart1.DefaultView.ChartArea.AxisX.AutoRange = false;

                int minValue = this.MinValueComboBox != null ? int.Parse(this.MinValueComboBox.SelectedItem.ToString()) : 0;
                int maxValue = this.MaxValueComboBox != null ? int.Parse(this.MaxValueComboBox.SelectedItem.ToString()) : 31;
                int step = this.StepComboBox != null ? int.Parse(this.StepComboBox.SelectedItem.ToString()) : 1;

                this.RadChart1.DefaultView.ChartArea.AxisX.AddRange(minValue, maxValue, step);
            }
        }

        private void LabelRotationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.RadChart1 != null)
                this.RadChart1.DefaultView.ChartArea.AxisX.LabelRotationAngle = e.NewValue;
        }

        private void TickDiestanceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.RadChart1 != null && this.TickDistanceComboBox != null)
                this.RadChart1.DefaultView.ChartArea.AxisX.TicksDistance = int.Parse(this.TickDistanceComboBox.SelectedItem.ToString());
        }

        private void LabelStepComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.RadChart1 != null && this.LabelStepComboBox != null)
                this.RadChart1.DefaultView.ChartArea.AxisX.LabelStep = int.Parse(this.LabelStepComboBox.SelectedItem.ToString());
        }

        private void LabelLevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.RadChart1 != null && this.LabelLevelComboBox != null)
                this.RadChart1.DefaultView.ChartArea.AxisX.StepLabelLevelCount = int.Parse(this.LabelLevelComboBox.SelectedItem.ToString());
        }

        private void MinValueComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.RadChart1 != null && this.MinValueComboBox != null)
                this.RadChart1.DefaultView.ChartArea.AxisX.MinValue = int.Parse(this.MinValueComboBox.SelectedItem.ToString());
        }

        private void StepComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.RadChart1 != null && this.StepComboBox != null)
                this.RadChart1.DefaultView.ChartArea.AxisX.Step = int.Parse(this.StepComboBox.SelectedItem.ToString());
        }

        private void MaxValueComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.RadChart1 != null && this.MaxValueComboBox != null)
                this.RadChart1.DefaultView.ChartArea.AxisX.MaxValue = int.Parse(this.MaxValueComboBox.SelectedItem.ToString());
        }

        private void ExtendDirectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.RadChart1 != null && this.ExtendDirectionComboBox != null)
                this.RadChart1.DefaultView.ChartArea.AxisY.ExtendDirection = (AxisExtendDirection)this.ExtendDirectionComboBox.SelectedIndex;
        }

        private void LayoutModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.RadChart1 != null && this.LayoutModeComboBox != null)
                this.RadChart1.DefaultView.ChartArea.AxisX.LayoutMode = (AxisLayoutMode)this.LayoutModeComboBox.SelectedIndex;
        }
    }
}

