using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.DataBar.FirstLook
{
    public class CountrySalaryStatistic
    {
        public CountrySalaryStatistic(string countryName, double hourlyCompensationCost, double hourlyBenefits, double hourlySocialInsuranceExpenditures, double compensationInDollarsComparedToLastYear, double compensationInNationalCurrencyComparedToLastYear)
        {
            this.CountryName = countryName;
            this.HourlyCompensationCosts = hourlyCompensationCost;
            this.HourlyBenefitsPercent = hourlyBenefits;
            this.HourlySocialInsuranceExpendituresPercent = hourlySocialInsuranceExpenditures;
            this.CompensationInDollarsComparedToLastYear = compensationInDollarsComparedToLastYear;
            this.CompensationInNationalCurrencyComparedToLastYear = compensationInNationalCurrencyComparedToLastYear;
        }

        public string CountryName { get; set; }
        public double HourlyCompensationCosts { get; set; }
        public double HourlyBenefitsPercent { get; set; }
        public double HourlySocialInsuranceExpendituresPercent { get; set; }

        public double CompensationInDollarsComparedToLastYear { get; set; }
        public double CompensationInNationalCurrencyComparedToLastYear { get; set; }

        public IEnumerable<HourlyCompensationInfo> SalaryComponents
        {
            get
            {
                var components = new List<HourlyCompensationInfo>() 
                {
                    new HourlyCompensationInfo() { Value = this.HourlySocialInsuranceExpendituresPercent, ToolTip = String.Format("Social insurance expenditures: {0} %", this.HourlySocialInsuranceExpendituresPercent), },
                    new HourlyCompensationInfo() { Value = this.HourlyBenefitsPercent, ToolTip = String.Format("Directly-paid benefits: {0} %", this.HourlyBenefitsPercent), },
                };

                return components;
            }
        }
    }
}
