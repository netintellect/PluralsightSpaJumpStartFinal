using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Telerik.Windows.Examples.ChartView.EmptyValues
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private IEnumerable<FootballTeam> _data;
        private FootballTeam _selectedTeam;
        private bool _showLabels;
        private List<string> _chartTypes;
        private string _selectedChartType;

        public ExampleViewModel()
        {
            this.InitializeChartTypes();
            this.GetData("Premierleaguedata.csv");
            this.SelectedChartType = this.ChartTypes[1];
        }

        public IEnumerable<FootballTeam> Data
        {
            get
            {
                return this._data;
            }
            set
            {
                if (this._data == value)
                {
                    return;
                }

                this._data = value;
                this.OnPropertyChanged("Data");
            }
        }

        public FootballTeam SelectedTeam
        {
            get
            {
                return this._selectedTeam;
            }
            set
            {
                if (this._selectedTeam == value)
                {
                    return;
                }

                this._selectedTeam = value;
                this.OnPropertyChanged("SelectedTeam");
            }
        }

        public List<string> ChartTypes
        {
            get { return this._chartTypes; }
        }

        public string SelectedChartType
        {
            get
            {
                return this._selectedChartType;
            }
            set
            {
                if (this._selectedChartType == value)
                    return;

                this._selectedChartType = value;
                this.OnPropertyChanged("SelectedChartType");
            }
        }

        public bool ShowLabels
        {
            get
            {
                return this._showLabels;
            }
            set
            {
                if (this._showLabels != value)
                {
                    this._showLabels = value;
                    this.OnPropertyChanged("ShowLabels");
                }
            }
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            var footballTeamStats = data as IEnumerable<FootballTeamStats>;
            var query = from teamStats in footballTeamStats
                        group teamStats by new { teamStats.Name, teamStats.LogoPath }
                            into team
                            select new FootballTeam()
                            {
                                Name = team.Key.Name,
                                LogoPath = team.Key.LogoPath,
                                Stats = team.ToArray(),
                                TotalWins = team.Where(c => c.Wins.HasValue).Sum(c => c.Wins.Value),
                                TotalDraws = team.Where(c => c.Draws.HasValue).Sum(c => c.Draws.Value),
                                TotalLosses = team.Where(c => c.Losses.HasValue).Sum(c => c.Losses.Value),
                            };
            this.Data = query.ToArray();
            this.SelectedTeam = this.Data.ElementAt(2);
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<FootballTeamStats> dataList = new List<FootballTeamStats>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                var stat = new FootballTeamStats();
                stat.Name = data[0].Trim();
                stat.Season = data[1].Trim();
                if (!string.IsNullOrEmpty(data[2]))
                {
                    stat.Wins = int.Parse(data[2], CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(data[3]))
                {
                    stat.Draws = int.Parse(data[3], CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(data[4]))
                {
                    stat.Losses = int.Parse(data[4], CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(data[5]))
                {
                    stat.GoalDifference = int.Parse(data[5], CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(data[6]))
                {
                    stat.Points = int.Parse(data[6], CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(data[7]))
                {
                    stat.Position = int.Parse(data[7], CultureInfo.InvariantCulture);
                }
                stat.LogoPath = string.Format("../../Images/ChartView/EmptyValues/{0}", data[8].Trim());

                dataList.Add(stat);
            }

            return dataList;
        }

        private void InitializeChartTypes()
        {
            this._chartTypes = new List<string>();
            this._chartTypes.Add("Bar");
            this._chartTypes.Add("Line");
            this._chartTypes.Add("Spline");
            this._chartTypes.Add("Area");
            this._chartTypes.Add("SplineArea");
        }
    }
}
