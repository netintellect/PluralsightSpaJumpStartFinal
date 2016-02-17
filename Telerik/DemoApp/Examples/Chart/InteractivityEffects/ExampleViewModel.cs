using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.InteractivityEffects
{
    public class ExampleViewModel : ViewModelBase
    {
        private List<DataObject> _data;

        public ExampleViewModel()
        {
            this.FillSampleData();
        }

        public List<DataObject> Data
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

        private void FillSampleData()
        {
            this.Data = DataObject.GetData();
        }
    }
}
