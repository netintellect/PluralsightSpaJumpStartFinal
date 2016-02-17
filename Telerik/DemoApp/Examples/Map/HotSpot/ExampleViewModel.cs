using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
using System.Windows.Input;
using System.Net;

namespace Telerik.Windows.Examples.Map.HotSpot
{
    public class ExampleViewModel : ViewModelBase
    {
#if SILVERLIGHT
        private string VEKey;
#endif
        private MapProviderBase _provider;
        private ICommand _changeHotSpotCommand;
        private bool _hotSpotFractionEnabled;
        private bool _hotSpotPixelsEnabled;
        private bool _hotSpotInnerPixelsEnabled;
        private HotSpotUnit _hotSpotUnits;
        private double _hotSpotX;
        private double _hotSpotY;
        private double _hotSpotXFraction = 0.5;
        private double _hotSpotYFraction = 0.5;
        private double _hotSpotXPixels;
        private double _hotSpotYPixels;
        private double _hotSpotXInnerPixels;
        private double _hotSpotYInnerPixels;
        private int _hotSpotGridColumn;
        private int _hotSpotGridRow;


        public ExampleViewModel()
        {
#if WPF
            SetProvider();
#elif SILVERLIGHT
            this.GetVEServiceKey();
#endif
            this.ChangeHotSpotCommand = new DelegateCommand(ChangeHotSpot);
        }

        private void SetProvider()
        {
#if SILVERLIGHT
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, this.VEKey);
#endif
#if WPF
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, BingMapHelper.VEKey);
            provider.IsTileCachingEnabled = true;
#endif
            this.Provider = provider;
        }

#if SILVERLIGHT
        private void GetVEServiceKey()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            Uri keyURI = new Uri(URIHelper.CurrentApplicationURL, "VEKey.txt");
            wc.DownloadStringAsync(keyURI);
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.VEKey = e.Result;
            this.SetProvider();
        }
