using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.Sparklines.WinLossChart
{
    public class PilotDataViewModel
    {
        private PilotData _data;

        public PilotData Data
        {
            get
            {
                return this._data;
            }
            set
            {
                if (this._data != value)
                {
                    this._data = value;
                }
            }
        }

        public IEnumerable<Race> PointsView
        {
            get
            {
                return from race in Data.Points
                       select (race.HasCompeted && race.Points == 0d) ? new Race(-1d) : race;
            }
        }

        public double? PointsSum
        {
            get
            {
                return (from race in Data.Points
                        where race.HasCompeted
                        select race.Points).Sum();
            }
        }
    }
}
