using Telerik.Windows.Controls;
using System.Windows.Input;

namespace Telerik.Windows.Examples.Barcode.Gallery
{
    public class GalleryViewModel : ViewModelBase
    {
        private bool _showChecksum = true;
        private bool _code128Visibility = true;
        private bool _code128AVisibility = false;
        private bool _code128BVisibility = false;
        private bool _code128CVisibility = false;
        private bool _code39Visibility = true;
        private bool _code39ExtendedVisibility = false;
        private bool _codeEAN13Visibility = true;
        private bool _codeEAN8Visibility = false;
        private bool _code25StandardVisibility = true;
        private bool _code25InterleavedVisibility = false;
        private bool _code93Visibility = true;
        private bool _code93ExtendedVisibility = false;
        private bool _codeUPCAVisibility = true;
        private bool _codeUPCEVisibility = false;
        private bool _codeUPCSupplement2Visibility = true;
        private bool _codeUPCSupplement5Visibility = false;
        
        private ICommand _code128VisibilityChangedCommand;
        private ICommand _code39VisibilityCommand;
        private ICommand _code93VisibilityCommand;
        private ICommand _codeEANVisibilityCommand;
        private ICommand _code25VisibilityCommand;
        private ICommand _codeUPCVisibilityCommand;
        private ICommand _codeUPCSupplementCommand;

        public ICommand CodeUPCSupplementCommand
        {
            get
            {
                if (this._codeUPCSupplementCommand == null)
                {
                    this._codeUPCSupplementCommand = new DelegateCommand(CodeUPCSupplementVisibilityChanged);
                }

                return this._codeUPCSupplementCommand;
            }
        }

        public ICommand CodeUPCVisibilityCommand
        {
            get
            {
                if (this._codeUPCVisibilityCommand == null)
                {
                    this._codeUPCVisibilityCommand = new DelegateCommand(CodeUPCVisibilityChanged);
                }

                return this._codeUPCVisibilityCommand;
            }
        }

        public ICommand Code25VisibilityCommand
        {
            get
            {
                if (this._code25VisibilityCommand == null)
                {
                    this._code25VisibilityCommand = new DelegateCommand(Code25VisibilityChanged);
                }

                return this._code25VisibilityCommand;
            }
        }

        public ICommand CodeEANVisibilityCommand
        {
            get
            {
                if (this._codeEANVisibilityCommand == null)
                {
                    this._codeEANVisibilityCommand = new DelegateCommand(CodeEANVisibilityChanged);
                }

                return this._codeEANVisibilityCommand;
            }
        }

        public ICommand Code39VisibilityCommand
        {
            get
            {
                if (this._code39VisibilityCommand == null)
                {
                    this._code39VisibilityCommand = new DelegateCommand(Code39VisibilityChanged);
                }

                return this._code39VisibilityCommand;
            }
        }

        public ICommand Code93VisibilityCommand
        {
            get
            {
                if (this._code93VisibilityCommand == null)
                {
                    this._code93VisibilityCommand = new DelegateCommand(Code93VisibilityChanged);
                }

                return this._code93VisibilityCommand;
            }
        }

        protected virtual void Code93VisibilityChanged(object parameter)
        {
            string selectedItem = parameter.ToString();

            switch (selectedItem)
            {
                case "Code93":
                    this.Code93Visibility = true;
                    this.Code93ExtendedVisibility = false;
                    break;
                case "Code93Extended":
                    this.Code93Visibility = false;
                    this.Code93ExtendedVisibility = true;
                    break;
            }
        }

        protected virtual void Code39VisibilityChanged(object parameter)
        {
            string selectedItem = parameter.ToString();

            switch (selectedItem)
            {
                case "Code39":
                    this.Code39Visibility = true;
                    this.Code39ExtendedVisibility = false;
                    break;
                case "Code39Extended":
                    this.Code39Visibility = false;
                    this.Code39ExtendedVisibility = true; 
                    break;
            }
        }

