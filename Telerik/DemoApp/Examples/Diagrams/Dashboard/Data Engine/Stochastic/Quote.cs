using System;
using System.ComponentModel;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// Captures the stock information that Yahoo provides.
	/// </summary>
	public sealed class Quote : INotifyPropertyChanged
	{
		private decimal? ask;
		private decimal? averageDailyVolume;
		private decimal? bid;
		private decimal? bookValue;
		private decimal? change;
		private decimal? changeFromTwoHundredDayMovingAverage;
		private decimal? changeFromYearHigh;
		private decimal? changeFromYearLow;
		private decimal? changeInPercent;
		private decimal? changePercent;
		private decimal? dailyHigh;
		private decimal? dailyLow;
		private DateTime? dividendPayDate;
		private decimal? dividendShare;
		private decimal? dividendYield;
		private decimal? earningsShare;
		private decimal? ebitda;
		private decimal? epsEstimateCurrentYear;
		private decimal? epsEstimateNextQuarter;
		private decimal? epsEstimateNextYear;
		private DateTime? exDividendDate;
		private decimal? fiftyDayMovingAverage;
		private DateTime? lastTradeDate;
		private decimal? lastTradePrice;
		private DateTime lastUpdate;
		private decimal? marketCapitalization;
		private string name;
		private decimal? oneYearPriceTarget;
		private decimal? open;
		private decimal? peRatio;
		private decimal? pegRatio;
		private decimal? percentChangeFromFiftyDayMovingAverage;
		private decimal? percentChangeFromTwoHundredDayMovingAverage;
		private decimal? percentChangeFromYearHigh;
		private decimal? percentChangeFromYearLow;
		private decimal? previousClose;
		private decimal? priceBook;
		private decimal? priceEpsEstimateCurrentYear;
		private decimal? priceEpsEstimateNextYear;
		private decimal? priceSales;
		private decimal? shortRatio;
		private string stockExchange;
		private string symbol;
		private decimal? twoHunderedDayMovingAverage;
		private decimal? volume;
		private decimal? yearlyHigh;
		private decimal? yearlyLow;

		/// <summary>
		/// Initializes a new instance of the <see cref="Quote"/> class.
		/// </summary>
		/// <param name="ticker">The ticker.</param>
		public Quote(string ticker)
		{
			this.symbol = ticker;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Gets or sets the ask.
		/// </summary>
		/// <value>
		/// The ask.
		/// </value>
		public decimal? Ask
		{
			get
			{
				return this.ask;
			}
			set
			{
				this.ask = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Ask"));
				}
			}
		}

		public decimal? AverageDailyVolume
		{
			get
			{
				return this.averageDailyVolume;
			}
			set
			{
				this.averageDailyVolume = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("AverageDailyVolume"));
				}
			}
		}

		public decimal? Bid
		{
			get
			{
				return this.bid;
			}
			set
			{
				this.bid = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Bid"));
				}
			}
		}

		public decimal? BookValue
		{
			get
			{
				return this.bookValue;
			}
			set
			{
				this.bookValue = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("BookValue"));
				}
			}
		}

		public decimal? Change
		{
			get
			{
				return this.change;
			}
			set
			{
				this.change = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Change"));
				}
			}
		}

		public decimal? ChangeFromTwoHundredDayMovingAverage
		{
			get
			{
				return this.changeFromTwoHundredDayMovingAverage;
			}
			set
			{
				this.changeFromTwoHundredDayMovingAverage = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("ChangeFromTwoHundredDayMovingAverage"));
				}
			}
		}

		public decimal? ChangeFromYearHigh
		{
			get
			{
				return this.changeFromYearHigh;
			}
			set
			{
				this.changeFromYearHigh = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("ChangeFromYearHigh"));
				}
			}
		}

		public decimal? ChangeFromYearLow
		{
			get
			{
				return this.changeFromYearLow;
			}
			set
			{
				this.changeFromYearLow = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("ChangeFromYearLow"));
				}
			}
		}

		public decimal? ChangeInPercent
		{
			get
			{
				return this.changeInPercent;
			}
			set
			{
				this.changeInPercent = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("ChangeInPercent"));
				}
			}
		}

		public decimal? ChangePercent
		{
			get
			{
				return this.changePercent;
			}
			set
			{
				this.changePercent = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("ChangePercent"));
				}
			}
		}

		public decimal? DailyHigh
		{
			get
			{
				return this.dailyHigh;
			}
			set
			{
				this.dailyHigh = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("DailyHigh"));
				}
			}
		}

		public decimal? DailyLow
		{
			get
			{
				return this.dailyLow;
			}
			set
			{
				this.dailyLow = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("DailyLow"));
				}
			}
		}

		public DateTime? DividendPayDate
		{
			get
			{
				return this.dividendPayDate;
			}
			set
			{
				this.dividendPayDate = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("DividendPayDate"));
				}
			}
		}

		public decimal? DividendShare
		{
			get
			{
				return this.dividendShare;
			}
			set
			{
				this.dividendShare = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("DividendShare"));
				}
			}
		}

		public decimal? DividendYield
		{
			get
			{
				return this.dividendYield;
			}
			set
			{
				this.dividendYield = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("DividendYield"));
				}
			}
		}

		public decimal? EarningsShare
		{
			get
			{
				return this.earningsShare;
			}
			set
			{
				this.earningsShare = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("EarningsShare"));
				}
			}
		}

		public decimal? Ebitda
		{
			get
			{
				return this.ebitda;
			}
			set
			{
				this.ebitda = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Ebitda"));
				}
			}
		}

		public decimal? EpsEstimateCurrentYear
		{
			get
			{
				return this.epsEstimateCurrentYear;
			}
			set
			{
				this.epsEstimateCurrentYear = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("EpsEstimateCurrentYear"));
				}
			}
		}

		public decimal? EpsEstimateNextQuarter
		{
			get
			{
				return this.epsEstimateNextQuarter;
			}
			set
			{
				this.epsEstimateNextQuarter = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("EpsEstimateNextQuarter"));
				}
			}
		}

		public decimal? EpsEstimateNextYear
		{
			get
			{
				return this.epsEstimateNextYear;
			}
			set
			{
				this.epsEstimateNextYear = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("EpsEstimateNextYear"));
				}
			}
		}

		public DateTime? ExDividendDate
		{
			get
			{
				return this.exDividendDate;
			}
			set
			{
				this.exDividendDate = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("ExDividendDate"));
				}
			}
		}

		public decimal? FiftyDayMovingAverage
		{
			get
			{
				return this.fiftyDayMovingAverage;
			}
			set
			{
				this.fiftyDayMovingAverage = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("FiftyDayMovingAverage"));
				}
			}
		}

		public DateTime? LastTradeDate
		{
			get
			{
				return this.lastTradeDate;
			}
			set
			{
				this.lastTradeDate = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("LastTradeDate"));
				}
			}
		}

		public decimal? LastTradePrice
		{
			get
			{
				return this.lastTradePrice;
			}
			set
			{
				this.lastTradePrice = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("LastTradePrice"));
				}
			}
		}

		public DateTime LastUpdate
		{
			get
			{
				return this.lastUpdate;
			}
			set
			{
				this.lastUpdate = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("LastUpdate"));
				}
			}
		}

		public decimal? MarketCapitalization
		{
			get
			{
				return this.marketCapitalization;
			}
			set
			{
				this.marketCapitalization = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("MarketCapitalization"));
				}
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
				}
			}
		}

		public decimal? OneYearPriceTarget
		{
			get
			{
				return this.oneYearPriceTarget;
			}
			set
			{
				this.oneYearPriceTarget = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("OneYearPriceTarget"));
				}
			}
		}

		public decimal? Open
		{
			get
			{
				return this.open;
			}
			set
			{
				this.open = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Open"));
				}
			}
		}

		public decimal? PeRatio
		{
			get
			{
				return this.peRatio;
			}
			set
			{
				this.peRatio = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PeRatio"));
				}
			}
		}

		public decimal? PegRatio
		{
			get
			{
				return this.pegRatio;
			}
			set
			{
				this.pegRatio = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PegRatio"));
				}
			}
		}

		public decimal? PercentChangeFromFiftyDayMovingAverage
		{
			get
			{
				return this.percentChangeFromFiftyDayMovingAverage;
			}
			set
			{
				this.percentChangeFromFiftyDayMovingAverage = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PercentChangeFromFiftyDayMovingAverage"));
				}
			}
		}

		public decimal? PercentChangeFromTwoHundredDayMovingAverage
		{
			get
			{
				return this.percentChangeFromTwoHundredDayMovingAverage;
			}
			set
			{
				this.percentChangeFromTwoHundredDayMovingAverage = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PercentChangeFromTwoHundredDayMovingAverage"));
				}
			}
		}

		public decimal? PercentChangeFromYearHigh
		{
			get
			{
				return this.percentChangeFromYearHigh;
			}
			set
			{
				this.percentChangeFromYearHigh = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PercentChangeFromYearHigh"));
				}
			}
		}

		public decimal? PercentChangeFromYearLow
		{
			get
			{
				return this.percentChangeFromYearLow;
			}
			set
			{
				this.percentChangeFromYearLow = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PercentChangeFromYearLow"));
				}
			}
		}

		public decimal? PreviousClose
		{
			get
			{
				return this.previousClose;
			}
			set
			{
				this.previousClose = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PreviousClose"));
				}
			}
		}

		public decimal? PriceBook
		{
			get
			{
				return this.priceBook;
			}
			set
			{
				this.priceBook = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PriceBook"));
				}
			}
		}

		public decimal? PriceEpsEstimateCurrentYear
		{
			get
			{
				return this.priceEpsEstimateCurrentYear;
			}
			set
			{
				this.priceEpsEstimateCurrentYear = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PriceEpsEstimateCurrentYear"));
				}
			}
		}

		public decimal? PriceEpsEstimateNextYear
		{
			get
			{
				return this.priceEpsEstimateNextYear;
			}
			set
			{
				this.priceEpsEstimateNextYear = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PriceEpsEstimateNextYear"));
				}
			}
		}

		public decimal? PriceSales
		{
			get
			{
				return this.priceSales;
			}
			set
			{
				this.priceSales = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("PriceSales"));
				}
			}
		}

		public decimal? ShortRatio
		{
			get
			{
				return this.shortRatio;
			}
			set
			{
				this.shortRatio = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("ShortRatio"));
				}
			}
		}

		public string StockExchange
		{
			get
			{
				return this.stockExchange;
			}
			set
			{
				this.stockExchange = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("StockExchange"));
				}
			}
		}

		public string Symbol
		{
			get
			{
				return this.symbol;
			}
			set
			{
				this.symbol = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Symbol"));
				}
			}
		}

		public decimal? TwoHunderedDayMovingAverage
		{
			get
			{
				return this.twoHunderedDayMovingAverage;
			}
			set
			{
				this.twoHunderedDayMovingAverage = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("TwoHunderedDayMovingAverage"));
				}
			}
		}

		public decimal? Volume
		{
			get
			{
				return this.volume;
			}
			set
			{
				this.volume = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Volume"));
				}
			}
		}

		public decimal? YearlyHigh
		{
			get
			{
				return this.yearlyHigh;
			}
			set
			{
				this.yearlyHigh = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("YearlyHigh"));
				}
			}
		}

		public decimal? YearlyLow
		{
			get
			{
				return this.yearlyLow;
			}
			set
			{
				this.yearlyLow = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("YearlyLow"));
				}
			}
		}
	}
}