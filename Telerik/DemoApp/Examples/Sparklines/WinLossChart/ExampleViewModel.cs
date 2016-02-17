using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Telerik.Windows.Examples.Sparklines.WinLossChart
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private IEnumerable<PilotDataViewModel> _data;

        public ExampleViewModel()
        {
            this.GetData("F12009.csv");
        }

        public IEnumerable<PilotDataViewModel> Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (this._data != value)
                {
                    this._data = value;
                    OnPropertyChanged("Data");
                }
            }
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as IEnumerable<PilotDataViewModel>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            List<PilotDataViewModel> data = new List<PilotDataViewModel>();
            string line;

            while ((line = dataReader.ReadLine()) != null)
            {
                string[] lineData = line.Split(',');
                List<Race> races = new List<Race>(lineData.Length - 1);

                for (int index = 1; index < lineData.Length; index++)
                {
                    Race race;

                    if (lineData[index] == "null")
                    {
                        race = new Race(null);
                    }
                    else
                    {
                        double points = double.Parse(lineData[index], CultureInfo.InvariantCulture);
                        race = new Race(points);
                    }

                    races.Add(race);
                }

                PilotData pilot = new PilotData();
                pilot.Name = lineData[0].Trim();
                pilot.Points = races;

                PilotDataViewModel pilotDataViewModel = new PilotDataViewModel();
                pilotDataViewModel.Data = pilot;

                data.Add(pilotDataViewModel);
            }

            return data;
        }
    }
}

