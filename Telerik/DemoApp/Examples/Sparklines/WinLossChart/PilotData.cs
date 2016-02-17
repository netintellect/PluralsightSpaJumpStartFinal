using System.Collections.Generic;
namespace Telerik.Windows.Examples.Sparklines.WinLossChart
{
    public class PilotData
    {
        private string _name;
        private IEnumerable<Race> _points;

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                }
            }
        }

        public IEnumerable<Race> Points
        {
            get
            {
                return this._points;
            }
            set
            {
                if (this._points != value)
                {
                    this._points = value;
                }
            }
        }
    }
}
