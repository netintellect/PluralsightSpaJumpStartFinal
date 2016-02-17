using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Barcode.Pdf417Configurator
{
    public class PDF417ViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _generateButtonPressedCommand;
        private string _pdf417Text = "";

        public ICommand GenerateButtonPressedCommand
        {
            get
            {
                if (this._generateButtonPressedCommand == null)
                {
                    this._generateButtonPressedCommand = new DelegateCommand(GenerateButtonPressed);
                }
                return this._generateButtonPressedCommand;
            }
        }

        protected virtual void GenerateButtonPressed(object parameter)
        {
            this.PopulatePDF417Text();
        }

        private void PopulatePDF417Text()
        {
            if (this.CountryComboSelectedIndex != 0)
                this.PDF417Text = this.Country + " " + this.City + " " + this.Address + " " + this.Date + " " + this.FullName + " " + this.Phone;
            else
                this.PDF417Text = this.City + " " + this.Address + " " + this.Date + " " + this.FullName + " " + this.Phone;
        }

        private ICommand _countrySelectedIndexChangedCommand;

        public ICommand CountrySelectedIndexChangedCommand
        {
            get
            {
                if (this._countrySelectedIndexChangedCommand == null)
                {
                    this._countrySelectedIndexChangedCommand = new DelegateCommand(CountrySelectedIndexChanged);
                }
                return this._countrySelectedIndexChangedCommand;
            }
        }

        protected virtual void CountrySelectedIndexChanged(object parameter)
        {
            if (this.CountryComboSelectedIndex != 0)
                this.Country = this.Countries[this.CountryComboSelectedIndex];
        }

        public int OrderNumber
        {
            get 
            {
                Random rand = new Random();
                return rand.Next(1000000, 10000000);
            }            
        }

        public int CountryComboSelectedIndex
        {
            get;
            set;
        }

        public string PDF417Text
        {
            get
            {
                return _pdf417Text;
            }
            set
            {
                this._pdf417Text = value;
                this.OnPropertyChanged("PDF417Text");
            }
        }
       
        public string Country 
        {
        get; 
        set; 
        }

        public string City
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Date
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        } 
      
        public List<string> Countries
        {
            get
            {
                return new List<string>() { "SELECT A COUNTRY", "Afghanistan","Albania","Algeria","American Samoa","Andorra","Angola","Anguilla","Antarctica","Antigua & Barbuda","Antilles, Netherlands", 
"Arabia, Saudi","Argentina","Armenia","Aruba","Australia","Austria","Azerbaijan","Bahamas, The","Bahrain","Bangladesh","Barbados","Belarus","Belgium","Belize","Benin","Bermuda",
"Bhutan","Bolivia","Bosnia and Herzegovina","Botswana","Bouvet Island","Brazil","British Indian Ocean T.","British Virgin Islands","Brunei Darussalam","Bulgaria","Burkina Faso",
"Burundi","Cambodia","Cameroon","Canada","Cape Verde","Caribbean, the","Cayman Islands","Central African Republic","Chad","Chile","China","Christmas Island","Cocos (Keeling) Islands",
"Colombia","Comoros","Congo","Congo, Dem. Rep. of the","Cook Islands","Costa Rica","Cote D'Ivoire","Croatia","Cuba","Cyprus","Czech Republic","Denmark","Djibouti","Dominica",
"Dominican Republic","East Timor (Timor-Leste)","Ecuador","Egypt","El Salvador","Equatorial Guinea","Eritrea","Estonia","Ethiopia","Europe","Falkland Islands (Malvinas)",
"Faroe Islands","Fiji","Finland","France","French Guiana","French Polynesia","French Southern Terr.","Gabon","Gambia, the","Georgia","Germany","Ghana","Gibraltar","Greece",
"Greenland","Grenada","Guadeloupe","Guam","Guatemala","Guernsey and Alderney","Guiana, French","Guinea","Guinea-Bissau","Guinea, Equatorial","Guyana","Haiti","Heard & McDonald Is.(AU)","Holy See (Vatican)","Honduras","Hong Kong, (China)","Hungary","Iceland","India","Indonesia","Iran, Islamic Republic of","Iraq","Ireland","Israel","Italy","Ivory Coast (Cote d'Ivoire)","Jamaica","Japan","Jersey","Jordan","Kazakhstan","Kenya","Kiribati","Korea Dem. People's Rep.","Korea, (South) Republic of","Kosovo","Kuwait","Kyrgyzstan",
"Lao People's Democ. Rep.","Latvia","Lebanon","Lesotho","Liberia","Libyan Arab Jamahiriya","Liechtenstein","Lithuania","Luxembourg","Macao, (China)","Macedonia, TFYR","Madagascar",
"Malawi","Malaysia","Maldives","Mali","Malta","Man, Isle of","Marshall Islands","Martinique (FR)","Mauritania","Mauritius","Mayotte (FR)","Mexico","Micronesia, Fed. States of",
"Moldova, Republic of","Monaco","Mongolia","Montenegro","Montserrat","Morocco","Mozambique","Myanmar (ex-Burma)","Namibia","Nauru","Nepal","Netherlands","Netherlands Antilles",
"New Caledonia","New Zealand","Nicaragua","Niger","Nigeria","Niue","Norfolk Island","Northern Mariana Islands","Norway","Oman","Pakistan","Palau","Palestinian Territory",
"Panama","Papua New Guinea","Paraguay","Peru","Philippines","Pitcairn Island","Poland","Portugal","Puerto Rico","Qatar","Reunion (FR)","Romania","Russia","Rwanda","Sahara, Western",
"Saint Barthelemy (FR)","Saint Helena (UK)","Saint Kitts and Nevis","Saint Lucia","Saint Martin (FR)","S Pierre & Miquelon(FR)","S Vincent & Grenadines","Samoa","San Marino",
"Sao Tome and Principe","Saudi Arabia","Senegal","Serbia","Seychelles","Sierra Leone","Singapore","Slovakia","Slovenia","Solomon Islands","Somalia","South Africa","South America",
"S.George & S.Sandwich","South Sudan","Spain","Sri Lanka (ex-Ceilan)","Sudan","Suriname","Svalbard & Jan Mayen Is.","Swaziland","Sweden","Switzerland","Syrian Arab Republic",
"Taiwan","Tajikistan","Tanzania, United Rep. of","Thailand","Timor-Leste (East Timor)","Togo","Tokelau","Tonga","Trinidad & Tobago","Tunisia","Turkey","Turkmenistan",
"Turks and Caicos Is.","Tuvalu","Uganda","Ukraine","United Arab Emirates","United Kingdom","United States","US Minor Outlying Isl.","Uruguay","Uzbekistan","Vanuatuv",
"Venezuela","Viet Nam","Virgin Islands, British","Virgin Islands, U.S.","Wallis and Futuna","Western Sahara","Yemen","Zambia","Zimbabwe"}; }
        }     
    }
}
