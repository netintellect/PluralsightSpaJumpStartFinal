using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.CoverFlow.Integration
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();	
			
            List<DataItem> listDataItem = new List<DataItem>();

            DataItem tempDataItem = new DataItem();
            tempDataItem.ImageSource = new Uri("../Images/CoverFlow/Paris_1.jpg", UriKind.Relative);
			tempDataItem.Description = "Paris is the most popular tourist destination in the world with 45 million tourists annually. The city and region contain numerous iconic landmarks.";
            tempDataItem.Name = "Paris";
			tempDataItem.Country = GetCountry("Paris");
            listDataItem.Add(tempDataItem);

            tempDataItem = new DataItem();
			tempDataItem.ImageSource = new Uri("../Images/CoverFlow/London_2.jpg", UriKind.Relative);
			tempDataItem.Description = "London is the 2nd most visited city in the world. It is a leading global city with its strengths in the arts, commerce, education, entertainment, fashion, finance, etc.";
			tempDataItem.Name = "London";
			tempDataItem.Country = GetCountry("London");
            listDataItem.Add(tempDataItem);

            tempDataItem = new DataItem();
			tempDataItem.ImageSource = new Uri("../Images/CoverFlow/Bangkok_3.jpg", UriKind.Relative);
			tempDataItem.Description = "Bangkok is the 3rd most visited city in the world with estimated 10.84 million visitors a year. It is Thailand's major tourist gateway, which means that the majority of foreign tourists arrive in Bangkok.";
			tempDataItem.Name = "Bangkok";
			tempDataItem.Country = GetCountry("Bangkok");
            listDataItem.Add(tempDataItem);

            tempDataItem = new DataItem();
			tempDataItem.ImageSource = new Uri("../Images/CoverFlow/Singapore_4.jpg", UriKind.Relative);
			tempDataItem.Description = "Singapore is the 4th most visited city in the world with estimated 10.1 million visitors a year. Tourism in Singapore is a major industry and attracts millions of tourists each year.";
			tempDataItem.Name = "Singapore";
			tempDataItem.Country = GetCountry("Singapore");
            listDataItem.Add(tempDataItem);

            tempDataItem = new DataItem();
			tempDataItem.ImageSource = new Uri("../Images/CoverFlow/New-york5.jpg", UriKind.Relative);
			tempDataItem.Description = "New York City is the 5th most visited city in the world. Tourism is one of New York City's most vital industries.";
			tempDataItem.Name = "New York";
			tempDataItem.Country = GetCountry("New York");
            listDataItem.Add(tempDataItem);

            tempDataItem = new DataItem();
			tempDataItem.ImageSource = new Uri("../Images/CoverFlow/Hong-kong_6.jpg", UriKind.Relative);
			tempDataItem.Description = "Hong Kong is the 6th most visited city in the world. Hong Kong is frequently described as a place where 'East meets West'.";
			tempDataItem.Name = "Hong Kong";
			tempDataItem.Country = GetCountry("Hong Kong");
            listDataItem.Add(tempDataItem);

            tempDataItem = new DataItem();
			tempDataItem.ImageSource = new Uri("../Images/CoverFlow/Istanbul_7.jpg", UriKind.Relative);
			tempDataItem.Description = "Istanbul is the 7th most visited city in the world. Istanbul is becoming increasingly colorful in terms of its rich social, cultural, and commercial activities.";
            tempDataItem.Name = "Istanbul";
			tempDataItem.Country = GetCountry("Istanbul");
            listDataItem.Add(tempDataItem);

			tempDataItem = new DataItem();
			tempDataItem.ImageSource = new Uri("../Images/CoverFlow/Dubai_8.jpg", UriKind.Relative);
			tempDataItem.Description = "Dubai is the 8th most visited city in the world. It is a highly cosmopolitan society with a diverse and vibrant culture.";
			tempDataItem.Name = "Dubai";
			tempDataItem.Country = GetCountry("Dubai");
			listDataItem.Add(tempDataItem);

			tempDataItem = new DataItem();
			tempDataItem.ImageSource = new Uri("../Images/CoverFlow/Shanghai_9.jpg", UriKind.Relative);
			tempDataItem.Description = "Shanghai is the 9th most visited city in the world. Today, Shanghai is described as the 'showpiece' of the world's fastest-growing major economy.";
			tempDataItem.Name = "Shanghai";
			tempDataItem.Country = GetCountry("Shanghai");
			listDataItem.Add(tempDataItem);

			tempDataItem = new DataItem();
			tempDataItem.ImageSource = new Uri("../Images/CoverFlow/Rome_10.jpg", UriKind.Relative);
			tempDataItem.Description = "Rome is the 10th most visited city in the world, due to the incalculable immensity of its archaeological and artistic treasures as well as the majesty of its magnificent 'villas' (parks).";
			tempDataItem.Name = "Rome";
			tempDataItem.Country = GetCountry("Rome");
			listDataItem.Add(tempDataItem);

            this.DataContext = listDataItem;
        }

		public string GetCountry(string cityName)
		{
			string country = "";
			switch (cityName)
			{
				case "Paris": country = "France";
					break;
				case "London": country = "England";
					break;
				case "Bangkok": country = "Thailand";
					break;
				case "Singapore": country = "Singapore";
					break;
				case "New York": country = "USA";
					break;
				case "Hong Kong": country = "China";
					break;
				case "Istanbul": country = "Turkey";
					break;
				case "Dubai": country = "Dubai";
					break;
				case "Shanghai": country = "China";
					break;
				case "Rome": country = "Italy";
					break;
			}
			return country;
		}
    }

    public class DataItem
    {
        private Uri imageSource;
        private string name;
		private string description;
		private string country;

        public Uri ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
			set { description = value; }
        }

		public string Country
		{
			get { return country; }
			set { country = value; }
		}
    }
}
