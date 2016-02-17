using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Buttons.FirstLook.ViewModels
{
    public class PassengersViewModel : DataSourceViewModelBase
    {
        public List<string> Languages { get; set; }
        public List<string> Meals { get; set; }
        
        private string mealDropDownButtonContent;
        public string MealDropDownButtonContent
        {
            get { return this.mealDropDownButtonContent; }
            set
            {
                if (this.mealDropDownButtonContent != value)
                {
                    this.mealDropDownButtonContent = value;
                    this.OnPropertyChanged("MealDropDownButtonContent");
                }
            }
        }
        
        private string languageDropDownButtonContent;
        public string LanguageDropDownButtonContent
        {
            get { return this.languageDropDownButtonContent; }
            set
            {
                if (this.languageDropDownButtonContent != value)
                {
                    this.languageDropDownButtonContent = value;
                    this.OnPropertyChanged("LanguageDropDownButtonContent");
                }
            }
        }
        
        private bool isMealDropDownOpen;
        public bool IsMealDropDownOpen
        {
            get { return this.isMealDropDownOpen; }
            set
            {
                if (this.isMealDropDownOpen != value)
                {
                    this.isMealDropDownOpen = value;
                    this.OnPropertyChanged("IsMealDropDownOpen");
                }
            }
        }

        private bool isLanguageDropDownOpen;
        public bool IsLanguageDropDownOpen
        {
            get { return this.isLanguageDropDownOpen; }
            set
            {
                if (this.isLanguageDropDownOpen != value)
                {
                    this.isLanguageDropDownOpen = value;
                    this.OnPropertyChanged("IsLanguageDropDownOpen");
                }
            }
        }

        public DelegateCommand CloseDropDownButtonCommand { get; set; }

        public PassengersViewModel()
        {
            this.Languages = new List<string>();
            this.GetData("Languages.csv");

            this.Meals = new List<string>();
            this.GetData("Meals.csv");
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            var list = data as List<string>;

            if (list != null)
            {
                if (list.First().ToLower().Contains("meals"))
                {
                    string[] meals = list[1].Split(',');
                    for (int i = 1; i < meals.Count(); i++)
                    {
                        this.Meals.Add(meals[i]);
                    }
                }
                else if (list.First().ToLower().Contains("languages"))
                {
                    string[] lang = list[1].Split(',');
                    for (int i = 1; i < lang.Count(); i++)
                    {
                        this.Languages.Add(lang[i]);
                    }
                }

            }
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            return dataReader.ReadToEnd().Replace("\r", "").Replace("\n", "").Split(':').ToList<string>();
        }
    }
}