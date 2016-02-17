namespace Telerik.Windows.Examples.DataBar.AnnualExpenditures
{
    public class ExpenditureInfo
    {
        public ExpenditureInfo(string type, string name, double expenditures2010, double expenditures2009, double expendituresChangePercent, double annualExpendituresPercent)
        {
            this.Type = type;
            this.Name = name;
            this.Expenditures2010 = expenditures2010;
            this.Expenditures2009 = expenditures2009;
            this.ExpendituresChangePercent = expendituresChangePercent;
            this.AnnualExpendituresPercent = annualExpendituresPercent;
        }

        public string Type { get; set; }
        public string Name { get; set; }
        public double Expenditures2010 { get; set; }
        public double Expenditures2009 { get; set; }
        public double ExpendituresChangePercent { get; set; }
        public double AnnualExpendituresPercent { get; set; }
        public double YearlyExpendituresPercentChangeByType { get; set; }
    }
}
