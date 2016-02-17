using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using System.Net;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace Telerik.Windows.Examples.Sparklines.LiveData
{
    public class ExampleViewModel : ViewModelBase
    {
        private ObservableCollection<Call> CallsPerson1;
        private ObservableCollection<Call> CallsPerson2;
        private ObservableCollection<Call> CallsPerson3;

        private Collection<Call> CallsPersonChartData;

        private Random rModel = new Random();
        private DispatcherTimer timer1;

        public TimeSpan _avarageHoldData1;
        public TimeSpan _avarageData1;
        public TimeSpan _avarageHoldData2;
        public TimeSpan _avarageData2;
        public TimeSpan _avarageHoldData3;
        public TimeSpan _avarageData3;

        public bool _durationOverLimitData1;
        public bool _holdOverLimitData1;
        public bool _durationOverLimitData2;
        public bool _holdOverLimitData2;
        public bool _durationOverLimitData3;
        public bool _holdOverLimitData3;

        private int _numberOfItems = 23;

        public ExampleViewModel()
        {
            SetUpTimer();
        }

        public Collection<Call> Data4
        {
            get
            {
                if (this.CallsPersonChartData == null)
                    AddItemsToData4();

                return this.CallsPersonChartData;
            }

        }

        public void AddItemsToData4()
        {
            if (this.CallsPersonChartData == null)
                this.CallsPersonChartData = new Collection<Call>();

            Call CallsPersonChartDataEntry;

            DateTime date = new DateTime(2010, 12, 12, 10, 0, 0);

            for (int i = 0; i < this._numberOfItems; i++)
            {
                CallsPersonChartDataEntry = new Call();

                CallsPersonChartDataEntry.TicksDuration = rModel.Next(0, 100);

                CallsPersonChartDataEntry.TicksHoldTime = rModel.Next(0, 100);

                CallsPersonChartDataEntry.Abandonments = rModel.Next(0, 50);

                CallsPersonChartDataEntry.TimeInverval = date;

                date = date.AddHours(1);

                this.CallsPersonChartData.Add(CallsPersonChartDataEntry);
            }
        }

        private void SetUpTimer()
        {
            this.CallsPerson1 = new ObservableCollection<Call>();
            this.CallsPerson2 = new ObservableCollection<Call>();
            this.CallsPerson3 = new ObservableCollection<Call>();

            for (int i = 0; i < this._numberOfItems; i++)
            {
                AddItemsToData(this.CallsPerson1, 1);
                AddItemsToData(this.CallsPerson2, 2);
                AddItemsToData(this.CallsPerson3, 3);
            }

            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromMilliseconds(500);
            timer1.Tick += timer1_Tick;
        }

        public bool DurationOverLimitData1
        {
            get
            {
                return _durationOverLimitData1;
            }
            set
            {
                _durationOverLimitData1 = value;
                this.OnPropertyChanged("DurationOverLimitData1");
            }
        }

        public bool HoldOverLimitData1
        {
            get
            {
                return _holdOverLimitData1;
            }
            set
            {
                _holdOverLimitData1 = value;
                this.OnPropertyChanged("HoldOverLimitData1");
            }
        }

        public bool DurationOverLimitData2
        {
            get
            {
                return _durationOverLimitData2;
            }
            set
            {
                _durationOverLimitData2 = value;
                this.OnPropertyChanged("DurationOverLimitData2");
            }
        }

        public bool HoldOverLimitData2
        {
            get
            {
                return _holdOverLimitData2;
            }
            set
            {
                _holdOverLimitData2 = value;
                this.OnPropertyChanged("HoldOverLimitData2");
            }
        }

        public bool DurationOverLimitData3
        {
            get
            {
                return _durationOverLimitData3;
            }
            set
            {
                _durationOverLimitData3 = value;
                this.OnPropertyChanged("DurationOverLimitData3");
            }
        }

        public bool HoldOverLimitData3
        {
            get
            {
                return _holdOverLimitData3;
            }
            set
            {
                _holdOverLimitData3 = value;
                this.OnPropertyChanged("HoldOverLimitData3");
            }
        }

        public ObservableCollection<Call> Data1
        {
            get
            {
                return this.CallsPerson1;
            }

        }

        public ObservableCollection<Call> Data2
        {
            get
            {
                return this.CallsPerson2;
            }

        }

        public ObservableCollection<Call> Data3
        {
            get
            {
                return this.CallsPerson3;
            }

        }

        public TimeSpan AvarageData1
        {
            get
            {
                return _avarageData1;
            }
            set
            {
                if (_avarageData1 != value)
                {
                    _avarageData1 = value;
                    this.OnPropertyChanged("AvarageData1");
                }
            }
        }

        public TimeSpan AvarageHoldData1
        {
            get
            {
                return _avarageHoldData1;
            }
            set
            {
                if (_avarageHoldData1 != value)
                {
                    _avarageHoldData1 = value;
                    this.OnPropertyChanged("AvarageHoldData1");
                }
            }
        }

        public TimeSpan AvarageData2
        {
            get
            {
                return _avarageData2;
            }
            set
            {
                if (_avarageData2 != value)
                {
                    _avarageData2 = value;
                    this.OnPropertyChanged("AvarageData2");
                }
            }
        }

        public TimeSpan AvarageHoldData2
        {
            get
            {
                return _avarageHoldData2;
            }
            set
            {
                if (_avarageHoldData2 != value)
                {
                    _avarageHoldData2 = value;
                    this.OnPropertyChanged("AvarageHoldData2");
                }
            }
        }

        public TimeSpan AvarageData3
        {
            get
            {
                return _avarageData3;
            }
            set
            {
                if (_avarageData3 != value)
                {
                    _avarageData3 = value;
                    this.OnPropertyChanged("AvarageData3");
                }
            }
        }

        public TimeSpan AvarageHoldData3
        {
            get
            {
                return _avarageHoldData3;
            }
            set
            {
                if (_avarageHoldData3 != value)
                {
                    _avarageHoldData3 = value;
                    this.OnPropertyChanged("AvarageHoldData3");
                }
            }
        }

        public void AddItemsToData(ObservableCollection<Call> CallPerson, int index)
        {
            if (CallPerson.Count >= 20)
            {
                reorderCollection(CallPerson);
                UpdateAvarage(CallPerson, index);
            }

            Call CallsPerson1Entry = new Call();
            CallsPerson1Entry.Duration = new TimeSpan(0, rModel.Next(0, 40), rModel.Next(1, 59));
            CallsPerson1Entry.TicksDuration = rModel.Next(0, 100);
            CallsPerson1Entry.HoldTime = new TimeSpan(0, rModel.Next(0, 40), rModel.Next(1, 59));
            CallsPerson1Entry.TicksHoldTime = rModel.Next(0, 100); ;
            CallsPerson1Entry.IssueResolved = rModel.Next(-100, 100);

            CallPerson.Add(CallsPerson1Entry);

            UpdateAvarage(CallPerson, index);
        }

        public void UpdateAvarage(ObservableCollection<Call> collection, int collectionIndex)
        {
            TimeSpan tempDuration = new TimeSpan(0, rModel.Next(1, 40), rModel.Next(1, 59));

            if (collectionIndex == 1)
            {
                this.AvarageData1 = new TimeSpan(tempDuration.Hours, tempDuration.Minutes, tempDuration.Seconds);
                tempDuration = new TimeSpan(0, rModel.Next(1, 40), rModel.Next(1, 59));
                this.AvarageHoldData1 = new TimeSpan(tempDuration.Hours, tempDuration.Minutes, tempDuration.Seconds);

                if (this.AvarageData1.Minutes > 30)
                {
                    DurationOverLimitData1 = true;
                }
                else
                {
                    DurationOverLimitData1 = false;
                }

                if (this.AvarageHoldData1.Minutes > 30)
                {
                    HoldOverLimitData1 = true;
                }
                else
                {
                    HoldOverLimitData1 = false;
                }


            }
            else if (collectionIndex == 2)
            {
                this.AvarageData2 = new TimeSpan(tempDuration.Hours, tempDuration.Minutes, tempDuration.Seconds);
                tempDuration = new TimeSpan(0, rModel.Next(1, 40), rModel.Next(1, 59));
                this.AvarageHoldData2 = new TimeSpan(tempDuration.Hours, tempDuration.Minutes, tempDuration.Seconds);

                if (this.AvarageData2.Minutes > 30)
                {
                    DurationOverLimitData2 = true;
                }
                else
                {
                    DurationOverLimitData2 = false;
                }

                if (this.AvarageHoldData2.Minutes > 30)
                {
                    HoldOverLimitData2 = true;
                }
                else
                {
                    HoldOverLimitData2 = false;
                }


            }

            else if (collectionIndex == 3)
            {
                this.AvarageData3 = new TimeSpan(tempDuration.Hours, tempDuration.Minutes, tempDuration.Seconds);
                tempDuration = new TimeSpan(0, rModel.Next(1, 40), rModel.Next(1, 59));
                this.AvarageHoldData3 = new TimeSpan(tempDuration.Hours, tempDuration.Minutes, tempDuration.Seconds);

                if (this.AvarageData3.Minutes > 30)
                {
                    DurationOverLimitData3 = true;
                }
                else
                {
                    DurationOverLimitData3 = false;
                }

                if (this.AvarageHoldData3.Minutes > 30)
                {
                    HoldOverLimitData3 = true;
                }
                else
                {
                    HoldOverLimitData3 = false;
                }


            }
        }

        public void reorderCollection(ObservableCollection<Call> collection)
        {
            collection.RemoveAt(0);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            AddItemsToData(this.CallsPerson1, 1);
            AddItemsToData(this.CallsPerson2, 2);
            AddItemsToData(this.CallsPerson3, 3);
        }

        public void StartTimer()
        {
            this.timer1.Start();

        }

        public void StopTimer()
        {
            this.timer1.Stop();
        }
    }
}




