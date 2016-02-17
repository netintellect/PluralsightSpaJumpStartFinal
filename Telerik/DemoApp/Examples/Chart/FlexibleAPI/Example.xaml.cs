using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Controls;
#if WPF
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
#elif SILVERLIGHT
using SelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangedEventArgs;
#endif

namespace Telerik.Windows.Examples.Chart.FlexibleAPI
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

#if SILVERLIGHT
        CheckBox HideElementsOnRotationCheckbox = new CheckBox();
#endif

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {

#if SILVERLIGHT
            this.ConfigureHideElementsCheckBox();
#endif

            this.InitializeRadChart();
            this.RadChart1.DefaultView.ChartArea.AxisX.DefaultLabelFormat = "MMM/dd/yy";

            this.InitializeFormatComboboxes();
            this.InitializeCheckBoxes();

            this.PaletteComboBox.SelectedIndex = 5;
        }

        private void InitializeCheckBoxes()
        {
            this.ShowLabelsCheckbox.IsChecked = true;
            this.ShowTooltipsCheckbox.IsChecked = true;
            AxisXCheckbox.IsChecked = true;
            AxisYCheckbox.IsChecked = true;
            AxisXStripLinesCheckbox.IsChecked = true;
            AxisYStripLinesCheckbox.IsChecked = true;
        }

        private void InitializeRadChart()
        {
            this.Initialize2DChart();

            RadChart1.DefaultView.ChartLegend.Visibility = Visibility.Collapsed;
        }

        private void Initialize2DChart()
        {
            ChartArea chartArea = this.InitializeChartArea<BarSeriesDefinition>();
            RadChart1.DefaultView.ChartArea.Loaded -= this.ChartAreaLoaded;
            chartArea.AxisX.AutoRange = false;
            chartArea.AxisX.MinValue = DateTime.Today.AddDays(-6).ToOADate();
            chartArea.AxisX.MaxValue = DateTime.Today.ToOADate();
            chartArea.AxisX.Step = DateTime.Today.ToOADate() - DateTime.Today.AddDays(-1).ToOADate();

            RadChart1.DefaultView.ChartArea = chartArea;

            PaletteComboBox.Visibility = System.Windows.Visibility.Visible;

#if SILVERLIGHT
            HideElementsOnRotationCheckbox.Visibility = Visibility.Collapsed;
#endif

            this.SynchronizeChartSettings();
            this.SetCustomAppearanceSettings();
        }

        private void Initialize3DChart()
        {
            ChartArea chartArea = this.InitializeChartArea<Bar3DSeriesDefinition>();
            chartArea.Loaded += this.ChartAreaLoaded;

            RadChart1.DefaultView.ChartArea = chartArea;

            PaletteComboBox.Visibility = System.Windows.Visibility.Collapsed;

            this.SynchronizeChartSettings();
        }

        private ChartArea InitializeChartArea<TSeriesDefinition>() where TSeriesDefinition : ISeriesDefinition, new()
        {
            ChartArea chartArea = new ChartArea();
            DataSeries barSeries = new DataSeries();
            barSeries.Definition = new TSeriesDefinition();
            barSeries.LegendLabel = "Bar Series";

            chartArea.AxisX.LabelRotationAngle = 45;
            chartArea.AxisX.IsDateTime = true;
            chartArea.ItemToolTipOpening += new ItemToolTipEventHandler(ChartArea1_ItemToolTipOpening);

            SeriesExtensions.FillWithSampleData(barSeries, 7);

            int lastIndex = barSeries.Count - 1;

            foreach (DataPoint point in barSeries)
                point.XValue = DateTime.Today.AddDays(barSeries.IndexOf(point) - lastIndex).ToOADate();

            chartArea.DataSeries.Add(barSeries);

            chartArea.DataSeries[0].Definition.ItemLabelFormat = this.FormatComboItem.Text;
            chartArea.AxisX.DefaultLabelFormat = this.FormatComboX.Text;
            chartArea.AxisY.DefaultLabelFormat = this.FormatComboY.Text;
            chartArea.AxisY.IsZeroBased = true;

            chartArea.Legend = RadChart1.DefaultView.ChartLegend;

            return chartArea;
        }

        private void ChartAreaLoaded(object sender, RoutedEventArgs e)
        {
            CameraExtension cameraExtension = new CameraExtension();
            cameraExtension.SpinAxis = SpinAxis.XY;
            cameraExtension.ZoomEnabled = true;

            (sender as ChartArea).Extensions.Add(cameraExtension);

#if SILVERLIGHT
            HideElementsOnRotationCheckbox.Visibility = Visibility.Visible;
            HideElementsOnRotationCheckbox.IsChecked = true;
#endif
        }

        private void SynchronizeChartSettings()
        {
            this.SetAxisXTitle();
            this.SetAxisYTitle();
            this.SetAxisXVisibility();
            this.SetAxisYVisibility();
            this.SetAxisXGridLinesVisibility();
            this.SetAxisYGridLinesVisibility();
            this.SetAxisXStripLinesVisibility();
            this.SetAxisYStripLinesVisibility();
            this.SetItemLabelVisibility();
            this.SetItemToolTipVisibility();

#if SILVERLIGHT
            this.SetHideElementsOnRotation();
#endif
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RadComboBox formatCombobox = e.Source as RadComboBox;
            if (string.IsNullOrEmpty(formatCombobox.Text) || formatCombobox.SelectedValue == null)
                return;

            if (e.Source == this.FormatComboItem)
                this.RadChart1.DefaultView.ChartArea.DataSeries[0].Definition.ItemLabelFormat = formatCombobox.SelectedValue.ToString();
            else if (e.Source == this.FormatComboX)
                this.RadChart1.DefaultView.ChartArea.AxisX.DefaultLabelFormat = formatCombobox.SelectedValue.ToString();
            else if (e.Source == this.FormatComboY)
                this.RadChart1.DefaultView.ChartArea.AxisY.DefaultLabelFormat = formatCombobox.SelectedValue.ToString();
        }

        private void ShowLabelsChecked(object sender, RoutedEventArgs e)
        {
            this.SetItemLabelVisibility();
        }

        private void ShowToolTipsChecked(object sender, RoutedEventArgs e)
        {
            this.SetItemToolTipVisibility();
        }

        private void Bar3DChecked(object sender, RoutedEventArgs e)
        {
            Initialize3DChart();
        }

        private void Bar3DUnchecked(object sender, RoutedEventArgs e)
        {
            Initialize2DChart();
        }

        private void AxisXVisibilityChecked(object sender, RoutedEventArgs e)
        {
            this.SetAxisXVisibility();
        }

        private void AxisYVisibilityChecked(object sender, RoutedEventArgs e)
        {
            this.SetAxisYVisibility();
        }

        private void AxisXGridLinesChecked(object sender, RoutedEventArgs e)
        {
            this.SetAxisXGridLinesVisibility();
        }

        private void AxisYGridLinesChecked(object sender, RoutedEventArgs e)
        {
            this.SetAxisYGridLinesVisibility();
        }

        private void AxisXStripLinesChecked(object sender, RoutedEventArgs e)
        {
            this.SetAxisXStripLinesVisibility();
        }

        private void AxisYStripLinesChecked(object sender, RoutedEventArgs e)
        {
            this.SetAxisYStripLinesVisibility();
        }

        private void XAxisTitleTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            this.SetAxisXTitle();
        }

        private void YAxisTitleTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            this.SetAxisYTitle();
        }

        private void SetAxisXTitle()
        {
            RadChart1.DefaultView.ChartArea.AxisX.Title = AxisXTitleTextbox.Text;
        }

        private void SetAxisYTitle()
        {
            RadChart1.DefaultView.ChartArea.AxisY.Title = AxisYTitleTextbox.Text;
        }

        private void SetItemToolTipVisibility()
        {
            if (RadChart1.DefaultView.ChartArea.DataSeries.Count > 0)
                RadChart1.DefaultView.ChartArea.DataSeries[0].Definition.ShowItemToolTips = (bool)ShowTooltipsCheckbox.IsChecked;
        }

        private void SetItemLabelVisibility()
        {
            if (RadChart1.DefaultView.ChartArea.DataSeries.Count > 0)
                RadChart1.DefaultView.ChartArea.DataSeries[0].Definition.ShowItemLabels = (bool)ShowLabelsCheckbox.IsChecked;
        }

        private void SetAxisXVisibility()
        {
            bool isChecked = (bool)AxisXCheckbox.IsChecked;
            if (isChecked)
                RadChart1.DefaultView.ChartArea.AxisX.Visibility = Visibility.Visible;
            else
                RadChart1.DefaultView.ChartArea.AxisX.Visibility = Visibility.Collapsed;
        }

        private void SetAxisYVisibility()
        {
            bool isChecked = (bool)AxisYCheckbox.IsChecked;
            if (isChecked)
                RadChart1.DefaultView.ChartArea.AxisY.Visibility = Visibility.Visible;
            else
                RadChart1.DefaultView.ChartArea.AxisY.Visibility = Visibility.Collapsed;
        }

        private void SetAxisXGridLinesVisibility()
        {
            bool isChecked = (bool)AxisXGridLinesCheckbox.IsChecked;
            if (isChecked)
                RadChart1.DefaultView.ChartArea.AxisX.MajorGridLinesVisibility = Visibility.Visible;
            else
                RadChart1.DefaultView.ChartArea.AxisX.MajorGridLinesVisibility = Visibility.Collapsed;
        }

        private void SetAxisYGridLinesVisibility()
        {
            bool isChecked = (bool)AxisYGridLinesCheckbox.IsChecked;
            if (isChecked)
                RadChart1.DefaultView.ChartArea.AxisY.MajorGridLinesVisibility = Visibility.Visible;
            else
                RadChart1.DefaultView.ChartArea.AxisY.MajorGridLinesVisibility = Visibility.Collapsed;
        }

        private void SetAxisXStripLinesVisibility()
        {
            bool isChecked = (bool)AxisXStripLinesCheckbox.IsChecked;
            if (isChecked)
                RadChart1.DefaultView.ChartArea.AxisX.StripLinesVisibility = Visibility.Visible;
            else
                RadChart1.DefaultView.ChartArea.AxisX.StripLinesVisibility = Visibility.Collapsed;
        }

        private void SetAxisYStripLinesVisibility()
        {
            bool isChecked = (bool)AxisYStripLinesCheckbox.IsChecked;
            if (isChecked)
                RadChart1.DefaultView.ChartArea.AxisY.StripLinesVisibility = Visibility.Visible;
            else
                RadChart1.DefaultView.ChartArea.AxisY.StripLinesVisibility = Visibility.Collapsed;
        }

        private void SetCustomAppearanceSettings()
        {
            RadChart1.DefaultView.ChartArea.DataSeries[0].Definition.Appearance.Fill = PaletteComboBox.SelectedValue as Brush;
            RadChart1.DefaultView.ChartArea.DataSeries[0].Definition.Appearance.Stroke = PaletteComboBox.SelectedValue as Brush;
        }

        private void InitializeFormatComboboxes()
        {
            AddFormats(this.FormatComboX, true, true);
            AddFormats(this.FormatComboY, false, true);
            AddFormats(this.FormatComboItem, false, false);
        }

        private void ChartArea1_ItemToolTipOpening(ItemToolTip2D tooltip, ItemToolTipEventArgs e)
        {
            tooltip.Content = string.Format("Day: {0}\r\nRevenue: {1}", DateTime.FromOADate(e.DataPoint.XValue).ToString("MMM/dd/yyyy"), string.Format("{0:C0}", e.DataPoint.YValue * 1000));
        }

        private void AddFormats(RadComboBox cb, bool isDateTime, bool isAxis)
        {
            cb.Items.Clear();

            if (isDateTime)
            {
                RadComboBoxItem cbi = new RadComboBoxItem();
                //StyleManager.SetTheme(cbi, new QuickStartTheme());
                cbi.Content = "MMM/dd/yy";
                cbi.IsSelected = true;
                cb.Items.Add(cbi);

                cbi = new RadComboBoxItem();
                //StyleManager.SetTheme(cbi, new QuickStartTheme());
                cbi.Content = "MM/dd/yyyy";

                cb.Items.Add(cbi);

                if (isAxis)
                {
                    cbi = new RadComboBoxItem();
                    //StyleManager.SetTheme(cbi, new QuickStartTheme());
                    cbi.Content = "Day: #VAL{dddd}";
                    cb.Items.Add(cbi);
                }

                cbi = new RadComboBoxItem();
                //StyleManager.SetTheme(cbi, new QuickStartTheme());
                cbi.Content = "HH:mm:ss";
                cb.Items.Add(cbi);

                cbi = new RadComboBoxItem();
                //StyleManager.SetTheme(cbi, new QuickStartTheme());
                cbi.Content = "yyyy MMMM";
                cb.Items.Add(cbi);
            }
            else
            {
                RadComboBoxItem cbi;

                cbi = new RadComboBoxItem();
                //StyleManager.SetTheme(cbi, new QuickStartTheme());
                cbi.Content = "N";
                cbi.IsSelected = true;
                cb.Items.Add(cbi);

                cbi = new RadComboBoxItem();
                //StyleManager.SetTheme(cbi, new QuickStartTheme());
                cbi.Content = "C";
                cb.Items.Add(cbi);

                if (isAxis)
                {
                    cbi = new RadComboBoxItem();
                    //StyleManager.SetTheme(cbi, new QuickStartTheme());
                    cbi.Content = "Amount: #VAL{C0}";
                    cb.Items.Add(cbi);
                }
                else
                {
                    cbi = new RadComboBoxItem();
                    //StyleManager.SetTheme(cbi, new QuickStartTheme());
                    cbi.Content = "Amount: #Y{C0}";
                    cb.Items.Add(cbi);
                }
            }
        }

        private void PaletteComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RadChart1.DefaultView.ChartArea.DataSeries.Count > 0)
                this.SetCustomAppearanceSettings();
        }

#if SILVERLIGHT
        private void ConfigureHideElementsCheckBox()
        {
            if (this.ConfigPanel.Children.IndexOf(this.HideElementsOnRotationCheckbox) == -1)
            {
                HideElementsOnRotationCheckbox.Content = "No-elements Rotation";
                HideElementsOnRotationCheckbox.Checked += this.HideElementsOnRotationChecked;
                HideElementsOnRotationCheckbox.Unchecked += this.HideElementsOnRotationChecked;
                this.ConfigPanel.Children.Insert(2, HideElementsOnRotationCheckbox);
            }
        }

        private void HideElementsOnRotationChecked(object sender, RoutedEventArgs e)
        {
            this.SetHideElementsOnRotation();
        }

        private void SetHideElementsOnRotation()
        {
            if (RadChart1.DefaultView.ChartArea.Extensions.Count > 0)
                (RadChart1.DefaultView.ChartArea.Extensions[0] as CameraExtension).HidePlaneElementsDuringRotation =
                    (bool)HideElementsOnRotationCheckbox.IsChecked;
        }
#endif
    }
}
