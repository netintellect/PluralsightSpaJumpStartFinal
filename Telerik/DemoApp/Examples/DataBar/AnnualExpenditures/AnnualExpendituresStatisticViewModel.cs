using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.DataBar.AnnualExpenditures
{
    public class AnnualExpendituresStatisticViewModel
    {
        public AnnualExpendituresStatisticViewModel()
        {
            var statistics = new List<ExpenditureInfo>() 
            {
                new ExpenditureInfo("Food", "Food at home", 3624, 3753, 0d, 0d),
                new ExpenditureInfo("Food", "Food away from home", 2505, 2619, 0d, 0d),
                new ExpenditureInfo("Housing", "Shelter", 9812, 10075, 0d, 0d),
                new ExpenditureInfo("Housing", "Utilities, fuels, public services", 3660, 3645, 0d, 0d),
                new ExpenditureInfo("Housing", "Household operations", 1007, 1011, 0d, 0d),
                new ExpenditureInfo("Housing", "Housekeeping supplies", 612, 659, 0d, 0d),
                new ExpenditureInfo("Housing", "Furnishings, equipment", 1467, 1506, 0d, 0d),    
                new ExpenditureInfo("Transportation", "Vehicle purchases", 2588, 2657, 0d, 0d),
                new ExpenditureInfo("Transportation", "Gasoline and motor oil", 2132, 1986, 0d, 0d),
                new ExpenditureInfo("Transportation", "Other vehicle expenses", 2464, 2536, 0d, 0d),
                new ExpenditureInfo("Transportation", "Public transportation", 493, 479, 0d, 0d),
                new ExpenditureInfo("Apparel and services", "Men and boys", 382, 383, 0d, 0d),
                new ExpenditureInfo("Apparel and services", "Women and girls", 663, 678, 0d, 0d),
                new ExpenditureInfo("Apparel and services", "Children under 2", 91, 91, 0d, 0d),
                new ExpenditureInfo("Apparel and services", "Footwear", 303, 323, 0d, 0d),
                new ExpenditureInfo("Apparel and services", "Others", 261, 249, 0d, 0d),  
                new ExpenditureInfo("Healthcare", "Health insurance", 1831, 1785, 0d, 0d),
                new ExpenditureInfo("Healthcare", "Medical services", 722, 736, 0d, 0d),
                new ExpenditureInfo("Healthcare", "Drugs", 485, 486, 0d, 0d),
                new ExpenditureInfo("Healthcare", "Medical supplies", 119, 119, 0d, 0d),
                new ExpenditureInfo("Entertainment", "Fees and admissions", 581, 628, 0d, 0d),
                new ExpenditureInfo("Entertainment", "Audio and visual equipment", 954, 975, 0d, 0d),
                new ExpenditureInfo("Entertainment", "Pets, toys, hobbies", 606, 690, 0d, 0d),
                new ExpenditureInfo("Entertainment", "Others", 364, 400, 0d, 0d),
                new ExpenditureInfo("Personal care products and services", "Products and services", 100, 110, 0d, 0d),
                new ExpenditureInfo("Reading", "Reading", 2588, 2657, 0d, 0d),
                new ExpenditureInfo("Education", "Education", 1074, 1068, 0d, 0d),
                new ExpenditureInfo("Tobacco products and smoking supplies", "Products and supplies", 362, 380, 0d, 0d),                
                new ExpenditureInfo("Miscellaneous", "Miscellaneous", 849, 816, 0d, 0d),
                new ExpenditureInfo("Personal insurance and pensions", "Life, other insurance", 318, 309, 0d, 0d),
                new ExpenditureInfo("Personal insurance and pensions", "Pensions, Social Security", 5054, 5162, 0d, 0d),
                new ExpenditureInfo("Alcoholic beverages", "Alcoholic beverages", 412, 435, 0d, 0d),
            };

            double totalExpenditures2010 = statistics.Sum(info => info.Expenditures2010);

            for (int i = 0; i < statistics.Count; i++)
            {
                statistics[i].AnnualExpendituresPercent = statistics[i].Expenditures2010 / totalExpenditures2010;
                statistics[i].ExpendituresChangePercent = statistics[i].Expenditures2010 / statistics[i].Expenditures2009 - 1d;

                double currentTypeExpenditures2009 = statistics.Where(info => info.Type == statistics[i].Type).Sum(info => info.Expenditures2009);
                double currentTypeExpenditures2010 = statistics.Where(info => info.Type == statistics[i].Type).Sum(info => info.Expenditures2010);
                statistics[i].YearlyExpendituresPercentChangeByType = statistics[i].Expenditures2010 / currentTypeExpenditures2009 - statistics[i].Expenditures2010 / currentTypeExpenditures2010;
            }

            this.Statistics = new QueryableCollectionView(statistics);

            this.AVGAnnualIncomeBeforeTaxes = new List<DateTimeDoublePair>() 
            {
                new DateTimeDoublePair(new DateTime(2000, 6, 1), 44649),
                new DateTimeDoublePair(new DateTime(2001, 6, 1), 47507),
                new DateTimeDoublePair(new DateTime(2002, 6, 1), 49430),
                new DateTimeDoublePair(new DateTime(2003, 6, 1), 51128),
                new DateTimeDoublePair(new DateTime(2004, 6, 1), 54453),
                new DateTimeDoublePair(new DateTime(2005, 6, 1), 58712),
                new DateTimeDoublePair(new DateTime(2006, 6, 1), 60533),
                new DateTimeDoublePair(new DateTime(2007, 6, 1), 63091),
                new DateTimeDoublePair(new DateTime(2008, 6, 1), 63563),
                new DateTimeDoublePair(new DateTime(2009, 6, 1), 62857), 
                new DateTimeDoublePair(new DateTime(2010, 6, 1), 62481), 
            };

            this.AVGAnnualExpenditures = new List<DateTimeDoublePair>() 
            {
                new DateTimeDoublePair(new DateTime(2000, 6, 1), 40238),
                new DateTimeDoublePair(new DateTime(2001, 6, 1), 41395),
                new DateTimeDoublePair(new DateTime(2002, 6, 1), 42557),
                new DateTimeDoublePair(new DateTime(2003, 6, 1), 42742),
                new DateTimeDoublePair(new DateTime(2004, 6, 1), 43395),
                new DateTimeDoublePair(new DateTime(2005, 6, 1), 46409),
                new DateTimeDoublePair(new DateTime(2006, 6, 1), 48398),
                new DateTimeDoublePair(new DateTime(2007, 6, 1), 49638),
                new DateTimeDoublePair(new DateTime(2008, 6, 1), 50486),
                new DateTimeDoublePair(new DateTime(2009, 6, 1), 49067), 
                new DateTimeDoublePair(new DateTime(2010, 6, 1), 48109), 
            };

            this.EstimatedMarketValueOfOwnedHome = new List<DateTimeDoublePair>() 
            {
                new DateTimeDoublePair(new DateTime(2000, 6, 1), 88989),
                new DateTimeDoublePair(new DateTime(2001, 6, 1), 97681),
                new DateTimeDoublePair(new DateTime(2002, 6, 1), 104331),
                new DateTimeDoublePair(new DateTime(2003, 6, 1), 119104),
                new DateTimeDoublePair(new DateTime(2004, 6, 1), 137639),
                new DateTimeDoublePair(new DateTime(2005, 6, 1), 164800),
                new DateTimeDoublePair(new DateTime(2006, 6, 1), 183212),
                new DateTimeDoublePair(new DateTime(2007, 6, 1), 182336),
                new DateTimeDoublePair(new DateTime(2008, 6, 1), 169794),
                new DateTimeDoublePair(new DateTime(2009, 6, 1), 157630), 
                new DateTimeDoublePair(new DateTime(2010, 6, 1), 155083), 
            };

            this.PersonalTaxes = new List<DateTimeDoublePair>() 
            {
                new DateTimeDoublePair(new DateTime(2000, 6, 1), 3117),
                new DateTimeDoublePair(new DateTime(2001, 6, 1), 2920),
                new DateTimeDoublePair(new DateTime(2002, 6, 1), 2496),
                new DateTimeDoublePair(new DateTime(2003, 6, 1), 2532),
                new DateTimeDoublePair(new DateTime(2004, 6, 1), 2166),
                new DateTimeDoublePair(new DateTime(2005, 6, 1), 2408),
                new DateTimeDoublePair(new DateTime(2006, 6, 1), 2432),
                new DateTimeDoublePair(new DateTime(2007, 6, 1), 2233),
                new DateTimeDoublePair(new DateTime(2008, 6, 1), 1789),
                new DateTimeDoublePair(new DateTime(2009, 6, 1), 2104), 
                new DateTimeDoublePair(new DateTime(2010, 6, 1), 1769), 
            };

            for (int i = 0; i < this.AVGAnnualIncomeBeforeTaxes.Count; i++)
            {
                this.AVGAnnualIncomeBeforeTaxes[i].Value /= 1000;
            }

            for (int i = 0; i < this.AVGAnnualIncomeBeforeTaxes.Count; i++)
            {
                this.AVGAnnualExpenditures[i].Value /= 1000;
            }

            for (int i = 0; i < this.AVGAnnualIncomeBeforeTaxes.Count; i++)
            {
                this.EstimatedMarketValueOfOwnedHome[i].Value /= 1000;
            }

            for (int i = 0; i < this.AVGAnnualIncomeBeforeTaxes.Count; i++)
            {
                this.PersonalTaxes[i].Value /= 1000;
            }
        }

        public QueryableCollectionView Statistics { get; private set; }

        public List<DateTimeDoublePair> AVGAnnualIncomeBeforeTaxes { get; private set; }
        public List<DateTimeDoublePair> AVGAnnualExpenditures { get; private set; }
        public List<DateTimeDoublePair> EstimatedMarketValueOfOwnedHome { get; private set; }
        public List<DateTimeDoublePair> PersonalTaxes { get; private set; }
    }
}
