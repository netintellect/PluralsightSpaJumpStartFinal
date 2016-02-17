using System;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.HeatMap.Selection
{
    public partial class Example : UserControl
    {
        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/HeatMap;component/Selection/Resources/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/HeatMap;component/Selection/Resources/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            InitializeComponent();
        }
    }
}
