using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using System.IO;
using System.Globalization;

namespace Telerik.Windows.Examples.Timeline.Grouping
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private readonly List<string> alliesCountries = new List<string> { "USSR", "Great Britain", "France", "USA" };
        private readonly List<string> axisCountries = new List<string> { "Germany", "Japan", "Italy" };

        private List<WorldWar2Event> data;
        private List<WorldWar2Annotation> annotationData;
        private DateTime startDate, endDate, visibleStartDate, visibleEndDate;
        private WorldWar2Event selectedItem;
        private List<string> currentAlliesCountries;
        private List<string> currentAxisCountries;
        private string selectedAlliesCountry;
        private string selectedAxisCountry;

        private bool isSelectionHandlingSuspended = false;

        public ExampleViewModel()
        {
            this.GetData("WorldWar2Events.csv");
        }

        public List<WorldWar2Event> Data
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

        public List<WorldWar2Annotation> AnnotationData
        {
            get
            {
                return this.annotationData;
            }
            private set
            {
                if (this.annotationData == value)
                    return;

                this.annotationData = value;
                this.OnPropertyChanged("AnnotationData");
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

        public WorldWar2Event SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                if (!this.isSelectionHandlingSuspended)
                {
                    this.isSelectionHandlingSuspended = true;

                    if (value == null)
                    {
                        this.CurrentAlliesCountries = null;
                        this.CurrentAxisCountries = null;
                        this.SelectedAlliesCountry = null;
                        this.SelectedAxisCountry = null;
                    }
                    else
                    {
                        this.CurrentAlliesCountries = value.Allies;
                        this.CurrentAxisCountries = value.Axis;

                        if (this.axisCountries.Any(country => string.Equals(country, value.Country)))
                        {
                            this.SelectedAlliesCountry = null;
                            this.SelectedAxisCountry = value.Country;
                        }
                        else
                        {
                            this.SelectedAxisCountry = null;
                            this.SelectedAlliesCountry = value.Country;
                        }
                    }

                    this.isSelectionHandlingSuspended = false;
                }

                this.selectedItem = value;
                this.OnPropertyChanged("SelectedItem");
            }
        }

        public List<string> AlliesCountries
        {
            get
            {
                return this.alliesCountries;
            }
        }

        public List<string> AxisCountries
        {
            get
            {
                return this.axisCountries;
            }
        }

        public List<string> CurrentAlliesCountries
        {
            get
            {
                return this.currentAlliesCountries;
            }
            set
            {
                this.currentAlliesCountries = value;
                this.OnPropertyChanged("CurrentAlliesCountries");
            }
        }

        public List<string> CurrentAxisCountries
        {
            get
            {
                return this.currentAxisCountries;
            }
            set
            {
                this.currentAxisCountries = value;
                this.OnPropertyChanged("CurrentAxisCountries");
            }
        }

        public string SelectedAlliesCountry
        {
            get
            {
                return this.selectedAlliesCountry;
            }
            set
            {
                if (!this.isSelectionHandlingSuspended)
                {
                    this.isSelectionHandlingSuspended = true;
                    this.SelectedAxisCountry = null;
                    if (value == null || this.SelectedItem == null)
                        this.SelectedItem = null;
                    else
                        this.SelectedItem = this.Data.Where(item => string.Equals(item.Country, value) && string.Equals(item.Details, this.SelectedItem.Details)).FirstOrDefault();
                    this.isSelectionHandlingSuspended = false;
                }

                this.selectedAlliesCountry = value;
                this.OnPropertyChanged("SelectedAlliesCountry");
            }
        }

        public string SelectedAxisCountry
        {
            get
            {
                return this.selectedAxisCountry;
            }
            set
            {
                if (!this.isSelectionHandlingSuspended)
                {
                    this.isSelectionHandlingSuspended = true;
                    this.SelectedAlliesCountry = null;
                    if (value == null || this.SelectedItem == null)
                        this.SelectedItem = null;
                    else
                        this.SelectedItem = this.Data.Where(item => string.Equals(item.Country, value) && string.Equals(item.Details, this.SelectedItem.Details)).FirstOrDefault();
                    this.isSelectionHandlingSuspended = false;
                }

                this.selectedAxisCountry = value;
                this.OnPropertyChanged("SelectedAxisCountry");
            }
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<WorldWar2Event>;
            this.AnnotationData = this.GenerateAnnotationData();

            var startYear = this.Data.Select(dataEntry => dataEntry.StartDate).OrderBy(date => date).FirstOrDefault().Year;
            var endYear = this.Data.Select(dataEntry => dataEntry.EndDate).OrderBy(date => date).LastOrDefault().AddYears(1).Year;

            this.StartDate = new DateTime(startYear, 1, 1);
            this.EndDate = new DateTime(endYear, 1, 1);
            this.VisibleStartDate = new DateTime(1940, 5, 1);
            this.VisibleEndDate = new DateTime(1942, 9, 1);

            DateTime selectedItemDate = new DateTime(1940, 9, 27);
            this.SelectedItem = this.Data.FirstOrDefault(item => item.Country.Equals("Germany") && item.StartDate.Date == selectedItemDate);
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<WorldWar2Event> data = new List<WorldWar2Event>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var endDateIndex = line.IndexOf(',');
                var axisIndex = line.IndexOf(',', endDateIndex + 1);
                var alliesIndex = line.IndexOf(',', axisIndex + 1);
                var detailsIndex = line.IndexOf(',', alliesIndex + 1);

                var startDate = line.Substring(0, endDateIndex);
                var endDate = line.Substring(endDateIndex + 1, axisIndex - endDateIndex - 1);
                var axis = line.Substring(axisIndex + 1, alliesIndex - axisIndex - 1);
                var allies = line.Substring(alliesIndex + 1, detailsIndex - alliesIndex - 1);
                var details = line.Substring(detailsIndex + 1);

                var axisList = (axis == string.Empty) ? new List<string>() : axis.Split(' ').ToList();
                var alliesList = (allies == string.Empty) ? new List<string>() : allies.Split(' ').ToList();

                int britainIndex = alliesList.IndexOf("Britain");
                if (britainIndex > -1)
                {
                    alliesList[britainIndex] = "Great Britain";
                }

                this.CreateWorldWar2Events(data, axisList, startDate, endDate, axisList, alliesList, details);
                this.CreateWorldWar2Events(data, alliesList, startDate, endDate, axisList, alliesList, details);
            }

            return data;
        }

        private void CreateWorldWar2Events(List<WorldWar2Event> data, List<string> countries, string startDate, string endDate, List<string> axisList, List<string> alliesList, string details)
        {
            foreach (var country in countries)
            {
                WorldWar2Event dataItem = new WorldWar2Event();
                dataItem.StartDate = DateTime.Parse(startDate, CultureInfo.InvariantCulture);
                dataItem.EndDate = endDate == String.Empty ? dataItem.StartDate : DateTime.Parse(endDate, CultureInfo.InvariantCulture);
                dataItem.Country = country;
                dataItem.Axis = axisList;
                dataItem.Allies = alliesList;
                dataItem.Details = details;

                data.Add(dataItem);
            }
        }

        private List<WorldWar2Annotation> GenerateAnnotationData()
        {
            List<WorldWar2Annotation> data = new List<WorldWar2Annotation>();

            data.Add(new WorldWar2Annotation() { StartDate = new DateTime(1934, 8, 19), Details = "Hitler becomes Führer" });
            data.Add(new WorldWar2Annotation() { StartDate = new DateTime(1940, 9, 27), Details = "Tripartite signed" });
            data.Add(new WorldWar2Annotation() { StartDate = new DateTime(1945, 4, 30), Details = "Hitler suicides" });

            return data;
        }
    }
}
