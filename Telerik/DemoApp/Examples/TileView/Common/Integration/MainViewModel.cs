using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TileView.Common.ViewModels
{
	public partial class MainViewModel : ViewModelBase
	{
		private Team leader;
		private DispatcherTimer timer1, timer2;

		public MainViewModel()
		{
			this.timer1 = new DispatcherTimer();
			this.timer1.Tick += this.Timer1_Tick;
			this.timer2 = new DispatcherTimer();
			this.timer2.Tick += this.Timer2_Tick;
			this.SetSpeedRatio();
			this.Teams = new ObservableCollection<Team>();
			this.Teams.CollectionChanged += this.Teams_CollectionChanged;
			this.AddTeams();
			this.Leader = this.Teams[0];
			this.TotalLaps = 60;
		}

		private void Teams_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Team team = e.NewItems[0] as Team;
			team.Pilot.PropertyChanged += this.Pilot_PropertyChanged;
		}

		private void Pilot_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Position" && !this.RaceStarted)
			{
				this.GetLeader();
			}
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			this.GenerateRandomPosition();
			this.GetLeader();
		}

		private void Timer2_Tick(object sender, EventArgs e)
		{
			this.GenerateRandomPosition();
			this.GetLeader();
			this.CurrentLap += 1;
		}

		private void GetLeader()
		{
			foreach (Team team in this.Teams)
			{
				if (team.Pilot.Position == 1)
				{
					this.Leader = team;
					break;
				}
			}
		}

		private SpeedRatio speedRatio;

		public SpeedRatio SpeedRatio
		{
			get
			{
				return this.speedRatio;
			}
			set
			{
				if (this.speedRatio != value)
				{
					this.speedRatio = value;
					this.SetSpeedRatio();
					this.OnPropertyChanged("SpeedRatio");
				}
			}
		}

		private void SetSpeedRatio()
		{
			if (this.speedRatio == SpeedRatio.Normal)
			{
				this.timer1.Interval = TimeSpan.FromSeconds(1.5);
				this.timer2.Interval = TimeSpan.FromSeconds(2.3);
			}
			else
			{
				this.timer1.Interval = TimeSpan.FromSeconds(0.7);
				this.timer2.Interval = TimeSpan.FromSeconds(0.9);
			}
		}

		private int totalLaps;

		public int TotalLaps
		{
			get
			{
				return this.totalLaps;
			}
			set
			{
				if (this.totalLaps != value)
				{
					this.totalLaps = value;
					this.OnPropertyChanged("TotalLaps");
				}
			}
		}

		private int currentLap = 1;

		public int CurrentLap
		{
			get
			{
				return this.currentLap;
			}
			set
			{
				if (this.currentLap != value)
				{
					this.currentLap = value;
					if(this.currentLap > this.totalLaps)
					{
						this.currentLap = 1;
					}
					this.OnPropertyChanged("CurrentLap");
				}
			}
		}

		private void GenerateRandomPosition()
		{
			Random rnd = new Random(DateTime.Now.Millisecond);
			int teamsCount = this.Teams.Count();
			int randomTeamIndex = rnd.Next(teamsCount);
			Team randomTeam = this.Teams[randomTeamIndex];
			Pilot randomPlayer = randomTeam.Pilot;

			if (randomPlayer.Position.Equals(1))
			{
				randomPlayer.Position++;
			}
			else if (randomPlayer.Position.Equals(teamsCount))
			{
				randomPlayer.Position--;
			}
			else
			{
				int newPosition = 0;
				while (newPosition.Equals(0))
				{
					newPosition = rnd.Next(-1, 2);
				}
				randomPlayer.Position += newPosition;
			}
		}

		public void StartRace()
		{
			this.timer1.Start();
			this.timer2.Start();
		}

		public void StopRace()
		{
			this.timer1.Stop();
			this.timer2.Stop();
		}

		public ObservableCollection<Team> Teams { get; set; }

		public Team Leader
		{
			get
			{
				return this.leader;
			}
			set
			{
				if (this.leader != value)
				{
					this.leader = value;
					this.OnPropertyChanged("Leader");
				}
			}
		}

		private bool RaceStarted
		{
			get
			{
				return this.timer1.IsEnabled || this.timer2.IsEnabled;
			}
		}
	}

	public enum SpeedRatio
	{
		Normal,
		Fast
	}
}
