using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.Stadium
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void MapShapeReader_ReadCompleted(object sender, Telerik.Windows.Controls.Map.ReadShapesCompletedEventArgs eventArgs)
        {
            InformationLayer layer = (sender as MapShapeReader).Layer;

            // extract the seat colorization information from the data attributes
            foreach (MapShape shape in layer.Items)
            {
                byte red = byte.Parse(shape.ExtendedData.GetValue("RGB0").ToString(), CultureInfo.InvariantCulture);
                byte green = byte.Parse(shape.ExtendedData.GetValue("RGB1").ToString(), CultureInfo.InvariantCulture);
                byte blue = byte.Parse(shape.ExtendedData.GetValue("RGB2").ToString(), CultureInfo.InvariantCulture);

                shape.Fill = new SolidColorBrush(Color.FromArgb(255, red, green, blue));
                shape.MouseLeftButtonDown += Shape_MouseLeftButtonDown;
            }
#if WPF
            if (!layer.IsArrangeValid)
            {
                RadMap1.LayoutUpdated += this.RadMap1_LayoutUpdated;
                return;
            }
#endif
            // make sure the map zoom / center settings ensure best view of the loaded shapes
            this.SetBestView(layer);
        }

#if WPF
        private void RadMap1_LayoutUpdated(object sender, System.EventArgs e)
        {
            RadMap1.LayoutUpdated -= this.RadMap1_LayoutUpdated;

            this.SetBestView(SeatsLayer);
        }
#endif

        private void SetBestView(InformationLayer layer)
        {
            LocationRect bestView = layer.GetBestView(layer.Items.Cast<object>());
            RadMap1.SetView(bestView);
        }

        private void Shape_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MapShape shape = sender as MapShape;
            string sector = shape.ExtendedData.GetValue("LAYER").ToString();

            this.StartTransitionAnimation();
            (this.Resources["DataContext"] as ExampleViewModel).UpdateViewModel(sector);
        }

        private void StartTransitionAnimation()
        {
            if (this.TransitionWrapper != null)
            {
                this.TransitionWrapper.PrepareAnimation();
                this.TransitionWrapper.StartAnimation();
            }
        }
    }
}
