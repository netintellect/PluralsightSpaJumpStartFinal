using System;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Buttons.FirstLook.Common
{
    public class Seat : ViewModelBase
    {
        private bool? isSeatTaken = false;
        public bool? IsSeatTaken
        {
            get { return this.isSeatTaken; }
            set
            {
                if (this.isSeatTaken != value)
                {
                    this.isSeatTaken = value;
                    this.OnPropertyChanged("IsSeatTaken");
                }
            }
        }

        private string seatStatus = "";
        public string SeatStatus
        {
            get { return this.seatStatus; }
            set
            {
                if (this.seatStatus != value)
                {
                    this.seatStatus = value;
                    this.OnPropertyChanged("SeatStatus");
                }
            }
        }
    }
}
