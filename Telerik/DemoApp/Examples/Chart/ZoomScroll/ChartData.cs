
namespace Telerik.Windows.Examples.Chart.ZoomScroll
{
    public class ChartData
    {
        private int _xValue;
        private double _yValue;

        public ChartData(int xValue, double yValue)
        {
            this.XValue = xValue;
            this.YValue = yValue;
        }

        public int XValue
        {
            get
            {
                return this._xValue;
            }
            set
            {
                this._xValue = value;
            }
        }

        public double YValue
        {
            get
            {
                return this._yValue;
            }
            set
            {
                this._yValue = value;
            }
        }
    }
}
