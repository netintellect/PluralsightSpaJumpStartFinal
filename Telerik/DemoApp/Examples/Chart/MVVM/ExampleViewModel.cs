using System.Collections.Generic;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.MVVM
{
    public class ExampleViewModel
    {
        int startYear = 1970;
        int endYear;
        double[] euData = new double[] { 4401.2d, 4002d, 3381.2d, 2775d, 2800.2d, 1274.4d, -199.6d, 570.6d, 667.6d, 248.2d, -209.6d, -737.6d, -1178.2d, -1436.6d, -1540.2d, -1659.6d, -1828.6d };
        double[] worldData = new double[] { 70821.4d, 75108d, 75258.4d, 81727.6d, 88841d, 84524.2d, 80458.8d, 79381.8d, 79282.4d, 78699.6d, 74529.4d, 67340d, 59472.4d, 52335d, 46125.2d, 39029.6d, 30728d };

        public List<DataViewModel> Data
        {
            get
            {
                this.endYear = startYear;

                List<Data> dataList = new List<Data>();

                for (int i = 0; i < euData.Length; i++)
                {
                    dataList.Add(new Data(this.endYear, euData[i], worldData[i]));
                    this.endYear += 5;
                }

                List<DataViewModel> modelList = new List<DataViewModel>();
                foreach (Data dataItem in dataList)
                    modelList.Add(new DataViewModel(dataItem));

                return modelList;
            }
        }

        public Brush ApplicationThemeAwareForeground
        {
            get
            {
                if (StyleManager.ApplicationTheme.GetType() == typeof(Expression_DarkTheme))
                    return new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));

                return new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            }
        }
    }
}
