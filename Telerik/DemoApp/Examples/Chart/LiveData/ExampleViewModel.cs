using System;
using System.Collections.Generic;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.LiveData
{
    public class ExampleViewModel : ViewModelBase
    {
        private const int queueCapacity = 30;
        private Random r = new Random();
        private Queue<SystemLoadInfo> cpuData = new Queue<SystemLoadInfo>(queueCapacity);
        private DateTime nowTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        private DispatcherTimer timer1;
        private Queue<SystemLoadInfo> _data;
        private double _axisXMinValue;
        private double _axisXMaxValue;
        private double _axisXStep;

        public ExampleViewModel()
        {
            this.SetUpTimer();
        }

        public Queue<SystemLoadInfo> Data
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

        public double AxisXMinValue
        {
            get
            {
                return this._axisXMinValue;
            }
            set
            {
                if (this._axisXMinValue != value)
                {
                    this._axisXMinValue = value;
                    this.OnPropertyChanged("AxisXMinValue");
                }
            }
        }

        public double AxisXMaxValue
        {
            get
            {
                return this._axisXMaxValue;
            }
            set
            {
                if (this._axisXMaxValue != value)
                {
                    this._axisXMaxValue = value;
                    this.OnPropertyChanged("AxisXMaxValue");
                }
            }
        }

        public double AxisXStep
        {
            get
            {
                return this._axisXStep;
            }
            set
            {
                if (this._axisXStep != value)
                {
                    this._axisXStep = value;
                    this.OnPropertyChanged("AxisXStep");
                }
            }
        }

        public void StartTimer()
        {
            if (timer1 != null)
                timer1.Start();
        }

        public void StopTimer()
        {
            if (timer1 != null)
                timer1.Stop();
        }

        private void SetUpTimer()
        {
            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromMilliseconds(500);
            timer1.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            this.nowTime = this.nowTime.AddMilliseconds(500);

            this.UpdateData(this.nowTime);
            this.SetUpAxisXRange(this.nowTime);

            this.Data = null;
            this.Data = this.cpuData;
        }

        private void SetUpAxisXRange(DateTime now)
        {
            this.AxisXMinValue = now.AddSeconds(-14.5).ToOADate();
            this.AxisXMaxValue = now.ToOADate();
            this.AxisXStep = 1.0 / 24.0 / 3600.0 / 2.0;
        }

        private void UpdateData(DateTime now)
        {
            if (this.cpuData.Count >= queueCapacity)
                this.cpuData.Dequeue();

            SystemLoadInfo systemInfo = new SystemLoadInfo();

            systemInfo.CPULoad = r.NextDouble();
            systemInfo.MemUsage = r.Next(100, 200);
            systemInfo.Time = now;

            this.cpuData.Enqueue(systemInfo);
        }
    }
}

