using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.DataBar.FootballPlayers
{
    public class FootballPlayersViewModel : ViewModelBase
    {
        public FootballPlayersViewModel()
        {            
            this.FootballPlayerInfos = new List<FootballPlayerInfoViewModel>() 
            {
                new FootballPlayerInfoViewModel(1, "Dimitar Berbatov", "Man Utd", 8, 12, 16, 4, 12), 
                new FootballPlayerInfoViewModel(1, "Carlos Tevez", "Man City", 11, 9, 13, 7, 23), 
                new FootballPlayerInfoViewModel(3, "Robin van Persie", "Arsenal", 8, 10, 7, 11, 9), 
                new FootballPlayerInfoViewModel(4, "Darren Bent", "Sunderland", 9, 8, 6, 11, 24),
                new FootballPlayerInfoViewModel(5, "Peter Odemwingie", "West Brom", 6, 9, 10, 5, null),
                new FootballPlayerInfoViewModel(6, "Florent Malouda", "Chelsea", 8, 5, 11, 2, 12),
                new FootballPlayerInfoViewModel(6, "Rafael van der Vaart", "Spurs", 7, 6, 8, 5, null),
                new FootballPlayerInfoViewModel(6, "Dudley Campbell", "Blackpool", 5, 8, 8, 5, null),
                new FootballPlayerInfoViewModel(6, "Dirk Kuyt", "Liverpool", 8, 5, 9, 4, 9),
                new FootballPlayerInfoViewModel(6, "Andrew Carroll", "Newcastle", 5, 8, 9, 4, null),
                new FootballPlayerInfoViewModel(6, "Javier Hernandez", "Man Utd", 5, 8, 5, 8, null),
                new FootballPlayerInfoViewModel(12, "Kevin Nolan", "Newcastle", 9, 3, 10, 2, null),
                new FootballPlayerInfoViewModel(12, "Clint Dempsey", "Fulham", 5, 7, 8, 4, 7),
                new FootballPlayerInfoViewModel(12, "Charlie Adam", "Blackpool", 8, 4, 5, 7, null),
                new FootballPlayerInfoViewModel(15, "Didier Drogba", "Chelsea", 6, 5, 7, 4, 29),
                new FootballPlayerInfoViewModel(15, "Wayne Rooney", "Man Utd", 5, 6, 4, 7, 26),
                new FootballPlayerInfoViewModel(17, "Frank Lampard", "Chelsea", 5, 5, 5, 5, 22),
                new FootballPlayerInfoViewModel(18, "Salomon Kalou", "Chelsea", 6, 4, 4, 6, 5),
                new FootballPlayerInfoViewModel(19, "Maxi Rodriguez", "Liverpool", 5, 5, 6, 4, 1),
                new FootballPlayerInfoViewModel(20, "Johan Elmander", "Bolton", 1, 9, 3, 7, 3),
                new FootballPlayerInfoViewModel(21, "Fernando Torres", "Liverpool", 5, 5, 6, 4, 18),
                new FootballPlayerInfoViewModel(22, "Steven Fletcher", "Wolves", 5, 5, 7, 3, 8),
                new FootballPlayerInfoViewModel(22, "Samir Nasri", "Arsenal", 6, 4, 6, 4, 2),
                new FootballPlayerInfoViewModel(22, "Asamoah Gyan", "Sunderland", 2, 8, 6, 4, null),
                new FootballPlayerInfoViewModel(25, "Tim Cahill", "Everton", 6, 3, 5, 4, 8),
                new FootballPlayerInfoViewModel(25, "Charles N'Zogbia", "Wigan", 6, 3, 3, 6, 5),
                new FootballPlayerInfoViewModel(25, "Kenwyne Jones", "Stoke", 5, 4, 6, 3, 9),
                new FootballPlayerInfoViewModel(25, "Theo Walcott", "Arsenal", 6, 3, 4, 5, 3),
                new FootballPlayerInfoViewModel(25, "Roman Pavlyuchenko", "Spurs", 4, 5, 6, 3, 5),
                new FootballPlayerInfoViewModel(25, "Nani", "Man Utd", 4, 5, 7, 2, 4),
                new FootballPlayerInfoViewModel(25, "Hugo Rodallega", "Wigan", 2, 7, 5, 4, 10),
                new FootballPlayerInfoViewModel(32, "Kevin Davies", "Bolton", 5, 3, 5, 3, 7),
                new FootballPlayerInfoViewModel(32, "Craig Gardner", "Birmingham", 0, 8, 6, 2, 1),
                new FootballPlayerInfoViewModel(32, "Daniel Sturridge", "Bolton", 3, 5, 5, 3, 1),
                new FootballPlayerInfoViewModel(32, "Jermaine Beckford", "Everton", 3, 5, 5, 3, null),
                new FootballPlayerInfoViewModel(36, "Louis Saha", "Everton", 3, 4, 6, 1, 13),
                new FootballPlayerInfoViewModel(36, "Stewart Downing", "Aston Villa", 6, 1, 5, 2, 2),
                new FootballPlayerInfoViewModel(36, "Sylvan Ebanks-Blake", "Wolves", 1, 6, 4, 3, 2),
                new FootballPlayerInfoViewModel(36, "Ashley Young", "Aston Villa", 3, 4, 5, 2, 5),
                new FootballPlayerInfoViewModel(36, "Marouane Chamakh", "Arsenal", 2, 5, 4, 3, null),
                new FootballPlayerInfoViewModel(36, "Gareth Bale", "Spurs", 4, 3, 4, 3, 3),
                new FootballPlayerInfoViewModel(36, "Demba Ba", "West Ham", 5, 2, 2, 5, null),
            };
        }

        public List<FootballPlayerInfoViewModel> FootballPlayerInfos
        {
            get;
            private set;
        }
               
        public int MaxTotalGoalsCount
        {
            get { return this.FootballPlayerInfos.Max(info => info.TotalGoalsCount); }
            
        }
    }
}
