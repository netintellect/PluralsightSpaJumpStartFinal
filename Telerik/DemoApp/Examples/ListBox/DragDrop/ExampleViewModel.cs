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
using Telerik.Windows.Controls;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.ListBox.DragDrop
{
	public class ExampleViewModel : ViewModelBase
	{
		ObservableCollection<Country> countryList = new ObservableCollection<Country>();

		public ExampleViewModel()
		{
			this.GroupA = new ObservableCollection<Country>();
			this.GroupB = new ObservableCollection<Country>();
			this.GroupC = new ObservableCollection<Country>();
			this.GroupD = new ObservableCollection<Country>();
		}

		public ObservableCollection<Country> CountryList
		{
			get
			{
				this.countryList.Add(new Country { CountryName = "Portugal", CountryFlag = new Uri("../Images/ListBox/DragDrop/pt.png", UriKind.RelativeOrAbsolute)});
				this.countryList.Add(new Country { CountryName = "Germany", CountryFlag = new Uri("../Images/ListBox/DragDrop/de.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Spain", CountryFlag = new Uri("../Images/ListBox/DragDrop/es.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Italy", CountryFlag = new Uri("../Images/ListBox/DragDrop/it.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Ukraine", CountryFlag = new Uri("../Images/ListBox/DragDrop/ua.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Sweden", CountryFlag = new Uri("../Images/ListBox/DragDrop/se.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "France", CountryFlag = new Uri("../Images/ListBox/DragDrop/fr.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "England", CountryFlag = new Uri("../Images/ListBox/DragDrop/gb.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Netherland", CountryFlag = new Uri("../Images/ListBox/DragDrop/nl.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Russia", CountryFlag = new Uri("../Images/ListBox/DragDrop/ru.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Denmark", CountryFlag = new Uri("../Images/ListBox/DragDrop/dk.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Croatia", CountryFlag = new Uri("../Images/ListBox/DragDrop/cr.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Czech Republic", CountryFlag = new Uri("../Images/ListBox/DragDrop/cz.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Poland", CountryFlag = new Uri("../Images/ListBox/DragDrop/pl.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Greece", CountryFlag = new Uri("../Images/ListBox/DragDrop/gr.png", UriKind.RelativeOrAbsolute) });
				this.countryList.Add(new Country { CountryName = "Republic of Ireland", CountryFlag = new Uri("../Images/ListBox/DragDrop/ie.png", UriKind.RelativeOrAbsolute) });
				
				return this.countryList;
			}
		}

		public ObservableCollection<Country> GroupA
		{
			get;
			set;
		}

		public ObservableCollection<Country> GroupB
		{
			get;
			set;
		}

		public ObservableCollection<Country> GroupC
		{
			get;
			set;
		}

		public ObservableCollection<Country> GroupD
		{
			get;
			set;
		}

	}
}
