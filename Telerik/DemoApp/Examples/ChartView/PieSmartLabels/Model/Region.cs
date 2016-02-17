using System;
using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    public class Region : RegionBase
    {
        public List<Subregion> Subregions { get; set; }
        public List<Revenue> Revenues { get; set; }

        public override double UnitCaseVolume
        {
            get
            {
                return this.Subregions.Sum(subregion => subregion.UnitCaseVolume);
            }
        }

        public override string Label
        {
            get
            {
                return string.Format("{0}{1}{2:#0%}", this.Name, Environment.NewLine, this.UnitCaseVolume);
            }
        }
    }
}
