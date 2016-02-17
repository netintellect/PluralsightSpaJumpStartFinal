using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    /// <summary>
    /// Interaction logic for Regions.xaml
    /// </summary>
    public partial class Regions : UserControl
    {
        private List<string> selectedRegions = new List<string>();
        public event EventHandler SelectionChanged;

        public Regions()
        {
            InitializeComponent();
            this.Loaded += this.Regions_Loaded;
        }

        void Regions_Loaded(object sender, RoutedEventArgs e)
        {
            this.HandleRegionClicked("latin");
            this.HandleRegionClicked("eurasia");
            this.HandleRegionClicked("pacific");
        }

        public List<string> GetSelectedRegions()
        {
            return new List<string>(this.selectedRegions);
        }

        private void HandleMouseEnterRegion(string regionName)
        {
            if (this.selectedRegions.Contains(regionName))
            {
                return;
            }

            Image image = this.GetImage(regionName);
            image.Opacity = 0.7;
        }

        private void HandleMouseLeaveRegion(string regionName)
        {
            if (this.selectedRegions.Contains(regionName))
            {
                return;
            }

            Image image = this.GetImage(regionName);
            image.Opacity = 0;
        }

        private Image GetImage(string regionName)
        {
            switch (regionName)
            {
                case "latin": return this.ImageLatinAmericaMap;
                case "north": return this.ImageNorthAmericaMap;
                case "eurasia": return this.ImageEurasiaMap;
                case "europe": return this.ImageEuropeMap;
                case "pacific": return this.ImagePacificMap;
                default: return null;
            }
        }

        private void HandleRegionClicked(string regionName)
        {
            Image image = this.GetImage(regionName);
            if (this.selectedRegions.Contains(regionName))
            {
                if (this.selectedRegions.Count >= 2)
                {
                    this.selectedRegions.Remove(regionName);
                    image.Opacity = 0.7;
                }
            }
            else
            {
                this.selectedRegions.Add(regionName);
                image.Opacity = 1;
            }

            this.RaiseSelectionChanged();
        }

        private void RaiseSelectionChanged()
        {
            EventHandler handler = this.SelectionChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void Path_MouseEnter(object sender, MouseEventArgs e)
        {
            this.HandleMouseEnterRegion(((Path)sender).Tag as string);
        }

        private void Path_MouseLeave(object sender, MouseEventArgs e)
        {
            this.HandleMouseLeaveRegion(((Path)sender).Tag as string);
        }

        private void Path_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string regionName = ((Path)sender).Tag as string;
            this.HandleRegionClicked(regionName);
        }
    }
}
