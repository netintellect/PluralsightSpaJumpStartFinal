using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RadialMenu.Configurator
{
    public partial class Example : UserControl
    {
        private ViewModel exampleViewModel;
        public Example()
        {
            InitializeComponent();
            this.exampleViewModel = new ViewModel();
            this.DataContext = this.exampleViewModel;
            this.configPanel.DataContext = exampleViewModel;
        }

        private void RadRadialMenu_PreviewToolTipOpen(object sender, Controls.RadialMenu.MenuToolTipEventArgs e)
        {
            e.Placement = PlacementModeParser.CastPlacementMode(this.PlacementModeComboBox.SelectedValue);
        }

        private void OnApplyRadButtonClick(object sender, RoutedEventArgs e)
        {
            // Need to reopen the menu, so that the changes to take effect.
            this.RadRadialMenu.IsOpen = false;
            this.UpdateRadRadialMenuFactors();
            this.RadRadialMenu.IsOpen = true;
        }

        private void UpdateRadRadialMenuFactors()
        {
            this.RadRadialMenu.OuterRadiusFactor = this.exampleViewModel.OuterRadiusFactor;
            this.RadRadialMenu.InnerNavigationRadiusFactor = this.exampleViewModel.InnerNavigationRadiusFactor;
            this.RadRadialMenu.InnerRadiusFactor = this.exampleViewModel.InnerRadiusFactor;
        }

        private void OnRadRadialMenuSelectionChanged(object sender, Controls.RadialMenu.MenuSelectionChangedEventArgs e)
        {
            // Needed to update the ConfigurationPanel.
            if (e.Item.IsSelected)
            {
                this.exampleViewModel.SelectedItem = e.Item;
            }
            else
            {
                this.exampleViewModel.SelectedItem = null;
            }
        }

        private void OnRadColorSelectorSelectedColorChanged(object sender, EventArgs e)
        {
            if (exampleViewModel.SelectedItem != null)
            {
                exampleViewModel.SelectedItem.ContentSectorBackground = new SolidColorBrush((sender as RadColorSelector).SelectedColor);
            }
        }

        private void OnResetRadButtonClick(object sender, RoutedEventArgs e)
        {
            // Need to reopen the menu, so that the changes to take effect.
            this.RadRadialMenu.IsOpen = false;
            this.exampleViewModel.OuterRadiusFactor = 1d;
            this.exampleViewModel.InnerNavigationRadiusFactor = 0.85d;
            this.exampleViewModel.InnerRadiusFactor = 0.2d;
            this.UpdateRadRadialMenuFactors();
            this.RadRadialMenu.IsOpen = true;
        }

        private void OnRadColorSelectorNoColorButtonClicked(object sender, RoutedEventArgs e)
        {
            if (exampleViewModel.SelectedItem != null)
            {
                exampleViewModel.SelectedItem.ContentSectorBackground = new SolidColorBrush((sender as RadColorSelector).AutomaticColor);
            }
        }
    }
}