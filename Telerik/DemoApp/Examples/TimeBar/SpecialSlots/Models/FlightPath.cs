using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.TimeBar.SpecialSlots
{
    public class FlightPath
    {
        public FlightPath(Airport from, Airport to)
        {
            this.From = from;
            this.To = to;
        }

        public Airport From { get; set; }
        public Airport To { get; set; }

        public Location DepartureLocation
        {
            get
            {
                return this.From.Location;
            }
        }

        public Location ArrivalLocation
        {
            get
            {
                return this.To.Location;
            }
        }
    }
}