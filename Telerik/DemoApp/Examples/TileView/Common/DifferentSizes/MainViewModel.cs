using Telerik.Windows.Examples.TileView.Features.DifferentSizes;
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
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TileView.Features.DifferentSizes
{
	public class MainViewModel : ViewModelBase
	{
		private ObservableCollection<ImagePair> items;
		private ObservableCollection<ImagePair> backgounds;
		private ImagePair selectedPair;
		private DelegateCommand selectNextPerson;
		private DelegateCommand selectPreviousPerson;

		public MainViewModel()
		{
			this.items = new ObservableCollection<ImagePair>();
			for (int i = 0; i < 8; i++)
			{
				this.items.Add(new ImagePair()
				{
					SmallImage = this.simages[i],
					LargeImage = this.limages[i],
				});
			}

			this.backgounds = new ObservableCollection<ImagePair>();
			for (int i = 0; i < 4; i++)
			{
				this.backgounds.Add(new ImagePair()
				{
					SmallImage = this.simages[8 + i],
					LargeImage = this.limages[8 + i],
				});
			}

			this.selectNextPerson = new DelegateCommand(new Action<object>(SelectNext), new Predicate<object>(CanSelectNext));
			this.selectPreviousPerson = new DelegateCommand(new Action<object>(SelectPrevious), new Predicate<object>(CanSelectPrevious));
			this.SelectedPair = this.Items[0];
		}

		public ObservableCollection<ImagePair> Items
		{
			get
			{
				return this.items;
			}
		}
		public ObservableCollection<ImagePair> Backgounds
		{
			get
			{
				return this.backgounds;
			}
		}
		public ImagePair SelectedPair
		{
			get
			{
				return this.selectedPair;
			}
			set
			{
				if (this.selectedPair != value)
				{
					this.selectedPair = value;
					this.OnPropertyChanged("SelectedPair");
					this.SelectNextPerson.InvalidateCanExecute();
					this.SelectPreviousPerson.InvalidateCanExecute();
				}
			}
		}
		public DelegateCommand SelectPreviousPerson
		{
			get
			{
				return this.selectPreviousPerson;
			}
		}
		public DelegateCommand SelectNextPerson
		{
			get
			{
				return this.selectNextPerson;
			}
		}

		private List<string> simages = new List<string>()
		{
#if SILVERLIGHT
			"../../Images/TileView/DifferentSizes/Small/1.png",
			"../../Images/TileView/DifferentSizes/Small/2.png",
			"../../Images/TileView/DifferentSizes/Small/3.png",
			"../../Images/TileView/DifferentSizes/Small/4.png",
			"../../Images/TileView/DifferentSizes/Small/5.png",
			"../../Images/TileView/DifferentSizes/Small/6.png",
			"../../Images/TileView/DifferentSizes/Small/7.png",
			"../../Images/TileView/DifferentSizes/Small/8.png",
			"../../Images/TileView/DifferentSizes/Small/BG0.png",
			"../../Images/TileView/DifferentSizes/Small/BG1.png",
			"../../Images/TileView/DifferentSizes/Small/BG2.png",
			"../../Images/TileView/DifferentSizes/Small/BG3.png",
#else
			"/TileView;component/Images/TileView/DifferentSizes/Small/1.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/2.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/3.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/4.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/5.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/6.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/7.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/8.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/BG0.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/BG1.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/BG2.png",
			"/TileView;component/Images/TileView/DifferentSizes/Small/BG3.png",
#endif
		};

		private List<string> limages = new List<string>()
		{
#if SILVERLIGHT
			"../../Images/TileView/DifferentSizes/Large/1.png",
			"../../Images/TileView/DifferentSizes/Large/2.png",
			"../../Images/TileView/DifferentSizes/Large/3.png",
			"../../Images/TileView/DifferentSizes/Large/4.png",
			"../../Images/TileView/DifferentSizes/Large/5.png",
			"../../Images/TileView/DifferentSizes/Large/6.png",
			"../../Images/TileView/DifferentSizes/Large/7.png",
			"../../Images/TileView/DifferentSizes/Large/8.png",
			"../../Images/TileView/DifferentSizes/Large/BG0.png",
			"../../Images/TileView/DifferentSizes/Large/BG1.png",
			"../../Images/TileView/DifferentSizes/Large/BG2.png",
			"../../Images/TileView/DifferentSizes/Large/BG3.png",
#else
			"/TileView;component/Images/TileView/DifferentSizes/Large/1.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/2.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/3.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/4.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/5.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/6.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/7.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/8.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/BG0.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/BG1.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/BG2.png",
			"/TileView;component/Images/TileView/DifferentSizes/Large/BG3.png",
#endif
		};

		private bool CanSelectNext(object target)
		{
			return this.items.IndexOf(this.SelectedPair) < this.items.Count - 1;
		}

		private void SelectNext(object target)
		{
			int selectedIndex = this.items.IndexOf(this.SelectedPair);
			this.SelectedPair = this.items[selectedIndex + 1];
		}

		private bool CanSelectPrevious(object target)
		{
			return this.items.IndexOf(this.SelectedPair) > 0;
		}

		private void SelectPrevious(object target)
		{
			int selectedIndex = this.items.IndexOf(this.SelectedPair);
			this.SelectedPair = this.items[selectedIndex - 1];
		}
	}
}
