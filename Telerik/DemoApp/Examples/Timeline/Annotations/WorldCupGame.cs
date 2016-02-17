using System;
using System.ComponentModel;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Timeline.Annotations
{
    public class WorldCupGame : INotifyPropertyChanged
    {
        private Brush groupBrush;

        public WorldCupGame()
        {
            // default brush
            this.GroupBrush = new SolidColorBrush(Color.FromArgb(255, 118, 118, 118));
        }

        public string Venue
        {
            get;
            set;
        }

        public DateTime MatchDate
        {
            get;
            set;
        }

        public string Team1
        {
            get;
            set;
        }

        public string Team2
        {
            get;
            set;
        }

        public int MatchNumber 
        { 
            get; 
            set; 
        }

        public string Group
        {
            get;
            set;
        }

        public string MatchHeader
        {
            get
            {
                return string.Format("{0} - {1} ({2})", this.Team1, this.Team2, this.MatchNumber);
            }
        }

        public string ToolTipHeader
        {
            get
            {
                return string.Format("Match #{0} of 64", this.MatchNumber);
            }
        }

        public Brush GroupBrush
        {
            get
            {
                return this.groupBrush;
            }
            set
            {
                if (this.groupBrush != value)
                {
                    this.groupBrush = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("GroupBrush"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, args);
            }
        }
    }
}
