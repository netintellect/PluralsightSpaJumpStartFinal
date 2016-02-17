using System;
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
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.ContextMenu.FirstLook
{
    public class FlagsViewModel : ViewModelBase
    {
        private DelegateCommand _EnableCommand;
        public ICommand EnableCommand
        {
            get
            {
                return this._EnableCommand;
            }
        }
        private DelegateCommand _ZoomCommand;
        public ICommand ZoomCommand
        {
            get
            {
                return this._ZoomCommand;
            }
        }
        private DelegateCommand _MapCountryCommand;
        public ICommand MapCountryCommand
        {
            get
            {
                return this._MapCountryCommand;
            }
        }

        public FlagsViewModel()
        {          
            this._EnableCommand = new DelegateCommand(EnableFlagCommand, CanExecuteEnableFlag);
            this._ZoomCommand = new DelegateCommand(ZoomFlagCommand, CanExecuteZoomFlag);
            this._MapCountryCommand = new DelegateCommand(MapFlagToCountryCommand, CanExecuteMapFlagToCountry);

            //this.UpdateCommands();
            this.CountryHeader = "Check Country";
        }

        //private void UpdateCommands()
        //{
        //    this.EnableDisableHeader = this.ClickedListBoxItem != null && this.ClickedListBoxItem.Opacity < 1 ? "Enable" : "Disable";
        //    this.ZoomHeader = this.ClickedListBoxItem != null && this.ClickedListBoxItem.IsSelected ? "Zoom Out" : "Zoom In";
        //    this._ZoomCommand.InvalidateCanExecute();
        //}

        //private ObservableCollection<Flag> _flagsCollection;
        public ObservableCollection<Flag> FlagsCollection
        {
            get
            {               
                    ObservableCollection<Flag> flags = CreateFlags();
                    return flags;               
            }
        }

        private string _enableDisableHeader;
        public string EnableDisableHeader
        {
            get
            {
                return this._enableDisableHeader;
            }
            set
            {               
                    this._enableDisableHeader = value;
                    OnPropertyChanged("EnableDisableHeader");               
            }
        }

        private string _zoomHeader;
        public string ZoomHeader
        {
            get
            {
                return this._zoomHeader;
            }
            set
            {
                this._zoomHeader = value;
                OnPropertyChanged("ZoomHeader");
               
            }
        }

        private string _countryHeader;
        public string CountryHeader
        {
            get
            {
                return this._countryHeader;
            }
            set
            {               
                this._countryHeader = value;
                OnPropertyChanged("CountryHeader");
               
            }
        }


        public ObservableCollection<Flag> CreateFlags()
        {
            ObservableCollection<Flag> flags = new ObservableCollection<Flag>();
                flags.Add(new Flag("USA", "../../Images/ContextMenu/Configurator/usa.png"));
                flags.Add(new Flag("Bolivia", "../../Images/ContextMenu/Configurator/bolivia.png"));
                flags.Add(new Flag("Brazil", "../../Images/ContextMenu/Configurator/brazil.png"));
                flags.Add(new Flag("Canada", "../../Images/ContextMenu/Configurator/canada.png"));
                flags.Add(new Flag("Chad", "../../Images/ContextMenu/Configurator/chad.png"));
                flags.Add(new Flag("Chile", "../../Images/ContextMenu/Configurator/chile.png"));
                flags.Add(new Flag("Columbia", "../../Images/ContextMenu/Configurator/columbia.png"));
                flags.Add(new Flag("EU", "../../Images/ContextMenu/Configurator/eu.png"));
                flags.Add(new Flag("Holland", "../../Images/ContextMenu/Configurator/holland.png"));
                flags.Add(new Flag("Norway", "../../Images/ContextMenu/Configurator/norway.png"));
                flags.Add(new Flag("Panama", "../../Images/ContextMenu/Configurator/panama.png"));
                flags.Add(new Flag("Portugal", "../../Images/ContextMenu/Configurator/portugal.png"));
                flags.Add(new Flag("Slovakia", "../../Images/ContextMenu/Configurator/slovakia.png"));
                flags.Add(new Flag("Spain", "../../Images/ContextMenu/Configurator/spain.png"));
                flags.Add(new Flag("Suriname", "../../Images/ContextMenu/Configurator/suriname.png"));
                flags.Add(new Flag("Sweden", "../../Images/ContextMenu/Configurator/sweden.png"));
                flags.Add(new Flag("Switzerland", "../../Images/ContextMenu/Configurator/swiss.png"));
                flags.Add(new Flag("Turkey", "../../Images/ContextMenu/Configurator/turkey.png"));
                flags.Add(new Flag("UK", "../../Images/ContextMenu/Configurator/uk.png"));
                flags.Add(new Flag("Venezuela", "../../Images/ContextMenu/Configurator/venezuela.png"));

            return flags;
        }
        /// <summary>
        /// Enable / Disable the flag
        /// </summary>
        /// <param name="parameter"></param>
        public void EnableFlagCommand(object parameter)
        {
            UIElement clickedElement = parameter as UIElement;
           
            if (clickedElement != null)
            {
                bool isFaded = clickedElement.Opacity < 1;
                if (isFaded)
                {
                    //Opaque look
                    clickedElement.Opacity = 1;
                }
                else
                {
                    //Fade out
                    clickedElement.Opacity = 0.3;
                }
            }

            //this.UpdateCommands();
        }

        public bool CanExecuteEnableFlag(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Zoom the flag
        /// </summary>
        /// <param name="parameter"></param>
        public void ZoomFlagCommand(object parameter)
        {
            System.Windows.Controls.ListBoxItem clickedElement = parameter as System.Windows.Controls.ListBoxItem;

            if (clickedElement != null)
            {
                clickedElement.IsSelected = !clickedElement.IsSelected;
            }

            //this.UpdateCommands();
        }

        public bool CanExecuteZoomFlag(object parameter)
        {
             System.Windows.Controls.ListBoxItem clickedElement = parameter as System.Windows.Controls.ListBoxItem;
            return clickedElement != null && clickedElement.Opacity == 1;
        }

        /// <summary>
        /// Display country corresponding to the flag
        /// </summary>
        /// <param name="parameter"></param>
        public void MapFlagToCountryCommand(object parameter)
        {          
             System.Windows.Controls.ListBoxItem clickedElement = parameter as System.Windows.Controls.ListBoxItem;

             if (clickedElement != null)
             {
                 Flag flag = clickedElement.Content as Flag;
                 string country = flag == null ? "" : flag.Country;
                 RadWindow.Alert(new DialogParameters
                 {
                     Header = country,
                     IconContent = null,
                     Content = String.Format("The selected country is {0}", country)
                 });
             }
        }

        public bool CanExecuteMapFlagToCountry(object parameter)
        {
            return true;
        }
    }
}
