using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.DataBar.FootballPlayers
{
    public class FootballPlayerInfoViewModel : ViewModelBase
    {
        public FootballPlayerInfoViewModel(int rank, string name, string team, int firstHalfGoalsCount,
            int secondHalfGoalsCount, int homeGoalsCount, int awayGoalsCount, int? lastSeasonGoalsCount)
        {
            this.rank = rank;
            this.name = name;
            this.team = team;
            this.firstHalfGoalsCount = firstHalfGoalsCount;
            this.secondHalfGoalsCount = secondHalfGoalsCount;
            this.homeGoalsCount = homeGoalsCount;
            this.awayGoalsCount = awayGoalsCount;
            this.lastSeasonGoalsCount = lastSeasonGoalsCount;
        }

        private int rank;
        public int Rank
        {
            get { return this.rank; }
            set
            {
                if (this.rank != value)
                {
                    this.rank = value;
                    this.OnPropertyChanged("Rank");
                }
            }
        }

        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        private string team;
        public string Team
        {
            get { return this.team; }
            set
            {
                if (this.team != value)
                {
                    this.team = value;
                    this.OnPropertyChanged("Team");
                }
            }
        }

        private int firstHalfGoalsCount;
        public int FirstHalfGoalsCount
        {
            get { return this.firstHalfGoalsCount; }
            set
            {
                if (this.firstHalfGoalsCount != value)
                {
                    this.firstHalfGoalsCount = value;
                    this.OnPropertyChanged("FirstHalfGoalsCount");
                    this.OnPropertyChanged("TotalGoalsCount");
                }
            }
        }

        private int secondHalfGoalsCount;
        public int SecondHalfGoalsCount
        {
            get { return this.secondHalfGoalsCount; }
            set
            {
                if (this.secondHalfGoalsCount != value)
                {
                    this.secondHalfGoalsCount = value;
                    this.OnPropertyChanged("SecondHalfGoalsCount");
                    this.OnPropertyChanged("TotalGoalsCount");
                }
            }
        }

        public IEnumerable<GoalsInfo> FirstHalfSecondHalfGoalsInfos
        {
            get
            {
                return new List<GoalsInfo>() 
                {   
                    new GoalsInfo{ Count = this.FirstHalfGoalsCount, ToolTip = "Goals first half: " + this.FirstHalfGoalsCount}, 
                    new GoalsInfo{ Count = this.SecondHalfGoalsCount, ToolTip = "Goals second half: " + this.SecondHalfGoalsCount}, 
                };
            }
        }

        private int homeGoalsCount;
        public int HomeGoalsCount
        {
            get { return this.homeGoalsCount; }
            set
            {
                if (this.homeGoalsCount != value)
                {
                    this.homeGoalsCount = value;
                    this.OnPropertyChanged("HomeGoalsCount");
                }
            }
        }

        private int awayGoalsCount;
        public int AwayGoalsCount
        {
            get { return this.awayGoalsCount; }
            set
            {
                if (this.awayGoalsCount != value)
                {
                    this.awayGoalsCount = value;
                    this.OnPropertyChanged("AwayGoalsCount");
                }
            }
        }

        public IEnumerable<GoalsInfo> HomeAwayGoalsInfos
        {
            get
            {
                return new List<GoalsInfo>() 
                {   
                    new GoalsInfo{ Count = this.HomeGoalsCount, ToolTip = "Goals home: " + this.HomeGoalsCount}, 
                    new GoalsInfo{ Count = this.AwayGoalsCount, ToolTip = "Goals away: " + this.AwayGoalsCount}, 
                };
            }
        }

        public int TotalGoalsCount
        {
            get { return this.FirstHalfGoalsCount + this.SecondHalfGoalsCount; }
        }

        private int? lastSeasonGoalsCount;
        public int? LastSeasonGoalsCount
        {
            get { return this.lastSeasonGoalsCount; }
            set
            {
                if (this.lastSeasonGoalsCount.Value != value.Value)
                {
                    this.lastSeasonGoalsCount = value;
                    this.OnPropertyChanged("LastSeasonGoalsCount");
                }
            }
        }
    }
}