        protected virtual void CodeEANVisibilityChanged(object parameter)
        {
            string selectedItem = parameter.ToString();

            switch (selectedItem)
            {
                case "EAN13":
                    this.CodeEAN13Visibility = true;
                    this.CodeEAN8Visibility = false;
                    break;
                case "EAN8":
                    this.CodeEAN13Visibility = false;
                    this.CodeEAN8Visibility = true;
                    break;
            }
        }

        protected virtual void CodeUPCVisibilityChanged(object parameter)
        {
            string selectedItem = parameter.ToString();

            switch (selectedItem)
            {
                case "CodeUPCA":
                    this.CodeUPCAVisibility = true;
                    this.CodeUPCEVisibility = false;
                    break;
                case "CodeUPCE":
                    this.CodeUPCAVisibility = false;
                    this.CodeUPCEVisibility = true;
                    break;
            }
        }

        protected virtual void CodeUPCSupplementVisibilityChanged(object parameter)
        {
            string selectedItem = parameter.ToString();

            switch (selectedItem)
            {
                case "CodeUPCSupplement2":
                    this.CodeUPCSupplement2Visibility = true;
                    this.CodeUPCSupplement5Visibility = false;
                    break;
                case "CodeUPCSupplement5":
                    this.CodeUPCSupplement2Visibility = false;
                    this.CodeUPCSupplement5Visibility = true;
                    break;
            }
        }

        protected virtual void Code25VisibilityChanged(object parameter)
        {
            string selectedItem = parameter.ToString();

            switch (selectedItem)
            {
                case "Code25Standard":
                    this.Code25StandardVisibility = true;
                    this.Code25InterleavedVisibility = false;
                    break;
                case "Code25Interleaved":
                    this.Code25StandardVisibility = false;
                    this.Code25InterleavedVisibility = true;
                    break;
            }
        }

        public ICommand Code128VisibilityChangedCommand
        {
            get
            {
                if (this._code128VisibilityChangedCommand == null)
                {
                    this._code128VisibilityChangedCommand = new DelegateCommand(Code128visibilityChanged);
                }

                return this._code128VisibilityChangedCommand;
            }
        }

        protected virtual void Code128visibilityChanged(object parameter)
        {
            string selectedItem = parameter.ToString();

            switch (selectedItem)
            {
                case "Code128":
                    this.Code128Visibility = true;
                    this.Code128AVisibility = false;
                    this.Code128BVisibility = false;
                    this.Code128CVisibility = false;
                    break;
                case "Code128A":
                    this.Code128Visibility = false;
                    this.Code128AVisibility = true;
                    this.Code128BVisibility = false;
                    this.Code128CVisibility = false;
                    break;
                case "Code128B":
                    this.Code128Visibility = false;
                    this.Code128AVisibility = false;
                    this.Code128BVisibility = true;
                    this.Code128CVisibility = false;
                    break;
                case "Code128C":
                    this.Code128Visibility = false;
                    this.Code128AVisibility = false;
                    this.Code128BVisibility = false;
                    this.Code128CVisibility = true;
                    break;
            }
        }

        public bool Code128Visibility
        {
            get
            {
                return this._code128Visibility;
            }
            set
            {
                if (this._code128Visibility != value)
                {
                    this._code128Visibility = value;
                    this.OnPropertyChanged("Code128Visibility");
                }
            }
        }

        public bool Code128AVisibility
        {
            get
            {
                return this._code128AVisibility;
            }
            set
            {
                if (this._code128AVisibility != value)
                {
                    this._code128AVisibility = value;
                    this.OnPropertyChanged("Code128AVisibility");
                }
            }
        }

        public bool Code128BVisibility
        {
            get
            {
                return this._code128BVisibility;
            }
            set
            {
                if (this._code128BVisibility != value)
                {
                    this._code128BVisibility = value;
                    this.OnPropertyChanged("Code128BVisibility");
                }
            }
        }

        public bool Code128CVisibility
        {
            get
            {
                return this._code128CVisibility;
            }
            set
            {
                if (this._code128CVisibility != value)
                {
                    this._code128CVisibility = value;
                    this.OnPropertyChanged("Code128CVisibility");
                }
            }
        }

