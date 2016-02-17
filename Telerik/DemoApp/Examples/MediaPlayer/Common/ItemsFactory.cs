using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Examples.MediaPlayer.CS.Silverlight.Common
{
    public static class ItemsFactory
    {
        public static ObservableCollection<MediaItem> GetItems()
        {
            MediaItem item1 = new MediaItem
            {
                Source = "http://773649a1298f63779f19-68dcd217a70edadad8c7b04ba4a904f0.r12.cf2.rackcdn.com/XAMLflix_ChartView_Getting-Started_Using-RadCartesianChart-for-Silverlight-and-WPF.mp4",
                Title = "Getting started using RadCartesianChart for Silverlight and WPF",
                Image = "../Images/MediaPlayer/RadCartesianChart5.png"
            };
            item1.Chapters = new List<Chapter>(){
				new Chapter{Title = "Defining Telerik RadCartesianChart grid", Position = new TimeSpan(0, 1, 15), Parent = item1},
				new Chapter{Title = "Defining Telerik RadCartesianChart axes", Position = new TimeSpan(0, 2, 14), Parent = item1},
                new Chapter{Title = "Defining Telerik RadCartesianChart series", Position = new TimeSpan(0, 3, 08), Parent = item1},
                new Chapter{Title = "Populating with data", Position = new TimeSpan(0, 4, 18), Parent = item1},
                new Chapter{Title = "Result", Position = new TimeSpan(0, 6, 51), Parent = item1},
			};

            MediaItem item2 = new MediaItem
            {
                Source = "http://773649a1298f63779f19-68dcd217a70edadad8c7b04ba4a904f0.r12.cf2.rackcdn.com/XAMLflix_ChartView_Getting-Started_Using-RadPolarChart-for-Silverlight-and-WPF.mp4",
                Title = "Getting started using RadPolarChart for Silverlight and WPF",
                Image = "../Images/MediaPlayer/RadPolarChart5.png"
            };
            item2.Chapters = new List<Chapter>(){
				new Chapter{Title = "Defining Telerik RadPolarChart grid", Position = new TimeSpan(0, 1, 02), Parent = item2},
				new Chapter{Title = "Defining Telerik RadPolarChart axes", Position = new TimeSpan(0, 1, 45), Parent = item2},
                new Chapter{Title = "Defining Telerik RadPolarChart series", Position = new TimeSpan(0, 2, 27), Parent = item2},
                new Chapter{Title = "Populating with data", Position = new TimeSpan(0, 3, 01), Parent = item2},
                new Chapter{Title = "Result", Position = new TimeSpan(0, 4, 53), Parent = item2},
			};

            MediaItem item3 = new MediaItem
            {
                Source = "http://773649a1298f63779f19-68dcd217a70edadad8c7b04ba4a904f0.r12.cf2.rackcdn.com/XAMLflix_Map_Getting-Started_Getting-Started-with-RadMap.mp4",
                Title = "Getting started with RadMap",
                Image = "../Images/MediaPlayer/RadMap1.png"
            };

            MediaItem item4 = new MediaItem
            {
                Source = "http://773649a1298f63779f19-68dcd217a70edadad8c7b04ba4a904f0.r12.cf2.rackcdn.com/XAMLflix_ScheduleView_Getting-Started_Getting-Started-with-RadScheduleView-for-Silverlight-and-WPF.mp4",
                Title = "Getting started with RadScheduleView for Silverlight and WPF",
                Image = "../Images/MediaPlayer/RadScheduleView1.png"
            };

            MediaItem item5 = new MediaItem
            {
                Source = "http://773649a1298f63779f19-68dcd217a70edadad8c7b04ba4a904f0.r12.cf2.rackcdn.com/XAMLflix_GanttView_Getting-Started_Getting-Started-with-RadGanttView.mp4",
                Title = "Getting started with RadGanttView",
                Image = "../Images/MediaPlayer/RadGanttView1.png"
            };

            ObservableCollection<MediaItem> items = new ObservableCollection<MediaItem>();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);

            return items;
        }
    }
}
