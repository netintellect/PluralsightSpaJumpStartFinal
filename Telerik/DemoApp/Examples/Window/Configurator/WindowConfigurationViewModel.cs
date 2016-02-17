using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

#if SILVERLIGHT
using WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation;
#endif

namespace Telerik.Windows.Examples.Window.Configurator
{
    public class WindowConfigurationViewModel : ViewModelBase
    {
        private bool canClose;
        private bool canMove;
        private bool restoreMinimizedLocation;
        private ResizeMode resizeMode;
        private WindowState state;
        private WindowStartupLocation startupLocation;
        private double left;
        private double top;
        private double width = 390;
        private double height = 230;
        private bool isOpen;
        
        public ICommand WindowStateChanged { get; set; }

        public bool CanClose
        {
            get
            {
                return this.canClose;
            }
            set
            {
                if (this.canClose != value)
                {
                    this.canClose = value;
                    OnPropertyChanged("CanClose");
                }
            }
        }

        public bool CanMove
        {
            get
            {
                return this.canMove;
            }
            set
            {
                if (this.canMove != value)
                {
                    this.canMove = value;
                    OnPropertyChanged("CanMove");
                }
            }
        }

        public bool RestoreMinimizedLocation
        {
            get
            {
                return this.restoreMinimizedLocation;
            }
            set
            {
                if (this.restoreMinimizedLocation != value)
                {
                    this.restoreMinimizedLocation = value;
                    OnPropertyChanged("RestoreMinimizedLocation");
                }
            }
        }

        public ResizeMode ResizeMode
        {
            get
            {
                return this.resizeMode;
            }
            set
            {
                if (this.resizeMode != value)
                {
                    this.resizeMode = value;
                    OnPropertyChanged("ResizeMode");
                }
            }
        }

        public WindowState State
        {
            get
            {
                return this.state;
            }
            set
            {
                if (this.state != value)
                {
                    this.state = value;
                    OnPropertyChanged("State");
                }
            }
        }

        public WindowStartupLocation StartupLocation
        {
            get
            {
                return this.startupLocation;
            }
            set
            {
                if (this.startupLocation != value)
                {
                    this.startupLocation = value;
                    OnPropertyChanged("StartupLocation");
                }
            }
        }

        public double Left
        {
            get
            {
                return this.left;
            }
            set
            {
                if (this.left != value)
                {
                    this.left = value;
                    OnPropertyChanged("Left");
                }
            }
        }

        public double Top
        {
            get
            {
                return this.top;
            }
            set
            {
                if (this.top != value)
                {
                    this.top = value;
                    OnPropertyChanged("Top");
                }
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
#if WPF
                if (this.width != value)
                {
                    this.width = value;

                    OnPropertyChanged("Width");
                }
#endif
#if SILVERLIGHT
                if (this.width != value && !double.IsNaN(value))
                {
                        this.width = value;

                        OnPropertyChanged("Width");
                }
#endif

            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
#if WPF
                if (this.height != value)
                {
                    this.height = value;

                    OnPropertyChanged("Height");
                }
#endif
#if SILVERLIGHT
                if (this.height != value && !double.IsNaN(value))
                {
                        this.height = value;

                    OnPropertyChanged("Height");
                }
#endif
            }
        }

        public bool IsOpen
        {
            get
            {
                return this.isOpen;
            }
            set
            {
                if (this.isOpen != value)
                {
                    this.isOpen = value;
                    OnPropertyChanged("IsOpen");
                }
            }
        }
    }
}