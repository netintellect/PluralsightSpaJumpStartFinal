using System.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.AxisSmartLabels
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            this.CheckBoxAxisSmartLabels.IsChecked = true;
            this.CheckBoxAxisSmartRange.IsChecked = true;
            this.ComboBoxLabelFitMode.SelectedIndex = 0;
        }

        private void CheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            bool isAxisSmartLabelsOn = this.CheckBoxAxisSmartLabels.IsChecked == true;

            if (isAxisSmartLabelsOn)
                this.CheckBoxAxisSmartRange.IsEnabled = true;
            else
                this.CheckBoxAxisSmartRange.IsEnabled = false;

            foreach (var axis in Telerik.Windows.Controls.ChildrenOfTypeExtensions.ChildrenOfType<DateTimeContinuousAxis>(this))
            {
                if (isAxisSmartLabelsOn)
                    axis.SmartLabelsMode = Telerik.Charting.AxisSmartLabelsMode.SmartStep;
                else
                    axis.SmartLabelsMode = Telerik.Charting.AxisSmartLabelsMode.None;
            }

            foreach (var axis in Telerik.Windows.Controls.ChildrenOfTypeExtensions.ChildrenOfType<NumericalAxis>(this))
            {
                if (isAxisSmartLabelsOn)
                {
                    if (this.CheckBoxAxisSmartRange.IsChecked == true)
                        axis.SmartLabelsMode = Telerik.Charting.AxisSmartLabelsMode.SmartStepAndRange;
                    else
                        axis.SmartLabelsMode = Telerik.Charting.AxisSmartLabelsMode.SmartStep;
                }
                else
                {
                    axis.SmartLabelsMode = Telerik.Charting.AxisSmartLabelsMode.None;
                }
            }
        }
    }
}
