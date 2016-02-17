using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace Telerik.Windows.Examples.ProgressBar.Integration
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		private DispatcherTimer timer = new DispatcherTimer();
		public Example()
		{
			InitializeComponent();
			this.timer.Interval = TimeSpan.FromMilliseconds(10);
			this.timer.Tick += new EventHandler(Timer_Tick);
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			this.BufferingProgressBar.Value += 1;
			int perfentage = Convert.ToInt32((this.BufferingProgressBar.Value / (this.BufferingProgressBar.Maximum - this.BufferingProgressBar.Minimum)) * 100);
			this.BufferingPercentageLabel.Text = string.Format("BUFFERING:    {0} % Complete", perfentage);
			if (this.BufferingProgressBar.Value == this.BufferingProgressBar.Maximum)
			{
				this.timer.Stop();
			}
		}

		private void RadCoverFlow_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (this.BufferingProgressBar != null)
			{
				this.BufferingProgressBar.Value = 0;
			}
			this.timer.Stop();
			this.timer.Start();
		}
	}

	public class RadioStations : ObservableCollection<RadioStation>
	{
		public RadioStations()
		{
			this.Add(new RadioStation("JAZZ RADIO", "../Images/ProgressBar/Jazz1.png", "103.3 FM"));
			this.Add(new RadioStation("ROCK RADIO", "../Images/ProgressBar/Rock2.png", "101.0 FM"));
			this.Add(new RadioStation("TRANCE RADIO", "../Images/ProgressBar/Trance3.png", "102.2 FM"));
			this.Add(new RadioStation("CHILLOUT RADIO", "../Images/ProgressBar/Chillout4.png", "104.2 FM"));
			this.Add(new RadioStation("JUICE RADIO", "../Images/ProgressBar/Juice5.png", "99.9 FM"));
			this.Add(new RadioStation("HOUSE RADIO", "../Images/ProgressBar/House6.png", "100.5 FM"));
			this.Add(new RadioStation("MIX RADIO", "../Images/ProgressBar/Mix7.png", "108.8 FM"));
			this.Add(new RadioStation("TECHNO RADIO", "../Images/ProgressBar/Techno8.png", "106.5 FM"));
		}
	}

	public class RadioStation
	{
		public RadioStation(string title, string url, string frequency)
		{
			this.Title = title;
			this.Logo = new Uri(url, UriKind.RelativeOrAbsolute);
			this.Frequency = frequency;
		}
		public Uri Logo { get; set; }
		public string Title { get; set; }
		public string Frequency { get; set; }
	}
}