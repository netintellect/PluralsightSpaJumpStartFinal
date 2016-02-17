
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// A collection of methods related to random data generation.
	/// </summary>
	public static class DataGenerator
	{
		public const double Epsilon = 0.000001;
		private static MarkovNameGenerator markovMaleNameGenerator;
		private static MarkovNameGenerator markovFemaleNameGenerator;
		private static MarkovNameGenerator markovFamilyNameGenerator;

		/// <summary>
		/// The randomizer at the basis of all.
		/// </summary>
		private static readonly Random Rand = new Random(Environment.TickCount);

		public static int RandomInteger(int minimum = 0, int maximum = 100)
		{
			return Rand.Next(minimum, maximum);
		}
		
		/// <summary>
		/// Returns a random paragraph of lipsum text of the specified length.
		/// </summary>
		/// <param name="numWords">The num words; default is 25 and must be more than 5.</param>
		/// <returns></returns>
		public static string RandomLipsum(int numWords = 25)
		{
			numWords = System.Math.Max(numWords, 5);
			var sb = new StringBuilder();
			sb.Append("Lorem ipsum dolor sit amet");
			var counter = 5;
			var capitalize = false;
			for (var i = 0; i <= (numWords - 6); i++)
			{
				var newWord = DataStore.LipsumData[Rand.Next(DataStore.LipsumData.Length)];
				if (capitalize)
				{
					newWord = newWord.Capitalize();
					capitalize = false;
				}
				sb.AppendFormat(" {0}", newWord);
				counter++;

				// create sentences of random length;
				if (counter >= 15 && Rand.NextDouble() < .7)
				{
					sb.Append(".");
					counter = 0;
					capitalize = true;
				}
			}

			sb.Append(".");
			return sb.ToString();
		}
		public static decimal RandomValue(decimal minimum, decimal maximum, int digits = 2)
		{
			return decimal.Round(minimum + (decimal)Rand.NextDouble() * maximum, digits);
		}
		public static void RandomQuote(ref Quote quote)
		{
			RandomQuoteValues(ref quote);
		}
		public static Quote RandomQuoteValues(string symbol)
		{
			var quote = new Quote(symbol);
			RandomQuoteValues(ref quote);
			return quote;
		}
		private static void RandomQuoteValues(ref Quote quote)
		{
			quote.Ask = RandomValue(-255, 255);
			quote.Bid = RandomValue(0, 855);
			quote.AverageDailyVolume = RandomValue(0, 2255);
			quote.BookValue = RandomValue(0, 7255);
			quote.Change = RandomValue(10, 88);
			quote.DividendShare = RandomValue(0, 1255);
			quote.LastTradeDate = RandomDate(DateTime.Now.AddDays(-2), DateTime.Now);
			quote.EarningsShare = RandomValue(0, 1255);
			quote.EpsEstimateCurrentYear = RandomValue(0, 255);
			quote.EpsEstimateNextYear = RandomValue(0, 155);
			quote.EpsEstimateNextQuarter = RandomValue(0, 455);
			quote.DailyLow = RandomValue(-60, 15);
			quote.DailyHigh = RandomValue(10, 35);
			quote.YearlyLow = RandomValue(10, 25);
			quote.YearlyHigh = RandomValue(10, 35);
			quote.MarketCapitalization = RandomValue(10, 35);
			quote.Ebitda = RandomValue(10, 35);
			quote.ChangeFromYearLow = RandomValue(10, 35);
			quote.PercentChangeFromYearLow = RandomValue(10, 35);
			quote.ChangeFromYearHigh = RandomValue(-40, 35);
			quote.LastTradePrice = RandomValue(100, 235);
			quote.PercentChangeFromYearHigh = RandomValue(0, 99); ////missspelling in yahoo for field name
			quote.FiftyDayMovingAverage = RandomValue(10, 135);
			quote.TwoHunderedDayMovingAverage = RandomValue(10, 175);
			quote.ChangeFromTwoHundredDayMovingAverage = RandomValue(10, 135);
			quote.PercentChangeFromTwoHundredDayMovingAverage = RandomValue(10, 455);
			quote.PercentChangeFromFiftyDayMovingAverage = RandomValue(10, 85);
			quote.Name = quote.Symbol;
			quote.Open = RandomValue(17, 435);
			quote.PreviousClose = RandomValue(10, 435);
			quote.ChangeInPercent = RandomValue(4, 88);
			quote.PriceSales = RandomValue(10, 35);
			quote.PriceBook = RandomValue(100, 135);
			quote.ExDividendDate = RandomDate(DateTime.Now.AddDays(-2), DateTime.Now.AddMonths(1));
			quote.PeRatio = RandomValue(100, 135);
			quote.DividendPayDate = RandomDate(DateTime.Now.AddDays(-2), DateTime.Now.AddMonths(11));
			quote.PegRatio = RandomValue(100, 135);
			quote.PriceEpsEstimateCurrentYear = RandomValue(170, 195);
			quote.PriceEpsEstimateNextYear = RandomValue(100, 225);
			quote.ShortRatio = RandomValue(100, 236);
			quote.OneYearPriceTarget = RandomValue(100, 155);
			quote.Volume = RandomValue(1000, 1235);
			quote.StockExchange = "NASDAQ";

			quote.LastUpdate = RandomDate(DateTime.Now.AddMinutes(-200), DateTime.Now);
		}
		/// <summary>
		/// Returns a collection of person names.
		/// </summary>
		/// <param name="type">The option specifying the format of the returned names.</param>
		/// <param name="count">The amount of person names to be returned.</param>
		/// <returns></returns>
		public static IEnumerable<string> RandomPersonNameCollection(PersonDataType type = PersonDataType.FullNameWithMiddleInitial, int count = 15)
		{
			if (count < 1)
				throw new Exception("The amount of names to generate should be bigger than one.");
			if (count == 1) return new List<string> { RandomPersonName(type) };
			var list = new List<string>();
			Range.Create(1, count).ForEach(() => list.Add(RandomPersonName(type)));
			return list;
		}

		/// <summary>
		/// Returns a random person name.
		/// </summary>
		/// <param name="type">The option specifying the format of the returned name. Default is <see cref="PersonDataType.FullNameWithMiddleInitial"/>.</param>
		public static string RandomPersonName(PersonDataType type = PersonDataType.FullNameWithMiddleInitial)
		{
			switch (type)
			{
				case PersonDataType.FirstName:
					return RandomFirstName();
				case PersonDataType.MaleFirstName:
					return RandomMaleName();
				case PersonDataType.FemalFirstName:
					return RandomFemaleName();
				case PersonDataType.FamilyName:
					return RandomFamilyName();
				case PersonDataType.FullName:
					return String.Format("{0} {1}", RandomFirstName(), RandomFamilyName());
				case PersonDataType.FullNameWithMiddleInitial:
					return String.Format("{0} {1}. {2}", RandomFirstName(), RandomLetter(CaseType.UpperCase), RandomFamilyName());
				default:
					throw new ArgumentOutOfRangeException("type");
			}
		}
		private static string RandomFirstName()
		{
			if (Rand.NextDouble() < .5) return RandomFemaleName();
			else return RandomMaleName();
		}
		private static string RandomMaleName()
		{
			if (markovMaleNameGenerator == null)
				markovMaleNameGenerator = new MarkovNameGenerator(DataStore.EnglishMaleNames);
			return markovMaleNameGenerator.NextName;
		}

		public static List<string> RandomMaleNames(int count = 15)
		{
			if (count < 1) throw new Exception("The amount of names to generate should be bigger than one.");

			if (markovMaleNameGenerator == null) markovMaleNameGenerator = new MarkovNameGenerator(DataStore.EnglishMaleNames);

			if (count == 1) return new List<string> { RandomMaleName() };
			var list = new List<string>();
			Range.Create(1, count).ForEach(() => list.Add(markovMaleNameGenerator.NextName));
			return list;
		}

		private static string RandomFemaleName()
		{
			if (markovFemaleNameGenerator == null)
				markovFemaleNameGenerator = new MarkovNameGenerator(DataStore.EnglishFemaleNames);
			return markovFemaleNameGenerator.NextName;
		}
		private static string RandomFamilyName()
		{
			if (markovFamilyNameGenerator == null)
				markovFamilyNameGenerator = new MarkovNameGenerator(DataStore.FamilyNames);
			return markovFamilyNameGenerator.NextName;
		}

		public static List<string> RandomFemaleNames(int count = 15)
		{
			if (count < 1)
				throw new Exception("The amount of names to generate should be bigger than one.");
			if (count == 1) return new List<string> { RandomFemaleName() };

			if (markovFemaleNameGenerator == null)
				markovFemaleNameGenerator = new MarkovNameGenerator(DataStore.EnglishFemaleNames);
			var list = new List<string>();
			Range.Create(1, count).ForEach(() => list.Add(markovFemaleNameGenerator.NextName));
			return list;
		}

		/// <summary>
		/// Resets the markov chains and re-initializes on the basis of the data in the <see cref="DataStore"/>.
		/// Use this method if you have defined your own custom arrays in the <see cref="DataStore"/>.
		/// </summary>
		public static void ResetMarkovChains()
		{
			markovFamilyNameGenerator = null;
			markovFemaleNameGenerator = null;
			markovMaleNameGenerator = null;
		}

		public static string RandomLetter(CaseType type)
		{
			char start;
			switch (type)
			{
				case CaseType.UpperCase:
					start = 'A';
					break;
				case CaseType.LowerCase:
					start = 'A';
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}
			var num = Rand.Next(0, 26);
			var result = (char)((short)start + num);
			return result.ToString(CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Returns a random city name.
		/// </summary>
		/// <returns></returns>
		public static string RandomCityName()
		{
			return DataStore.CityNames[Rand.Next(DataStore.CityNames.Length)];
		}

		/// <summary>
		/// Returns a random zip code.
		/// </summary>
		/// <returns></returns>
		public static string RandomZipCode()
		{
			return DataStore.ZipCodes[Rand.Next(DataStore.ZipCodes.Length)];
		}

		/// <summary>
		/// Returns a random state name.
		/// </summary>
		/// <returns></returns>
		public static string RandomStateName()
		{
			return DataStore.StateNames[Rand.Next(DataStore.StateNames.Length)];
		}

		/// <summary>
		/// Returns a random country name.
		/// </summary>
		/// <returns></returns>
		public static string RandomCountryName()
		{
			return DataStore.CountryNames[Rand.Next(DataStore.CountryNames.Length)];
		}

		/// <summary>
		/// Returns a random company name.
		/// </summary>
		/// <returns></returns>
		public static string RandomCompanyName()
		{
			return Rand.NextDouble() < .4
					? String.Format(
						"{0} {1}",
						DataStore.CompanyNames[Rand.Next(DataStore.CompanyNames.Length)],
						DataStore.CompanySuffixes[Rand.Next(DataStore.CompanySuffixes.Length)])
					: DataStore.CompanyNames[Rand.Next(DataStore.CompanyNames.Length)];
		}

		/// <summary>
		/// Levy random distribution with mean zero and variance <c>c*Sqrt2</c>.
		/// See http://en.wikipedia.org/wiki/L%C3%A9vy_distribution .
		/// </summary>
		/// <param name="c">The scale parameter; positive value. The higher, the more flat the distribution.</param>
		/// <param name="mu">The location parameter, the distribution is only defined then for values bigger than this parameter.</param>
		/// <returns></returns>
		public static double LevyRandom(double c = 5.5, double mu = 1)
		{
			double u, v, t, s;

			u = Math.PI * (Rand.NextDouble() - 0.5);

			// the Cauchy case
			if (Math.Abs(mu - 1) < Epsilon)
			{
				t = Math.Tan(u);
				return c * t;
			}

			do
			{
				v = -Math.Log(Rand.NextDouble());
			} while (Math.Abs(v - 0) < Epsilon);

			// the Gaussian case
			if (Math.Abs(mu - 2) < Epsilon)
			{
				t = 2 * Math.Sin(u) * Math.Sqrt(v);
				return c * t;
			}

			// the general case
			t = Math.Sin(mu * u) / Math.Pow(Math.Cos(u), 1 / mu);
			s = Math.Pow(Math.Cos((1 - mu) * u) / v, (1 - mu) / mu);

			return c * t * s;
		}
		/// <summary>
		/// Generates a collection of random document titles.
		/// </summary>
		/// <param name="count">The amount of items to generate.</param>
		/// <returns></returns>
		public static List<string> RandomDocumentTitleCollection(int count)
		{
			var rx = new Regex(@"(\S.+?[.!?])(?=\s+|$)");
			var list = new List<string>();
			while (list.Count < count)
			{
				list.AddRange((from Match match in rx.Matches(MarkovTextGenerator.Generate(DataStore.DocumentTitleSample, 140, 3)) let i = match.Index select match).Select(match => UtilityExtensions.ToSentenceCase(match.Value)));
			}
			return list.Take(count).ToList();
		}
		
		/// <summary>
		/// Generates a collection of random financial headlines.
		/// </summary>
		/// <param name="count">The amount of items to generate.</param>
		/// <returns></returns>
		public static List<string> RandomFinanceHeadlineCollection(int count)
		{
			var rx = new Regex(@"(\S.+?[.!?])(?=\s+|$)");
			var list = new List<string>();
			while (list.Count < count)
			{
				list.AddRange((from Match match in rx.Matches(MarkovTextGenerator.Generate(DataStore.FinanceHeadlineSample, 140, 3)) let i = match.Index select match).Select(match => UtilityExtensions.ToSentenceCase(match.Value)));
			}
			return list.Take(count).ToList();
		}



		/// <summary>
		/// Returns a random street name.
		/// </summary>
		/// <returns></returns>
		public static string RandomStreetName(bool includeHouseNumber = true)
		{
			return includeHouseNumber ? String.Format("{0} {1}", DataStore.StreetNames[Rand.Next(DataStore.StreetNames.Length)], Rand.Next(542)) : DataStore.StreetNames[Rand.Next(DataStore.StreetNames.Length)];
		}

		/// <summary>
		/// Generates a random address.
		/// </summary>
		/// <remarks>The address type if a flag type so you can combine the options. The default includes all options.</remarks>
		/// <param name="type">The address type.</param>
		/// <returns></returns>
		public static string RandomAddress(AddressType type = AddressType.CompanyName|AddressType.CountryName|AddressType.StateName)
		{
			var sb = new StringBuilder();
			if ((type & AddressType.CompanyName) == AddressType.CompanyName) sb.AppendLine(RandomCompanyName());
			sb.AppendLine(RandomStreetName());
			sb.AppendLine(String.Format("{0} {1}", RandomZipCode(), RandomCityName()));
			if ((type & AddressType.StateName) == AddressType.StateName) sb.AppendLine(String.Format("{0}, {1}", RandomStateName(), RandomCountryName()));
			else sb.AppendLine(RandomCountryName());
			return sb.ToString();
		}

		/// <summary>
		/// Returns a collection of address.
		/// </summary>
		/// <param name="type">The option specifying the format of the returned addresses.</param>
		/// <param name="count">The amount of addresses to be returned.</param>
		/// <returns></returns>
		public static IEnumerable<string> RandomAddressCollection(AddressType type = AddressType.CompanyName|AddressType.StateName|AddressType.CountryName, int count = 15)
		{
			if (count < 1)
				throw new Exception("The amount of addresses to generate should be bigger than one.");
			if (count == 1) return new List<string> { RandomAddress(type) };
			var list = new List<string>();
			Range.Create(1, count).ForEach(() => list.Add(RandomAddress(type)));
			return list;
		}
		/// <summary>
		/// Generates a random variation of a philosophical text.
		/// </summary>
		/// <param name="style">The style of text to base the variation on.</param>
		/// <param name="size">The size of the text to generate.</param>
		/// <returns></returns>
		public static string RandomTextVariation(TextSamples style, int size = 1000)
		{
			string sample;
			switch (style)
			{
				case TextSamples.Latin:
					sample = DataStore.LatinSample;
					break;
				case TextSamples.Spanish:
					sample = DataStore.SpanishSample;
					break;
				case TextSamples.Bulgarian:
					sample = DataStore.BulgarianSample;
					break;
				case TextSamples.Biology:
					sample = DataStore.BiologySample;
					break;
				case TextSamples.Finance:
					sample = DataStore.FinanceSample;
					break;
				case TextSamples.FinanceProfile:
					sample = DataStore.FinanceProfileSample;
					break;
				case TextSamples.Philosophy:
					sample = DataStore.PhilosophySample;
					break;
				case TextSamples.English1:
					sample = DataStore.English1Sample;
					break;
				case TextSamples.English2:
					sample = DataStore.English2Sample;
					break;
				default:
					throw new ArgumentOutOfRangeException("style");
			}
			return MarkovTextGenerator.Generate(sample, size);
		}
		/// <summary>
		/// Returns a random file extension.
		/// </summary>
		/// <remarks>The optional <see cref="FileExtensionType"/> is a flag enumeration and you can combine different types.</remarks>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static string RandomFileExtension(FileExtensionType type = FileExtensionType.CommonFiles|FileExtensionType.MsOffice)
		{
			var list = new List<string>();
			if ((type & FileExtensionType.CommonFiles) == FileExtensionType.CommonFiles) list.AddRange(DataStore.CommonExtensions.Keys);
			if ((type & FileExtensionType.MsOffice) == FileExtensionType.MsOffice) list.AddRange(DataStore.OfficeExtensions.Keys);
			return list[Rand.Next(list.Count)].ToLower();
		}

		/// <summary>
		/// Gets the file extension description, if available.
		/// </summary>
		/// <param name="extension">The extension to look up.</param>
		/// <returns></returns>
		public static string GetFileExtensionDescription(string extension)
		{
			if (DataStore.CommonExtensions.ContainsKey(extension)) return DataStore.CommonExtensions[extension];
			if (DataStore.OfficeExtensions.ContainsKey(extension)) return DataStore.OfficeExtensions[extension];
			return "Unknown file extensions.";
		}

		/// <summary>
		/// Generates a variation on the given text sample.
		/// </summary>
		/// <param name="sample">The sample on which the variation is based.</param>
		/// <param name="size">The size of the generated text.</param>
		/// <seealso cref="MarkovTextGenerator"/>
		/// <returns></returns>
		public static string RandomTextVariation(string sample, int size = 1000)
		{
			if (String.IsNullOrEmpty(sample)) throw new Exception("The sample cannot be empty.");
			if (size < 1) throw new Exception("The variation's length cannot be zero.");
			return MarkovTextGenerator.Generate(sample, size);

		}

		/// <summary>
		/// Returns a random letter.
		/// </summary>
		/// <param name="charType">The types of characters to include in the pool.</param>
		/// <returns></returns>
		public static string RandomLetter(CharType charType = CharType.UpperCaseLetters)
		{
			return RandomString(1, charType);
		}

		/// <summary>
		/// Generates a random string.
		/// </summary>
		/// <param name="size">The length of the generated string.</param>
		/// <param name="charType">The types of characters to include in the pool.</param>
		/// <returns></returns>
		public static string RandomString(int size, CharType charType = ( CharType.French|CharType.Brackets|CharType.Numbers|CharType.Special|CharType.LowerCaseLetters|CharType.UpperCaseLetters))
		{
			var input = "";
			if ((charType & CharType.UpperCaseLetters) == CharType.UpperCaseLetters)
				input += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			if ((charType & CharType.LowerCaseLetters) == CharType.LowerCaseLetters)
				input += "abcdefghijklmnopqrstuvwxyz";
			if ((charType & CharType.Numbers) == CharType.Numbers)
				input += "0123456789";
			if ((charType & CharType.French) == CharType.French)
				input += "éèçà";
			if ((charType & CharType.Brackets) == CharType.Brackets)
				input += "()[]{}";
			if ((charType & CharType.Special) == CharType.Special)
				input += "&@#§!-_°*$µ£ù%;:,?=<>/";

			var chars = Enumerable.Range(0, size).Select(x => input[Rand.Next(0, input.Length)]);
			return new string(chars.ToArray());
		}

		/// <summary>
		/// Generates a random string on the basis of the given input string.
		/// </summary>
		/// <param name="size">The length of the generated string.</param>
		/// <param name="input">The string from which a new random string will be generated.</param>
		/// <returns></returns>
		public static string RandomString(int size, string input)
		{
			if (size < 1) throw new ArgumentException("The size cannot be smaller than one.", "size");
			if (string.IsNullOrEmpty(input)) throw new ArgumentNullException("input");
			var chars = Enumerable.Range(0, size).Select(x => input[Rand.Next(0, input.Length)]);
			return new string(chars.ToArray());
		}

		/// <summary>
		/// Generates a random date within the specified interval.
		/// </summary>
		/// <param name="minDate">The start date of the interval.</param>
		/// <param name="maxDate">The end date of the interval.</param>
		/// <returns></returns>
		public static DateTime RandomDate(DateTime minDate, DateTime maxDate)
		{
			var totalDays = (int)DateTimeUtil.DateDiff(DateIntervalType.Day, minDate, maxDate);
			var randomDays = Rand.Next(0, totalDays);

			// set the time to zero and add a random time within the same day
			return (minDate.AddDays(randomDays) + new TimeSpan(0, 0, 0)).AddMilliseconds(Rand.Next(72000000));
		}

		/// <summary>
		/// Returns a random <c>TimeSpan</c> within the given interval.
		/// </summary>
		/// <param name="minDate">The min date.</param>
		/// <param name="maxDate">The max date.</param>
		/// <returns></returns>
		public static TimeSpan RandomTimeSpan(DateTime minDate, DateTime maxDate)
		{
			var diff = (int)System.Math.Floor((maxDate - minDate).TotalMilliseconds);
			return minDate.AddMilliseconds(Rand.Next(diff)) - minDate;
		}

		/// <summary>
		/// Returns a random date within the full span of the <c>DateTime</c> range.
		/// </summary>
		/// <returns></returns>
		public static DateTime RandomDate()
		{
			return RandomDate(DateTime.MinValue, DateTime.MaxValue);
		}


	}
	public static class UtilityExtensions
	{
		/// <summary>
		/// Applies the action to each element of the sequence.
		/// </summary>
		/// <typeparam name="T">The data type of the list.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="action">The action.</param>
		public static void ForEach<T>(this IEnumerable<T> source, Action action)
		{
			if (source == null) throw new ArgumentNullException("source");
			if (action == null) throw new ArgumentNullException("action");
			source.ToList().ForEach(m => action());
		}
		/// <summary>
		/// Creates a custom enumerable sequence.
		/// </summary>
		/// <remarks>The sequence can be infinite in contrast to lists and other similar structures.</remarks>
		/// <typeparam name="T">The data type of the sequence.</typeparam>
		/// <param name="getNext">The get next.</param>
		/// <param name="startVal">The start val.</param>
		/// <param name="endReached">The end reached.</param>
		/// <returns></returns>
		internal static IEnumerable<T> CreateSequence<T>(Func<T, T> getNext, T startVal, Func<T, bool> endReached)
		{
			if (getNext == null) yield break;
			yield return startVal;
			var val = startVal;
			while (endReached == null || !endReached(val))
			{
				val = getNext(val);
				yield return val;
			}
		}
		/// <summary>
		/// Applies the action to each element of the sequence.
		/// </summary>
		/// <typeparam name="T">The data type of the list.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="action">The action.</param>
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (var item in source) action(item);
		}
		/// <summary>
		/// Capitalizes the first character of the given string.
		/// </summary>
		/// <param name="s">The string to capiatalize.</param>
		public static string Capitalize(this string s)
		{
			return string.IsNullOrEmpty(s) ? string.Empty : char.ToUpper(s[0]) + s.Substring(1);
		}

		/// <summary>
		/// Capitalizes the first letter after a period ('.').
		/// </summary>
		/// <param name="text">The text to be processes.</param>
		/// <returns></returns>
		public static string ToSentenceCase(string text)
		{
			// start by converting entire string to lower case
			var lowerCase = text.ToLower();
			// matches the first sentence of a string, as well as subsequent sentences
			var r = new Regex(@"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture);
			// MatchEvaluator delegate defines replacement of setence starts to uppercase
			var result = r.Replace(lowerCase, s => s.Value.ToUpper());
			return result;
		}
	}

	/// <summary>
	/// Implementation of the <see cref="Range"/> for a set of common data types.
	/// </summary>
	public static class Range
	{
		/// <summary>
		/// Creates a range of bytes within the given interval.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <returns></returns>
		public static Range<byte> Create(byte start, byte end)
		{
			return new Range<byte>(start, end, GetNext);
		}

		/// <summary>
		/// Creates a range of <c>Int16</c> integers within the given interval.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <returns></returns>
		public static Range<short> Create(short start, short end)
		{
			return new Range<short>(start, end, GetNext);
		}

		/// <summary>
		/// Creates a range of integers within the given interval.
		/// </summary>
		/// <param name="start">Inclusive start of the range.</param>
		/// <param name="end">Inclusive end of the range.</param>
		/// <returns></returns>
		public static Range<int> Create(int start, int end)
		{
			return new Range<int>(start, end, GetNext);
		}

		/// <summary>
		/// Creates a range of <c>Int64</c> integers within the given interval.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <returns></returns>
		public static Range<long> Create(long start, long end)
		{
			return new Range<long>(start, end, GetNext);
		}

		/// <summary>
		/// Creates a range of doubles within the given interval.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <returns></returns>
		public static Range<double> Create(double start, double end)
		{
			return new Range<double>(start, end, GetNext);
		}

		/// <summary>
		/// Creates a range of floats within the given interval.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <returns></returns>
		public static Range<float> Create(float start, float end)
		{
			return new Range<float>(start, end, GetNext);
		}

		/// <summary>
		/// Creates a range of decimals within the given interval.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <returns></returns>
		public static Range<decimal> Create(decimal start, decimal end)
		{
			return new Range<decimal>(start, end, GetNext);
		}

		/// <summary>
		/// Creates a range of chars within the given interval.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <returns></returns>
		public static Range<char> Create(char start, char end)
		{
			return new Range<char>(start, end, GetNext);
		}

		/// <summary>
		/// Creates a range of datetime values within the given interval.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <returns></returns>
		public static Range<DateTime> Create(DateTime start, DateTime end)
		{
			return new Range<DateTime>(start, end, GetNext);
		}

		/// <summary>
		/// Creates a range of values within the given interval using a 'next' functional and a comparison to ensure the end-value can be compared..
		/// </summary>
		/// <typeparam name="T">The data type of the sequence.</typeparam>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <param name="getNext">The get next.</param>
		/// <param name="compare">The compare.</param>
		/// <returns></returns>
		public static Range<T> Create<T>(T start, T end, Func<T, T> getNext, Comparison<T> compare)
		{
			return new Range<T>(start, end, getNext, compare);
		}

		/// <summary>
		/// Creates a range of values within the given interval using a 'next' functional.
		/// </summary>
		/// <typeparam name="T">The data type of the sequence.</typeparam>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <param name="getNext">The get next.</param>
		/// <returns></returns>
		public static Range<T> Create<T>(T start, T end, Func<T, T> getNext)
		{
			return new Range<T>(start, end, getNext);
		}

		private static byte GetNext(byte val)
		{
			return (byte)(val + 1);
		}

		private static short GetNext(short val)
		{
			return (short)(val + 1);
		}

		private static int GetNext(int val)
		{
			return val + 1;
		}

		private static long GetNext(long val)
		{
			return val + 1;
		}

		private static double GetNext(double val)
		{
			return val + 1;
		}

		private static float GetNext(float val)
		{
			return val + 1;
		}

		private static decimal GetNext(decimal val)
		{
			return val + 1;
		}

		private static DateTime GetNext(DateTime val)
		{
			return val.AddDays(1);
		}

		private static char GetNext(char val)
		{
			return (char)(val + 1);
		}

		/// <summary>
		/// Ensures the range.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="min">The min.</param>
		/// <param name="max">The max.</param>
		/// <returns></returns>
		public static double EnsureRange(double value, double? min, double? max)
		{
			if (min.HasValue && (value < min.Value)) return min.Value;
			if (max.HasValue && (value > max.Value)) return max.Value;
			return value;
		}

		/// <summary>
		/// Creates the rectangle.
		/// </summary>
		/// <param name="startPoint">The start point.</param>
		/// <param name="endPoint">The end point.</param>
		/// <returns></returns>
		public static Rect CreateRectangle(Point startPoint, Point endPoint)
		{
			return new Rect(startPoint, new Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y));
		}
	}
	/// <summary>
	/// Generic range implementation.
	/// </summary>
	/// <typeparam name="TData">The data type of the range.</typeparam>
	public class Range<TData> : IEnumerable<TData>
	{
		private readonly Comparison<TData> compare;

		private readonly TData end;

		private readonly IEnumerable<TData> sequence;

		private readonly TData start;

		/// <summary>
		/// Initializes a new instance of the <see cref="Range&lt;TData&gt;"/> class.
		/// </summary>
		/// <param name="start">The start-element of the range.</param>
		/// <param name="end">The end-element of the range.</param>
		/// <param name="nextElement">The functional mapping from one element to the next one.</param>
		/// <param name="compare">The comparison between two items.</param>
		public Range(TData start, TData end, Func<TData, TData> nextElement, Comparison<TData> compare)
		{
			this.start = start;
			this.end = end;
			this.compare = compare;
			this.sequence = UtilityExtensions.CreateSequence(nextElement, start, v => compare(nextElement(v), end) > 0);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Range&lt;TData&gt;"/> class.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <param name="nextElement">The get next.</param>
		public Range(TData start, TData end, Func<TData, TData> nextElement)
			: this(start, end, nextElement, Compare)
		{
		}

		/// <summary>
		/// Gets the end of the range.
		/// </summary>
		public TData End
		{
			get
			{
				return this.end;
			}
		}

		/// <summary>
		/// Gets the start of the range.
		/// </summary>
		public TData Start
		{
			get
			{
				return this.start;
			}
		}

		/// <summary>
		/// Returns whether the given value is in the range.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if the specified value is inside the range; otherwise, <c>false</c>.
		/// </returns>
		public bool Contains(TData value)
		{
			return this.compare(value, this.start) >= 0 && this.compare(this.end, value) >= 0;
		}

		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <returns></returns>
		IEnumerator<TData> IEnumerable<TData>.GetEnumerator()
		{
			return this.sequence.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<TData>)this).GetEnumerator();
		}

		/// <summary>
		/// Compares the specified one.
		/// </summary>
		/// <param name="item1">The first item.</param>
		/// <param name="item2">The second item.</param>
		/// <returns></returns>
		private static int Compare(TData item1, TData item2)
		{
			return Comparer<TData>.Default.Compare(item1, item2);
		}
	}
}