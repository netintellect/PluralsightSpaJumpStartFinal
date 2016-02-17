using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Chart.Selection
{
    public static class MapInteractivity
    {
        private static readonly Dictionary<string, Color> countryToColor = new Dictionary<string, Color>();
        private static readonly MapShapeFill highlightedShapeFill;

        static MapInteractivity()
        {
            highlightedShapeFill = new MapShapeFill();
            highlightedShapeFill.Fill = new SolidColorBrush(Color.FromArgb(255, 222, 222, 222));
            highlightedShapeFill.Stroke = new SolidColorBrush(Colors.Black);
            highlightedShapeFill.StrokeThickness = 1;

            countryToColor = new Dictionary<string, Color>();
            countryToColor.Add("Germany", Color.FromArgb(0xFF, 0x8E, 0xBC, 0x00));
            countryToColor.Add("France", Color.FromArgb(0xFF, 0x25, 0xA0, 0xDA));
            countryToColor.Add("Spain", Color.FromArgb(0xFF, 0xEB, 0x7A, 0x2A));
            countryToColor.Add("Poland", Color.FromArgb(0xFF, 0x98, 0x68, 0x27));
            countryToColor.Add("United Kingdom", Color.FromArgb(0xFF, 0xD8, 0xE4, 0x04));
            countryToColor.Add("Italy", Color.FromArgb(0xFF, 0x30, 0x9B, 0x46));
            countryToColor.Add("Romania", Color.FromArgb(0xFF, 0x16, 0xAB, 0xA9));
            countryToColor.Add("Netherlands", Color.FromArgb(0xFF, 0xDC, 0x4B, 0x08));
            countryToColor.Add("Portugal", Color.FromArgb(0xFF, 0xF2, 0xCA, 0x04));
        }

        private static MapShapeFill CreateNormalMapShapeFill(Color color)
        {
            MapShapeFill fill = new MapShapeFill();

            fill.Fill = new SolidColorBrush(color);
            fill.Stroke = new SolidColorBrush(Colors.Black);
            fill.StrokeThickness = 1;

            return fill;
        }

        private static MapShapeFill CreateSelectedMapShapeFill(Color color)
        {
            MapShapeFill fill = new MapShapeFill();

            fill.Fill = new SolidColorBrush(color);
            fill.Stroke = new SolidColorBrush(Colors.Black);
            fill.StrokeThickness = 2;

            return fill;
        }

        public static Color ReturnNormalColor(MapShape mapShape)
        {
            string countryName = Country.ExtractNameFromMapShapeExtendedData(mapShape);
            Color color;
            if (countryToColor.ContainsKey(countryName))
                color = countryToColor[countryName];
            else
                color = Colors.Black;

            return color;
        }

        public static void SelectShape(MapShape mapShape)
        {
            mapShape.Tag = true;
            mapShape.ShapeFill = CreateSelectedMapShapeFill(ReturnNormalColor(mapShape));
        }

        public static void UnSelectShape(MapShape mapShape)
        {
            mapShape.Tag = false;
            mapShape.ShapeFill = CreateNormalMapShapeFill(ReturnNormalColor(mapShape));
        }

        public static void HighlightShape(MapShape mapShape)
        {
            mapShape.HighlightFill = highlightedShapeFill;
        }

        public static bool IsSelected(MapShape mapShape)
        {
            return (bool)mapShape.Tag;
        }

        //
        // Mouse Events
        //

        public static void MapShapeMouseEnter(object sender, MouseEventArgs e)
        {
            MapShape mapShape = sender as MapShape;
            mapShape.ShapeFill = highlightedShapeFill;
        }

        public static void MapShapeMouseLeave(object sender, MouseEventArgs e)
        {
            MapShape mapShape = sender as MapShape;
            Color countryColor = ReturnNormalColor(mapShape);
            if (IsSelected(mapShape))
                mapShape.ShapeFill = CreateSelectedMapShapeFill(countryColor);
            else
                mapShape.ShapeFill = CreateNormalMapShapeFill(countryColor);
        }

        public static void MapShapeMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MapShape mapShape = sender as MapShape;
            if (mapShape != null)
            {
                mapShape.ExtendedData.GetValue(Country.ExtendedPropertyCountryName);
                if (IsSelected(mapShape))
                    UnSelectShape(mapShape);
                else
                    SelectShape(mapShape);
            }
        }
    }
}
