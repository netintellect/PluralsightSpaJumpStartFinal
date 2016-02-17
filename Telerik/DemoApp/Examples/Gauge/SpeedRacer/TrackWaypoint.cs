using System.Windows;

namespace Telerik.Windows.Examples.Gauge.SpeedRacer
{
    public class TrackWaypoint
    {
        public TrackWaypoint(Point position, double rpm)
        {
            this.Position = position;
            this.Rpm = rpm;
        }

        public Point Position
        {
            get;
            private set;
        }

        public double Rpm
        {
            get;
            private set;
        }
    }
}
