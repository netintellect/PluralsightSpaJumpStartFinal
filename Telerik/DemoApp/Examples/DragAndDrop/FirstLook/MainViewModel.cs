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

namespace Telerik.Windows.Examples.DragAndDrop.FirstLook
{
	public class MainViewModel
	{
		private ObservableCollection<ApplicationInfo> allApplications = GenerateApplicationInfos();
		private ObservableCollection<ApplicationInfo> myApplications = GenerateMyApplicationInfos();

		public ObservableCollection<ApplicationInfo> AllApplications
		{
			get
			{
				return this.allApplications;
			}
			set
			{
				this.allApplications = value;
			}
		}

		public ObservableCollection<ApplicationInfo> MyApplications
		{
			get
			{
				return this.myApplications;
			}
			set
			{
				this.myApplications = value;
			}
		}

		public static ObservableCollection<ApplicationInfo> GenerateApplicationInfos()
		{
			ObservableCollection<ApplicationInfo> result = new ObservableCollection<ApplicationInfo>();

			ApplicationInfo info1 = new ApplicationInfo();
			info1.Name = "Large Collider";
			info1.Author = "C.E.R.N.";
			info1.IconPath = @"../../Images/DragAndDrop/LargeIcons/Atom.png";
			result.Add(info1);

			ApplicationInfo info2 = new ApplicationInfo();
			info2.Name = "Paintbrush";
			info2.Author = "Imagine Inc.";
			info2.IconPath = @"../../Images/DragAndDrop/LargeIcons/Brush.png";
			result.Add(info2);

			ApplicationInfo info3 = new ApplicationInfo();
			info3.Name = "Lively Calendar";
			info3.Author = "Control AG";
			info3.IconPath = @"../../Images/DragAndDrop/LargeIcons/CalendarEvents.png";
			result.Add(info3);

			ApplicationInfo info4 = new ApplicationInfo();
			info4.Name = "Fire Burning ROM";
			info4.Author = "The CD Factory";
			info4.IconPath = @"../../Images/DragAndDrop/LargeIcons/CDBurn.png";
			result.Add(info4);

			ApplicationInfo info5 = new ApplicationInfo();
			info5.Name = "Fav Explorer";
			info5.Author = "Star Factory";
			info5.IconPath = @"../../Images/DragAndDrop/LargeIcons/favorites.png";
			result.Add(info5);

			ApplicationInfo info6 = new ApplicationInfo();
			info6.Name = "IE Fox";
			info6.Author = "Open Org";
			info6.IconPath = @"../../Images/DragAndDrop/LargeIcons/Connected.png";
			result.Add(info6);

			return result;
		}

		public static ObservableCollection<ApplicationInfo> GenerateMyApplicationInfos()
		{
			ObservableCollection<ApplicationInfo> result = new ObservableCollection<ApplicationInfo>();

			ApplicationInfo info7 = new ApplicationInfo();
			info7.Name = "Charting";
			info7.Author = "AA-AZ inc";
			info7.IconPath = @"../../Images/DragAndDrop/LargeIcons/ChartDot.png";
			result.Add(info7);

			ApplicationInfo info8 = new ApplicationInfo();
			info8.Name = "SuperPlay";
			info8.Author = "EB Games";
			info8.IconPath = @"../../Images/DragAndDrop/LargeIcons/Games.png";
			result.Add(info8);

			return result;
		}
	}
}