#endif

        public MapProviderBase Provider
        {
            get
            {
                return this._provider;
            }
            set
            {
                if (this._provider != value)
                {
                    this._provider = value;
                    this.OnPropertyChanged("Provider");
                }
            }
        }

        public ICommand ChangeHotSpotCommand
        {
            get
            {
                return this._changeHotSpotCommand;
            }
            set
            {
                this._changeHotSpotCommand = value;
                this.OnPropertyChanged("ChangeHotSpotCommand");
            }
        }

        public bool HotSpotFractionEnabled
        {
            get
            {
                return this._hotSpotFractionEnabled;
            }
            set
            {
                this._hotSpotFractionEnabled = value;
                this.OnPropertyChanged("HotSpotFractionEnabled");
            }
        }

        public bool HotSpotPixelsEnabled
        {
            get
            {
                return this._hotSpotPixelsEnabled;
            }
            set
            {
                this._hotSpotPixelsEnabled = value;
                this.OnPropertyChanged("HotSpotPixelsEnabled");
            }
        }

        public bool HotSpotInnerPixelsEnabled
        {
            get
            {
                return this._hotSpotInnerPixelsEnabled;
            }
            set
            {
                this._hotSpotInnerPixelsEnabled = value;
                this.OnPropertyChanged("HotSpotInnerPixelsEnabled");
            }
        }

        public HotSpotUnit HotSpotUnits
        {
            get
            {
                return this._hotSpotUnits;
            }
            set
            {
                this._hotSpotUnits = value;
                this.OnPropertyChanged("HotSpotUnits");
            }
        }

        public double HotSpotX
        {
            get
            {
                return this._hotSpotX;
            }
            set
            {
                this._hotSpotX = value;
                this.OnPropertyChanged("HotSpotX");
            }
        }

        public double HotSpotY
        {
            get
            {
                return this._hotSpotY;
            }
            set
            {
                this._hotSpotY = value;
                this.OnPropertyChanged("HotSpotY");
            }
        }

        public double HotSpotXFraction
        {
            get
            {
                return this._hotSpotXFraction;
            }
            set
            {
                this._hotSpotXFraction = value;
                this.OnPropertyChanged("HotSpotXFraction");
            }
        }

        public double HotSpotYFraction
        {
            get
            {
                return this._hotSpotYFraction;
            }
            set
            {
                this._hotSpotYFraction = value;
                this.OnPropertyChanged("HotSpotYFraction");
            }
        }

        public double HotSpotXPixels
        {
            get
            {
                return this._hotSpotXPixels;
            }
            set
            {
                this._hotSpotXPixels = value;
                this.OnPropertyChanged("HotSpotXPixels");
            }
        }

        public double HotSpotYPixels
        {
            get
            {
                return this._hotSpotYPixels;
            }
            set
            {
                this._hotSpotYPixels = value;
                this.OnPropertyChanged("HotSpotYPixels");
            }
        }

        public double HotSpotXInnerPixels
        {
            get
            {
                return this._hotSpotXInnerPixels;
            }
            set
            {
                this._hotSpotXInnerPixels = value;
                this.OnPropertyChanged("HotSpotXInnerPixels");
            }
        }

        public double HotSpotYInnerPixels
        {
            get
            {
                return this._hotSpotYInnerPixels;
            }
            set
            {
                this._hotSpotYInnerPixels = value;
                this.OnPropertyChanged("HotSpotYInnerPixels");
            }
        }

        public int HotSpotGridColumn
        {
            get
            {
                return this._hotSpotGridColumn;
            }
            set
            {
                this._hotSpotGridColumn = value;
                this.OnPropertyChanged("HotSpotGridColumn");
            }
        }

        public int HotSpotGridRow
        {
            get
            {
                return this._hotSpotGridRow;
            }
            set
            {
                this._hotSpotGridRow = value;
                this.OnPropertyChanged("HotSpotGridRow");
            }
        }

        public void ChangeHotSpot(object parameter)
        {
            if (parameter.ToString() == "Fraction")
            {
                this.HotSpotUnits = HotSpotUnit.Fraction;
                if (this.HotSpotX < 0)
                    this.HotSpotX = 0;
                else if (this.HotSpotX > 1)
                    this.HotSpotX = 1;
                if (this.HotSpotY < 0)
                    this.HotSpotY = 0;
                else if (this.HotSpotY > 1)
                    this.HotSpotY = 1;
            }
            else if (parameter.ToString() == "Pixel")
            {
                this.HotSpotUnits = HotSpotUnit.Pixels;
            }
            else if (parameter.ToString() == "InnerPixel")
            {
                this.HotSpotUnits = HotSpotUnit.InsetPixels;
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName == "HotSpotXFraction" ||
                propertyName == "HotSpotXPixels" ||
                propertyName == "HotSpotXInnerPixels" ||
                propertyName == "HotSpotUnits")
                this.CalculateHotSpotX();

            if (propertyName == "HotSpotYFraction" ||
                propertyName == "HotSpotYPixels" ||
                propertyName == "HotSpotYInnerPixels" ||
                propertyName == "HotSpotUnits")
                this.CalculateHotSpotY();

            base.OnPropertyChanged(propertyName);
        }

        private void CalculateHotSpotX()
        {
            if (this.HotSpotUnits == HotSpotUnit.Fraction)
                this.HotSpotX = this.HotSpotXFraction;
            else if (this.HotSpotUnits == HotSpotUnit.Pixels)
                this.HotSpotX = this.HotSpotXPixels;
            else if (this.HotSpotUnits == HotSpotUnit.InsetPixels)
                this.HotSpotX = this.HotSpotXInnerPixels;
        }

        private void CalculateHotSpotY()
        {
            if (this.HotSpotUnits == HotSpotUnit.Fraction)
                this.HotSpotY = this.HotSpotYFraction;
            else if (this.HotSpotUnits == HotSpotUnit.Pixels)
                this.HotSpotY = this.HotSpotYPixels;
            else if (this.HotSpotUnits == HotSpotUnit.InsetPixels)
                this.HotSpotY = this.HotSpotYInnerPixels;
        }
    }


}
