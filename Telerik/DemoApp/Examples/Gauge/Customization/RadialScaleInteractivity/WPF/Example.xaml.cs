using System;
using System.Windows.Controls;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Gauge.Customization.RadialScaleInteractivity
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : DynamicBasePage
    {
        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Customization/RadialScaleInteractivity/WPF/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Customization/RadialScaleInteractivity/WPF/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            InitializeComponent();
        }
    }
}
