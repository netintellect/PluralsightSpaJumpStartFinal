using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.ChartView.MultipleAxes
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
#if SILVERLIGHT
        private const string ShapeRelativeUriFormat = "DataSources/Geospatial/europe.shp";
#else
        private const string ShapeRelativeUriFormat = "/ChartView;component/Resources/europe.shp";
#endif
        private IEnumerable gdpData2010;
        private IEnumerable gdpSelection;
        private bool isSavingsChecked;
        private bool isInvestmentChecked;
        private bool isInflationChecked;
        private bool isNetDebtChecked;
        private bool isGovrnmentRevenueChecked;
        private bool isGovernmentExpenditureChecked;
        private bool isGrowthChecked;
        private bool isAccountBalanceChecked;
        private string gdpLabel;
        private string gdpLabelFormat = "GDP, bln {0}";
        private string gdpIndicatorLabel;
        private DataPointBinding gdpIndicatorBinding;
        private string selectedCountryName;

        public ExampleViewModel()
        {
            this.SelectedCountryName = "United Kingdom";
            this.IsInvestmentChecked = true;
            this.GetData("GDPDetails.csv");
            this.GdpData2010 = GdpInfo.Create();
        }

        public Uri ShapeSourceUri
        {
            get
            {
                return new Uri(ShapeRelativeUriFormat, UriKind.Relative);
            }
        }

        public string SelectedCountryName
        {
            get
            {
                return this.selectedCountryName;
            }
            set
            {
                if (this.selectedCountryName != value)
                {
                    this.selectedCountryName = value;
                    this.OnPropertyChanged("SelectedCountryName");

                    this.GdpLabel = string.Format(gdpLabelFormat, localCurrency[value]);
                    this.UpdateGdpDataSelection(value);
                }
            }
        }

        public DataPointBinding GdpIndicatorBinding
        {
            get
            {
                return this.gdpIndicatorBinding;
            }
            set
            {
                if (this.gdpIndicatorBinding != value)
                {
                    this.gdpIndicatorBinding = value;
                    this.OnPropertyChanged("GdpIndicatorBinding");
                }
            }
        }

        public string GdpLabel
        {
            get
            {
                return this.gdpLabel;
            }
            set
            {
                if (this.gdpLabel != value)
                {
                    this.gdpLabel = value;
                    this.OnPropertyChanged("GdpLabel");
                }
            }
        }

        public string GdpIndicatorLabel
        {
            get
            {
                return this.gdpIndicatorLabel;
            }
            set
            {
                if (this.gdpIndicatorLabel != value)
                {
                    this.gdpIndicatorLabel = value;
                    this.OnPropertyChanged("GdpIndicatorLabel");
                }
            }
        }

        public bool IsSavingsChecked
        {
            get
            {
                return this.isSavingsChecked;
            }
            set
            {
                if (this.isSavingsChecked != value)
                {
                    this.isSavingsChecked = value;
                    this.OnPropertyChanged("IsSavingsChecked");

                    if (value)
                    {
                        this.GdpIndicatorLabel = "Gross National Savings, % of GDP";
                        this.GdpIndicatorBinding = new PropertyNameDataPointBinding("Savings");
                    }
                }
            }
        }

        public bool IsInvestmentChecked
        {
            get
            {
                return this.isInvestmentChecked;
            }
            set
            {
                if (this.isInvestmentChecked != value)
                {
                    this.isInvestmentChecked = value;
                    this.OnPropertyChanged("IsInvestmentChecked");

                    if (value)
                    {
                        this.GdpIndicatorLabel = "Investment, % of GDP";
                        this.GdpIndicatorBinding = new PropertyNameDataPointBinding("Investment");
                    }
                }
            }
        }

        public bool IsInflationChecked
        {
            get
            {
                return this.isInflationChecked;
            }
            set
            {
                if (this.isInflationChecked != value)
                {
                    this.isInflationChecked = value;
                    this.OnPropertyChanged("IsInflationChecked");

                    if (value)
                    {
                        this.GdpIndicatorLabel = "Inflation, average consumer price change %";
                        this.GdpIndicatorBinding = new PropertyNameDataPointBinding("Inflation");
                    }
                }
            }
        }

        public bool IsNetDebtChecked
        {
            get
            {
                return this.isNetDebtChecked;
            }
            set
            {
                if (this.isNetDebtChecked != value)
                {
                    this.isNetDebtChecked = value;
                    this.OnPropertyChanged("IsNetDebtChecked");

                    if (value)
                    {
                        this.GdpIndicatorLabel = "Total Government Net Debt, % of GDP";
                        this.GdpIndicatorBinding = new PropertyNameDataPointBinding("TotalGovernmentNetDebt");
                    }
                }
            }
        }

        public bool IsGovernmentRevenueChecked
        {
            get
            {
                return this.isGovrnmentRevenueChecked;
            }
            set
            {
                if (this.isGovrnmentRevenueChecked != value)
                {
                    this.isGovrnmentRevenueChecked = value;
                    this.OnPropertyChanged("IsGovernmentRevenueChecked");

                    if (value)
                    {
                        this.GdpIndicatorLabel = "General Government Revenue, % of GDP";
                        this.GdpIndicatorBinding = new PropertyNameDataPointBinding("GeneralGovernmentRevenue");
                    }
                }
            }
        }

        public bool IsGovernmentExpenditureChecked
        {
            get
            {
                return this.isGovernmentExpenditureChecked;
            }
            set
            {
                if (this.isGovernmentExpenditureChecked != value)
                {
                    this.isGovernmentExpenditureChecked = value;
                    this.OnPropertyChanged("IsGovernmentExpenditureChecked");

                    if (value)
                    {
                        this.GdpIndicatorLabel = "Gross Government Total Expenditure, % of GDP";
                        this.GdpIndicatorBinding = new PropertyNameDataPointBinding("GeneralGovernmentTotalExpenditure");
                    }
                }
            }
        }

        public bool IsGrowthChecked
        {
            get
            {
                return this.isGrowthChecked;
            }
            set
            {
                if (this.isGrowthChecked != value)
                {
                    this.isGrowthChecked = value;
                    this.OnPropertyChanged("IsGrowthChecked");

                    if (value)
                    {
                        this.GdpIndicatorLabel = "GDP Growth, annual % change";
                        this.GdpIndicatorBinding = new PropertyNameDataPointBinding("GdpGrowth");
                    }
                }
            }
        }

        public bool IsAccountBalanceChecked
        {
            get
            {
                return this.isAccountBalanceChecked;
            }
            set
            {
                if (this.isAccountBalanceChecked != value)
                {
                    this.isAccountBalanceChecked = value;
                    this.OnPropertyChanged("IsAccountBalanceChecked");

                    if (value)
                    {
                        this.GdpIndicatorLabel = "Current Account Balance, % of GDP";
                        this.GdpIndicatorBinding = new PropertyNameDataPointBinding("AccountBalance");
                    }
                }
            }
        }

        public IEnumerable GdpData2010
        {
            get
            {
                return this.gdpData2010;
            }
            set
            {
                if (this.gdpData2010 != value)
                {
                    this.gdpData2010 = value;
                    this.OnPropertyChanged("GdpData2010");
                }
            }
        }

        public IEnumerable GdpSelection
        {
            get
            {
                return this.gdpSelection;
            }
            set
            {
                if (this.gdpSelection != value)
                {
                    this.gdpSelection = value;
                    this.OnPropertyChanged("GdpSelection");
                }
            }
        }

        private IEnumerable<IGrouping<string, GdpDetailsInfo>> GdpDataDetails
        {
            get;
            set;
        }

        protected override IEnumerable ParseData(System.IO.TextReader dataReader)
        {
            string line;
            List<GdpDetailsInfo> dataList = new List<GdpDetailsInfo>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                var gdpDetails = new GdpDetailsInfo();
                gdpDetails.CountryName = data[0].Trim();
                if (!string.IsNullOrEmpty(data[1]))
                    gdpDetails.Year = int.Parse(data[1], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[2]))
                    gdpDetails.Value = double.Parse(data[2], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[3]))
                    gdpDetails.Savings = double.Parse(data[3], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[4]))
                    gdpDetails.Investment = double.Parse(data[4], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[5]))
                    gdpDetails.Inflation = double.Parse(data[5], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[6]))
                    gdpDetails.TotalGovernmentNetDebt = double.Parse(data[6], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[7]))
                    gdpDetails.GeneralGovernmentRevenue = double.Parse(data[7], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[8]))
                    gdpDetails.GeneralGovernmentTotalExpenditure = double.Parse(data[8], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[9]))
                    gdpDetails.GdpGrowth = double.Parse(data[9], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[10]))
                    gdpDetails.AccountBalance = double.Parse(data[10], CultureInfo.InvariantCulture);

                dataList.Add(gdpDetails);
            }

            return dataList;
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.GdpDataDetails = data.Cast<GdpDetailsInfo>().GroupBy(item => item.CountryName);
            this.UpdateGdpDataSelection(this.SelectedCountryName);
        }

        private void UpdateGdpDataSelection(string country)
        {
            if (this.GdpDataDetails == null)
                return;

            this.GdpSelection = this.GdpDataDetails.Single(group => (string)group.Key == country);
        }

        private readonly Dictionary<string, string> localCurrency = new Dictionary<string, string>()
            {
                { "Austria", "euro" },
                { "Belgium", "euro" },
                { "Bulgaria", "lev" },
                { "Cyprus", "euro" },
                { "Czech Republic", "koruna" }, 
                { "Denmark", "krone" },
                { "Estonia", "kroon" },
                { "Finland", "euro" },
                { "France", "euro" },
                { "Germany", "euro" },
                { "Greece", "euro" },
                { "Hungary", "forint" },
                { "Ireland", "euro" },
                { "Italy", "euro" },
                { "Latvia", "lats" },
                { "Lithuania", "litas" },
                { "Luxembourg", "euro" },
                { "Malta", "euro" },
                { "Netherlands", "euro" },
                { "Poland", "zloty" },
                { "Portugal", "euro" },
                { "Romania", "lei" },
                { "Slovakia", "koruna" },
                { "Slovenia", "euro" },
                { "Spain", "euro" },
                { "Sweden", "krona" },
                { "United Kingdom", "pound" }
            };
    }
}
