namespace Telerik.Windows.Examples.Sparklines.WinLossChart
{
    public class Race
    {
        private double? _points;

        public Race(double? points)
        {
            this._points = points;
        }

        public double? Points
        {
            get
            {
                return _points;
            }
        }

        public bool HasCompeted
        {
            get
            {
                return this._points.HasValue;
            }
        }
    }
}
