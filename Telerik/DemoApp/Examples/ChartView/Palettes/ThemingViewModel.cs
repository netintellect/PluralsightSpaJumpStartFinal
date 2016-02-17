using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.Palettes
{
    public class ThemingViewModel : ViewModelBase
    {
        // Office <-> Forest
        // Windows8 <-> Windows8
        // Expression_Dark <-> Lilac
        // Windows7 <-> Spring
        // Vista <-> Flower
        // Summer <-> Summer

        private Random rand = new Random(123456);
        private object _data;
        private object _lineData;
        private object _polarData;
        private object _barData;
        private ChartPalette _palette;
        private List<ChartPalette> _palettes;

        public ThemingViewModel()
        {
            this.InitializeData();

            this.InitializePalettePresets();
        }

        private void InitializePalettePresets()
        {
            List<ChartPalette> palettes = new List<ChartPalette>();
            palettes.Add(ChartPalettes.Arctic);
            palettes.Add(ChartPalettes.Autumn);
            palettes.Add(ChartPalettes.Cold);
            palettes.Add(ChartPalettes.Flower);
            palettes.Add(ChartPalettes.Forest);
            palettes.Add(ChartPalettes.Grayscale);
            palettes.Add(ChartPalettes.Green);
            palettes.Add(ChartPalettes.Ground);
            palettes.Add(ChartPalettes.Lilac);
            palettes.Add(ChartPalettes.Natural);
            palettes.Add(ChartPalettes.Office2013);
            palettes.Add(ChartPalettes.Pastel);
            palettes.Add(ChartPalettes.Rainbow);
            palettes.Add(ChartPalettes.Spring);
            palettes.Add(ChartPalettes.Summer);
            palettes.Add(ChartPalettes.Warm);
            palettes.Add(ChartPalettes.Windows8);
            palettes.Add(ChartPalettes.VisualStudio2013);

            this.Palettes = palettes;
            this.Palette = ChartPalettes.Windows8;
        }

        private void InitializeData()
        {
            this.BarData = this.CreateBarData();
            this.LineData = this.CreateLineData();
            this.Data = this.CreatePieData();
            this.PolarData = this.CreatePolarData();
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

        public object PolarData
        {
            get
            {
                return this._polarData;
            }
            set
            {
                if (this._polarData != value)
                {
                    this._polarData = value;
                    this.OnPropertyChanged("PolarData");
                }
            }
        }

        public ChartPalette Palette
        {
            get
            {
                return this._palette;
            }
            set
            {
                if (this._palette != value)
                {
                    this._palette = value;
                    this.OnPropertyChanged("Palette");
                }
            }
        }

        public List<ChartPalette> Palettes
        {
            get
            {
                return this._palettes;
            }
            set
            {
                if (this._palettes != value)
                {
                    this._palettes = value;
                    this.OnPropertyChanged("Palettes");
                }
            }
        }

        private IEnumerable<IEnumerable<Data>> CreateBarData()
        {
            DateTime today = DateTime.Today;
            List<IEnumerable<Data>> BarData = new List<IEnumerable<Data>>();

            List<Data> FirefoxData = new List<Data>();
            FirefoxData.Add(new Data(today.AddYears(-2), 0.464));
            FirefoxData.Add(new Data(today.AddYears(-1), 0.435));
            FirefoxData.Add(new Data(today, 0.397));

            List<Data> ChromeData = new List<Data>();
            ChromeData.Add(new Data(today.AddYears(-2), 0.098));
            ChromeData.Add(new Data(today.AddYears(-1), 0.224));
            ChromeData.Add(new Data(today, 0.305));

            List<Data> IEdata = new List<Data>();
            IEdata.Add(new Data(today.AddYears(-2), 0.372));
            IEdata.Add(new Data(today.AddYears(-1), 0.275));
            IEdata.Add(new Data(today, 0.229));

            List<Data> SafariData = new List<Data>();
            SafariData.Add(new Data(today.AddYears(-2), 0.36));
            SafariData.Add(new Data(today.AddYears(-1), 0.38));
            SafariData.Add(new Data(today, 0.40));

            List<Data> OperaData = new List<Data>();
            OperaData.Add(new Data(today.AddYears(-2), 0.23));
            OperaData.Add(new Data(today.AddYears(-1), 0.22));
            OperaData.Add(new Data(today, 0.22));

            BarData.Add(FirefoxData);
            BarData.Add(ChromeData);
            BarData.Add(IEdata);
            BarData.Add(SafariData);
            BarData.Add(OperaData);

            return BarData;
        }

        private IEnumerable<IEnumerable<Data>> CreateLineData()
        {
            DateTime today = DateTime.Today;
            List<IEnumerable<Data>> LineData = new List<IEnumerable<Data>>();

            List<Data> WinXPData = new List<Data>();
            WinXPData.Add(new Data("Q2,2010", 0.5809));
            WinXPData.Add(new Data("Q3,2010", 0.5179));
            WinXPData.Add(new Data("Q4,2010", 0.5532));
            WinXPData.Add(new Data("Q1,2011", 0.4803));

            List<Data> Win7Data = new List<Data>();
            Win7Data.Add(new Data("Q2,2010", 0.1481));
            Win7Data.Add(new Data("Q3,2010", 0.1947));
            Win7Data.Add(new Data("Q4,2010", 0.2423));
            Win7Data.Add(new Data("Q1,2011", 0.2913));

            List<Data> VistaData = new List<Data>();
            VistaData.Add(new Data("Q2,2010", 0.1946));
            VistaData.Add(new Data("Q3,2010", 0.1767));
            VistaData.Add(new Data("Q4,2010", 0.1602));
            VistaData.Add(new Data("Q1,2011", 0.1439));

            List<Data> MacOSXData = new List<Data>();
            MacOSXData.Add(new Data("Q2,2010", 0.575));
            MacOSXData.Add(new Data("Q3,2010", 0.57));
            MacOSXData.Add(new Data("Q4,2010", 0.617));
            MacOSXData.Add(new Data("Q1,2011", 0.656));

            List<Data> LinuxData = new List<Data>();
            LinuxData.Add(new Data("Q2,2010", 0.08));
            LinuxData.Add(new Data("Q3,2010", 0.078));
            LinuxData.Add(new Data("Q4,2010", 0.077));
            LinuxData.Add(new Data("Q1,2011", 0.075));

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
            PieData.Add(new Data("Google", 82.35));
            PieData.Add(new Data("Yahoo!", 6.69));
            PieData.Add(new Data("Baidu", 5.12));
            PieData.Add(new Data("Others", 4.71));

            return PieData;
        }

        private IEnumerable<IEnumerable<PolarData>> CreatePolarData()
        {
            List<IEnumerable<PolarData>> polarDataList = new List<IEnumerable<PolarData>>();
            polarDataList.Add(this.FillData(100, 100));
            polarDataList.Add(this.FillData(100, 70));
            polarDataList.Add(this.FillData(100, 50));

            return polarDataList;
        }

        private IEnumerable<PolarData> FillData(int count, double scale)
        {
            List<PolarData> list = new List<PolarData>();

            double angleStep = 2 * Math.PI / count;

            for (int i = 0; i < count; i++)
            {
                double angle = i * angleStep;
                double c1 = 1.0 * Math.Sin(angle * 3);
                double c2 = 0.3 * Math.Sin(angle * 1.5);
                double c3 = 0.05 * Math.Cos(angle * 26);
                double c4 = 0.05 * (0.5 - this.rand.NextDouble());
                double value = scale * (Math.Abs(c1 + c2 + c3) + c4);

                if (value < 0)
                    value = 0;

                list.Add(new PolarData(angle * 180 / Math.PI, value));
            }

            return list;
        }
    }
}
