using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TreeView.HierarchicalTemplate
{
	public class MainViewModel : ViewModelBase
	{
		public ObservableCollection<OlympicGame> OlympicGames{get;private set;}

		public MainViewModel()
		{
			OlympicGame saltLake = new OlympicGame();
			saltLake.Name = "2002 Salt Lake";
			saltLake.Description = "The 2002 Winter Olympics, officially the XIX Olympic Winter Games, were a winter multi-sport event " +
					"that was celebrated in February 2002 in and around Salt Lake City, Utah, United States. " +
					"Approximately 2,400 athletes from 77 nations participated in 78 events in fifteen disciplines, held throughout 165 sporting sessions. " +
					" It was the most successful of all.";
			saltLake.IsSelected = true;
			saltLake.IsExpanded = true;
			saltLake[MedalType.Gold].CountryMedals.Add(new CountryMedal("Norway", 13, "../Images/TreeView/Flags/Norway.png"));
			saltLake[MedalType.Gold].CountryMedals.Add(new CountryMedal("Germany", 12, "../Images/TreeView/Flags/Image8.png"));
			saltLake[MedalType.Gold].CountryMedals.Add(new CountryMedal("United States", 10, "../Images/TreeView/Flags/Image2.png"));

			saltLake[MedalType.Silver].CountryMedals.Add(new CountryMedal("Germany", 16, "../Images/TreeView/Flags/Image8.png"));
			saltLake[MedalType.Silver].CountryMedals.Add(new CountryMedal("United States", 13, "../Images/TreeView/Flags/Image2.png"));
			saltLake[MedalType.Silver].CountryMedals.Add(new CountryMedal("Norway", 5, "../Images/TreeView/Flags/Norway.png"));

			saltLake[MedalType.Bronze].CountryMedals.Add(new CountryMedal("United States", 11, "../Images/TreeView/Flags/Image2.png"));
			saltLake[MedalType.Bronze].CountryMedals.Add(new CountryMedal("Austria", 10, "../Images/TreeView/Flags/Austria.png"));
			saltLake[MedalType.Bronze].CountryMedals.Add(new CountryMedal("Germany", 8, "../Images/TreeView/Flags/Image8.png"));

			OlympicGame athens = new OlympicGame();
			athens.Name = "2004 Athens";
			athens.Description = "The 2004 Summer Olympic Games, officially known as the Games of the XXVIII Olympiad, " +
					"was a premier international multi-sport event held in Athens, Greece from August 13 to August 29, 2004 with the motto Welcome Home. " +
					"10,625 athletes competed,some 600 more than expected, accompanied by 5,501 team officials from 201 countries.";

			athens[MedalType.Gold].CountryMedals.Add(new CountryMedal("United States", 35, "../Images/TreeView/Flags/Image2.png"));
			athens[MedalType.Gold].CountryMedals.Add(new CountryMedal("China", 32, "../Images/TreeView/Flags/China.png"));
			athens[MedalType.Gold].CountryMedals.Add(new CountryMedal("Russia", 28, "../Images/TreeView/Flags/Russia.png"));

			athens[MedalType.Silver].CountryMedals.Add(new CountryMedal("United States", 39, "../Images/TreeView/Flags/Image2.png"));
			athens[MedalType.Silver].CountryMedals.Add(new CountryMedal("Russia", 26, "../Images/TreeView/Flags/Russia.png"));
			athens[MedalType.Silver].CountryMedals.Add(new CountryMedal("China", 17, "../Images/TreeView/Flags/China.png"));

			athens[MedalType.Bronze].CountryMedals.Add(new CountryMedal("Russia", 38, "../Images/TreeView/Flags/Russia.png"));
			athens[MedalType.Bronze].CountryMedals.Add(new CountryMedal("United States", 29, "../Images/TreeView/Flags/Image2.png"));
			athens[MedalType.Bronze].CountryMedals.Add(new CountryMedal("Germany", 20, "../Images/TreeView/Flags/Image8.png"));

			OlympicGame torino = new OlympicGame();
			torino.Name = "2006 Torino";
			torino.Description = "The 2006 Winter Olympics, officially known as the XX Olympic Winter Games, was a winter multi-sport event " +
					"which was celebrated in Turin, Italy from February 10, 2006, through February 26, 2006.";

			torino[MedalType.Gold].CountryMedals.Add(new CountryMedal("Germany", 11, "../Images/TreeView/Flags/Image8.png"));
			torino[MedalType.Gold].CountryMedals.Add(new CountryMedal("United States", 9, "../Images/TreeView/Flags/Image2.png"));
			torino[MedalType.Gold].CountryMedals.Add(new CountryMedal("Austria", 9, "../Images/TreeView/Flags/Austria.png"));

			torino[MedalType.Silver].CountryMedals.Add(new CountryMedal("Germany", 12, "../Images/TreeView/Flags/Image8.png"));
			torino[MedalType.Silver].CountryMedals.Add(new CountryMedal("Canada", 10, "../Images/TreeView/Flags/Image10.png"));
			torino[MedalType.Silver].CountryMedals.Add(new CountryMedal("United States", 9, "../Images/TreeView/Flags/Image2.png"));

			torino[MedalType.Bronze].CountryMedals.Add(new CountryMedal("Russia", 8, "../Images/TreeView/Flags/Russia.png"));
			torino[MedalType.Bronze].CountryMedals.Add(new CountryMedal("Canada", 7, "../Images/TreeView/Flags/Image10.png"));
			torino[MedalType.Bronze].CountryMedals.Add(new CountryMedal("United States", 7, "../Images/TreeView/Flags/Image2.png"));

			OlympicGame beining = new OlympicGame();
			beining.Name = "2008 Beijing";
			beining.Description = "The 2008 Summer Olympics, officially known as the Games of the XXIX Olympiad, " +
					"was a major international multi-sport event that took place in Beijing, China, from August 8 to August 24, 2008.";

			beining[MedalType.Gold].CountryMedals.Add(new CountryMedal("China", 51, "../Images/TreeView/Flags/China.png"));
			beining[MedalType.Gold].CountryMedals.Add(new CountryMedal("United States", 36, "../Images/TreeView/Flags/Image2.png"));
			beining[MedalType.Gold].CountryMedals.Add(new CountryMedal("Russia", 23, "../Images/TreeView/Flags/Russia.png"));

			beining[MedalType.Silver].CountryMedals.Add(new CountryMedal("United States", 38, "../Images/TreeView/Flags/Image2.png"));
			beining[MedalType.Silver].CountryMedals.Add(new CountryMedal("Russia", 21, "../Images/TreeView/Flags/Russia.png"));
			beining[MedalType.Silver].CountryMedals.Add(new CountryMedal("China", 21, "../Images/TreeView/Flags/China.png"));

			beining[MedalType.Bronze].CountryMedals.Add(new CountryMedal("United States", 36, "../Images/TreeView/Flags/Image2.png"));
			beining[MedalType.Bronze].CountryMedals.Add(new CountryMedal("Russia", 28, "../Images/TreeView/Flags/Russia.png"));
			beining[MedalType.Bronze].CountryMedals.Add(new CountryMedal("China", 28, "../Images/TreeView/Flags/China.png"));

			this.OlympicGames = new ObservableCollection<OlympicGame>();
			this.OlympicGames.Add(saltLake);
			this.OlympicGames.Add(athens);
			this.OlympicGames.Add(torino);
			this.OlympicGames.Add(beining);
		}
	}

	public class OlympicGame : NamedViewModel
	{
		public OlympicGame()
		{
			var medals = new List<MedalDistribution>();
			medals.Add(new MedalDistribution(MedalType.Gold, "../Images/TreeView/medal-gold.png"));
			medals.Add(new MedalDistribution(MedalType.Silver, "../Images/TreeView/medal-silver.png"));
			medals.Add(new MedalDistribution(MedalType.Bronze, "../Images/TreeView/medal-bronze.png"));
			this.MedalsInfo = medals;
		}

		public string Description { get; set; }

		public IEnumerable<MedalDistribution> MedalsInfo { get; private set; }

		public MedalDistribution this[MedalType medalType]
		{
			get
			{
				foreach (MedalDistribution medalinfo in this.MedalsInfo)
				{
					if (medalinfo.Type == medalType)
						return medalinfo;
				}
				return null;
			}
		}
	}

	public class MedalDistribution : NamedViewModel
	{
		public MedalDistribution(MedalType type, string imageUriString)
		{
			this.Type = type;
			this.CountryMedals = new List<CountryMedal>();
			this.Image = new BitmapImage(new Uri(imageUriString, UriKind.RelativeOrAbsolute));
		}

		public MedalType Type { get; set; }

		public List<CountryMedal> CountryMedals { get; private set; }
	}

	public class CountryMedal : NamedViewModel
	{
		public CountryMedal(string countryName, int medalCount, string imageUri)
		{
			this.Name = countryName;
			this.MedalCount = medalCount;
			this.Image = new BitmapImage(new Uri(imageUri, UriKind.RelativeOrAbsolute));
		}

		public int MedalCount { get; set; }
	}

	public class NamedViewModel : ViewModelBase
	{
		private bool isSelected;
		private bool isExpanded;

		public string Name { get; set; }

		public ImageSource Image { get; set; }

		public bool IsSelected
		{
			get
			{
				return this.isSelected;
			}
			set
			{
				if (this.isSelected != value)
				{
					this.isSelected = value;
					this.OnPropertyChanged("IsSelected");
				}
			}
		}

		public bool IsExpanded
		{
			get
			{
				return this.isExpanded;
			}
			set
			{
				if (this.isExpanded != value)
				{
					this.isExpanded = value;
					this.OnPropertyChanged("IsExpanded");
				}
			}
		}
	}

	public enum MedalType
	{
		Gold,
		Silver,
		Bronze
	}
}
