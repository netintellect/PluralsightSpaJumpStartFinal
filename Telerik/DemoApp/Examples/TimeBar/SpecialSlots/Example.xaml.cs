using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Controls.TimeBar;

namespace Telerik.Windows.Examples.TimeBar.SpecialSlots
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            ExampleViewModel viewModel = this.DataContext as ExampleViewModel;
            viewModel.InformationLayerItemsSourceChanged += ViewModel_InformationLayerItemsSourceChanged;
            viewModel.InvalidRangeSelected += ViewModel_InvalidRangeSelected;

            this.radTimeBar1.SpecialSlotsGenerator = new WeekendsGenerator();
            this.radTimeBar2.SpecialSlotsGenerator = new WeekendsGenerator();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            var contentString = radioButton.Content.ToString();

            this.SetSpecialSlotsGenerator(contentString);
        }

        private void ViewModel_InformationLayerItemsSourceChanged(object sender, System.EventArgs e)
        {
            this.MapSetBestView();
        }

        private void ViewModel_InvalidRangeSelected(object sender, System.EventArgs e)
        {
            string alertText = "You have selected an invalid date range.";
            RadWindow.Alert(alertText, new EventHandler<WindowClosedEventArgs>(InvalidRangeWindowClosed));
        }

        private void MapInformationLayer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.MapSetBestView();
        }

        private void SetSpecialSlotsGenerator(string contentString)
        {
            ITimeRangeGenerator newGenerator;
            if (contentString == "Weekends")
            {
                newGenerator = new WeekendsGenerator();
            }
            else
            {
                newGenerator = new WorkDaysGenerator();
            }

            if (this.radTimeBar1 != null &&
                this.radTimeBar2 != null)
            {
                this.radTimeBar1.SpecialSlotsGenerator = newGenerator;
                this.radTimeBar2.SpecialSlotsGenerator = newGenerator;
            }
        }

        private void MapSetBestView()
        {
            LocationRect rect = this.informationLayer.GetBestView(this.informationLayer.Items.Cast<object>());

            rect.MapControl = this.RadMap1;
            this.RadMap1.Center = rect.Center;
            this.RadMap1.ZoomLevel = rect.ZoomLevel;
        }

        private void InvalidRangeWindowClosed(object sender, Controls.WindowClosedEventArgs e)
        {
            ExampleViewModel viewModel = this.DataContext as ExampleViewModel;

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                viewModel.CorrectInvalidRange();
            }));
        }
    }
}
