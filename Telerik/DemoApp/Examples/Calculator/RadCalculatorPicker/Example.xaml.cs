using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Examples.Calculator.SampleDataSource;

namespace Telerik.Windows.Examples.Calculator.RadCalculatorPicker
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            this.DataContext = new EmployeeDataContext();
        }
    }
}
