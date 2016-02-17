using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.HeatMap.CellLabels
{
    public partial class Example : UserControl
    {
        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/HeatMap;component/FirstLook/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/HeatMap;component/FirstLook/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }

            InitializeComponent();

            var data = this.GetData();
            this.DataContext = data;
        }

        private List<PlotInfo> GetData()
        {
            var data = new List<PlotInfo>();

            data.Add(new PlotInfo("Parksley","January", 103));
            data.Add(new PlotInfo("Parksley", "February", 78));
            data.Add(new PlotInfo("Parksley", "March", 89));
            data.Add(new PlotInfo("Parksley", "April", 88));
            data.Add(new PlotInfo("Parksley", "May", 89));
            data.Add(new PlotInfo("Parksley", "June", 102));
            data.Add(new PlotInfo("Parksley", "July", 90));
            data.Add(new PlotInfo("Parksley", "August", 108));
            data.Add(new PlotInfo("Parksley", "September", 98));
            data.Add(new PlotInfo("Parksley", "October", 81));
            data.Add(new PlotInfo("Parksley", "November", 88));
            data.Add(new PlotInfo("Parksley", "December", 99));

            data.Add(new PlotInfo("Oak Hall", "January",  103));
            data.Add(new PlotInfo("Oak Hall","February",  85));
            data.Add(new PlotInfo("Oak Hall","March",  84));
            data.Add(new PlotInfo("Oak Hall","April",  91));
            data.Add(new PlotInfo("Oak Hall", "May", 96));
            data.Add(new PlotInfo( "Oak Hall","June", 87));
            data.Add(new PlotInfo( "Oak Hall","July", 97));
            data.Add(new PlotInfo("Oak Hall","August",  81));
            data.Add(new PlotInfo("Oak Hall","September",  60));
            data.Add(new PlotInfo("Oak Hall", "October", 82));
            data.Add(new PlotInfo( "Oak Hall","November", 78));
            data.Add(new PlotInfo( "Oak Hall","December", 70));

            data.Add(new PlotInfo("Chincoteague", "January", 66));
            data.Add(new PlotInfo( "Chincoteague","February", 56));
            data.Add(new PlotInfo("Chincoteague","March",  48));
            data.Add(new PlotInfo("Chincoteague","April",  53));
            data.Add(new PlotInfo("Chincoteague", "May", 87));
            data.Add(new PlotInfo( "Chincoteague","June", 85));
            data.Add(new PlotInfo( "Chincoteague","July", 100));
            data.Add(new PlotInfo("Chincoteague","August",  107));
            data.Add(new PlotInfo("Chincoteague","September",  87));
            data.Add(new PlotInfo("Chincoteague", "October", 72));
            data.Add(new PlotInfo( "Chincoteague","November", 48));
            data.Add(new PlotInfo( "Chincoteague","December", 57));

            data.Add(new PlotInfo("Melfa","January",  71));
            data.Add(new PlotInfo( "Melfa","February", 54));
            data.Add(new PlotInfo("Melfa", "March", 68));
            data.Add(new PlotInfo("Melfa", "April", 60));
            data.Add(new PlotInfo("Melfa", "May", 67));
            data.Add(new PlotInfo( "Melfa","June", 68));
            data.Add(new PlotInfo( "Melfa","July", 60));
            data.Add(new PlotInfo("Melfa","August",  62));
            data.Add(new PlotInfo("Melfa","September",  61));
            data.Add(new PlotInfo("Melfa", "October", 68));
            data.Add(new PlotInfo( "Melfa","November", 89));
            data.Add(new PlotInfo( "Melfa","December", 76));

            data.Add(new PlotInfo("Bloxom", "January", 64));
            data.Add(new PlotInfo( "Bloxom","February", 52));
            data.Add(new PlotInfo("Bloxom","March",  56));
            data.Add(new PlotInfo("Bloxom","April",  50));
            data.Add(new PlotInfo("Bloxom", "May", 58));
            data.Add(new PlotInfo( "Bloxom","June", 64));
            data.Add(new PlotInfo( "Bloxom","July", 86));
            data.Add(new PlotInfo("Bloxom","August",  59));
            data.Add(new PlotInfo("Bloxom","September",  66));
            data.Add(new PlotInfo("Bloxom", "October", 55));
            data.Add(new PlotInfo( "Bloxom","November", 49));
            data.Add(new PlotInfo( "Bloxom","December", 54));

            data.Add(new PlotInfo("Onancock", "January", 42));
            data.Add(new PlotInfo( "Onancock","February", 51));
            data.Add(new PlotInfo( "Onancock","March", 51));
            data.Add(new PlotInfo( "Onancock","April", 41));
            data.Add(new PlotInfo("Onancock", "May", 42));
            data.Add(new PlotInfo( "Onancock","June", 58));
            data.Add(new PlotInfo( "Onancock","July", 55));
            data.Add(new PlotInfo("Onancock","August",  38));
            data.Add(new PlotInfo("Onancock","September",  46));
            data.Add(new PlotInfo("Onancock", "October", 43));
            data.Add(new PlotInfo( "Onancock","November", 52));
            data.Add(new PlotInfo( "Onancock","December", 61));

            data.Add(new PlotInfo("Onley", "January", 38));
            data.Add(new PlotInfo( "Onley","February", 38));
            data.Add(new PlotInfo( "Onley","March", 24));
            data.Add(new PlotInfo( "Onley","April", 34));
            data.Add(new PlotInfo("Onley", "May", 46));
            data.Add(new PlotInfo( "Onley","June", 56));
            data.Add(new PlotInfo( "Onley","July", 49));
            data.Add(new PlotInfo("Onley","August",  49));
            data.Add(new PlotInfo( "Onley","September", 49));
            data.Add(new PlotInfo("Onley", "October", 48));
            data.Add(new PlotInfo( "Onley","November", 42));
            data.Add(new PlotInfo( "Onley","December", 48));

            data.Add(new PlotInfo("Community", "January", 17));
            data.Add(new PlotInfo( "Community","February", 5));
            data.Add(new PlotInfo("Community","March",  13));
            data.Add(new PlotInfo("Community","April",  20));
            data.Add(new PlotInfo("Community", "May", 16));
            data.Add(new PlotInfo( "Community","June", 13));
            data.Add(new PlotInfo( "Community","July", 17));
            data.Add(new PlotInfo("Community", "August", 17));
            data.Add(new PlotInfo("Community","September",  10));
            data.Add(new PlotInfo("Community", "October", 18));
            data.Add(new PlotInfo( "Community","November", 11));
            data.Add(new PlotInfo( "Community","December", 14));

            data.Add(new PlotInfo("Wachapreague", "January", 11));
            data.Add(new PlotInfo( "Wachapreague","February", 11));
            data.Add(new PlotInfo("Wachapreague","March",  10));
            data.Add(new PlotInfo("Wachapreague","April",  11));
            data.Add(new PlotInfo("Wachapreague", "May", 21));
            data.Add(new PlotInfo( "Wachapreague","June", 10));
            data.Add(new PlotInfo( "Wachapreague","July", 17));
            data.Add(new PlotInfo("Wachapreague","August",  11));
            data.Add(new PlotInfo("Wachapreague","September",  15));
            data.Add(new PlotInfo("Wachapreague", "October", 11));
            data.Add(new PlotInfo( "Wachapreague","November", 10));
            data.Add(new PlotInfo( "Wachapreague","December", 7));

            data.Add(new PlotInfo("Saxis", "January", 6));
            data.Add(new PlotInfo( "Saxis","February", 3));
            data.Add(new PlotInfo("Saxis","March",  7));
            data.Add(new PlotInfo("Saxis","April",  11));
            data.Add(new PlotInfo("Saxis", "May", 6));
            data.Add(new PlotInfo( "Saxis","June", 10));
            data.Add(new PlotInfo( "Saxis","July", 10));
            data.Add(new PlotInfo("Saxis","August",  11));
            data.Add(new PlotInfo( "Saxis","September", 14));
            data.Add(new PlotInfo("Saxis", "October", 8));
            data.Add(new PlotInfo( "Saxis","November", 8));
            data.Add(new PlotInfo( "Saxis","December", 24));

            data.Add(new PlotInfo("Greenbackville", "January", 13));
            data.Add(new PlotInfo( "Greenbackville","February", 13));
            data.Add(new PlotInfo("Greenbackville","March",  9));
            data.Add(new PlotInfo("Greenbackville","April",  11));
            data.Add(new PlotInfo("Greenbackville", "May", 11));
            data.Add(new PlotInfo( "Greenbackville","June", 12));
            data.Add(new PlotInfo( "Greenbackville","July", 6));
            data.Add(new PlotInfo("Greenbackville","August",  7));
            data.Add(new PlotInfo("Greenbackville","September",  10));
            data.Add(new PlotInfo("Greenbackville", "October", 5));
            data.Add(new PlotInfo( "Greenbackville","November", 12));
            data.Add(new PlotInfo( "Greenbackville","December", 8));

            data.Add(new PlotInfo("Tangier", "January", 13));
            data.Add(new PlotInfo( "Tangier","February", 11));
            data.Add(new PlotInfo("Tangier","March",  11));
            data.Add(new PlotInfo("Tangier","April",  11));
            data.Add(new PlotInfo("Tangier", "May", 8));
            data.Add(new PlotInfo( "Tangier","June", 7));
            data.Add(new PlotInfo( "Tangier","July", 8));
            data.Add(new PlotInfo("Tangier","August",  9));
            data.Add(new PlotInfo("Tangier", "September", 10));
            data.Add(new PlotInfo("Tangier", "October", 12));
            data.Add(new PlotInfo( "Tangier","November", 2));
            data.Add(new PlotInfo( "Tangier","December", 8));

            return data;
        }
    }
}