using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
#if WPF
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
#elif SILVERLIGHT
using SelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangedEventArgs;
#endif

namespace Telerik.Windows.Examples.Chart.CustomPointMarks
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			InitializePointMarkCombo();
			InitializeAxisLayoutModeCombo();
			InitializePaletteCombo(PaletteComboBox);
			InitializePaletteCombo(PointMarkStrokePaletteComboBox);
			InitializePaletteCombo(PointMarkFillPaletteComboBox);
			PointMarkFillPaletteComboBox.Items.Insert(0, new SolidColorBrush(Colors.White));
			PointMarkStrokePaletteComboBox.Items.Insert(0, new SolidColorBrush(Colors.White));

			this.Loaded += this.Example_Loaded;
		}

		private void InitializePaletteCombo(RadComboBox combo)
		{
			combo.Items.Add(new SolidColorBrush(Color.FromArgb(255, 28, 214, 77)));
			combo.Items.Add(new SolidColorBrush(Color.FromArgb(255, 70, 230, 51)));
			combo.Items.Add(new SolidColorBrush(Color.FromArgb(255, 153, 248, 57)));
			combo.Items.Add(new SolidColorBrush(Color.FromArgb(255, 215, 252, 60)));
			combo.Items.Add(new SolidColorBrush(Color.FromArgb(255, 252, 237, 64)));
			combo.Items.Add(new SolidColorBrush(Color.FromArgb(255, 250, 199, 65)));
			combo.Items.Add(new SolidColorBrush(Color.FromArgb(255, 250, 160, 61)));
			combo.Items.Add(new SolidColorBrush(Color.FromArgb(255, 253, 129, 69)));
			combo.Items.Add(new SolidColorBrush(Color.FromArgb(255, 253, 88, 58)));
			combo.Items.Add(new SolidColorBrush(Color.FromArgb(255, 255, 61, 40)));
		}

		private void Example_Loaded(object sender, RoutedEventArgs e)
		{
			this.InitializeRadChart();
			ShowAreaCheckbox.IsChecked = false;
			ShowPointMarksCheckbox.IsChecked = true;
			PaletteComboBox.SelectedIndex = 0;
			PointMarkStrokePaletteComboBox.SelectedIndex = 1;
			PointMarkFillPaletteComboBox.SelectedIndex = 0;
		}

		private void InitializeRadChart()
		{
			InitializeLineChart();
			RadChart1.DefaultView.ChartLegend.Visibility = Visibility.Collapsed;
		}

		private void InitializeAreaChart()
		{
			this.InitializeChartArea<AreaSeriesDefinition>();
			this.SynchronizeChartSettings();
		}

		private void InitializeLineChart()
		{
			this.InitializeChartArea<LineSeriesDefinition>();
			this.SynchronizeChartSettings();
		}

		private void InitializeChartArea<TSeriesDefinition>() where TSeriesDefinition : ISeriesDefinition, new()
		{
			ChartArea chartArea = RadChart1.DefaultView.ChartArea;
			chartArea.EnableAnimations = false;

			DataSeries series = new DataSeries();
			series.LegendLabel = "Series1";
			series.Definition = new TSeriesDefinition();
			series.Definition.ShowItemLabels = false;
			series.Definition.Appearance.Stroke = PaletteComboBox.SelectedValue as Brush;
			series.Definition.Appearance.Fill = PaletteComboBox.SelectedValue as Brush;

			if (chartArea.DataSeries.Count > 0)
			{
				DataPoint dataPoint;
				foreach (DataPoint item in chartArea.DataSeries[0])
				{
					dataPoint = new DataPoint();
					dataPoint.YValue = item.YValue;
					series.Add(dataPoint);
				}
			}
			else
			{
				SeriesExtensions.FillWithSampleData(series, 12);
			}
			chartArea.DataSeries.Clear();
			chartArea.DataSeries.Add(series);
			UpdatePointMarks<TSeriesDefinition>();
		}

		private void InitializePointMarkCombo()
		{
			string[] shapes = (string[])EnumHelper.GetValuesAsString(typeof(MarkerShape));
			PointMarkCombo.ItemsSource = shapes;

			PointMarkCombo.SelectedIndex = 6;
			PointMarkCombo.SelectionChanged += this.PointMarkCombo_SelectionChanged;
		}

		private void InitializeAxisLayoutModeCombo()
		{
            string[] modes = (string[])EnumHelper.GetValuesAsString(typeof(AxisLayoutMode));
			AxisLayoutModeCombo.ItemsSource = modes;

			AxisLayoutModeCombo.SelectedIndex = 0;
			AxisLayoutModeCombo.SelectionChanged += this.AxisLayoutModeCombo_SelectionChanged;
		}

		void AxisLayoutModeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			RadChart1.DefaultView.ChartArea.AxisX.LayoutMode = (AxisLayoutMode)Enum.Parse(typeof(AxisLayoutMode), AxisLayoutModeCombo.SelectedItem.ToString(), false);
		}

		void PointMarkCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (RadChart1.DefaultView.ChartArea.DataSeries.Count > 0)
			{
				if (RadChart1.DefaultView.ChartArea.DataSeries[0].Definition is LineSeriesDefinition)
					UpdatePointMarks<LineSeriesDefinition>();
				else
					UpdatePointMarks<AreaSeriesDefinition>();
			}
		}

		private void UpdatePointMarks<TSeriesDefinition>() where TSeriesDefinition : ISeriesDefinition
		{
			ISeriesDefinition seriesDefinition;
			if (RadChart1.DefaultView.ChartArea.DataSeries.Count == 0)
				return;
			seriesDefinition = RadChart1.DefaultView.ChartArea.DataSeries[0].Definition;
			seriesDefinition.Appearance.PointMark.Shape = (MarkerShape)Enum.Parse(typeof(MarkerShape), PointMarkCombo.SelectedItem.ToString(), false);
			seriesDefinition.Appearance.PointMark.Stroke = PointMarkStrokePaletteComboBox.SelectedValue as Brush;
			seriesDefinition.Appearance.PointMark.Fill = PointMarkFillPaletteComboBox.SelectedValue as Brush;

			seriesDefinition.PointMarkItemStyle = this.RadChart1.Resources["CustomStyle"] as Style;
		}


		private void SynchronizeChartSettings()
		{
			this.SetItemPointMarkVisibility();
		}

		private void ShowAreaCheckboxChecked(object sender, RoutedEventArgs e)
		{
			CheckBox showArea = (CheckBox)sender;
			if ((bool)showArea.IsChecked)
				this.InitializeAreaChart();
			else
				this.InitializeLineChart();
		}

		private void SetItemPointMarkVisibility()
		{
			bool pointMarksVisible = (bool)ShowPointMarksCheckbox.IsChecked;
			InitializeSeriesPointMarks(pointMarksVisible);
		}

		private void ShowPointMarksCheckboxChecked(object sender, RoutedEventArgs e)
		{
			InitializeSeriesPointMarks((bool)((CheckBox)sender).IsChecked);
		}

		private void InitializeSeriesPointMarks(bool pointMarksVisible)
		{
			DataSeries series;
			if (RadChart1.DefaultView.ChartArea.DataSeries.Count > 0)
			{
				series = RadChart1.DefaultView.ChartArea.DataSeries[0];
				if (series.Definition is AreaSeriesDefinition)
					(RadChart1.DefaultView.ChartArea.DataSeries[0].Definition as AreaSeriesDefinition).ShowPointMarks = pointMarksVisible;
				else
					(RadChart1.DefaultView.ChartArea.DataSeries[0].Definition as LineSeriesDefinition).ShowPointMarks = pointMarksVisible;
			}
		}

		private void PaletteComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (RadChart1.DefaultView.ChartArea.DataSeries.Count > 0)
			{
				RadChart1.DefaultView.ChartArea.DataSeries[0].Definition.Appearance.Fill = PaletteComboBox.SelectedValue as Brush;
				RadChart1.DefaultView.ChartArea.DataSeries[0].Definition.Appearance.Stroke = PaletteComboBox.SelectedValue as Brush;
			}
		}

		private void PointMarkStrokePaletteComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (RadChart1.DefaultView.ChartArea.DataSeries.Count > 0)
				RadChart1.DefaultView.ChartArea.DataSeries[0].Definition.Appearance.PointMark.Stroke = PointMarkStrokePaletteComboBox.SelectedValue as Brush;
		}

		private void PointMarkFillPaletteComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (RadChart1.DefaultView.ChartArea.DataSeries.Count > 0)
				RadChart1.DefaultView.ChartArea.DataSeries[0].Definition.Appearance.PointMark.Fill = PointMarkFillPaletteComboBox.SelectedValue as Brush;
		}
	}
}
