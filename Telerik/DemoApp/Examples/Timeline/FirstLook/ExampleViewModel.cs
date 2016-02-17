using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;
using Telerik.Windows.Controls;
using System.Windows.Input;

namespace Telerik.Windows.Examples.Timeline.FirstLook
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private readonly DateTime currentDate;

        private List<PresidentData> data;
        private List<PresidentData> visibleData;
        private IEnumerable<string> partyData;
        private DateTime startDate, endDate;
        private DateTime visibleStartDate, visibleEndDate;
        private PresidentData selectedPresident;

        private ICommand previousPageCommand;
        private bool previousPageCanExecute;

        private ICommand nextPageCommand;
        private bool nextPageCanExecute;

        private int currentPage = -1;

        public ExampleViewModel()
        {
            this.currentDate = DateTime.Now;

            this.GetData("AmericanPresidents.csv");
        }

        public List<PresidentData> Data
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

        public List<PresidentData> VisibleData
        {
            get
            {
                return this.visibleData;
            }
            private set
            {
                if (this.visibleData == value)
                    return;

                this.visibleData = value;
                this.OnPropertyChanged("VisibleData");
            }
        }

        public IEnumerable<string> PartyLegendData
        {
            get
            {
                return this.partyData;
            }
            private set
            {
                if (this.partyData == value)
                    return;

                this.partyData = value;
                this.OnPropertyChanged("PartyLegendData");
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

        public PresidentData SelectedPresident
        {
            get
            {
                return this.selectedPresident;
            }
            set
            {
                this.selectedPresident = value;
                this.OnPropertyChanged("SelectedPresident");
            }
        }

        public ICommand PreviousPageCommand
        {
            get
            {
                if (this.previousPageCommand == null)
                    this.previousPageCommand = new DelegateCommand(PreviousPage, CanExecutePreviousPage);

                return this.previousPageCommand;
            }
            set
            {
                this.previousPageCommand = value;
            }
        }

        public ICommand NextPageCommand
        {
            get
            {
                if (this.nextPageCommand == null)
                    this.nextPageCommand = new DelegateCommand(NextPage, CanExecuteNextPage);

                return this.nextPageCommand;
            }
            set
            {
                this.nextPageCommand = value;
            }
        }

        private int CurrentPage
        {
            get
            {
                return this.currentPage;
            }
            set
            {

                if (value >= 0 && value < this.PagesCount)
                {
                    this.currentPage = value;

                    this.UpdateCurrentPage();
                    this.UpdateCommands();
                    this.UpdateSelectedItem();
                }
            }
        }

        private int PageSize
        {
            get
            {
                return 11;
            }
        }

        private int PagesCount
        {
            get
            {
                if (this.Data == null || this.Data.Count == 0)
                    return 0;

                return (int)Math.Ceiling((double)this.Data.Count / this.PageSize);
            }
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<PresidentData>;
            this.PartyLegendData = this.Data.Select(presidentData => presidentData.Party).Distinct();
            this.CurrentPage = 0;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<PresidentData> data = new List<PresidentData>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] splitData = line.Split(',');

                var name = splitData[0];
                var birthDate = splitData[1];
                var presidentFrom = splitData[2];
                var presidentUntil = splitData[3];
                var deathDate = splitData[4];
                var party = splitData[5];

                PresidentData dataItem = new PresidentData();
                dataItem.Name = name;
                dataItem.BirthDate = new DateTime(int.Parse(birthDate, CultureInfo.InvariantCulture), 06, 29);
                dataItem.DeathDate = deathDate == string.Empty ? this.currentDate : new DateTime(int.Parse(deathDate, CultureInfo.InvariantCulture), 06, 29);
                dataItem.PresidentFrom = new DateTime(int.Parse(presidentFrom, CultureInfo.InvariantCulture), 06, 29);
                dataItem.PresidentUntil = presidentUntil == string.Empty ? this.currentDate : new DateTime(int.Parse(presidentUntil, CultureInfo.InvariantCulture), 06, 29);
                if (presidentFrom == presidentUntil)
                {
                    dataItem.PresidentUntil = new DateTime(dataItem.PresidentUntil.AddYears(1).Year, 1, 1);

                    if (dataItem.DeathDate < dataItem.PresidentUntil)
                        dataItem.DeathDate = dataItem.PresidentUntil;
                }
                dataItem.Party = party;
                dataItem.ImageName = dataItem.Name + ".jpg";

                data.Add(dataItem);
            }

            return data;
        }

        private void PreviousPage(object parameter)
        {
            this.CurrentPage--;
        }

        private void NextPage(object parameter)
        {
            this.CurrentPage++;
        }

        private void UpdateCommands()
        {
            this.previousPageCanExecute = this.CurrentPage > 0;
            (this.PreviousPageCommand as DelegateCommand).InvalidateCanExecute();

            this.nextPageCanExecute = this.CurrentPage < this.PagesCount - 1;
            (this.NextPageCommand as DelegateCommand).InvalidateCanExecute();
        }

        private bool CanExecutePreviousPage(object parameter)
        {
            return this.previousPageCanExecute;
        }

        private bool CanExecuteNextPage(object parameter)
        {
            return this.nextPageCanExecute;
        }

        private void UpdateCurrentPage()
        {
            this.VisibleData = this.GetVisibleData().ToList();

            var newStartYear = this.VisibleData.Min(dataEntry => dataEntry.BirthDate).Year;
            var newEndYear = this.VisibleData.Max(dataEntry => dataEntry.DeathDate).AddYears(1).Year;

            var newStartDate = new DateTime(newStartYear, 1, 1);
            var newEndDate = new DateTime(newEndYear, 1, 1);

            if (newEndDate > this.currentDate)
                newEndDate = this.currentDate;

            this.StartDate = newStartDate;
            this.EndDate = newEndDate;
            this.VisibleStartDate = newStartDate;
            this.VisibleEndDate = newEndDate;
        }

        private void UpdateSelectedItem()
        {
            if (this.SelectedPresident == null)
            {
                this.SelectedPresident = this.VisibleData[0];
            }
        }

        private IEnumerable<PresidentData> GetVisibleData()
        {
            var data = this.Data;

            int startIndex = Math.Max(0, this.PageSize * this.currentPage);
            int endIndex = Math.Min(data.Count, startIndex + this.PageSize);

            for (int index = startIndex; index < endIndex; index++)
            {
                yield return data[index];
            }
        }
    }
}
