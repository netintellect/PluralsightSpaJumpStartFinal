using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.SmartLabels
{
    public class ExampleViewModel : ViewModelBase
    {
        private string _exampleTitle;

        private ICommand _changeSeriesTypeCommand;
        private ICommand _changeLabelDisplayModeCommand;
        private ICommand _changeLabelDistanceCommand;
        private ICommand _changeLabelOffsetCommand;
        private ICommand _changeShowConnectorsCommand;
        private ICommand _changeSpiderModeCommand;

        private SeriesMappingCollection _smartChartSeriesMappings;
        private SeriesMappingCollection _chartSeriesMappings;
        private object _data;
        private Dock _legendPosition;
        private Visibility _legendVisibility;
        private string _axisYTitle;
        private string _axisXLabelFormat;
        private string _axisYLabelFormat;
        private LabelDisplayMode _labelDisplayMode;

        private Visibility _barPanelVisibility;
        private Visibility _linePanelVisibility;
        private Visibility _piePanelVisibility;
        private Visibility _pieDistancePanelVisibility;
        private Visibility _pieLabelOffsetPanelVisibility;

        private int _barDistanceComboSelectedIndex;
        private int _barLabelModeComboSelectedIndex;
        private int _lineDistanceComboSelectedIndex;
        private bool _lineConnectorBoxIsChecked;
        private int _pieDistanceComboSelectedIndex;
        private int _pieLabelOffsetComboSelectedIndex;
        private bool _pieConnectorBoxIsChecked;
        private bool _pieSpiderBoxIsChecked;

        public ExampleViewModel()
        {
            this.WireCommands();
            this.Initialize();
        }

        private void Initialize()
        {
            this.ChartSeriesMappings = new SeriesMappingCollection();
            this.SmartChartSeriesMappings = new SeriesMappingCollection();

            this.BarPanelVisibility = Visibility.Collapsed;
            this.LinePanelVisibility = Visibility.Collapsed;

            this.ChangeSeriesType("Pie");
        }

        private void WireCommands()
        {
            this.ChangeSeriesTypeCommand = new DelegateCommand(ChangeSeriesType);
            this.ChangeLabelDisplayModeCommand = new DelegateCommand(ChangeLabelDisplayMode);
            this.ChangeLabelDistanceCommand = new DelegateCommand(ChangeLabelDistance);
            this.ChangeLabelOffsetCommand = new DelegateCommand(ChangeLabelOffset);
            this.ChangeShowConnectorsCommand = new DelegateCommand(ChangeShowConnectors);
            this.ChangeSpiderModeCommand = new DelegateCommand(ChangeSpiderMode);
        }

        public ICommand ChangeSeriesTypeCommand
        {
            get
            {
                return this._changeSeriesTypeCommand;
            }
            private set
            {
                this._changeSeriesTypeCommand = value;
            }
        }

        public ICommand ChangeLabelDisplayModeCommand
        {
            get
            {
                return this._changeLabelDisplayModeCommand;
            }
            private set
            {
                this._changeLabelDisplayModeCommand = value;
            }
        }

        public ICommand ChangeLabelDistanceCommand
        {
            get
            {
                return this._changeLabelDistanceCommand;
            }
            private set
            {
                this._changeLabelDistanceCommand = value;
            }
        }

        public ICommand ChangeLabelOffsetCommand
        {
            get
            {
                return this._changeLabelOffsetCommand;
            }
            private set
            {
                this._changeLabelOffsetCommand = value;
            }
        }

        public ICommand ChangeShowConnectorsCommand
        {
            get
            {
                return this._changeShowConnectorsCommand;
            }
            private set
            {
                this._changeShowConnectorsCommand = value;
            }
        }

        public ICommand ChangeSpiderModeCommand
        {
            get
            {
                return this._changeSpiderModeCommand;
            }
            private set
            {
                this._changeSpiderModeCommand = value;
            }
        }

        public Visibility BarPanelVisibility
        {
            get
            {
                return this._barPanelVisibility;
            }
            set
            {
                if (this._barPanelVisibility != value)
                {
                    this._barPanelVisibility = value;
                    this.OnPropertyChanged("BarPanelVisibility");
                }
            }
        }

        public Visibility LinePanelVisibility
        {
            get
            {
                return this._linePanelVisibility;
            }
            set
            {
                if (this._linePanelVisibility != value)
                {
                    this._linePanelVisibility = value;
                    this.OnPropertyChanged("LinePanelVisibility");
                }
            }
        }

        public Visibility PiePanelVisibility
        {
            get
            {
                return this._piePanelVisibility;
            }
            set
            {
                if (this._piePanelVisibility != value)
                {
                    this._piePanelVisibility = value;
                    this.OnPropertyChanged("PiePanelVisibility");
                }
            }
        }

        public LabelDisplayMode LabelDisplayMode
        {
            get
            {
                return this._labelDisplayMode;
            }
            set
            {
                if (this._labelDisplayMode != value)
                {
                    this._labelDisplayMode = value;
                    this.OnPropertyChanged("LabelDisplayMode");
                }
            }
        }

        public Dock LegendPosition
        {
            get
            {
                return this._legendPosition;
            }
            set
            {
                if (this._legendPosition != value)
                {
                    this._legendPosition = value;
                    this.OnPropertyChanged("LegendPosition");
                }
            }
        }

        public string ExampleTitle
        {
            get
            {
                return this._exampleTitle;
            }
            set
            {
                if (this._exampleTitle != value)
                {
                    this._exampleTitle = value;
                    this.OnPropertyChanged("ExampleTitle");
                }
            }
        }

        public SeriesMappingCollection SmartChartSeriesMappings
        {
            get
            {
                return this._smartChartSeriesMappings;
            }
            set
            {
                if (this._smartChartSeriesMappings != value)
                {
                    this._smartChartSeriesMappings = value;
                    this.OnPropertyChanged("SmartChartSeriesMappings");
                }
            }
        }

        public SeriesMappingCollection ChartSeriesMappings
        {
            get
            {
                return this._chartSeriesMappings;
            }
            set
            {
                if (this._chartSeriesMappings != value)
                {
                    this._chartSeriesMappings = value;
                    this.OnPropertyChanged("ChartSeriesMappings");
                }
            }
        }

        public object Data
        {
            get
            {
                return this._data;
            }
            set
            {
                if (this._data != value)
                {
                    this._data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }

        public Visibility LegendVisibility
        {
            get
            {
                return this._legendVisibility;
            }
            set
            {
                if (this._legendVisibility != value)
                {
                    this._legendVisibility = value;
                    this.OnPropertyChanged("LegendVisibility");
                }
            }
        }

        public string AxisYTitle
        {
            get
            {
                return this._axisYTitle;
            }
            set
            {
                if (this._axisYTitle != value)
                {
                    this._axisYTitle = value;
                    this.OnPropertyChanged("AxisYTitle");
                }
            }
        }

        public string AxisXLabelFormat
        {
            get
            {
                return this._axisXLabelFormat;
            }
            set
            {
                if (this._axisXLabelFormat != value)
                {
                    this._axisXLabelFormat = value;
                    this.OnPropertyChanged("AxisXLabelFormat");
                }
            }
        }

        public string AxisYLabelFormat
        {
            get
            {
                return this._axisYLabelFormat;
            }
            set
            {
                if (this._axisYLabelFormat != value)
                {
                    this._axisYLabelFormat = value;
                    this.OnPropertyChanged("AxisYLabelFormat");
                }
            }
        }

        public int BarDistanceComboSelectedIndex
        {
            get
            {
                return this._barDistanceComboSelectedIndex;
            }
            set
            {
                if (this._barDistanceComboSelectedIndex != value)
                {
                    this._barDistanceComboSelectedIndex = value;
                    this.OnPropertyChanged("BarDistanceComboSelectedIndex");
                }
            }
        }

        public int BarLabelModeComboSelectedIndex
        {
            get
            {
                return this._barLabelModeComboSelectedIndex;
            }
            set
            {
                if (this._barLabelModeComboSelectedIndex != value)
                {
                    this._barLabelModeComboSelectedIndex = value;
                    this.OnPropertyChanged("BarLabelModeComboSelectedIndex");
                }
            }
        }

        public int LineDistanceComboSelectedIndex
        {
            get
            {
                return this._lineDistanceComboSelectedIndex;
            }
            set
            {
                if (this._lineDistanceComboSelectedIndex != value)
                {
                    this._lineDistanceComboSelectedIndex = value;
                    this.OnPropertyChanged("LineDistanceComboSelectedIndex");
                }
            }
        }

        public bool LineConnectorBoxIsChecked
        {
            get
            {
                return this._lineConnectorBoxIsChecked;
            }
            set
            {
                if (this._lineConnectorBoxIsChecked != value)
                {
                    this._lineConnectorBoxIsChecked = value;
                    this.OnPropertyChanged("LineConnectorBoxIsChecked");
                }
            }
        }

        public int PieDistanceComboSelectedIndex
        {
            get
            {
                return this._pieDistanceComboSelectedIndex;
            }
            set
            {
                if (this._pieDistanceComboSelectedIndex != value)
                {
                    this._pieDistanceComboSelectedIndex = value;
                    this.OnPropertyChanged("PieDistanceComboSelectedIndex");
                }
            }
        }

        public int PieLabelOffsetComboSelectedIndex
        {
            get
            {
                return this._pieLabelOffsetComboSelectedIndex;
            }
            set
            {
                if (this._pieLabelOffsetComboSelectedIndex != value)
                {
                    this._pieLabelOffsetComboSelectedIndex = value;
                    this.OnPropertyChanged("PieLabelOffsetComboSelectedIndex");
                }
            }
        }

        public bool PieConnectorBoxIsChecked
        {
            get
            {
                return this._pieConnectorBoxIsChecked;
            }
            set
            {
                if (this._pieConnectorBoxIsChecked != value)
                {
                    this._pieConnectorBoxIsChecked = value;
                    this.OnPropertyChanged("PieConnectorBoxIsChecked");
                }
            }
        }

        public bool PieSpiderBoxIsChecked
        {
            get
            {
                return this._pieSpiderBoxIsChecked;
            }
            set
            {
                if (this._pieSpiderBoxIsChecked != value)
                {
                    this._pieSpiderBoxIsChecked = value;
                    this.OnPropertyChanged("PieSpiderBoxIsChecked");
                }
            }
        }

        public Visibility PieDistancePanelVisibility
        {
            get
            {
                return this._pieDistancePanelVisibility;
            }
            set
            {
                if (this._pieDistancePanelVisibility != value)
                {
                    this._pieDistancePanelVisibility = value;
                    this.OnPropertyChanged("PieDistancePanelVisibility");
                }
            }
        }

        public Visibility PieLabelOffsetPanelVisibility
        {
            get
            {
                return this._pieLabelOffsetPanelVisibility;
            }
            set
            {
                if (this._pieLabelOffsetPanelVisibility != value)
                {
                    this._pieLabelOffsetPanelVisibility = value;
                    this.OnPropertyChanged("PieLabelOffsetPanelVisibility");
                }
            }
        }

        public Brush ApplicationThemeAwareForeground
        {
            get
            {
                if (StyleManager.ApplicationTheme is Expression_DarkTheme)
                    return new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));

                return new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            }
        }

        public void ChangeLabelDisplayMode(object parameter)
        {
            if (parameter == null)
                return;

            LabelDisplayMode labelDisplayMode = (LabelDisplayMode)Enum.Parse(typeof(LabelDisplayMode), parameter.ToString(), true);

            SetLabelDisplayMode(this.SmartChartSeriesMappings, labelDisplayMode);
            SetLabelDisplayMode(this.ChartSeriesMappings, labelDisplayMode);
        }

        public void ChangeLabelDistance(object parameter)
        {
            if (parameter == null)
                return;

            double labelDistance = Convert.ToDouble(parameter, CultureInfo.InvariantCulture);

            this.SetLabelDistance(this.SmartChartSeriesMappings, labelDistance);
            this.SetLabelDistance(this.ChartSeriesMappings, labelDistance);
        }

        public void ChangeLabelOffset(object parameter)
        {
            if (parameter == null)
                return;

            double labelOffset = Convert.ToDouble(parameter, CultureInfo.InvariantCulture);

            this.SetLabelOffset(this.SmartChartSeriesMappings, labelOffset);
            this.SetLabelOffset(this.ChartSeriesMappings, labelOffset);
        }

        public void ChangeShowConnectors(object parameter)
        {
            if (parameter == null)
                return;

            bool shouldShowConnectors = Convert.ToBoolean(parameter, CultureInfo.InvariantCulture);

            this.ToggleShowConnectors(this.SmartChartSeriesMappings, shouldShowConnectors);
            this.ToggleShowConnectors(this.ChartSeriesMappings, shouldShowConnectors);
        }

        public void ChangeSpiderMode(object parameter)
        {
            if (parameter == null)
                return;

            bool shouldUseSpiderMode = Convert.ToBoolean(parameter, CultureInfo.InvariantCulture);

            this.ToggleSpiderMode(this.SmartChartSeriesMappings, shouldUseSpiderMode);
            this.ToggleSpiderMode(this.ChartSeriesMappings, shouldUseSpiderMode);

            this.PieConnectorBoxIsChecked = shouldUseSpiderMode;

            this.PieDistancePanelVisibility = shouldUseSpiderMode ? Visibility.Visible : Visibility.Collapsed;
            this.PieLabelOffsetPanelVisibility = shouldUseSpiderMode ? Visibility.Collapsed : Visibility.Visible;
        }

        public void ChangeSeriesType(object parameter)
        {
            if (parameter == null)
                return;

            string seriesType = parameter.ToString();

            this.BarPanelVisibility = Visibility.Collapsed;
            this.LinePanelVisibility = Visibility.Collapsed;
            this.PiePanelVisibility = Visibility.Collapsed;

            switch (seriesType)
            {
                case "Horizontal Bar":
                    DisplayHorizontalBar();
                    break;
                case "Line":
                    DisplayLine();
                    break;
                case "Pie":
                    DisplayPie();
                    break;
                default:
                    DisplayVerticalBar();
                    break;
            }
        }

        private void DisplayHorizontalBar()
        {
            this.Data = null;
            this.SmartChartSeriesMappings.Clear();
            this.ChartSeriesMappings.Clear();

            this.SmartChartSeriesMappings.Add(this.ConfigureCompanyMapping(new HorizontalBarSeriesDefinition()));
            this.ChartSeriesMappings.Add(this.ConfigureCompanyMapping(new HorizontalBarSeriesDefinition()));
            this.Data = this.CreateCompanyData();
            this.BarPanelVisibility = Visibility.Visible;
            this.ResetBarCombo();

            this.BarLabelModeComboSelectedIndex = 1;
            this.ExampleTitle = "Smartphone Sales Worldwide";

            this.LegendVisibility = Visibility.Collapsed;
            this.AxisYTitle = null;
        }

        private void DisplayLine()
        {
            this.ClearDataState();

            this.SmartChartSeriesMappings.Add(this.ConfigureLineMapping(0, "Mobile Internet Users"));
            this.SmartChartSeriesMappings.Add(this.ConfigureLineMapping(1, "Desktop Internet Users"));
            this.ChartSeriesMappings.Add(this.ConfigureLineMapping(0, "Mobile Internet Users"));
            this.ChartSeriesMappings.Add(this.ConfigureLineMapping(1, "Desktop Internet Users"));
            this.Data = this.CreateLineData();
            this.LinePanelVisibility = Visibility.Visible;
            this.ResetLineCombo();

            this.LineConnectorBoxIsChecked = true;
            this.ChangeShowConnectors(true);

            this.ExampleTitle = "Mobile vs. Desktop Internet Users Within 5 Years";

            this.LegendVisibility = Visibility.Visible;
            this.LegendPosition = Dock.Bottom;

            this.AxisYTitle = "Internet Users (MM)";
            this.AxisXLabelFormat = "yyyy";
            this.AxisYLabelFormat = null;
        }

        private void DisplayPie()
        {
            this.ClearDataState();

            PieSeriesDefinition definition1 = new PieSeriesDefinition();
            definition1.StartAngle = 130d;
            definition1.RadiusFactor = 0.5;
            definition1.LabelSettings = new RadialLabelSettings();
            this.SmartChartSeriesMappings.Add(this.ConfigureCompanyMapping(definition1));

            PieSeriesDefinition definition2 = new PieSeriesDefinition();
            definition2.StartAngle = 130d;
            definition2.RadiusFactor = 0.5;
            definition2.LabelSettings = new RadialLabelSettings();
            this.ChartSeriesMappings.Add(this.ConfigureCompanyMapping(definition2));

            this.Data = this.CreateCompanyData();

            this.PiePanelVisibility = Visibility.Visible;
            this.ResetPieCombo();

            this.ExampleTitle = "Smartphone Sales Worldwide";
            this.LegendVisibility = Visibility.Collapsed;
            this.AxisYTitle = null;
        }

        private void DisplayVerticalBar()
        {
            this.ClearDataState();

            this.SmartChartSeriesMappings.Add(this.ConfigureCompanyMapping(new BarSeriesDefinition()));
            this.ChartSeriesMappings.Add(this.ConfigureCompanyMapping(new BarSeriesDefinition()));
            this.Data = this.CreateCompanyData();

            this.BarPanelVisibility = Visibility.Visible;
            this.ResetBarCombo();

            this.BarLabelModeComboSelectedIndex = 1;

            this.ExampleTitle = "Smartphone Sales Worldwide";
            this.LegendVisibility = Visibility.Collapsed;
            this.AxisYTitle = null;
        }

        private void ClearDataState()
        {
            this.Data = null;
            this.SmartChartSeriesMappings.Clear();
            this.ChartSeriesMappings.Clear();
        }

        private SeriesMapping ConfigureCompanyMapping(SeriesDefinition definition)
        {
            SeriesMapping mapping = new SeriesMapping();
            mapping.SeriesDefinition = definition;
            mapping.ItemMappings.Add(new ItemMapping("Name", DataPointMember.XCategory));
            mapping.ItemMappings.Add(new ItemMapping("Share", DataPointMember.YValue));
            mapping.SeriesDefinition.ItemLabelFormat = "#Y% #XCAT";

            return mapping;
        }

        private SeriesMapping ConfigureLineMapping(int collectionIndex, string legendLabel)
        {
            SeriesMapping mapping = new SeriesMapping();
            mapping.SeriesDefinition = new LineSeriesDefinition();
            mapping.LegendLabel = legendLabel;
            mapping.CollectionIndex = collectionIndex;
            mapping.ItemMappings.Add(new ItemMapping("TimeStamp", DataPointMember.XValue));
            mapping.ItemMappings.Add(new ItemMapping("Value", DataPointMember.YValue));

            return mapping;
        }

        private IEnumerable<Company> CreateCompanyData()
        {
            List<Company> companyData = new List<Company>(6);
            companyData.Add(new Company("Nokia", 45d));
            companyData.Add(new Company("RIM", 19d));
            companyData.Add(new Company("Other", 14d));
            companyData.Add(new Company("Apple", 13d));
            companyData.Add(new Company("HTC", 6d));
            companyData.Add(new Company("Fujitsu", 3d));

            return companyData;
        }

        private IEnumerable<IEnumerable<Revenue>> CreateLineData()
        {
            List<IEnumerable<Revenue>> revenueData = new List<IEnumerable<Revenue>>();

            List<Revenue> revenueData1 = new List<Revenue>();
            revenueData1.Add(new Revenue(new DateTime(2009, 1, 1), 740));
            revenueData1.Add(new Revenue(new DateTime(2010, 1, 1), 940));
            revenueData1.Add(new Revenue(new DateTime(2011, 1, 1), 1170));
            revenueData1.Add(new Revenue(new DateTime(2012, 1, 1), 1388));
            revenueData1.Add(new Revenue(new DateTime(2013, 1, 1), 1540));
            revenueData1.Add(new Revenue(new DateTime(2014, 1, 1), 1720));
            revenueData1.Add(new Revenue(new DateTime(2015, 1, 1), 2000));

            List<Revenue> revenueData2 = new List<Revenue>();
            revenueData2.Add(new Revenue(new DateTime(2009, 1, 1), 1350));
            revenueData2.Add(new Revenue(new DateTime(2010, 1, 1), 1400));
            revenueData2.Add(new Revenue(new DateTime(2011, 1, 1), 1490));
            revenueData2.Add(new Revenue(new DateTime(2012, 1, 1), 1535));
            revenueData2.Add(new Revenue(new DateTime(2013, 1, 1), 1610));
            revenueData2.Add(new Revenue(new DateTime(2014, 1, 1), 1680));
            revenueData2.Add(new Revenue(new DateTime(2015, 1, 1), 1700));

            revenueData.Add(revenueData1);
            revenueData.Add(revenueData2);

            return revenueData;
        }

        private void ResetBarCombo()
        {
            this.BarDistanceComboSelectedIndex = 0;
            this.BarLabelModeComboSelectedIndex = 0;
        }

        private void ResetLineCombo()
        {
            this.LineDistanceComboSelectedIndex = 0;
            this.LineConnectorBoxIsChecked = false;
        }

        private void ResetPieCombo()
        {
            this.PieDistanceComboSelectedIndex = 0;
            this.PieLabelOffsetComboSelectedIndex = 0;
            this.PieConnectorBoxIsChecked = false;
            this.PieSpiderBoxIsChecked = false;
            this.PieDistancePanelVisibility = Visibility.Collapsed;
            this.PieLabelOffsetPanelVisibility = Visibility.Visible;
        }

        private void ToggleSpiderMode(SeriesMappingCollection seriesMappings, bool shouldShowConnectors)
        {
            foreach (SeriesMapping seriesMapping in seriesMappings)
            {
                RadialSeriesDefinition definition = seriesMapping.SeriesDefinition as RadialSeriesDefinition;

                if (definition != null)
                {
                    RadialLabelSettings settings = (definition.LabelSettings as RadialLabelSettings);
                    settings.SpiderModeEnabled = shouldShowConnectors;
                    settings.ShowConnectors = shouldShowConnectors;
                }
            }
        }

        private void ToggleShowConnectors(SeriesMappingCollection seriesMappings, bool shouldShowConnectors)
        {
            foreach (SeriesMapping seriesMapping in seriesMappings)
            {
                LabelSettings settings;
                ISeriesDefinition definition = seriesMapping.SeriesDefinition;

                if (definition is LinearSeriesDefinition)
                    settings = (definition as LinearSeriesDefinition).LabelSettings;
                else if (definition is RadialSeriesDefinition)
                    settings = (definition as RadialSeriesDefinition).LabelSettings;
                else
                    return;

                settings.ShowConnectors = shouldShowConnectors;
            }
        }

        private void SetLabelOffset(SeriesMappingCollection seriesMappings, double labelOffset)
        {
            foreach (SeriesMapping seriesMapping in seriesMappings)
            {
                RadialSeriesDefinition definition = seriesMapping.SeriesDefinition as RadialSeriesDefinition;

                if (definition != null)
                    definition.LabelSettings.LabelOffset = labelOffset;
            }
        }

        private void SetLabelDistance(SeriesMappingCollection seriesMappings, double labelDistance)
        {
            foreach (SeriesMapping seriesMapping in seriesMappings)
            {
                LabelSettings settings;
                ISeriesDefinition definition = seriesMapping.SeriesDefinition;

                if (definition is LinearSeriesDefinition)
                    settings = (definition as LinearSeriesDefinition).LabelSettings;
                else if (definition is RadialSeriesDefinition)
                    settings = (definition as RadialSeriesDefinition).LabelSettings;
                else if (definition is BarSeriesDefinition)
                    settings = (definition as BarSeriesDefinition).LabelSettings;
                else
                    return;

                settings.Distance = labelDistance;
            }
        }

        private void SetLabelDisplayMode(SeriesMappingCollection seriesMappings, LabelDisplayMode labelDisplayMode)
        {
            foreach (SeriesMapping seriesMapping in seriesMappings)
            {
                BarSeriesDefinition definition = seriesMapping.SeriesDefinition as BarSeriesDefinition;

                if (definition != null)
                    definition.LabelSettings.LabelDisplayMode = labelDisplayMode;
            }
        }
    }
}
