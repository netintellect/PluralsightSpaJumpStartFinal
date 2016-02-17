﻿using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using System;

namespace Telerik.Windows.Examples.TimeBar.Gallery.CombinedVisualization
{
    public partial class Example : UserControl
    {
        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/TimeBar;component/Gallery/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/TimeBar;component/Gallery/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });

            }
            InitializeComponent();
        }
    }
}
