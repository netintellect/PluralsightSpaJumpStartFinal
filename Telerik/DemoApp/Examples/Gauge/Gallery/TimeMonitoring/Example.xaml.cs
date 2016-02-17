using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Gauge.Gallery.TimeMonitoring
{
	/// <summary>
	/// Interaction logic for Time Monitoring Tool
	/// </summary>
	public partial class Example : DynamicBasePage
	{
		/// <summary>
		/// Application is started
		/// </summary>
		private bool started;
		/// <summary>
		/// Application has been started
		/// </summary>
		private bool wasStarted;
		/// <summary>
		/// Start of work time
		/// </summary>
		private DateTime startWorkTime;
		/// <summary>
		/// End of work time
		/// </summary>
		private DateTime endWorkTime;
		/// <summary>
		/// Lunch break
		/// </summary>
		private bool pause;
		/// <summary>
		/// Time multiplier
		/// </summary>
		private int timeMultiplier = 120;
		/// <summary>
		/// Current time
		/// </summary>
		private DateTime time;
		/// <summary>
		/// Work time
		/// </summary>
		private DateTime workTime;
		/// <summary>
		/// Lunch break time
		/// </summary>
		private DateTime breakTime;
		/// <summary>
		/// Start value for end of working day mark
		/// </summary>
		private double endWorkTimeMarkStartValue;
		/// <summary>
		/// Linear bars collection
		/// </summary>
		private List<BarIndicator> workHoursBars = new List<BarIndicator>();

		public Example()
		{
			time = DateTime.Now;

            StyleManager.ApplicationTheme = new Office_BlackTheme(); 
			InitializeComponent();

			workHoursBars.Add(linearBar1);
			workHoursBars.Add(linearBar2);
			workHoursBars.Add(linearBar3);
			workHoursBars.Add(linearBar4);
			workHoursBars.Add(linearBar5);
			workHoursBars.Add(linearBar6);
			workHoursBars.Add(linearBar7);
			workHoursBars.Add(linearBar8);
			workHoursBars.Add(linearBar9);
			workHoursBars.Add(linearBar10);

			InitReportData();
			ShowTime();
		}

		/// <summary>
		/// Init report data
		/// </summary>
		private void InitReportData()
		{
			object[][] data = new object[][]{
				new object[] {
					DateTime.Now.AddDays(-3),
					"9:00",
					"6:00",
					"1:00",
					"8:00"
				},
				new object[] {
					DateTime.Now.AddDays(-2),
					"9:05",
					"6:15",
					"1:00",
					"8:10"
				},
				new object[] {
					DateTime.Now.AddDays(-1),
					"8:45",
					"5:59",
					"1:10",
					"8:04"
				},
				new object[] {
					"",
					"",
					"",
					"",
					""
				}
			};

			int rowNumber = 1;
			foreach (object[] row in data)
			{
				AddTextBlock(rowNumber, 0, string.Format("{0:d}", row[0]));

				for (int column = 1; column < row.Length; column++)
				{
					AddTextBlock(rowNumber, column, row[column] as string);
				}

				rowNumber++;
			}
		}

		private void AddTextBlock(int row, int column, string text)
		{
			TextBlock textBlock = new TextBlock();

			textBlock.Style = this.Resources["GridTextStyle"] as Style;
			textBlock.Text = text;
			Grid.SetRow(textBlock, row);
			Grid.SetColumn(textBlock, column);

			reportGrid.Children.Add(textBlock);
		}

		private void ShowTime()
		{
			hoursNeedle.Value = (double)time.Hour + (double)time.Minute / 60d;
			minutesNeedle.Value = (double)time.Minute * 12d / 60d;

			if (!started || pause)
				return;

			numericIndicator.Value = (double)workTime.Hour + (double)workTime.Minute / 100d;

			if (workTime.Hour < workHoursBars.Count)
			{
				BarIndicator currentBar = workHoursBars[workTime.Hour];
				currentBar.Value = workTime.Minute;
			}
		}

		private void AddTime()
		{
			time = time.AddSeconds(timeMultiplier);

			if (!started)
				return;

			if (pause)
			{
				breakTime = breakTime.AddSeconds(timeMultiplier);
				endWorkTime = endWorkTime.AddSeconds(timeMultiplier);
                
#if WPF
				endWorkTimeMark.ToolTip = string.Format("{0:t}", endWorkTime);
#endif

				ScaleObject.SetValue(endWorkTimeMark, endWorkTimeMarkStartValue +
					(double)breakTime.Hour + (double)breakTime.Minute / 60d);
				return;
			}

			workTime = workTime.AddSeconds(timeMultiplier);
		}

		protected override void NewValue()
		{
			AddTime();
			ShowTime();
		}

		private void StartButtonClick(object sender, RoutedEventArgs e)
		{
			if (!started)
			{
				wasStarted = true;

				DateTime now = DateTime.Now;
				startWorkTime = new DateTime(now.Year, now.Month, now.Day, time.Hour, time.Minute, 0);
				workTime = breakTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

				started = true;

				ScaleObject.SetValue(startWorkTimeMark, (double)time.Hour + (double)time.Minute / 60d);
				ScaleObject.SetValue(endWorkTimeMark, endWorkTimeMarkStartValue = (double)time.Hour + 8d + (double)time.Minute / 60d);
#if WPF
				startWorkTimeMark.ToolTip = string.Format("{0:t}", startWorkTime);
#endif 

				endWorkTime = startWorkTime.AddHours(8);
                
#if WPF
				endWorkTimeMark.ToolTip = string.Format("{0:t}", endWorkTime);
#endif 
                
				startWorkTimeMark.Visibility = Visibility.Visible;
				endWorkTimeMark.Visibility = Visibility.Visible;

				foreach (BarIndicator bar in workHoursBars)
				{
					bar.Value = 0;
				}

				this.submitButton.IsEnabled = false;
				this.seeResultsButton.IsEnabled = false;
			}

			if (pause)
				pause = false;
		}

		private void PauseButtonClick(object sender, RoutedEventArgs e)
		{
			pause = true;
			//numericIndicator.RelativeWidth += 0.001;
			//backgroundNumericIndicator.RelativeWidth += 0.001;
		}

		private void EndButtonClick(object sender, RoutedEventArgs e)
		{
			if (started)
			{
				endWorkTime = time;
				started = false;
				pause = false;
				this.submitButton.IsEnabled = true;
				this.seeResultsButton.IsEnabled = true;
			}
		}

		private void SubmitButtonClick(object sender, RoutedEventArgs e)
		{
            int index;
			if (!started && wasStarted)
			{
				index = reportGrid.Children.Count - 6;
				(reportGrid.Children[++index] as TextBlock).Text = string.Format("{0:d}", startWorkTime);
                (reportGrid.Children[++index] as TextBlock).Text = string.Format("{0:t}", startWorkTime);
                (reportGrid.Children[++index] as TextBlock).Text = string.Format("{0:t}", endWorkTime);
                (reportGrid.Children[++index] as TextBlock).Text = string.Format("{0:t}", breakTime);
                (reportGrid.Children[++index] as TextBlock).Text = string.Format("{0:t}", workTime);
			}
		}

		private void SeeReportButtonClick(object sender, RoutedEventArgs e)
		{
			SubmitButtonClick(null, null);
			reportView.Background = new SolidColorBrush(Colors.White);
			reportView.Visibility = Visibility.Visible;
		}

		private void CloseButtonClick(object sender, RoutedEventArgs e)
		{
			reportView.Visibility = Visibility.Collapsed;
		}
	}
}
