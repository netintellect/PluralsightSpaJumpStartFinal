using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using System;

namespace Telerik.Windows.Examples.BulletGraph.FirstLook
{
    public partial class Example : UserControl
    {
        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/BulletGraph;component/FirstLook/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/BulletGraph;component/FirstLook/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });

            }
            InitializeComponent();
        }
    }
}
