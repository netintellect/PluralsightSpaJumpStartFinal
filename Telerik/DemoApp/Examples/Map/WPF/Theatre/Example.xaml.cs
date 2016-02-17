using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.Theatre
{
    public partial class Example : UserControl
    {
        private TheatreSeatInfoCollection selectedSeats = new TheatreSeatInfoCollection();

        public Example()
        {
            InitializeComponent();
        }

        private ExampleViewModel ViewModel
        {
            get
            {
                return this.Resources["DataContext"] as ExampleViewModel;
            }
        }

        private void SeatsShapeReader_ReadCompleted(object sender, Telerik.Windows.Controls.Map.ReadShapesCompletedEventArgs eventArgs)
        {
            InformationLayer layer = (sender as MapShapeReader).Layer;

            this.SetUpMapShapes(layer);

            if (this.ViewModel.Data != null)
                this.ColorizeMapShapes(layer);
            else
                this.ViewModel.PropertyChanged += this.ViewModelPropertyChanged;

            if (!layer.IsArrangeValid)
            {
                RadMap1.LayoutUpdated += this.RadMap1_LayoutUpdated;
                return;
            }

            // make sure the map zoom / center settings ensure best view of the loaded shapes
            this.SetBestView(layer);
        }

        private void RadMap1_LayoutUpdated(object sender, System.EventArgs e)
        {
            RadMap1.LayoutUpdated -= this.RadMap1_LayoutUpdated;

            this.SetBestView(SeatsLayer);
        }

        private void SetBestView(InformationLayer layer)
        {
            LocationRect bestView = layer.GetBestView(layer.Items.Cast<object>());
            RadMap1.SetView(bestView);
        }

        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Data")
                this.ColorizeMapShapes(SeatsLayer);
        }

        private void GridView_Filtered(object sender, Controls.GridView.GridViewFilteredEventArgs e)
        {
            this.ColorizeMapShapes(SeatsLayer);
        }

        private void SetUpMapShapes(InformationLayer layer)
        {
            foreach (MapShape seatShape in layer.Items)
            {
                seatShape.MouseLeftButtonDown += this.ShapeMouseLeftButtonDown;
                seatShape.CaptionTemplate = this.Resources["ShapeDataTemplate"] as DataTemplate;
                seatShape.CaptionLocation = seatShape.GeographicalBounds.Center;

                int seatId = int.Parse(seatShape.ExtendedData.GetValue("ID").ToString(), CultureInfo.InvariantCulture);
                seatShape.Tag = seatId;
            }
        }

        private void ColorizeMapShapes(InformationLayer layer)
        {
            this.selectedSeats.Clear();
            this.ViewModel.IsBuyButtonEnabled = false;

            // extract the seat colorization information from the data attributes
            foreach (MapShape seatShape in layer.Items)
            {
                SeatAvailability seatAvailability = this.GetSeatAvailability(seatShape);

                switch (seatAvailability)
                {
                    case SeatAvailability.NotAvailable:
                        seatShape.Fill = ColorizationHelper.NotAvailableBrush;
                        seatShape.Stroke = null;
                        seatShape.StrokeThickness = 0;
                        break;
                    case SeatAvailability.Reserved:
                        seatShape.Fill = ColorizationHelper.ReservedBrush;
                        seatShape.Stroke = null;
                        seatShape.StrokeThickness = 0;
                        break;
                    case SeatAvailability.Sold:
                        seatShape.Fill = ColorizationHelper.SoldBrush;
                        seatShape.Stroke = null;
                        seatShape.StrokeThickness = 0;
                        break;
                    default:
                        Color seatColor = GetSeatColor(seatShape);
                        seatShape.Fill = new SolidColorBrush(seatColor);
                        seatShape.Stroke = null;
                        seatShape.StrokeThickness = 0;
                        break;
                }
            }
        }

        private void ShapeMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MapShape shape = sender as MapShape;
            SeatAvailability seatAvailability = this.GetSeatAvailability(shape);

            if (seatAvailability != SeatAvailability.Free)
                return;

            TheatreSeatInfo seatInfo = this.GetSeatInfo(shape);
            if (this.selectedSeats.Contains(seatInfo))
                this.UnselectSeat(shape, seatInfo);
            else
                this.SelectSeat(shape, seatInfo);
        }

        private TheatreSeatInfo GetSeatInfo(MapShape shape)
        {
            int seatId = int.Parse(shape.ExtendedData.GetValue("ID").ToString(), CultureInfo.InvariantCulture);

            return this.ViewModel.GetSeatInfo(seatId);
        }

        private SeatAvailability GetSeatAvailability(MapShape shape)
        {
            int seatId = int.Parse(shape.ExtendedData.GetValue("ID").ToString(), CultureInfo.InvariantCulture);

            return this.ViewModel.GetSeatAvailability(seatId);
        }

        private void SelectSeat(MapShape shape, TheatreSeatInfo seatInfo)
        {
            this.selectedSeats.Add(seatInfo);

            shape.StrokeThickness = 1;
            shape.Stroke = ColorizationHelper.SelectedBrush;

            this.ViewModel.IsBuyButtonEnabled = this.selectedSeats.Count > 0;
        }

        private void UnselectSeat(MapShape shape, TheatreSeatInfo seatInfo)
        {
            this.selectedSeats.Remove(seatInfo);

            shape.StrokeThickness = 0;
            shape.Stroke = null;
            shape.HighlightFill = null;

            this.ViewModel.IsBuyButtonEnabled = this.selectedSeats.Count > 0;
        }

        private static Color GetSeatColor(MapShape shape)
        {
            byte red = byte.Parse(shape.ExtendedData.GetValue("RGB0").ToString(), CultureInfo.InvariantCulture);
            byte green = byte.Parse(shape.ExtendedData.GetValue("RGB1").ToString(), CultureInfo.InvariantCulture);
            byte blue = byte.Parse(shape.ExtendedData.GetValue("RGB2").ToString(), CultureInfo.InvariantCulture);

            return Color.FromArgb(255, red, green, blue);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow window = new BookingWindow();
            BookingViewModel viewModel = new BookingViewModel("Chicago", this.selectedSeats);
            window.DataContext = viewModel;
            window.Closed += this.BookingWindowClosed;
            window.ShowDialog();
        }

        private void BookingWindowClosed(object sender, Controls.WindowClosedEventArgs e)
        {
            BookingViewModel viewModel = (sender as FrameworkElement).DataContext as BookingViewModel;
            if (viewModel.IsFormSubmitted)
            {
                if (viewModel.IsBuyOptionSelected)
                {
                    this.BuySelectedSeats();
                }
                else if (viewModel.IsReserveOptionSelected)
                {
                    this.ReserveSelectedSeats();
                }

                this.ColorizeMapShapes(this.SeatsLayer);
            }
            else
            {
                this.UnselectSeats();
            }
        }

        private void UnselectSeats()
        {
            IEnumerable<MapShape> shapes = this.SeatsLayer.Items.Cast<MapShape>();
            for (int index = this.selectedSeats.Count - 1; index >= 0; index--)
            {
                TheatreSeatInfo seatInfo = this.selectedSeats[index];
                MapShape associatedShape = shapes.Where(shape => (int)shape.Tag == seatInfo.ID).FirstOrDefault();
                if (associatedShape != null)
                    this.UnselectSeat(associatedShape, seatInfo);
            }
        }

        private void BuySelectedSeats()
        {
            foreach (TheatreSeatInfo seatInfo in this.selectedSeats)
            {
                seatInfo.Status = SeatAvailability.Sold;
            }
        }

        private void ReserveSelectedSeats()
        {
            foreach (TheatreSeatInfo seatInfo in this.selectedSeats)
            {
                seatInfo.Status = SeatAvailability.Reserved;
            }
        }
    }
}
