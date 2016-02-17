using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.ProgressBar.Theming
{
	public partial class Example : System.Windows.Controls.UserControl
	{
        private DispatcherTimer timer;
        private SolidColorBrush expressionDarkForeground = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
        private SolidColorBrush visualStudio2013Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));

		public Example()
		{
			InitializeComponent();
            this.UpdateUIAccordingToTheme();
        	this.timer = new DispatcherTimer();
			this.timer.Interval = TimeSpan.FromMilliseconds(10.0);
			this.timer.Tick += new EventHandler(this.Timer_Tick);
		}

        public string CurrentTheme
        {
            get
            {
                return ApplicationThemeManager.GetInstance().CurrentTheme;
            }
        }

        private void UpdateUIAccordingToTheme()
        {
            if (this.CurrentTheme.Equals("Expression_Dark"))
            {
                this.LoadingLabel.Foreground = expressionDarkForeground;
                this.PercentageLabel.Foreground = expressionDarkForeground;
                this.IndeterminateLabel.Foreground = expressionDarkForeground;
                this.DeterminateLabel.Foreground = expressionDarkForeground;
            }

            else if (this.CurrentTheme.Equals("VisualStudio2013_Dark"))
            {
                this.LoadingLabel.Foreground = visualStudio2013Foreground;
                this.PercentageLabel.Foreground = visualStudio2013Foreground;
                this.IndeterminateLabel.Foreground = visualStudio2013Foreground;
                this.DeterminateLabel.Foreground = visualStudio2013Foreground;
            }

#if WPF
            else
            {
                this.LoadingLabel.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                this.PercentageLabel.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                this.IndeterminateLabel.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                this.DeterminateLabel.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
            }
#endif
        }

		private void Timer_Tick(object sender, EventArgs e)
		{
			this.RadProgressBar2.Value += 1;
		}

		private void RadProgressBar2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			int value = Convert.ToInt32((RadProgressBar2.Value / (RadProgressBar2.Maximum - RadProgressBar2.Minimum)) * 100);
			PercentageLabel.Text = value.ToString() + " %";
			if (this.RadProgressBar2.Value == this.RadProgressBar1.Maximum)
			{
				this.ButtonStart.IsEnabled = false;
				this.ButtonPause.IsEnabled = false;
				this.ButtonRestart.IsEnabled = true; 

				this.timer.Stop();
				this.LoadingLabel.Text = "Download Complete ";
			}
		}

		private void Pause_Click(object sender, RoutedEventArgs e)
		{
			this.ButtonStart.IsEnabled = true;
			this.ButtonPause.IsEnabled = false; 

			this.timer.Stop();
		}

		private void Start_Click(object sender, RoutedEventArgs e)
		{
			this.ButtonStart.IsEnabled = false; 
			this.ButtonPause.IsEnabled = true; 

			if (this.RadProgressBar2.Value < this.RadProgressBar2.Maximum)
			{
				this.LoadingLabel.Text = "Downloading...";
				this.timer.Start();
			}
		}

		private void Restart_Click(object sender, RoutedEventArgs e)
		{
			this.ButtonStart.IsEnabled = false;
			this.ButtonPause.IsEnabled = true; 

			this.LoadingLabel.Text = "Downloading...";
			RadProgressBar2.Value = 0;
			this.timer.Stop();
			this.timer.Start();
		}

        private void Example_ThemeChanged(object sender, System.EventArgs e)
        {
            this.UpdateUIAccordingToTheme();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
        }

	}
}