        public bool Code39Visibility
        {
            get
            {
                return this._code39Visibility;
            }
            set
            {
                if (this._code39Visibility != value)
                {
                    this._code39Visibility = value;
                    this.OnPropertyChanged("Code39Visibility");
                }
            }
        }

        public bool Code39ExtendedVisibility
        {
            get
            {
                return this._code39ExtendedVisibility;
            }
            set
            {
                if (this._code39ExtendedVisibility != value)
                {
                    this._code39ExtendedVisibility = value;
                    this.OnPropertyChanged("Code39ExtendedVisibility");
                }
            }
        }

        public bool Code93Visibility
        {
            get
            {
                return this._code93Visibility;
            }
            set
            {
                if (this._code93Visibility != value)
                {
                    this._code93Visibility = value;
                    this.OnPropertyChanged("Code93Visibility");
                }
            }
        }

        public bool Code93ExtendedVisibility
        {
            get
            {
                return this._code93ExtendedVisibility;
            }
            set
            {
                if (this._code93ExtendedVisibility != value)
                {
                    this._code93ExtendedVisibility = value;
                    this.OnPropertyChanged("Code93ExtendedVisibility");
                }
            }
        }

        public bool CodeUPCAVisibility
        {
            get
            {
                return this._codeUPCAVisibility;
            }
            set
            {
                if (this._codeUPCAVisibility != value)
                {
                    this._codeUPCAVisibility = value;
                    this.OnPropertyChanged("CodeUPCAVisibility");
                }
            }
        }

        public bool CodeUPCEVisibility
        {
            get
            {
                return this._codeUPCEVisibility;
            }
            set
            {
                if (this._codeUPCEVisibility != value)
                {
                    this._codeUPCEVisibility = value;
                    this.OnPropertyChanged("CodeUPCEVisibility");
                }
            }
        }

        public bool CodeEAN13Visibility
        {
            get
            {
                return this._codeEAN13Visibility;
            }
            set
            {
                if (this._codeEAN13Visibility != value)
                {
                    this._codeEAN13Visibility = value;
                    this.OnPropertyChanged("CodeEAN13Visibility");
                }
            }
        }

        public bool CodeEAN8Visibility
        {
            get
            {
                return this._codeEAN8Visibility;
            }
            set
            {
                if (this._codeEAN8Visibility != value)
                {
                    this._codeEAN8Visibility = value;
                    this.OnPropertyChanged("CodeEAN8Visibility");
                }
            }
        }

        public bool Code25StandardVisibility
        {
            get
            {
                return this._code25StandardVisibility;
            }
            set
            {
                if (this._code25StandardVisibility != value)
                {
                    this._code25StandardVisibility = value;
                    this.OnPropertyChanged("Code25StandardVisibility");
                }
            }
        }

        public bool Code25InterleavedVisibility
        {
            get
            {
                return this._code25InterleavedVisibility;
            }
            set
            {
                if (this._code25InterleavedVisibility != value)
                {
                    this._code25InterleavedVisibility = value;
                    this.OnPropertyChanged("Code25InterleavedVisibility");
                }
            }
        }

        public bool CodeUPCSupplement2Visibility
        {
            get
            {
                return this._codeUPCSupplement2Visibility;
            }
            set
            {
                if (this._codeUPCSupplement2Visibility != value)
                {
                    this._codeUPCSupplement2Visibility = value;
                    this.OnPropertyChanged("CodeUPCSupplement2Visibility");
                }
            }
        }

        public bool CodeUPCSupplement5Visibility
        {
            get
            {
                return this._codeUPCSupplement5Visibility;
            }
            set
            {
                if (this._codeUPCSupplement5Visibility != value)
                {
                    this._codeUPCSupplement5Visibility = value;
                    this.OnPropertyChanged("CodeUPCSupplement5Visibility");
                }
            }
        }

        public bool ShowChecksum
        {
            get
            {
                return this._showChecksum;
            }
            set
            {
                if (this._showChecksum != value)
                {
                    this._showChecksum = value;
                    this.OnPropertyChanged("ShowChecksum");
                }
            }
        }
    }
}
