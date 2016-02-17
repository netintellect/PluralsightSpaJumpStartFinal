using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Timeline.Annotations
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private List<WorldCupGame> data;
        private TimeSpan minZoomRange;
        private Color selectedColorGroupA, selectedColorGroupB, selectedColorGroupC, selectedColorGroupD,
            selectedColorGroupE, selectedColorGroupF, selectedColorGroupG, selectedColorGroupH;

        public ExampleViewModel()
        {
            this.GetData("WorldCup.csv");
        }

        public List<WorldCupGame> Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                if (this.data == value)
                    return;

                this.data = value;
                this.OnPropertyChanged("Data");
            }
        }

        public Color SelectedColorGroupA
        {
            get
            {
                return this.selectedColorGroupA;
            }
            set
            {
                if (this.selectedColorGroupA != value)
                {
                    this.selectedColorGroupA = value;
                    this.OnPropertyChanged("SelectedColorGroupA");

                    this.ColorizeGroupGames("A", new SolidColorBrush(this.selectedColorGroupA));
                }
            }
        }

        public Color SelectedColorGroupB
        {
            get
            {
                return this.selectedColorGroupB;
            }
            set
            {
                if (this.selectedColorGroupB != value)
                {
                    this.selectedColorGroupB = value;
                    this.OnPropertyChanged("SelectedColorGroupB");

                    this.ColorizeGroupGames("B", new SolidColorBrush(this.selectedColorGroupB));
                }
            }
        }

        public Color SelectedColorGroupC
        {
            get
            {
                return this.selectedColorGroupC;
            }
            set
            {
                if (this.selectedColorGroupC != value)
                {
                    this.selectedColorGroupC = value;
                    this.OnPropertyChanged("SelectedColorGroupC");

                    this.ColorizeGroupGames("C", new SolidColorBrush(this.selectedColorGroupC));
                }
            }
        }

        public Color SelectedColorGroupD
        {
            get
            {
                return this.selectedColorGroupD;
            }
            set
            {
                if (this.selectedColorGroupD != value)
                {
                    this.selectedColorGroupD = value;
                    this.OnPropertyChanged("SelectedColorGroupD");

                    this.ColorizeGroupGames("D", new SolidColorBrush(this.selectedColorGroupD));
                }
            }
        }

        public Color SelectedColorGroupE
        {
            get
            {
                return this.selectedColorGroupE;
            }
            set
            {
                if (this.selectedColorGroupE != value)
                {
                    this.selectedColorGroupE = value;
                    this.OnPropertyChanged("SelectedColorGroupE");

                    this.ColorizeGroupGames("E", new SolidColorBrush(this.selectedColorGroupE));
                }
            }
        }

        public Color SelectedColorGroupF
        {
            get
            {
                return this.selectedColorGroupF;
            }
            set
            {
                if (this.selectedColorGroupF != value)
                {
                    this.selectedColorGroupF = value;
                    this.OnPropertyChanged("SelectedColorGroupF");

                    this.ColorizeGroupGames("F", new SolidColorBrush(this.selectedColorGroupF));
                }
            }
        }

        public Color SelectedColorGroupG
        {
            get
            {
                return this.selectedColorGroupG;
            }
            set
            {
                if (this.selectedColorGroupG != value)
                {
                    this.selectedColorGroupG = value;
                    this.OnPropertyChanged("SelectedColorGroupG");

                    this.ColorizeGroupGames("G", new SolidColorBrush(this.selectedColorGroupG));
                }
            }
        }

        public Color SelectedColorGroupH
        {
            get
            {
                return this.selectedColorGroupH;
            }
            set
            {
                if (this.selectedColorGroupH != value)
                {
                    this.selectedColorGroupH = value;
                    this.OnPropertyChanged("SelectedColorGroupH");

                    this.ColorizeGroupGames("H", new SolidColorBrush(this.selectedColorGroupH));
                }
            }
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            this.Data = data as List<WorldCupGame>;

            this.SelectedColorGroupA = Color.FromArgb(255, 142, 196, 65);
            this.SelectedColorGroupB = Color.FromArgb(255, 37, 160, 218);
            this.SelectedColorGroupC = Color.FromArgb(255, 245, 151, 0);
            this.SelectedColorGroupD = Color.FromArgb(255, 212, 223, 50);
            this.SelectedColorGroupE = Color.FromArgb(255, 51, 153, 51);
            this.SelectedColorGroupF = Color.FromArgb(255, 0, 171, 169);
            this.SelectedColorGroupG = Color.FromArgb(255, 220, 91, 32);
            this.SelectedColorGroupH = Color.FromArgb(255, 232, 188, 52);
        }

        protected override IEnumerable ParseData(System.IO.TextReader dataReader)
        {
            string line;

            List<WorldCupGame> data = new List<WorldCupGame>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var strings = line.Split(';');
                if (strings.Length != 6)
                    continue;

                WorldCupGame dataItem = new WorldCupGame();
                dataItem.Venue = strings[0];
                dataItem.MatchDate = DateTime.Parse(strings[1], CultureInfo.InvariantCulture);
                dataItem.Team1 = strings[2];
                dataItem.Team2 = strings[3];
                dataItem.Group = strings[4];
                dataItem.MatchNumber = int.Parse(strings[5], CultureInfo.InvariantCulture);

                data.Add(dataItem);
            }

            return data;
        }

        private void ColorizeGroupGames(string groupKey, Brush brush)
        {
            var groupGames = this.Data.Where(game => game.Group == groupKey);
            foreach (var game in groupGames)
            {
                game.GroupBrush = brush;
            }
        }
    }
}
