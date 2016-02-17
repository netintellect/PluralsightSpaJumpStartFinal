using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Legend;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    public class ExampleViewModel : ViewModelBase
    {
        private IEnumerable<RegionBase> expandedRegions;

        public ExampleViewModel()
        {
            this.Regions = this.GetData();
            this.SelectedRegions = new ObservableCollection<Region>();
            this.SelectedRegions.CollectionChanged += this.selectedRegions_CollectionChanged;

            this.SelectedRegions.Add(this.Regions.First());
        }

        void selectedRegions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.UpdateExpandedRegions();
        }

        public IEnumerable<Region> Regions { get; private set; }

        public ObservableCollection<Region> SelectedRegions { get; private set; }

        public IEnumerable<RegionBase> ExpandedRegions
        {
            get { return this.expandedRegions; }
            set
            {
                if (this.expandedRegions != value)
                {
                    this.expandedRegions = value;
                    this.OnPropertyChanged("ExpandedRegions");
                }
            }
        }

        private void UpdateExpandedRegions()
        {
            List<RegionBase> expandedRegions = new List<RegionBase>();
            foreach (Region region in this.Regions)
            {
                if (this.SelectedRegions.Contains(region))
                {
                    expandedRegions.AddRange(region.Subregions);
                }
                else
                {
                    expandedRegions.Add(region);
                }
            }

            this.ExpandedRegions = expandedRegions;
        }

        private List<Region> GetData()
        {
            List<Region> regions = new List<Region>();

            regions.Add(this.CreateLatinAmericaRegion());
            regions.Add(this.CreateNorthAmericaRegion());
            regions.Add(this.CreateEurasiaAndAfricaRegion());
            regions.Add(this.CreatePacificRegion());
            regions.Add(this.CreateEuropeRegion());

            return regions;
        }

        private Region CreatePacificRegion()
        {
            Region region = new Region();

            region.Name = "Pacific";
            region.ColorRegionName = region.Name;

            region.Subregions = new List<Subregion> {
                new Subregion() { ColorRegionName = "Pacific", Name = "China", UnitCaseVolume = 0.0792 },
                new Subregion() { ColorRegionName = "Pacific", Name = "Japan", UnitCaseVolume = 0.0342 },
                new Subregion() { ColorRegionName = "Pacific", Name = "Other", UnitCaseVolume = 0.0252 },
                new Subregion() { ColorRegionName = "Pacific", Name = "Philippines", UnitCaseVolume = 0.0198 },
                new Subregion() { ColorRegionName = "Pacific", Name = "Australia", UnitCaseVolume = 0.0108 },
                new Subregion() { ColorRegionName = "Pacific", Name = "Thailand", UnitCaseVolume = 0.0108 }
            };
            region.Revenues = new List<Revenue>()
            {
                new Revenue() { ColorRegionName = region.Name, Year = 2010, RevenueValue = 2048 },
                new Revenue() { ColorRegionName = region.Name, Year = 2011, RevenueValue = 2151 },
                new Revenue() { ColorRegionName = region.Name, Year = 2012, RevenueValue = 2425 }
            };

            this.UpdateSubregionPercents(region);
            return region;
        }

        private Region CreateEurasiaAndAfricaRegion()
        {
            Region region = new Region();

            region.Name = "Eurasia & Africa";
            region.ColorRegionName = region.Name;

            region.Subregions = new List<Subregion> {
                new Subregion() { ColorRegionName = "Eurasia & Africa", Name = "Middle East & North Africa", UnitCaseVolume = 0.0486 },
                new Subregion() { ColorRegionName = "Eurasia & Africa", Name = "Central/East/West Africa", UnitCaseVolume = 0.0324 },
                new Subregion() { ColorRegionName = "Eurasia & Africa", Name = "India", UnitCaseVolume = 0.027 },
                new Subregion() { ColorRegionName = "Eurasia & Africa", Name = "Turkey", UnitCaseVolume = 0.0216 },
                new Subregion() { ColorRegionName = "Eurasia & Africa", Name = "South Africa", UnitCaseVolume = 0.0198 },
                new Subregion() { ColorRegionName = "Eurasia & Africa", Name = "Russia", UnitCaseVolume = 0.0162 },
                new Subregion() { ColorRegionName = "Eurasia & Africa", Name = "Other", UnitCaseVolume = 0.0144 }
            };
            region.Revenues = new List<Revenue>()
            {
                new Revenue() { ColorRegionName = region.Name, Year = 2010, RevenueValue = 980 },
                new Revenue() { ColorRegionName = region.Name, Year = 2011, RevenueValue = 1091 },
                new Revenue() { ColorRegionName = region.Name, Year = 2012, RevenueValue = 1169 }
            };

            this.UpdateSubregionPercents(region);
            return region;
        }

        private Region CreateEuropeRegion()
        {
            Region region = new Region();

            region.Name = "Europe";
            region.ColorRegionName = region.Name;

            region.Subregions = new List<Subregion> {
                new Subregion() { ColorRegionName = "Europe", Name = "Other", UnitCaseVolume = 0.028},
                new Subregion() { ColorRegionName = "Europe", Name = "Eastern Europe", UnitCaseVolume = 0.0266},
                new Subregion() { ColorRegionName = "Europe", Name = "Germany", UnitCaseVolume = 0.0238},
                new Subregion() { ColorRegionName = "Europe", Name = "Spain", UnitCaseVolume = 0.0196},
                new Subregion() { ColorRegionName = "Europe", Name = "Great Britain", UnitCaseVolume = 0.0182},
                new Subregion() { ColorRegionName = "Europe", Name = "France", UnitCaseVolume = 0.0126},
                new Subregion() { ColorRegionName = "Europe", Name = "Italy", UnitCaseVolume = 0.0112}
            };
            region.Revenues = new List<Revenue>()
            {
                new Revenue() { ColorRegionName = region.Name, Year = 2010, RevenueValue = 2976 },
                new Revenue() { ColorRegionName = region.Name, Year = 2011, RevenueValue = 3090 },
                new Revenue() { ColorRegionName = region.Name, Year = 2012, RevenueValue = 2960 }
            };

            this.UpdateSubregionPercents(region);
            return region;
        }

        private Region CreateLatinAmericaRegion()
        {
            Region region = new Region();

            region.Name = "Latin America";
            region.ColorRegionName = region.Name;

            region.Subregions = new List<Subregion> {
                new Subregion() { ColorRegionName = "Latin America", Name = "Mexico", UnitCaseVolume = 0.1276 },
                new Subregion() { ColorRegionName = "Latin America", Name = "Brazil", UnitCaseVolume = 0.0725 },
                new Subregion() { ColorRegionName = "Latin America", Name = "South Latin", UnitCaseVolume = 0.0522 },
                new Subregion() { ColorRegionName = "Latin America", Name = "Latin Center", UnitCaseVolume = 0.037 }
            };
            region.Revenues = new List<Revenue>()
            {
                new Revenue() { ColorRegionName = region.Name, Year = 2010, RevenueValue = 2405 },
                new Revenue() { ColorRegionName = region.Name, Year = 2011, RevenueValue = 2815 },
                new Revenue() { ColorRegionName = region.Name, Year = 2012, RevenueValue = 2879 }
            };

            this.UpdateSubregionPercents(region);
            return region;
        }

        private Region CreateNorthAmericaRegion()
        {
            Region region = new Region();

            region.Name = "North America";
            region.ColorRegionName = region.Name;

            region.Subregions = new List<Subregion> {
                new Subregion() { ColorRegionName = "North America", Name = "USA", UnitCaseVolume = 0.1974 },
                new Subregion() { ColorRegionName = "North America", Name = "Canada", UnitCaseVolume = 0.0126 }
            };
            region.Revenues = new List<Revenue>()
            {
                new Revenue() { ColorRegionName = region.Name, Year = 2010, RevenueValue = 1520 },
                new Revenue() { ColorRegionName = region.Name, Year = 2011, RevenueValue = 2319 },
                new Revenue() { ColorRegionName = region.Name, Year = 2012, RevenueValue = 2597 }
            };

            this.UpdateSubregionPercents(region);
            return region;
        }

        private void UpdateSubregionPercents(Region region)
        {
            double total = region.UnitCaseVolume;

            foreach (Subregion subregion in region.Subregions)
            {
                subregion.Percent = subregion.UnitCaseVolume / total;
            }
        }
    }
}
