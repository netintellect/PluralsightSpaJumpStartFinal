using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.InverseAxis
{
    public class ExampleViewModel : ViewModelBase
    {
        int startYear = 1964;
        int endYear;
        long[] feetPerWell = new long[] { 4179, 4328, 4590, 4214, 4166, 4125, 4578, 5072, 5476, 4782, 5442, 5923 };

        public IEnumerable<Data> DataSource
        {
            get
            {
                this.endYear = startYear;

                List<Data> data = new List<Data>();

                for (int i = 0; i < feetPerWell.Length; i++)
                {
                    data.Add(new Data(this.endYear, feetPerWell[i]));
                    this.endYear += 4;
                }

                return data;
            }
        }
    }
}
