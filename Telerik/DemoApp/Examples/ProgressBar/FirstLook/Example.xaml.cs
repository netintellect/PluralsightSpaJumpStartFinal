using System;
using System.Windows;
using System.Windows.Threading;

namespace Telerik.Windows.Examples.ProgressBar.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		private DispatcherTimer timer;

		public Example()
		{
			InitializeComponent();
			this.timer = new DispatcherTimer();
			this.timer.Interval = TimeSpan.FromMilliseconds(10.0);
			this.timer.Tick += new EventHandler(this.Timer_Tick);
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			this.RadProgressBar1.Value += 1;
		}

		private void RadProgressBar1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			int value = Convert.ToInt32((RadProgressBar1.Value / (RadProgressBar1.Maximum - RadProgressBar1.Minimum)) * 100);
			PercentageLabel.Text = value.ToString() + " %";
			if (this.RadProgressBar1.Value == this.RadProgressBar1.Maximum)
			{
				this.ButtonStart.IsEnabled = false;
				this.ButtonPause.IsEnabled = false;
				this.ButtonRestart.IsEnabled = true; 

				this.timer.Stop();
				this.ValueNumericInput.IsEnabled = true;
				this.LoadingLabel.Text = "Download Complete ";
			}
		}

		private void Pause_Click(object sender, RoutedEventArgs e)
		{
			this.ButtonStart.IsEnabled = true;
			this.ButtonPause.IsEnabled = false; 

			this.ValueNumericInput.IsEnabled = true;
			this.timer.Stop();
		}

		private void Start_Click(object sender, RoutedEventArgs e)
		{
			this.ButtonStart.IsEnabled = false;
			this.ButtonPause.IsEnabled = true; 

			if (this.RadProgressBar1.Value < this.RadProgressBar1.Maximum)
			{
				this.LoadingLabel.Text = "Downloading...";
				this.ValueNumericInput.IsEnabled = false;
				this.timer.Start();
			}
		}

		private void Restart_Click(object sender, RoutedEventArgs e)
		{
			this.ButtonStart.IsEnabled = false;
			this.ButtonPause.IsEnabled = true; 

			this.LoadingLabel.Text = "Downloading...";
			this.ValueNumericInput.IsEnabled = false;
			RadProgressBar1.Value = 0;
			this.timer.Stop();
			this.timer.Start();
		}
	}
}
