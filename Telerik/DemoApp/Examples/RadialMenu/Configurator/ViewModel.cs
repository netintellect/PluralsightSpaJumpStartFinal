using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RadialMenu.Configurator
{
    public class ViewModel : ViewModelBase
    {
        private RadRadialMenuItem selectedItem;
        private double outerRadiusFactor;
        private double innerNavigationRadiusFactor;
        private double innerRadiusFactor;

        public ViewModel()
        {
            this.InnerNavigationRadiusFactor = 0.85d;
            this.InnerRadiusFactor = 0.2d;
            this.OuterRadiusFactor = 1d;
        }

        /// <summary>
        /// Gets or sets InnerRadiusFactor and notifies for changes
        /// </summary>
        public double InnerRadiusFactor
        {
            get
            {
                return this.innerRadiusFactor;
            }

            set
            {
                if (this.innerRadiusFactor != value)
                {
                    this.innerRadiusFactor = value;
                    this.OnPropertyChanged(() => this.InnerRadiusFactor);
                }
            }
        }
        /// <summary>
        /// Gets or sets InnerNavigationRadiusFactor and notifies for changes
        /// </summary>
        public double InnerNavigationRadiusFactor
        {
            get
            {
                return this.innerNavigationRadiusFactor;
            }

            set
            {
                if (this.innerNavigationRadiusFactor != value)
                {
                    this.innerNavigationRadiusFactor = value;
                    this.OnPropertyChanged(() => this.InnerNavigationRadiusFactor);
                }
            }
        }

        /// <summary>
        /// Gets or sets OuterRadiusFactor and notifies for changes
        /// </summary>
        public double OuterRadiusFactor
        {
            get
            {
                return this.outerRadiusFactor;
            }

            set
            {
                if (this.outerRadiusFactor != value)
                {
                    this.outerRadiusFactor = value;
                    this.OnPropertyChanged(() => this.OuterRadiusFactor);
                }
            }
        }

        public RadRadialMenuItem SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                this.OnPropertyChanged(() => this.SelectedItem);
            }
        }
    }
}
