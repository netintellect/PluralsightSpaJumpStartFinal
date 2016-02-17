using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.DataFilter
{
	/// <summary>
	/// A football player.
	/// </summary>
	public class Player : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string name;
		private int number;
		private Position position;
		private string country;

		public string Name
		{
			get { return this.name; }
			set
			{
				if (value != this.name)
				{
					this.name = value;
					this.OnPropertyChanged("Name");
				}
			}
		}

		public int Number
		{
			get { return this.number; }
			set
			{
				if (value != this.number)
				{
					this.number = value;
					this.OnPropertyChanged("Number");
				}
			}
		}

		public Position Position
		{
			get { return this.position; }
			set
			{
				if (value != this.position)
				{
					this.position = value;
					this.OnPropertyChanged("Position");
				}
			}
		}

		public string Country
		{
			get { return this.country; }
			set
			{
				if (value != this.country)
				{
					this.country = value;
					this.OnPropertyChanged("Country");
				}
			}
		}

		public Player()
		{
		}

		public Player(string name, int number, Position position, string country)
		{
			this.name = name;
			this.number = number;
			this.position = position;
			this.country = country;
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public override string ToString()
		{
			return this.Name;
		}

		public static ObservableCollection<Player> GetPlayers()
		{
			ObservableCollection<Player> players = new ObservableCollection<Player>();
			IEnumerable<Club> clubs = Club.GetClubs();
			foreach (Club club in clubs)
			{
				foreach (Player player in club.Players)
				{
					players.Add(player);
				}
			}

			return players;
		}
	}
}
