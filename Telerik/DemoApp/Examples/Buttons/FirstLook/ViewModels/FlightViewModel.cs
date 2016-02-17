using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Buttons.FirstLook.ViewModels
{
    public class FlightViewModel:DataSourceViewModelBase
    {
        public List<string> FromList { get; set; }
        public List<string> ToList { get; set; }
        public List<string> AdultList { get; set; }
        public List<string> ChildList { get; set; }
        public List<string> InfantsList { get; set; }
        public List<string> ClassesList { get; set; }
        
        private string fromDropDownButtonContent;
        public string FromDropDownButtonContent
        {
            get { return this.fromDropDownButtonContent; }
            set
            {
                if (this.fromDropDownButtonContent != value)
                {
                    this.fromDropDownButtonContent = value;
                    this.OnPropertyChanged("FromDropDownButtonContent");
                }
            }
        }
        
        private string toDropDownButtonContent;
        public string ToDropDownButtonContent
        {
            get { return this.toDropDownButtonContent; }
            set
            {
                if (this.toDropDownButtonContent != value)
                {
                    this.toDropDownButtonContent = value;
                    this.OnPropertyChanged("ToDropDownButtonContent");
                }
            }
        }
        
        private string adultsDropDownButtonContent;
        public string AdultsDropDownButtonContent
        {
            get { return this.adultsDropDownButtonContent; }
            set
            {
                if (this.adultsDropDownButtonContent != value)
                {
                    this.adultsDropDownButtonContent = value;
                    this.OnPropertyChanged("AdultsDropDownButtonContent");
                }
            }
        }
        
        private string kidDropDownButtonContent;
        public string KidDropDownButtonContent
        {
            get { return this.kidDropDownButtonContent; }
            set
            {
                if (this.kidDropDownButtonContent != value)
                {
                    this.kidDropDownButtonContent = value;
                    this.OnPropertyChanged("KidDropDownButtonContent");
                }
            }
        }

        private string infantDropDownButtonContent;
        public string InfantDropDownButtonContent
        {
            get { return this.infantDropDownButtonContent; }
            set
            {
                if (this.infantDropDownButtonContent != value)
                {
                    this.infantDropDownButtonContent = value;
                    this.OnPropertyChanged("InfantDropDownButtonContent");
                }
            }
        }

        private string businessClassDropDownButtonContent;
        public string BusinessClassDropDownButtonContent
        {
            get { return this.businessClassDropDownButtonContent; }
            set
            {
                if (this.businessClassDropDownButtonContent != value)
                {
                    this.businessClassDropDownButtonContent = value;
                    this.OnPropertyChanged("BusinessClassDropDownButtonContent");
                }
            }
        }
        public byte SelectedFromIndex { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }

        private bool areTicketsTwoWay = true;
        public bool AreTicketsTwoWay
        {
            get { return this.areTicketsTwoWay; }
            set
            {
                if (this.areTicketsTwoWay != value)
                {
                    this.areTicketsTwoWay = value;
                    this.OnPropertyChanged("AreTicketsTwoWay");
                }
            }
        }
        
        private bool isFromDropDownOpen;
        public bool IsFromDropDownOpen
        {
            get { return this.isFromDropDownOpen; }
            set
            {
                if (this.isFromDropDownOpen != value)
                {
                    this.isFromDropDownOpen = value;
                    this.OnPropertyChanged("IsFromDropDownOpen");
                }
            }
        }
        
        private bool isToDropDownOpen;
        public bool IsToDropDownOpen
        {
            get { return this.isToDropDownOpen; }
            set
            {
                if (this.isToDropDownOpen != value)
                {
                    this.isToDropDownOpen = value;
                    this.OnPropertyChanged("IsToDropDownOpen");
                }
            }
        }
        
        private bool isAdultsDropDownOpen;
        public bool IsAdultsDropDownOpen
        {
            get { return this.isAdultsDropDownOpen; }
            set
            {
                if (this.isAdultsDropDownOpen != value)
                {
                    this.isAdultsDropDownOpen = value;
                    this.OnPropertyChanged("IsAdultsDropDownOpen");
                }
            }
        }

        private bool isKidDropDownOpen;
        public bool IsKidDropDownOpen
        {
            get { return this.isKidDropDownOpen; }
            set
            {
                if (this.isKidDropDownOpen != value)
                {
                    this.isKidDropDownOpen = value;
                    this.OnPropertyChanged("IsKidDropDownOpen");
                }
            }
        }

        private bool isInfantDropDownOpen;
        public bool IsInfantDropDownOpen
        {
            get { return this.isInfantDropDownOpen; }
            set
            {
                if (this.isInfantDropDownOpen != value)
                {
                    this.isInfantDropDownOpen = value;
                    this.OnPropertyChanged("IsInfantDropDownOpen");
                }
            }
        }

        private bool isBusinessClassDropDownOpen;
        public bool IsBusinessClassDropDownOpen
        {
            get { return this.isBusinessClassDropDownOpen; }
            set
            {
                if (this.isBusinessClassDropDownOpen != value)
                {
                    this.isBusinessClassDropDownOpen = value;
                    this.OnPropertyChanged("IsBusinessClassDropDownOpen");
                }
            }
        }
        
        public DelegateCommand CloseDropDownButtonCommand { get; set; }

        public FlightViewModel()
        {
            this.FromList = new List<string>();
            this.ToList = new List<string>();
            this.ChildList = new List<string>();
            this.AdultList = new List<string>();
            this.InfantsList = new List<string>();
            this.ClassesList = new List<string>();
            this.DepartureDate = DateTime.Today;
            this.ReturnDate = DateTime.Today.AddDays(7);

            this.GetData("PassengersAndClasses.csv");
            this.GetData("FromList.csv");
            this.GetData("ToList.csv");
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            var list = data as List<string>;

            if (list != null)
            {
                if (list.First().ToLower().Contains("from"))
                {
                    for (int i = 1; i < list.Count; i++)
                    {
                        this.FromList.Add(list[i]);
                    }
                }
                else if (list.First().ToLower().Contains("to"))
                {
                    for (int i = 1; i < list.Count; i++)
                    {
                        this.ToList.Add(list[i]);
                    }
                }
                else
                {
                    foreach (string item in data)
                    {

                        if (item.ToLower().Contains("adult"))
                        {
                            this.AdultList.Add(item);
                        }
                        else if (item.ToLower().Contains("kid"))
                        {
                            this.ChildList.Add(item);
                        }
                        else if (item.ToLower().Contains("infant"))
                        {
                            this.InfantsList.Add(item);
                        }
                        else
                        {
                            this.ClassesList.Add(item);
                        }
                    }
                }
            }
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            return dataReader.ReadToEnd().Replace("\r","").Replace("\n","").Split(',').ToList<string>();
        }
    }
}