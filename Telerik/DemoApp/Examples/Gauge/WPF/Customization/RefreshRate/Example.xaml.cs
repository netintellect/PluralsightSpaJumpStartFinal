using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Examples.Gauge;

namespace Telerik.Windows.Examples.Gauge.Customization.RefreshRate
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : DynamicBasePage
	{
		/// <summary>
		/// Randomizer
		/// </summary>
		private RealDataEmulator valueGenerator = new RealDataEmulator(0, 100, 0, 7, 7);
		private bool working = true;
		private bool stopped = false;
		private bool showProgress = true;
		private List<double> valueHistory = new List<double>();

		public Example()
		{
			InitializeComponent();

			Loaded += new RoutedEventHandler(Example_Loaded);
		}

		void Example_Loaded(object sender, RoutedEventArgs e)
		{
			this.TimerInterval = TimeSpan.FromSeconds(0.4);
		}

		protected override void NewValue()
		{
			if (!stopped)
			{
				double value = valueGenerator.GetNextValue();
				marker.Value = value;
				valueHistory.Add(value);
				if (showProgress)
					valueListBox.Items.Add(value);
			}
		}

		private void refreshRate_ValueChanged(object sender, RadRangeBaseValueChangedEventArgs e)
		{
			TimeSpan refreshRate = TimeSpan.FromSeconds(e.NewValue.Value);
			markerMax.RefreshRate = refreshRate;
			markerMin.RefreshRate = refreshRate;
			numericIndicator.RefreshRate = refreshRate;
		}

		private void indicator_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (!working)
			{
				stopped = true;
				this.timer.Stop();
			}

			needle.Value = e.NewValue;

			MoveResult(e.NewValue);
		}

		private void MoveResult(double newValue)
		{
			if (!showProgress)
			{
				valueListBox.Items.Clear();

				foreach (double value in valueHistory)
					valueListBox.Items.Add(value);
			}

			showProgress = false;

			valueListBox.Items.Add(numericIndicator.RefreshMode.ToString() + " value");
			valueListBox.Items.Add(newValue);

			valueHistory.Clear();
		}

		private void range_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (double.IsNaN(markerMin.Value) || double.IsNaN(markerMax.Value))
				return;

			double min = markerMin.Value;
			double max = markerMax.Value;

			if (min > max)
				return;

			if (range.Max < min)
			{
				range.Max = max;
				range.Min = min;
			}
			else
			{
				range.Min = min;
				range.Max = max;
			}
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			if (!stopped)
			{
				working = true;
				return;
			}

			valueListBox.Items.Clear();
			working = true;
			stopped = false;
			showProgress = true;
			this.timer.Start();
		}

		private void StopButton_Click(object sender, RoutedEventArgs e)
		{
			working = false;
		}
	}
}
