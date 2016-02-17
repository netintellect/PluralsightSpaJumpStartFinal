using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView
{
    public class PolarViewModel : ViewModelBase
    {
        private object _polarData;
        private object _polarPointData;

        public PolarViewModel()
        {
            this.InitializeData();
        }

        private void InitializeData()
        {
            this.PolarData = this.CreatePolarData();
            this.PolarPointData = this.CreatePolarPointData();
        }

        public object PolarData
        {
            get
            {
                return this._polarData;
            }
            set
            {
                if (this._polarData != value)
                {
                    this._polarData = value;
                    this.OnPropertyChanged("PolarData");
                }
            }
        }

        public object PolarPointData
        {
            get
            {
                return this._polarPointData;
            }
            set
            {
                if (this._polarPointData != value)
                {
                    this._polarPointData = value;
                    this.OnPropertyChanged("PolarPointData");
                }
            }
        }

        private IEnumerable<IEnumerable<UserDataPoint>> CreatePolarData()
        {
            List<IEnumerable<UserDataPoint>> polarDataList = new List<IEnumerable<UserDataPoint>>();
            polarDataList.Add(ExampleData.GetUserPolarData(100, 100));
            polarDataList.Add(ExampleData.GetUserPolarData(100, 70));
            polarDataList.Add(ExampleData.GetUserPolarData(100, 50));

            return polarDataList;
        }

        private IEnumerable<IEnumerable<UserDataPoint>> CreatePolarPointData()
        {
            List<IEnumerable<UserDataPoint>> polarDataList = new List<IEnumerable<UserDataPoint>>();
            polarDataList.Add(ExampleData.GetUserPolarPointData(10, 0));
            polarDataList.Add(ExampleData.GetUserPolarPointData(10, 1));

            return polarDataList;
        }
    }
}
