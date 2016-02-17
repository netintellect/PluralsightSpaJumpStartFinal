using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Examples.ChartView.Selection.Models;
using System.Windows.Input;

namespace Telerik.Windows.Examples.ChartView.Selection.Utilities
{
    public static class MapInteractivity
    {
        public static void InitializeFill(MapShape mapShape)
        {
            mapShape.Tag = false;
            string countryName = CountryUtilities.ExtractNameFromMapShapeExtendedData(mapShape);
            mapShape.ShapeFill = CreateFill(CountryUtilities.GetColor(countryName));
        }

        public static void UnselectShape(MapShape mapShape)
        {
            mapShape.Tag = false;
            string countryName = CountryUtilities.ExtractNameFromMapShapeExtendedData(mapShape);
            mapShape.ShapeFill = CreateFill(CountryUtilities.GetColor(countryName));
        }

        public static void SelectShape(MapShape mapShape)
        {
            mapShape.Tag = true;
            mapShape.ShapeFill = CreateSelectedFill(CountryUtilities.SelectedCountryColor);
        }

        public static bool IsSelected(MapShape mapShape)
        {
            return (bool)mapShape.Tag;
        }

        public static void MapShapeMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MapShape mapShape = sender as MapShape;
            if (mapShape != null)
            {
                if (IsSelected(mapShape))
                {
                    mapShape.ShapeFill = CreateSelectedHighlightFill(CountryUtilities.SelectedCountryColor, mapShape.ShapeFill.StrokeThickness);
                }
                else
                {
                    string countryName = CountryUtilities.ExtractNameFromMapShapeExtendedData(mapShape);
                    mapShape.ShapeFill = CreateHighlightFill(CountryUtilities.GetColor(countryName), mapShape.ShapeFill.StrokeThickness);
                }
            }
        }

        public static void MapShapeMouseLeave(object sender, MouseEventArgs e)
        {
            MapShape mapShape = sender as MapShape;
            if (mapShape != null)
            {
                string countryName = CountryUtilities.ExtractNameFromMapShapeExtendedData(mapShape);
                Color color = IsSelected(mapShape) ? CountryUtilities.SelectedCountryColor : CountryUtilities.GetColor(countryName);
                if (IsSelected(mapShape))
                    mapShape.ShapeFill = CreateSelectedFill(color);
                else
                    mapShape.ShapeFill = CreateFill(color);
            }
        }

        public static void MapShapeMouseEnter(object sender, MouseEventArgs e)
        {
            MapShape mapShape = sender as MapShape;
            if (mapShape != null)
            {
                string countryName = CountryUtilities.ExtractNameFromMapShapeExtendedData(mapShape);
                Color color = IsSelected(mapShape) ? CountryUtilities.SelectedCountryColor : CountryUtilities.GetColor(countryName);
                if (IsSelected(mapShape))
                    mapShape.ShapeFill = CreateSelectedHighlightFill(color, mapShape.ShapeFill.StrokeThickness);
                else
                    mapShape.ShapeFill = CreateHighlightFill(color, mapShape.ShapeFill.StrokeThickness);
            }
        }

        private static MapShapeFill CreateFill(Color color)
        {
            MapShapeFill fill = new MapShapeFill();
            fill.Fill = new SolidColorBrush(color);
            fill.StrokeThickness = 1;
            return fill;
        }

        private static MapShapeFill CreateSelectedFill(Color color)
        {
            MapShapeFill fill = new MapShapeFill();
            fill.Fill = new SolidColorBrush(color);
            fill.Stroke = new SolidColorBrush(CountryUtilities.CountryBorderColor);
            fill.StrokeThickness = 1;
            return fill;
        }

        private static MapShapeFill CreateHighlightFill(Color color, double strokeThickness)
        {
            MapShapeFill highlightFill = new MapShapeFill();
            color.A = 123;
            highlightFill.Fill = new SolidColorBrush(color);
            highlightFill.StrokeThickness = strokeThickness;
            return highlightFill;
        }

        private static MapShapeFill CreateSelectedHighlightFill(Color color, double strokeThickness)
        {
            MapShapeFill highlightFill = new MapShapeFill();
            color.A = 123;
            highlightFill.Fill = new SolidColorBrush(color);
            highlightFill.StrokeThickness = strokeThickness;
            highlightFill.Stroke = new SolidColorBrush(CountryUtilities.CountryBorderColor);
            return highlightFill;
        }
    }
}
