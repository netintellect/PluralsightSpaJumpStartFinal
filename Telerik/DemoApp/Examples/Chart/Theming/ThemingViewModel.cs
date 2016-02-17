using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using System.Collections.Generic;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.Theming
{
    public class ThemingViewModel: ViewModelBase
    {
        private SeriesMappingCollection _lineChartSeriesMappings;
        private SeriesMappingCollection _barChartSeriesMappings;
        private SeriesMappingCollection _pieChartSeriesMappings;
        private SeriesMappingCollection _stacked100AreaChartSeriesMappings;
        private object _data;
        private object _lineData;
        private object _barData;
        private object _stacked100AreaData;

        public ThemingViewModel()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.BarChartSeriesMappings = new SeriesMappingCollection();
            this.DisplayBar();
            this.LineChartSeriesMappings = new SeriesMappingCollection();
            this.DisplayLine();
            this.Stacked100AreaChartSeriesMappings = new SeriesMappingCollection();
            this.DisplayStacked100Area();
            this.PieChartSeriesMappings = new SeriesMappingCollection();
            this.DisplayPie();
        }

        public SeriesMappingCollection BarChartSeriesMappings
        {
            get
            {
                return this._barChartSeriesMappings;
            }
            set
            {
                if (this._barChartSeriesMappings != value)
                {
                    this._barChartSeriesMappings = value;
                    this.OnPropertyChanged("BarChartSeriesMappings");
                }
            }
        }

        public SeriesMappingCollection LineChartSeriesMappings
        {
            get
            {
                return this._lineChartSeriesMappings;
            }
            set
            {
                if (this._lineChartSeriesMappings != value)
                {
                    this._lineChartSeriesMappings = value;
                    this.OnPropertyChanged("LineChartSeriesMappings");
                }
            }
        }

        public SeriesMappingCollection Stacked100AreaChartSeriesMappings
        {
            get
            {
                return this._stacked100AreaChartSeriesMappings;
            }
            set
            {
                if (this._stacked100AreaChartSeriesMappings != value)
                {
                    this._stacked100AreaChartSeriesMappings = value;
                    this.OnPropertyChanged("Stacked100AreaChartSeriesMappings");
                }
            }
        }

        public SeriesMappingCollection PieChartSeriesMappings
        {
            get
            {
                return this._pieChartSeriesMappings;
            }
            set
            {
                if (this._pieChartSeriesMappings != value)
                {
                    this._pieChartSeriesMappings = value;
                    this.OnPropertyChanged("PieChartSeriesMappings");
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

        public object Stacked100AreaData
        {
            get
            {
                return this._stacked100AreaData;
            }
            set
            {
                if (this._stacked100AreaData != value)
                {
                    this._stacked100AreaData = value;
                    this.OnPropertyChanged("Stacked100AreaData");
                }
            }
        }

        public object BarData
        {
            get
            {
                return this._barData;
            }
            set
            {
                if (this._barData != value)
                {
                    this._barData = value;
                    this.OnPropertyChanged("BarData");
                }
            }
        }


        public object LineData
        {
            get
            {
                return this._lineData;
            }
            set
            {
                if (this._lineData != value)
                {
                    this._lineData = value;
                    this.OnPropertyChanged("LineData");
                }
            }
        }

        private IEnumerable<IEnumerable<Data>> CreateBarData()
        {
            DateTime today = DateTime.Today;
            List<IEnumerable<Data>> BarData = new List<IEnumerable<Data>>();

            List<Data> IEdata = new List<Data>();
            IEdata.Add(new Data(today.AddYears(-3), 56.05));
            IEdata.Add(new Data(today.AddYears(-2), 47.4));
            IEdata.Add(new Data(today.AddYears(-1), 42.26));

            List<Data> FirefoxData = new List<Data>();
            FirefoxData.Add(new Data(today.AddYears(-3), 34.78));
            FirefoxData.Add(new Data(today.AddYears(-2), 39.14));
            FirefoxData.Add(new Data(today.AddYears(-1), 38.56));

            List<Data> ChromeData = new List<Data>();
            ChromeData.Add(new Data(today.AddYears(-3), 0.7));
            ChromeData.Add(new Data(today.AddYears(-2), 2.95));
            ChromeData.Add(new Data(today.AddYears(-1), 9.89));

            List<Data> OperaData = new List<Data>();
            OperaData.Add(new Data(today.AddYears(-3), 5.81));
            OperaData.Add(new Data(today.AddYears(-2), 6.69));
            OperaData.Add(new Data(today.AddYears(-1), 4.37));

            List<Data> SafariData = new List<Data>();
            SafariData.Add(new Data(today.AddYears(-3), 2.39));
            SafariData.Add(new Data(today.AddYears(-2), 2.83));
            SafariData.Add(new Data(today.AddYears(-1), 4.07));

            BarData.Add(IEdata);
            BarData.Add(FirefoxData);
            BarData.Add(ChromeData);
            BarData.Add(OperaData);
            BarData.Add(SafariData);

            return BarData;
        }

        private IEnumerable<IEnumerable<Data>> CreateStacked100AreaData()
        {
            List<IEnumerable<Data>> Stacked100AreaData = new List<IEnumerable<Data>>();

            List<Data> higher = new List<Data>();
            higher.Add(new Data(new DateTime(2009, 1, 1), 57));
            higher.Add(new Data(new DateTime(2010, 1, 1), 76));
            higher.Add(new Data(new DateTime(2011, 1, 1), 85.10));

            List<Data> data1024x768 = new List<Data>();
            data1024x768.Add(new Data(new DateTime(2009, 1, 1), 36));
            data1024x768.Add(new Data(new DateTime(2010, 1, 1), 20));
            data1024x768.Add(new Data(new DateTime(2011, 1, 1), 13.80));

            List<Data> lower = new List<Data>();
            lower.Add(new Data(new DateTime(2009, 1, 1), 7));
            lower.Add(new Data(new DateTime(2010, 1, 1), 4));
            lower.Add(new Data(new DateTime(2011, 1, 1), 1.10));

            Stacked100AreaData.Add(higher);
            Stacked100AreaData.Add(data1024x768);
            Stacked100AreaData.Add(lower);

            return Stacked100AreaData;
        }

        private IEnumerable<IEnumerable<Data>> CreateLineData()
        {
            DateTime today = DateTime.Today;
            List<IEnumerable<Data>> LineData = new List<IEnumerable<Data>>();

            List<Data> WinXPData = new List<Data>();
            WinXPData.Add(new Data("Q2,2010", 58.09));
            WinXPData.Add(new Data("Q3,2010", 51.79));
            WinXPData.Add(new Data("Q4,2010", 55.32));
            WinXPData.Add(new Data("Q1,2011", 48.03));

            List<Data> Win7Data = new List<Data>();
            Win7Data.Add(new Data("Q2,2010", 14.81));
            Win7Data.Add(new Data("Q3,2010", 19.47));
            Win7Data.Add(new Data("Q4,2010", 24.23));
            Win7Data.Add(new Data("Q1,2011", 29.13));

            List<Data> VistaData = new List<Data>();
            VistaData.Add(new Data("Q2,2010", 19.46));
            VistaData.Add(new Data("Q3,2010", 17.67));
            VistaData.Add(new Data("Q4,2010", 16.02));
            VistaData.Add(new Data("Q1,2011", 14.39));

            List<Data> MacOSXData = new List<Data>();
            MacOSXData.Add(new Data("Q2,2010", 5.75));
            MacOSXData.Add(new Data("Q3,2010", 5.7));
            MacOSXData.Add(new Data("Q4,2010", 6.17));
            MacOSXData.Add(new Data("Q1,2011", 6.56));

            List<Data> LinuxData = new List<Data>();
            LinuxData.Add(new Data("Q2,2010", 0.8));
            LinuxData.Add(new Data("Q3,2010", 0.78));
            LinuxData.Add(new Data("Q4,2010", 0.77));
            LinuxData.Add(new Data("Q1,2011", 0.75));
          
            LineData.Add(WinXPData);
            LineData.Add(Win7Data);
            LineData.Add(VistaData);
            LineData.Add(MacOSXData);
            LineData.Add(LinuxData);

            return LineData;
        }

        private IEnumerable<Data> CreatePieData()
        {
            List<Data> PieData = new List<Data>(4);
            PieData.Add(new Data("Google", 90.12));
            PieData.Add(new Data("Yahoo!", 3.94));
            PieData.Add(new Data("bing", 4.21));
            PieData.Add(new Data("Others", 1.73));

            return PieData;
        }


        private void DisplayBar()
        {
            this.BarChartSeriesMappings.Add(this.ConfigureBarMapping(0, "IE"));
            this.BarChartSeriesMappings.Add(this.ConfigureBarMapping(1, "FireFox"));
            this.BarChartSeriesMappings.Add(this.ConfigureBarMapping(2, "Chrome"));
            this.BarChartSeriesMappings.Add(this.ConfigureBarMapping(3, "Opera"));
            this.BarChartSeriesMappings.Add(this.ConfigureBarMapping(4, "Safari"));

            this.BarData = this.CreateBarData();
        }

        private void DisplayStacked100Area()
        {
            this.Stacked100AreaChartSeriesMappings.Add(this.ConfigureStacked100AreaMapping(0, "higher"));
            this.Stacked100AreaChartSeriesMappings.Add(this.ConfigureStacked100AreaMapping(1, "1024x768"));
            this.Stacked100AreaChartSeriesMappings.Add(this.ConfigureStacked100AreaMapping(2, "lower"));

            this.Stacked100AreaData = this.CreateStacked100AreaData();
        }

        private void DisplayLine()
        {
            this.LineChartSeriesMappings.Add(this.ConfigureLineMapping(0, "WinXP"));
            this.LineChartSeriesMappings.Add(this.ConfigureLineMapping(1, "Win7"));
            this.LineChartSeriesMappings.Add(this.ConfigureLineMapping(2, "Vista"));
            this.LineChartSeriesMappings.Add(this.ConfigureLineMapping(3, "MacOSX"));
            this.LineChartSeriesMappings.Add(this.ConfigureLineMapping(4, "Linux"));

            this.LineData = this.CreateLineData();
        }

        private void DisplayPie()
        {
            PieSeriesDefinition pie = new PieSeriesDefinition();
            pie.RadiusFactor = 0.8;
            pie.StartAngle = -240;
            pie.LabelSettings = new RadialLabelSettings();
            this.PieChartSeriesMappings.Add(this.ConfigurePieMapping(pie));
            this.Data = this.CreatePieData();
        }


        private SeriesMapping ConfigureBarMapping(int collectionIndex, string legendLabel)
        {
            SeriesMapping mapping = new SeriesMapping();
            mapping.SeriesDefinition = new BarSeriesDefinition() { ShowItemLabels = false};
            mapping.LegendLabel = legendLabel;
            mapping.CollectionIndex = collectionIndex;
            mapping.ItemMappings.Add(new ItemMapping("TimeStamp", DataPointMember.XCategory));
            mapping.ItemMappings.Add(new ItemMapping("Value", DataPointMember.YValue));
            return mapping;
        }

        private SeriesMapping ConfigureStacked100AreaMapping(int collectionIndex, string legendLabel)
        {
            SeriesMapping mapping = new SeriesMapping();
            mapping.SeriesDefinition = new StackedArea100SeriesDefinition() { ShowItemLabels = false, ShowPointMarks = false };
            mapping.LegendLabel = legendLabel;
            mapping.CollectionIndex = collectionIndex;
            mapping.ItemMappings.Add(new ItemMapping("TimeStamp", DataPointMember.XCategory));
            mapping.ItemMappings.Add(new ItemMapping("Value", DataPointMember.YValue));
            return mapping;
        }

        private SeriesMapping ConfigureLineMapping(int collectionIndex, string legendLabel)
        {
            SeriesMapping mapping = new SeriesMapping();
            mapping.SeriesDefinition = new LineSeriesDefinition() { ShowItemLabels = false };
            mapping.LegendLabel = legendLabel;
            mapping.CollectionIndex = collectionIndex;
            mapping.ItemMappings.Add(new ItemMapping("Category", DataPointMember.XCategory));
            mapping.ItemMappings.Add(new ItemMapping("Value", DataPointMember.YValue));
            return mapping;
        }

        private SeriesMapping ConfigurePieMapping(SeriesDefinition definition)
        {
            SeriesMapping mapping = new SeriesMapping();
            mapping.SeriesDefinition = definition;
            mapping.ItemMappings.Add(new ItemMapping("Category", DataPointMember.LegendLabel));
            mapping.ItemMappings.Add(new ItemMapping("Value", DataPointMember.YValue));
            return mapping;
        }
    }
}
