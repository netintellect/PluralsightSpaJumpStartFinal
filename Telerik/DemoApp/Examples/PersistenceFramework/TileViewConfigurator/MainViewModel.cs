using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.PersistenceFramework.TileViewConfigurator
{
	public class MainViewModel
	{
		private static List<string> Images = new List<string>
		{
#if SILVERLIGHT
			"../../Images/PersistenceFramework/TileViewConfigurator/pic1.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic2.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic3.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic4.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic5.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic6.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic7.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic8.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic9.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic10.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic11.png",
			"../../Images/PersistenceFramework/TileViewConfigurator/pic12.png"
#else
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic1.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic2.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic3.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic4.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic5.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic6.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic7.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic8.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic9.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic10.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic11.png",
			"/PersistenceFramework;component/Images/PersistenceFramework/TileViewConfigurator/pic12.png"
#endif
		};

		private static List<string> Names = new List<string>
		{
			"Andrew Fuller",
			"Martin Sommer",
			"Anne Dogsworth",
			"Steven Buchanan",
			"Janet Leverling",
			"Michael Suyama",
			"Margaret Peacock",	
			"Robert King",
			"John Steel",
			"Laura Gallahan",
			"Nancy Davolio",
			"Ann Devon"
		};

		private static List<string> Emails = new List<string>
		{
			"Andrew@somemail.com",
			"Martin@somemail.com",
			"Anne@somemail.com",
			"Steven@somemail.com",
			"Janet@somemail.com",
			"Michael@somemail.com",
			"Margaret@somemail.com",	
			"Robert@somemail.com",
			"John@somemail.com",
			"Laura@somemail.com",
			"Nancy@somemail.com",
			"Ann@somemail.com"
		};
		private ObservableCollection<Person> items;

		private  string[] cities = new string[]{"London", "New York", "Paris", "Tokio", "Sofia", "Berlin"};
		private  string[] customers = new string[] { "CSC", "Toyota", "BMW", "Summit Partners", "Bank of America", "General Motors" };


		public MainViewModel()
		{
			List<Person> itemsSource = new List<Person>();
			for (int i = 0; i < 50; i++)
			{
				Person person = new Person()
				{
					Image = Images[i % 12],
					Name = Names[i % 12],
					Email = Emails[i % 12],
					Number = i.ToString()
				};
				itemsSource.Add(person);
			}

			this.items = new ObservableCollection<Person>(itemsSource);
		}

		public ObservableCollection<Person> Items
		{
			get
			{
				return this.items;
			}
		}
	}
}
