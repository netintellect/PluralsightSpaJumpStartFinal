using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Telerik.Windows.Examples.Buttons.FirstLook.Common;

namespace Telerik.Windows.Examples.Buttons.FirstLook.ViewModels
{
    public class SeatsViewModel : DataSourceViewModelBase
    {
        public ObservableCollection<Seat> FirstVipSectionSeats { get; set; }
        public ObservableCollection<Seat> SecondVipSectionSeats { get; set; }
        public ObservableCollection<Seat> FirstSectionSeats { get; set; }
        public ObservableCollection<Seat> SecondSectionSeats { get; set; }
        public ObservableCollection<Seat> SeatsStatuses { get; set; }
        private int remainingSeats;

        protected override void GetDataCompleted(IEnumerable data)
        {
             var list = data as List<string>;

             if (list != null)
             {
                 for (int i = 0; i < list.Count; i++)
                 {
                     string[] seats = null;
                     seats = list[i].Split(',');
                     if (i == 0)
                     {
                         foreach (string seat in seats)
                         {
                             bool result;
                             if (bool.TryParse(seat, out result))
                             {
                                 if (!result)
                                 {
                                     this.FirstVipSectionSeats.Add(new Seat() { IsSeatTaken = false });
                                 }
                                 else
                                 {
                                     this.FirstVipSectionSeats.Add(new Seat() { IsSeatTaken = null });
                                 }
                             }
                         }
                     }
                     else if (i == 1)
                     {
                         foreach (string seat in seats)
                         {
                             bool result;
                             if (bool.TryParse(seat, out result))
                             {
                                 if (!result)
                                 {
                                     this.SecondVipSectionSeats.Add(new Seat() { IsSeatTaken = false });
                                 }
                                 else
                                 {
                                     this.SecondVipSectionSeats.Add(new Seat() { IsSeatTaken = null });
                                 }
                             }
                             
                         }
                     }
                     else if (i == 2)
                     {
                         foreach (string seat in seats)
                         {
                             bool result;
                             if (bool.TryParse(seat, out result))
                             {
                                 if (!result)
                                 {
                                     this.FirstSectionSeats.Add(new Seat() { IsSeatTaken = false });
                                 }
                                 else
                                 {
                                     this.FirstSectionSeats.Add(new Seat() { IsSeatTaken = null });
                                 }
                             }
                             
                         }
                     }
                     else if (i == 3)
                     {
                         foreach (string seat in seats)
                         {
                             bool result;
                             if (bool.TryParse(seat, out result))
                             {
                                 if (!result)
                                 {
                                     this.SecondSectionSeats.Add(new Seat() { IsSeatTaken = false });
                                 }
                                 else
                                 {
                                     this.SecondSectionSeats.Add(new Seat() { IsSeatTaken = null });
                                 }
                             }
                             
                         }
                     }
                 }
             }
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            return dataReader.ReadToEnd().Replace("\r", "").Replace("\n", "").Split(':').ToList<string>();
        }

        public int RemainingSeats
        {
            get { return this.remainingSeats; }
            set
            {
                if (this.remainingSeats != value)
                {
                    this.remainingSeats = value;
                    this.OnPropertyChanged("RemainingSeats");
                }
            }
        }

        public SeatsViewModel()
        {
            this.FirstVipSectionSeats = new ObservableCollection<Seat>();
            this.SecondVipSectionSeats = new ObservableCollection<Seat>();
            this.FirstSectionSeats = new ObservableCollection<Seat>();
            this.SecondSectionSeats = new ObservableCollection<Seat>();
            this.SeatsStatuses = new ObservableCollection<Seat>();

            this.LoadSeats();

            this.SeatsStatuses.Add(new Seat() { IsSeatTaken = false, SeatStatus = "Available" });
            this.SeatsStatuses.Add(new Seat() { IsSeatTaken = null, SeatStatus = "Occupied" });
            this.SeatsStatuses.Add(new Seat() { IsSeatTaken = true, SeatStatus = "Selected" });
        }

        public void LoadSeats()
        {
            this.GetData("Seats.csv");
        }
    }
}