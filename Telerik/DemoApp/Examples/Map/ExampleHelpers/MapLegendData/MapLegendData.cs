using System.Windows.Media;

namespace Examples.Map.CS
{
    public class MapLegendData
    {
        private string _legendLabel;
        private Brush _fill;
        private Brush _borderBrush;

        public MapLegendData()
        {
        }

        public MapLegendData(string label, Brush fillBrush)
        {
            this.LegendLabel = label;
            this.Fill = fillBrush;
        }

        public MapLegendData(string label, Brush fillBrush, Brush strokeBrush)
        {
            this.LegendLabel = label;
            this.Fill = fillBrush;
            this.BorderBrush = strokeBrush;
        }

        public string LegendLabel
        {
            get
            {
                return this._legendLabel;
            }
            set
            {
                this._legendLabel = value;
            }
        }

        public Brush Fill
        {
            get
            {
                return this._fill;
            }
            set
            {
                this._fill = value;
            }
        }

        public Brush BorderBrush
        {
            get
            {
                return this._borderBrush;
            }
            set
            {
                this._borderBrush = value;
            }
        }
    }
}
