using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.DrillDown
{
    public partial class Example : UserControl
    {
        private const string StateExtendedPropertyName = "STATE_NAME";
        private MapShape countyShape;
        private MapShape stateShape;

        public Example()
        {
            InitializeComponent();
        }

        private void BringIntoView(MapShape shape)
        {
            LocationRect bestView = this.StateLayer.GetBestView(new object[] { shape });
            RadMap1.SetView(bestView);
        }

        private void CountyLayerReaderReadCompleted(object sender, ReadShapesCompletedEventArgs eventArgs)
        {
            if (eventArgs.Error != null)
                return;

            foreach (MapShape shape in this.CountyLayer.Items)
                shape.MouseLeftButtonUp += this.CountyShapeMouseLeftButtonUp;

            if (this.ZoomInCheckBox.IsChecked == true)
                this.BringIntoView(this.stateShape);
        }

        private void CountyShapeMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MapShape shape = sender as MapShape;

            this.ResetCountyShapeColor();

            this.countyShape = shape;
            shape.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xF0, 0xB5, 0x85));
        }

        private string GetExtendedProperty(MapShape shape, string propertyName)
        {
            return shape.ExtendedData.GetValue(propertyName).ToString();
        }

        private void LoadCountyDataCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            if (LoadCountyDataCheckBox == null)
                return;

            if ((bool)LoadCountyDataCheckBox.IsChecked)
                this.ResetStateShapeColor();
        }

        private void ResetCountyShapeColor()
        {
            if (this.countyShape != null)
                this.countyShape.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xDB, 0xA3));
        }

        private void ResetStateShapeColor()
        {
            if (this.stateShape != null)
                this.stateShape.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xF0, 0xD9));
        }

        private void StateLayerReaderReadCompleted(object sender, ReadShapesCompletedEventArgs eventArgs)
        {
            foreach (MapShape shape in this.StateLayer.Items)
                shape.MouseLeftButtonUp += this.StateShapeMouseLeftButtonUp;
        }

        private void StateShapeMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MapShape shape = sender as MapShape;

            if ((bool)this.LoadCountyDataCheckBox.IsChecked)
            {
                this.stateShape = shape;
                (this.Resources["DataContext"] as ExampleViewModel).County = GetExtendedProperty(shape, StateExtendedPropertyName);
            }
            else
            {
                this.ResetStateShapeColor();

                this.stateShape = shape;
                shape.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xE4, 0xBA));
            }
        }
    }
}
