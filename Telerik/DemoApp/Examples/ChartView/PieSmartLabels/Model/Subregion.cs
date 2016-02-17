namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    public class Subregion : RegionBase
    {
        public double Percent { get; set; }

        public override string Label
        {
            get
            {
                return string.Format("{0:#0%} {1}", this.Percent, this.Name);
            }
        }
    }
}
