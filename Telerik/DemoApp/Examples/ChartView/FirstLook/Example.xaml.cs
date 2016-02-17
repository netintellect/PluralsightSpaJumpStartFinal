using System;
using System.Globalization;
using System.Threading;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.ChartView.FirstLook
{
    public partial class Example : UserControl
    {
        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/ChartView;component/FirstLook/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/ChartView;component/FirstLook/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            InitializeComponent();
        }
    }
}
