using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Sparklines;

namespace Telerik.Windows.Examples.Sparklines.Configurator
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private IEnumerable<RadSparklineBase> Sparklines
        {
            get
            {
                return this.allSparklinesGrid.ChildrenOfType<RadSparklineBase>();
            }
        }

        private void AxisColorChanged(object sender, EventArgs e)
        {
            Color selectedColor = (sender as RadColorSelector).SelectedColor;
            Brush selectedBrush = new SolidColorBrush(selectedColor);

            foreach (RadIndicatedSparklineBase sparkline in this.Sparklines.OfType<RadIndicatedSparklineBase>())
            {
                sparkline.AxisStroke = selectedBrush;
            }
        }

        private void FirstPointColorChanged(object sender, EventArgs e)
        {
            Color selectedColor = (sender as RadColorSelector).SelectedColor;
            Brush selectedBrush = new SolidColorBrush(selectedColor);

            foreach (RadIndicatedSparklineBase sparkline in this.Sparklines.OfType<RadIndicatedSparklineBase>())
            {
                sparkline.FirstPointBrush = selectedBrush;
            }
        }

        private void HighPointColorChanged(object sender, EventArgs e)
        {
            Color selectedColor = (sender as RadColorSelector).SelectedColor;
            Brush selectedBrush = new SolidColorBrush(selectedColor);

            foreach (RadIndicatedSparklineBase sparkline in this.Sparklines.OfType<RadIndicatedSparklineBase>())
            {
                sparkline.HighPointBrush = selectedBrush;
            }
        }

        private void LastPointColorChanged(object sender, EventArgs e)
        {
            Color selectedColor = (sender as RadColorSelector).SelectedColor;
            Brush selectedBrush = new SolidColorBrush(selectedColor);

            foreach (RadIndicatedSparklineBase sparkline in this.Sparklines.OfType<RadIndicatedSparklineBase>())
            {
                sparkline.LastPointBrush = selectedBrush;
            }
        }

        private void LowPointColorChanged(object sender, EventArgs e)
        {
            Color selectedColor = (sender as RadColorSelector).SelectedColor;
            Brush selectedBrush = new SolidColorBrush(selectedColor);

            foreach (RadIndicatedSparklineBase sparkline in this.Sparklines.OfType<RadIndicatedSparklineBase>())
            {
                sparkline.LowPointBrush = selectedBrush;
            }
        }

        private void MarkerColorChanged(object sender, EventArgs e)
        {
            Color selectedColor = (sender as RadColorSelector).SelectedColor;
            Brush selectedBrush = new SolidColorBrush(selectedColor);

            foreach (RadLinearSparklineBase sparkline in this.Sparklines.OfType<RadLinearSparklineBase>())
            {
                sparkline.MarkersBrush = selectedBrush;
            }
        }

        private void NegativeColorChanged(object sender, EventArgs e)
        {
            Color selectedColor = (sender as RadColorSelector).SelectedColor;
            Brush selectedBrush = new SolidColorBrush(selectedColor);

            foreach (RadIndicatedSparklineBase sparkline in this.Sparklines.OfType<RadIndicatedSparklineBase>())
            {
                sparkline.NegativePointBrush = selectedBrush;
            }
        }

        private void SparklineColorChanged(object sender, EventArgs e)
        {
            Color selectedColor = (sender as RadColorSelector).SelectedColor;
            Brush selectedBrush = new SolidColorBrush(selectedColor);

            foreach (RadSparklineBase sparkline in this.Sparklines)
            {
                if (sparkline is RadLinearSparkline)
                {
                    (sparkline as RadLinearSparkline).LineStroke = selectedBrush;
                }
                else if (sparkline is RadAreaSparkline)
                {
                    RadAreaSparkline areaSparkline = (sparkline as RadAreaSparkline);
                    areaSparkline.PositiveAreaFill = selectedBrush;
                    areaSparkline.PositiveAreaStroke = selectedBrush;
                    areaSparkline.NegativeAreaFill = selectedBrush;
                    areaSparkline.NegativeAreaStroke = selectedBrush;
                }
                else if (sparkline is RadItemDrawnSparklineBase)
                {
                    (sparkline as RadItemDrawnSparklineBase).ItemFill = selectedBrush;
                }
            }
        }

        private void NormalRangeColorChanged(object sender, EventArgs e)
        {
            Color selectedColor = (sender as RadColorSelector).SelectedColor;
            Brush selectedBrush = new SolidColorBrush(selectedColor);

            foreach (RadSparklineBase sparkline in this.Sparklines.OfType<RadSparklineBase>())
            {
                if (sparkline is RadLinearSparkline)
                {
                    (sparkline as RadLinearSparkline).NormalRangeFill = selectedBrush;
                }
                else if (sparkline is RadScatterSparkline)
                {
                    (sparkline as RadScatterSparkline).NormalRangeFill = selectedBrush;
                }
            }

            foreach (RadScatterSparkline sparkline in this.Sparklines.OfType<RadScatterSparkline>())
            {
                sparkline.NormalRangeFill = selectedBrush;
            }
        }
        private void CheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.checkboxGrid == null)
                return;

            CheckBox checkbox = sender as CheckBox;
            IEnumerable<CheckBox> checkboxes = this.checkboxGrid.ChildrenOfType<CheckBox>();
            foreach (CheckBox c in checkboxes)
            {
                c.IsChecked = checkbox.IsChecked;
            }
        }
    }
}
