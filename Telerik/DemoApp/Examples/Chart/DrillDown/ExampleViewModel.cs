using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.DrillDown
{
    public class ExampleViewModel : DataSourceViewModelBase
    {

        private Visibility _legendVisibility;
        private ICommand _makeLegendVisible;

        public Visibility LegendVisibility
        {
            get
            {
                return this._legendVisibility;
            }
            set
            {
                if (this._legendVisibility != value)
                {
                    this._legendVisibility = value;
                    this.OnPropertyChanged("LegendVisibility");
                }
            }
        }

        public ICommand MakeLegendVisibleTypeCommand
        {
            get { return this._makeLegendVisible; }
            set { this._makeLegendVisible=value; }
        } 

        public void ChangeLegendVisibility(Object parameter)
        {
            this.LegendVisibility = Visibility.Visible;
        }       

        public ExampleViewModel()
        {
            this.GetData("PopulationPyramiddata.csv");
            this.MakeLegendVisibleTypeCommand = new DelegateCommand(ChangeLegendVisibility);            
            this.LegendVisibility = Visibility.Collapsed;
        }
        
        private IEnumerable _rowData;

        public IEnumerable RowData
        {
            get {
                return _rowData; 
                }
            set {
                _rowData = value; 
                this.OnPropertyChanged("RowData");
                }
        }
        
        protected override void GetDataCompleted(IEnumerable data)
        {
            this.RowData = data;
            List<CensusViewModel> res = data as List<CensusViewModel>;
          
            var groupedData = res.GroupBy(cvm => new { cvm.AgeRange, cvm.Gender }).Select(gr => new CensusGenderView { AgeRange = gr.Key.AgeRange, Gender = gr.Key.Gender, Population = gr.Sum(cvm => cvm.Population), Details = gr.GroupBy(cvm => new { cvm.Region, cvm.Age }).Select(innerGroup => new CensusDetails() { Region = innerGroup.Key.Region, Age = innerGroup.Key.Age, Population = innerGroup.Sum(e => e.Population) }).ToList() as List<CensusDetails> });

            this.RowData = groupedData;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<CensusViewModel> chartData = new List<CensusViewModel>();

            dataReader.ReadLine();
            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                CensusViewModel censusViewModel = new CensusViewModel();
                censusViewModel.AgeRange = data[0].Trim();
                censusViewModel.State = data[2].Trim();
                censusViewModel.Region = data[3].Trim();
                censusViewModel.Gender = data[4].Trim();
                censusViewModel.Age = int.Parse(data[6], CultureInfo.InvariantCulture);
                censusViewModel.Population = int.Parse(data[8], CultureInfo.InvariantCulture);

                chartData.Add(censusViewModel);
            }

            return chartData;
        }

        public Brush ApplicationThemeAwareForeground
        {
            get
            {
                if (StyleManager.ApplicationTheme is Expression_DarkTheme)
                    return new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));

                return new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            }
        }
    }
}
