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
using Telerik.Windows.Controls.Gauges;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Gauge.Gallery.NumericScale
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : DynamicBasePage
    {
        /// <summary>
        /// Randomizer
        /// </summary>
        private RealDataEmulator valueGenerator = new RealDataEmulator(0, 999, 500, 100, 100);

        public Example()
        {
            InitializeComponent();
        }

        protected override void NewValue()
        {
            double value = valueGenerator.GetNextValue();
            numericIndicator.Value = value;
            bottomNumericIndicator.Value = value;
        }
    }
}
