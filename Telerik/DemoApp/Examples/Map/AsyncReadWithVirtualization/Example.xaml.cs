using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.AsyncReadWithVirtualization
{
    public partial class Example : UserControl
    {
#if SILVERLIGHT
        private const string ShapeRelativeUriFormat = "DataSources/Geospatial/{0}";
#else
        private const string ShapeRelativeUriFormat = "/Map;component/Resources/{0}";
#endif

#if SILVERLIGHT
        private string VEKey;
#endif


        public Example()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadShapeFile();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.LoadShapeFile();
        }

        private void LoadShapeFile()
        {
			AsyncShapeFileReader reader = this.virtualizationSource.Reader as AsyncShapeFileReader;
			reader.Source = new Uri(string.Format(ShapeRelativeUriFormat, "County.shp"), UriKind.Relative);
			this.virtualizationSource.ReadAsync();
        }

        private void VisualizationLayer_MapShapeVisualizationCreated(object sender, MapShapeOperationEventArgs e)
        {
            if (e.Visualization != null)
            {
                // Attach mouse events to the map shape visualization.
                e.Visualization.MouseEnter += Visualization_MouseEnter;
                e.Visualization.MouseLeave += Visualization_MouseLeave;
            }
        }

        private void VisualizationLayer_MapShapeVisualizationRemoved(object sender, MapShapeOperationEventArgs e)
        {
            if (e.Visualization != null)
            {
                // Detach mouse events to the map shape visualization.
                e.Visualization.MouseEnter -= Visualization_MouseEnter;
                e.Visualization.MouseLeave -= Visualization_MouseLeave;
            }
        }

        private void Visualization_MouseLeave(object sender, MouseEventArgs e)
        {
            // Use regular fill when mouse leave the shape.
            FrameworkElement elt = sender as FrameworkElement;
            if (elt != null)
            {
                MapShapeData data = elt.DataContext as MapShapeData;
                data.UseRegularFill();
            }
        }

        private void Visualization_MouseEnter(object sender, MouseEventArgs e)
        {
            // Highlight shape when mouse enter.
            FrameworkElement elt = sender as FrameworkElement;
            if (elt != null)
            {
                MapShapeData data = elt.DataContext as MapShapeData;
                data.UseHighlightFill();
            }
        }
    }
}
