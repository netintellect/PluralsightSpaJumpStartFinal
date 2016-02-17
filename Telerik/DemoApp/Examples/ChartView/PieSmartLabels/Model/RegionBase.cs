namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    public abstract class RegionBase
    {
        public string Name { get; set; }
        public string ColorRegionName { get; set; }
        public virtual double UnitCaseVolume { get; set; }
        public abstract string Label { get; }
    }
}
