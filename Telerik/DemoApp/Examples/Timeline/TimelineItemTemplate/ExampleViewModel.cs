using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Timeline.TimelineItemTemplate
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private List<NobelPrize> data;
        private List<NobelPrize> legendData;
        private DateTime startDate, endDate, visibleStartDate, visibleEndDate;
        private DataTemplateSelector selector;
        private DataTemplateSelector legendSelector;
        private string type;

        private DataTemplateSelector scienceSelector;
        private DataTemplateSelector genderSelector;
        private DataTemplateSelector contributionSelector;

        private DataTemplateSelector legendScienceSelector;
        private DataTemplateSelector legendGenderSelector;
        private DataTemplateSelector legendContributionSelector;

        public ExampleViewModel()
        {
            this.GetData("NobelPrizeLaureates.csv");
        }

        public List<NobelPrize> Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                if (this.data == value)
                    return;

                this.data = value;
                this.OnPropertyChanged("Data");
            }
        }

        public List<NobelPrize> LegendData
        {
            get
            {
                return this.legendData;
            }
            private set
            {
                if (this.legendData == value)
                    return;

                this.legendData = value;
                this.OnPropertyChanged("LegendData");
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
                this.OnPropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
                this.OnPropertyChanged("EndDate");
            }
        }

        public DateTime VisibleStartDate
        {
            get
            {
                return this.visibleStartDate;
            }
            set
            {
                this.visibleStartDate = value;
                this.OnPropertyChanged("VisibleStartDate");
            }
        }

        public DateTime VisibleEndDate
        {
            get
            {
                return this.visibleEndDate;
            }
            set
            {
                this.visibleEndDate = value;
                this.OnPropertyChanged("VisibleEndDate");
            }
        }

        public DataTemplateSelector TemplateSelector
        {
            get
            {
                return this.selector;
            }
            set
            {
                this.selector = value;
                this.OnPropertyChanged("TemplateSelector");
            }
        }

        public DataTemplateSelector LegendTemplateSelector
        {
            get
            {
                return this.legendSelector;
            }
            set
            {
                this.legendSelector = value;
                this.OnPropertyChanged("LegendTemplateSelector");
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (this.type != value)
                {
                    this.type = value;
                    this.OnPropertyChanged("Type");

                    this.UpdateLegendData();
                    this.UpdateDataTemplateSelector();
                    this.UpdateLegendDataTemplateSelector();
                }
            }
        }

        public DataTemplateSelector ScienceSelector
        {
            get
            {
                return this.scienceSelector;
            }
            set
            {
                this.scienceSelector = value;
            }
        }

        public DataTemplateSelector GenderSelector
        {
            get
            {
                return this.genderSelector;
            }
            set
            {
                this.genderSelector = value;
            }
        }

        public DataTemplateSelector ContributionSelector
        {
            get
            {
                return this.contributionSelector;
            }
            set
            {
                this.contributionSelector = value;
            }
        }

        public DataTemplateSelector LegendScienceSelector
        {
            get
            {
                return this.legendScienceSelector;
            }
            set
            {
                this.legendScienceSelector = value;
            }
        }

        public DataTemplateSelector LegendGenderSelector
        {
            get
            {
                return this.legendGenderSelector;
            }
            set
            {
                this.legendGenderSelector = value;
            }
        }

        public DataTemplateSelector LegendContributionSelector
        {
            get
            {
                return this.legendContributionSelector;
            }
            set
            {
                this.legendContributionSelector = value;
            }
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<NobelPrize>;

            var startYear = this.Data.Select(dataEntry => dataEntry.Date).OrderBy(date => date).FirstOrDefault().Year;
            var endYear = this.Data.Select(dataEntry => dataEntry.Date).OrderBy(date => date).LastOrDefault().AddYears(1).Year;

            this.StartDate = new DateTime(startYear, 1, 1);
            this.EndDate = new DateTime(endYear, 1, 1);
            this.VisibleStartDate = new DateTime(1981, 1, 1);
            this.VisibleEndDate = new DateTime(2002, 1, 1);
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<NobelPrize> data = new List<NobelPrize>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] splitData = line.Split(';');

                var date = splitData[0];
                var category = splitData[1];
                var name = splitData[2];
                var country = splitData[3];
                var contribution = splitData[4];
                var gender = splitData[6];
                var details = splitData[7];

                NobelPrize dataItem = new NobelPrize();
                dataItem.Date = new DateTime(int.Parse(date, CultureInfo.InvariantCulture), 06, 29);
                dataItem.Category = category;
                dataItem.Name = name;
                dataItem.Country = country;
                dataItem.Contribution = double.Parse(contribution, CultureInfo.InvariantCulture);
                dataItem.Gender = gender;
                dataItem.Details = details;
                dataItem.ImageName = dataItem.Category + "ToolTipCorner.png";

                data.Add(dataItem);
            }

            return data;
        }

        private void UpdateDataTemplateSelector()
        {
            switch (this.Type)
            {
                case "Science":
                    this.TemplateSelector = this.ScienceSelector;
                    break;
                case "Gender":
                    this.TemplateSelector = this.GenderSelector;
                    break;
                case "Contribution":
                    this.TemplateSelector = this.ContributionSelector;
                    break;
                default:
                    this.TemplateSelector = this.ScienceSelector;
                    break;
            }
        }

        private void UpdateLegendDataTemplateSelector()
        {
            switch (this.Type)
            {
                case "Science":
                    this.LegendTemplateSelector = this.LegendScienceSelector;
                    break;
                case "Gender":
                    this.LegendTemplateSelector = this.LegendGenderSelector;
                    break;
                case "Contribution":
                    this.LegendTemplateSelector = this.LegendContributionSelector;
                    break;
                default:
                    this.LegendTemplateSelector = this.LegendScienceSelector;
                    break;
            }
        }

        private void UpdateLegendData()
        {
            var legendData = new List<NobelPrize>();

            switch (this.Type)
            {
                case "Science":
                    legendData.Add(new NobelPrize() { Category = "Physics" });
                    legendData.Add(new NobelPrize() { Category = "Chemistry" });
                    legendData.Add(new NobelPrize() { Category = "Medicine" });
                    legendData.Add(new NobelPrize() { Category = "Literature" });
                    legendData.Add(new NobelPrize() { Category = "Peace" });
                    legendData.Add(new NobelPrize() { Category = "Economics" });
                    break;
                case "Gender":
                    legendData.Add(new NobelPrize() { Gender = "M" });
                    legendData.Add(new NobelPrize() { Gender = "F" });
                    legendData.Add(new NobelPrize() { Gender = "" });
                    break;
                case "Contribution":
                    legendData.Add(new NobelPrize() { Contribution = 100 });
                    legendData.Add(new NobelPrize() { Contribution = 50 });
                    legendData.Add(new NobelPrize() { Contribution = 33.3 });
                    legendData.Add(new NobelPrize() { Contribution = 25 });
                    break;
                default:
                    break;
            }

            this.LegendData = legendData;
        }
    }
}
