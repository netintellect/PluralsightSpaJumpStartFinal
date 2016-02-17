﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using Telerik.Windows.Controls.TreeMap;

namespace Telerik.Windows.Examples.Treemap.FirstLook
{
    public class DefinitionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            PivotMapGroupDefinition originalDefinition = value as PivotMapGroupDefinition;

            if (originalDefinition == null)
                return value;

            GroupDefinitionCollection collection = new GroupDefinitionCollection();
            collection.Add(originalDefinition);

            return collection;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}