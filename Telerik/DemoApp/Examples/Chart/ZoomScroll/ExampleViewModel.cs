using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Windows.Input;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Controls;
using System.ComponentModel;

namespace Telerik.Windows.Examples.Chart.ZoomScroll
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private List<DowJonesData> _data;

        public ExampleViewModel()
        {
            this.GetData("chartdata.csv");
        }

        private ChartArea _chartArea;
        public ChartArea ChartArea
        {
            get
            {
                return this._chartArea;
            }
            set
            {
                this._chartArea = value;
            }
        }

        ICommand _zoomInCommand;
        public ICommand ZoomInCommand
        {
            get
            {
                if (_zoomInCommand == null)
                {
                    _zoomInCommand = new DelegateCommand(ZoomIn, CanZoomIn);
                }
                return _zoomInCommand;
            }
        }

        ICommand _zoomOutCommand;
        public ICommand ZoomOutCommand
        {
            get
            {
                if (_zoomOutCommand == null)
                {
                    _zoomOutCommand = new DelegateCommand(ZoomOut, CanZoomOut);
                }
                return _zoomOutCommand;
            }
        }

        public void ChartDataBound(object sender, ChartDataBoundEventArgs e)
        {
            ((DelegateCommand)_zoomInCommand).InvalidateCanExecute();
            ((DelegateCommand)_zoomOutCommand).InvalidateCanExecute();
        }

        public void ZoomIn(object parameter)
        {
            this.ChartArea.ZoomScrollSettingsX.SuspendNotifications();

            double zoomCenter = this.ChartArea.ZoomScrollSettingsX.RangeStart + (this.ChartArea.ZoomScrollSettingsX.Range / 2);
            double newRange = Math.Max(this.ChartArea.ZoomScrollSettingsX.MinZoomRange, this.ChartArea.ZoomScrollSettingsX.Range) / 2;
            this.ChartArea.ZoomScrollSettingsX.RangeStart = Math.Max(0, zoomCenter - (newRange / 2));
            this.ChartArea.ZoomScrollSettingsX.RangeEnd = Math.Min(1, zoomCenter + (newRange / 2));

            this.ChartArea.ZoomScrollSettingsX.ResumeNotifications();

            ((DelegateCommand)_zoomInCommand).InvalidateCanExecute();
            ((DelegateCommand)_zoomOutCommand).InvalidateCanExecute();
        }

        public bool CanZoomIn(object parameter)
        {
            if (this.ChartArea == null)
                return false;

            return this.ChartArea.ZoomScrollSettingsX.Range > this.ChartArea.ZoomScrollSettingsX.MinZoomRange;
        }

        public void ZoomOut(object parameter)
        {
            this.ChartArea.ZoomScrollSettingsX.SuspendNotifications();

            double zoomCenter = this.ChartArea.ZoomScrollSettingsX.RangeStart + (this.ChartArea.ZoomScrollSettingsX.Range / 2);
            double newRange = Math.Min(1, this.ChartArea.ZoomScrollSettingsX.Range) * 2;

            if (zoomCenter + (newRange / 2) > 1)
                zoomCenter = 1 - (newRange / 2);
            else if (zoomCenter - (newRange / 2) < 0)
                zoomCenter = newRange / 2;

            this.ChartArea.ZoomScrollSettingsX.RangeStart = Math.Max(0, zoomCenter - newRange / 2);
            this.ChartArea.ZoomScrollSettingsX.RangeEnd = Math.Min(1, zoomCenter + newRange / 2);

            this.ChartArea.ZoomScrollSettingsX.ResumeNotifications();

            ((DelegateCommand)_zoomInCommand).InvalidateCanExecute();
            ((DelegateCommand)_zoomOutCommand).InvalidateCanExecute();
        }

        public bool CanZoomOut(object parameter)
        {
            if (this.ChartArea == null)
                return false;

            return this.ChartArea.ZoomScrollSettingsX.Range < 1d;
        }


        public List<DowJonesData> Data
        {
            get
            {
                return _data;
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

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<DowJonesData>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<DowJonesData> chartData = new List<DowJonesData>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                DowJonesData dataItem = new DowJonesData();
                dataItem.Date = DateTime.Parse(data[0], CultureInfo.InvariantCulture);
                dataItem.Open = double.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.High = double.Parse(data[2], CultureInfo.InvariantCulture);
                dataItem.Low = double.Parse(data[3], CultureInfo.InvariantCulture);
                dataItem.Close = double.Parse(data[4], CultureInfo.InvariantCulture);
                dataItem.Volume = long.Parse(data[5], CultureInfo.InvariantCulture);
                dataItem.AdjustedClose = double.Parse(data[6], CultureInfo.InvariantCulture);

                chartData.Add(dataItem);
            }

            return chartData;
        }
    }
}
