using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Timeline;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private DateTime start;
        private DateTime end;
        private DateTime visibleStart;
        private DateTime visibleEnd;
        private TimeSpan maxZoomRange;
        private List<House> houses;
        private List<KingEvent> events;
        private List<King> kings;
        private List<object> items;
        private object selectedKing;
        private object selectedKingEvent;
        private List<object> selectedItems;
        private IItemRowIndexGenerator rowIndexGenerator;
        private ICommand updateVisiblePeriodCommand;
        private ICommand nextKingCommand;
        private bool nextKingCanExecute;
        private ICommand previousKingCommand;
        private bool previousKingCanExecute;

        public ExampleViewModel()
        {
            this.GetData("KingsAndEvents.csv");
        }

        public DateTime Start
        {
            get
            {
                return this.start;
            }
            private set
            {
                if (this.start != value)
                {
                    this.start = value;
                    this.OnPropertyChanged("Start");
                }
            }
        }

        public DateTime End
        {
            get
            {
                return this.end;
            }
            private set
            {
                if (this.end != value)
                {
                    this.end = value;
                    this.OnPropertyChanged("End");
                }
            }
        }

        public DateTime VisibleStart
        {
            get
            {
                return this.visibleStart;
            }
            set
            {
                if (this.visibleStart != value)
                {
                    this.visibleStart = value;
                    this.OnPropertyChanged("VisibleStart");
                }
            }
        }

        public DateTime VisibleEnd
        {
            get
            {
                return this.visibleEnd;
            }
            set
            {
                if (this.visibleEnd != value)
                {
                    this.visibleEnd = value;
                    this.OnPropertyChanged("VisibleEnd");
                }
            }
        }

        public TimeSpan MaxZoomRange
        {
            get
            {
                return this.maxZoomRange;
            }
            set
            {
                if (this.maxZoomRange != value)
                {
                    this.maxZoomRange = value;
                    this.OnPropertyChanged("MaxZoomRange");
                }
            }
        }

        public List<House> Houses
        {
            get
            {
                return this.houses;
            }
            private set
            {
                if (this.houses != value)
                {
                    this.houses = value;
                    this.OnPropertyChanged("Houses");
                }
            }
        }

        public List<KingEvent> Events
        {
            get
            {
                return this.events;
            }
            private set
            {
                if (this.events != value)
                {
                    this.events = value;
                    this.OnPropertyChanged("Events");
                }
            }
        }

        public List<King> Kings
        {
            get
            {
                return this.kings;
            }
            private set
            {
                if (this.kings != value)
                {
                    this.kings = value;
                    this.OnPropertyChanged("Kings");
                }
            }
        }

        public List<object> Items
        {
            get
            {
                return this.items;
            }
            private set
            {
                if (this.items != value)
                {
                    this.items = value;
                    this.OnPropertyChanged("Items");
                }
            }
        }

        public object SelectedKing
        {
            get
            {
                return this.selectedKing;
            }
            set
            {
                this.selectedKing = value;
                this.OnPropertyChanged("SelectedKing");

                this.UpdateCommands();
            }
        }

        public object SelectedKingEvent
        {
            get
            {
                return this.selectedKingEvent;
            }
            set
            {
                this.selectedKingEvent = value;
                this.OnPropertyChanged("SelectedKingEvent");
            }
        }

        public List<object> SelectedItems
        {
            get
            {
                return this.selectedItems;
            }
            set
            {
                this.selectedItems = value;
                this.OnPropertyChanged("SelectedItems");

                this.SelectedKing = value.FirstOrDefault(selectedItem => selectedItem.GetType() == typeof(King));
                this.SelectedKingEvent = value.FirstOrDefault(selectedItem => selectedItem.GetType() == typeof(KingEvent));
            }
        }

        public IItemRowIndexGenerator RowIndexGenerator
        {
            get
            {
                return this.rowIndexGenerator;
            }
            private set
            {
                if (this.rowIndexGenerator != value)
                {
                    this.rowIndexGenerator = value;
                    this.OnPropertyChanged("RowIndexGenerator");
                }
            }
        }

        public ICommand UpdateVisiblePeriodCommand
        {
            get
            {
                if (this.updateVisiblePeriodCommand == null)
                    this.updateVisiblePeriodCommand = new DelegateCommand(this.UpdateVisiblePeriod);
                return this.updateVisiblePeriodCommand;
            }
            set
            {
                this.updateVisiblePeriodCommand = value;
            }
        }

        public ICommand NextKingCommand
        {
            get
            {
                if (this.nextKingCommand == null)
                    this.nextKingCommand = new DelegateCommand(this.SelectNextKing, this.CanExecuteNextKing);

                return this.nextKingCommand;
            }
            set
            {
                this.nextKingCommand = value;
            }
        }

        public ICommand PreviousKingCommand
        {
            get
            {
                if (this.previousKingCommand == null)
                    this.previousKingCommand = new DelegateCommand(this.SelectPreviousKing, this.CanExecutePreviousKing);

                return this.previousKingCommand;
            }
            set
            {
                this.previousKingCommand = value;
            }
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            var tempData = (List<object>)data;

            this.Items = tempData;

            this.Kings = tempData.Where(item => item.GetType() == typeof(King)).Cast<King>().OrderBy(item => item.Begin).ToList();
            this.Events = tempData.Where(item => item.GetType() == typeof(KingEvent)).Cast<KingEvent>().OrderBy(item => item.Begin).ToList();

            var kingsMinDate = this.kings.Min(item => item.Begin);
            var eventsMinDate = this.events.Min(item => item.Begin);

            var kingsMaxDate = this.kings.Max(item => item.End);
            var eventsMaxDate = this.kings.Max(item => item.End);

            this.End = kingsMaxDate > eventsMaxDate ? kingsMaxDate : eventsMaxDate;
            this.Start = kingsMinDate < eventsMinDate ? kingsMinDate : eventsMinDate;

            this.VisibleStart = this.Kings.First(king => king.Name.Equals("Henry IV")).Begin;
            this.VisibleEnd = this.Kings.First(king => king.Name.Equals("Charles I")).End;

            this.MaxZoomRange = TimeSpan.FromDays(102345);

            List<House> houses = new List<House>();
            foreach (var item in this.kings.GroupBy(king => king.House))
            {
                if (item.Key == "Wessex")
                {
                    houses.Add(new House()
                    {
                        Name = item.Key,
                        Begin = new DateTime(796, 7, 29),
                        End = new DateTime(1016, 11, 30)
                    });

                    houses.Add(new House()
                    {
                        Name = item.Key,
                        Begin = new DateTime(1042, 6, 8),
                        End = new DateTime(1066, 10, 14)
                    });
                }
                else if (item.Key == "Stuart")
                {
                    houses.Add(new House()
                    {
                        Name = item.Key,
                        Begin = new DateTime(1603, 3, 24),
                        End = new DateTime(1649, 1, 30)
                    });
                    houses.Add(new House()
                    {
                        Name = item.Key,
                        Begin = new DateTime(1659, 1, 1),
                        End = new DateTime(1688, 12, 11)
                    });
                    houses.Add(new House()
                    {
                        Name = item.Key,
                        Begin = new DateTime(1702, 3, 8),
                        End = new DateTime(1714, 8, 1)
                    });
                }
                else
                {
                    houses.Add(new House()
                    {
                        Name = item.Key,
                        Begin = item.Min(king => king.Begin),
                        End = item.Max(king => king.End)
                    });
                }
            }
            houses.Add(new House()
            {
                Name = "Commonwealth",
                Begin = new DateTime(1649, 1, 30),
                End = new DateTime(1659, 1, 1)
            });

            this.Houses = houses;

            King defaultKing = this.kings.First(item => item.Name == "Henry VI");

            this.SelectKing(defaultKing, this.events.First(kingEvent => kingEvent.Ruler == defaultKing && kingEvent.Begin.Year == 1469));

            var housesList = this.kings.Select(item => item.House).Distinct().ToList();
            this.RowIndexGenerator = new HouseRowIndexGenerator(housesList, this.kings, this.events);
        }

        protected override IEnumerable ParseData(System.IO.TextReader dataReader)
        {
            string line;

            int lineCounter = 0;

            List<King> kingsData = new List<King>();
            List<KingEvent> eventsData = new List<KingEvent>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var strings = line.Split(';');

                if (lineCounter <= 60)
                {
                    King king = new King();

                    king.Begin = DateTime.Parse(strings[0]);
                    king.End = DateTime.Parse(strings[1]);
                    king.Name = strings[2];
                    king.House = strings[3];

                    king.Birth = DateTime.Parse(strings[4]);
                    king.Parents = strings[5];
                    king.Married = strings[6];
                    king.Children = strings[7];
                    king.Death = lineCounter == 60 ? DateTime.MaxValue : DateTime.Parse(strings[8]);
                    king.Successor = lineCounter == 60 ? "Current ruler" : strings[9];
                    king.Bio = strings[10];

                    var stringsCount = strings.Count();
                    if (10 < stringsCount - 1)
                    {
                        for (int i = 10; i < stringsCount; i++)
                        {
                            king.Bio += strings[i];
                        }
                    }

                    kingsData.Add(king);
                }
                else
                {
                    KingEvent kingEvent = new KingEvent();

                    kingEvent.Ruler = kingsData.First(item => item.Name == (strings[0]));
                    kingEvent.Begin = DateTime.Parse(strings[1]);
                    kingEvent.End = DateTime.Parse(strings[1]);
                    kingEvent.EventDescription = strings[2];

                    eventsData.Add(kingEvent);
                }

                lineCounter++;
            }

            List<object> data = new List<object>();
            data.AddRange(kingsData);
            data.AddRange(eventsData);

            return data;
        }

        private void UpdateVisiblePeriod(object parameter)
        {
            string houseName = (string)parameter;
            IEnumerable<House> houses = this.houses.Where(item => item.Name.Contains(houseName));

            this.SelectFirstKingInHouse(houses.FirstOrDefault());

            this.VisibleStart = houses.Min(item => item.Begin).AddYears(-5);
            this.VisibleEnd = houses.Max(item => item.End).AddYears(5);
        }

        private void SelectFirstKingInHouse(House house)
        {
            King firstKing = this.kings.FirstOrDefault(king => king.House == house.Name);

            if (firstKing != null)
            {
                this.SelectKing(firstKing);
            }
        }

        private void SelectNextKing(object parameter)
        {
            this.SelectAdjacentKing(1);
        }

        private void SelectPreviousKing(object parameter)
        {
            this.SelectAdjacentKing(-1);
        }

        private void SelectAdjacentKing(int indexOffset)
        {
            var king = this.SelectedItems.FirstOrDefault(selectedItem => selectedItem.GetType() == typeof(King));
            if (king != null)
            {
                var currentIndex = this.kings.IndexOf(king as King);
                int newIndex = currentIndex + indexOffset;

                if (newIndex < 0 || newIndex >= this.kings.Count)
                    return;

                King nextKing = this.kings[newIndex];

                this.SelectKing(nextKing);

                if (nextKing.End.AddYears(5) > this.VisibleEnd)
                {
                    DateTime newVisiblePeriodEnd = nextKing.End.AddYears(5);

                    if (newVisiblePeriodEnd > this.End)
                        newVisiblePeriodEnd = this.End;

                    this.VisibleStart = newVisiblePeriodEnd - (this.VisibleEnd - this.VisibleStart);
                    this.VisibleEnd = newVisiblePeriodEnd;
                }

                if (nextKing.Begin.AddYears(-5) < this.VisibleStart)
                {
                    DateTime newVisiblePeriodStart = nextKing.Begin.AddYears(-5);

                    if (newVisiblePeriodStart < this.Start)
                        newVisiblePeriodStart = this.Start;

                    this.VisibleEnd = newVisiblePeriodStart + (this.VisibleEnd - this.VisibleStart);
                    this.VisibleStart = newVisiblePeriodStart;
                }
            }
        }

        private void SelectKing(King king)
        {
            this.SelectKing(king, this.events.First(kingEvent => kingEvent.Ruler == king));
        }

        private void SelectKing(King king, KingEvent kingEvent)
        {
            List<object> newSelectedItems = new List<object>()
            {
                king,
                kingEvent
            };

            this.SelectedItems = newSelectedItems;
        }

        private void UpdateCommands()
        {
            this.nextKingCanExecute = !this.SelectedKing.Equals(this.Kings.Last());
            (this.NextKingCommand as DelegateCommand).InvalidateCanExecute();

            this.previousKingCanExecute = !this.SelectedKing.Equals(this.Kings.First());
            (this.PreviousKingCommand as DelegateCommand).InvalidateCanExecute();
        }

        private bool CanExecuteNextKing(object parameter)
        {
            return this.nextKingCanExecute;
        }

        private bool CanExecutePreviousKing(object parameter)
        {
            return this.previousKingCanExecute;
        }
    }
}