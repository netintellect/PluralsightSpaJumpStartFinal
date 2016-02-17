using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.IO;
using System.Globalization;
using Telerik.Windows.Controls;
#if WPF
using System.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.Timeline.Selection
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private List<LifeEvent> data;
        private List<SelectionMode> selectionModes;
        private SelectionMode timelineSelectionMode;
        private DateTime startDate, endDate, visibleStartDate, visibleEndDate;
        private int selectedCategoryIndex = -1;

        public ExampleViewModel()
        {
            this.selectionModes = new List<SelectionMode>()
            {
                SelectionMode.Single,
                SelectionMode.Multiple,
                SelectionMode.Extended
            };

            this.TimelineSelectionMode = SelectionMode.Extended;


            this.GetData("MichaelJacksonEvents.csv");
        }

        public List<LifeEvent> Data
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

        public List<SelectionMode> SelectionModeValues
        {
            get
            {
                return this.selectionModes;
            }
        }

        public SelectionMode TimelineSelectionMode
        {
            get
            {
                return this.timelineSelectionMode;
            }
            set
            {
                this.timelineSelectionMode = value;
                this.OnPropertyChanged("TimelineSelectionMode");
                this.OnPropertyChanged("CategoriesIsSelectionEnabled");
            }
        }

        public bool CategoriesIsSelectionEnabled
        {
            get
            {
                return this.TimelineSelectionMode != SelectionMode.Single;
            }
        }

        public int SelectedCategoryIndex
        {
            get
            {
                return this.selectedCategoryIndex;
            }
            set
            {
                this.selectedCategoryIndex = value;
                this.OnPropertyChanged("SelectedCategoryIndex");
            }
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<LifeEvent>;

            var startYear = this.Data.Select(dataEntry => dataEntry.StartDate).OrderBy(date => date).FirstOrDefault().Year;
            var endYear = this.Data.Select(dataEntry => dataEntry.EndDate).OrderBy(date => date).LastOrDefault().AddYears(1).Year;

            this.StartDate = new DateTime(startYear, 1, 1);
            this.EndDate = new DateTime(endYear, 1, 1);
            this.VisibleStartDate = new DateTime(1983, 1, 1);
            this.VisibleEndDate = new DateTime(1999, 1, 1);

            this.SelectedCategoryIndex = 0;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<LifeEvent> data = new List<LifeEvent>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var endDateIndex = line.IndexOf(',');
                var groupIndex = line.IndexOf(',', endDateIndex + 1);
                var categoryIndex = line.IndexOf(',', groupIndex + 1);
                var detailsIndex = line.IndexOf(',', categoryIndex + 1);

                var startDate = line.Substring(0, endDateIndex);
                var endDate = line.Substring(endDateIndex + 1, groupIndex - endDateIndex - 1);
                var groupName = line.Substring(groupIndex + 1, categoryIndex - groupIndex - 1);
                var categories = line.Substring(categoryIndex + 1, detailsIndex - categoryIndex - 1);
                var details = line.Substring(detailsIndex + 1);

                LifeEvent dataItem = new LifeEvent();
                dataItem.StartDate = DateTime.Parse(startDate, CultureInfo.InvariantCulture);
                dataItem.EndDate = endDate == String.Empty ? dataItem.StartDate : DateTime.Parse(endDate, CultureInfo.InvariantCulture);
                dataItem.GroupName = groupName;
                dataItem.Categories = categories.Split(' ').ToList();
                dataItem.Details = details;

                data.Add(dataItem);
            }

            return data;
        }
    }
}
