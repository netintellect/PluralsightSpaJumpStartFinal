using System;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.ChartView.LiveData
{
    public class LiveDataViewModel : ViewModelBase
    {
        public RadObservableCollection<ChartBusinessObject> _data;
        public RadObservableCollection<ChartBusinessObject> _data2;
        private string messagesPerSecond;
        private string messagesPerMinute;
        private int tickCountSecond;
        private int tickCountMinute;
        private DispatcherTimer timer;
        private DateTime lastDate;
        private Random random = new Random();
        private DateTime? alignmentDate;
        private bool useAlignmentDate;
        private const int TimerInterval = 200;

        public LiveDataViewModel()
        {
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
            this.timer.Tick += this.OnTimer;

            this.FillData();
            this.FillData2();
            this.MessagesPerSecond = this.random.Next(900, 1100).ToString("#,#");
            this.MessagesPerMinute = this.random.Next(50000, 55000).ToString("#,#");
            this.useAlignmentDate = true;
        }

        public string MessagesPerSecond
        {
            get
            {
                return this.messagesPerSecond;
            }
            set
            {
                if (this.messagesPerSecond != value)
                {
                    this.messagesPerSecond = value;
                    this.OnPropertyChanged("MessagesPerSecond");
                }
            }
        }

        public string MessagesPerMinute
        {
            get
            {
                return this.messagesPerMinute;
            }
            set
            {
                if (this.messagesPerMinute != value)
                {
                    this.messagesPerMinute = value;
                    this.OnPropertyChanged("MessagesPerMinute");
                }
            }
        }

        public RadObservableCollection<ChartBusinessObject> Data
        {
            get
            {
                return this._data;
            }
            set
            {
                if (this._data != value)
                {
                    this._data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }

        public RadObservableCollection<ChartBusinessObject> Data2
        {
            get
            {
                return this._data2;
            }
            set
            {
                if (this._data2 != value)
                {
                    this._data2 = value;
                    this.OnPropertyChanged("Data2");
                }
            }
        }

        public DateTime? AlignmentDate
        {
            get
            {
                return this.alignmentDate;
            }
            set
            {
                if (this.alignmentDate != value)
                {
                    this.alignmentDate = value;
                    this.OnPropertyChanged("AlignmentDate");
                }
            }
        }

        public bool UseAlignmentDate
        {
            get
            {
                return this.useAlignmentDate;
            }
            set
            {
                if (this.useAlignmentDate != value)
                {
                    this.useAlignmentDate = value;
                    this.OnPropertyChanged("UseAlignmentDate");
                    this.UpdateAlignmentDate();
                }
            }
        }

        public void StartTimer()
        {
            this.timer.Start();
        }

        public void StopTimer()
        {
            this.timer.Stop();
        }

        public void UpdateTimer(double interval)
        {
            this.timer.Interval = TimeSpan.FromMilliseconds(interval);
        }

        private void FillData()
        {
            RadObservableCollection<ChartBusinessObject> collection = new RadObservableCollection<ChartBusinessObject>();
            this.lastDate = DateTime.Now;
            this.alignmentDate = this.lastDate;

            for (int i = 0; i < 31; i++)
            {
                this.lastDate = this.lastDate.AddMilliseconds(TimerInterval);
                collection.Add(this.CreateBusinessObject());
            }

            this.Data = collection;
        }

        private void FillData2()
        {
            RadObservableCollection<ChartBusinessObject> collection = new RadObservableCollection<ChartBusinessObject>();
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            for (int i = 0; i < 24; i++)
                collection.Add(this.CreateBusinessObject2(date.AddHours(i)));

            this.Data2 = collection;
        }

        private void OnTimer(object sender, EventArgs e)
        {
            this.lastDate = this.lastDate.AddMilliseconds(TimerInterval);

            this.Data.SuspendNotifications();

            this.Data.RemoveAt(0);
            this.Data.Add(this.CreateBusinessObject());
            this.Data.ResumeNotifications();
            this.UpdateMetrics();
        }

        private void UpdateMetrics()
        {
            this.tickCountSecond++;
            this.tickCountMinute++;

            if (this.tickCountSecond == 5)
            {
                this.tickCountSecond = 0;
                this.MessagesPerSecond = this.random.Next(900, 1100).ToString("#,#");
            }

            if (this.tickCountMinute == 300)
            {
                this.tickCountMinute = 0;
                this.MessagesPerMinute = this.random.Next(50000, 55000).ToString("#,#");
            }
        }

        private ChartBusinessObject CreateBusinessObject()
        {
            ChartBusinessObject obj = new ChartBusinessObject();

            obj.Value = this.random.Next(800, 1800);
            obj.Category = this.lastDate;

            return obj;
        }

        private ChartBusinessObject CreateBusinessObject2(DateTime date)
        {
            ChartBusinessObject obj = new ChartBusinessObject();

            obj.Value = this.random.Next(3300, 3800);
            obj.Category = date;

            return obj;
        }

        private void UpdateAlignmentDate()
        {
            this.AlignmentDate = this.useAlignmentDate ? (DateTime?)this.lastDate : null;
        }
    }
}
