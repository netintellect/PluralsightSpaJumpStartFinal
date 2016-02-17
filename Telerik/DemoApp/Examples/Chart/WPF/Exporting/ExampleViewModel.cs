using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.Exporting
{
    public class ExampleViewModel : ViewModelBase
    {
        public string[] ExportFormatData
        {
            get
            {
                return new string[] { "PNG", "BMP", "XLSX", "XPS" };
            }
        }

        public List<double[]> Data
        {
            get
            {
                List<double[]> _data = new List<double[]>();
                double[] inquiries = new double[] { 70, 76, 90, 96, 156, 178, 154, 123, 91, 86, 132, 143 };
                _data.Add(inquiries);

                double[] travellers = new double[] { 82, 96, 126, 90, 112, 127, 172, 172, 103, 67, 90, 161 };
                _data.Add(travellers);

                return _data;
            }
        }
    }
}
