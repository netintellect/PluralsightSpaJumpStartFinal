using System.Windows.Controls;
using Telerik.Examples.Gauge;
using System.Globalization;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using System;

namespace Telerik.Windows.Examples.Gauge.FirstLook
{
    public partial class Example : DynamicBasePage
    {
        private RealDataEmulator valueGenerator = new RealDataEmulator(130, 410, 200);
        private RealDataEmulator valueGenerator2 = new RealDataEmulator(25, 42, 35);
        private RealDataEmulator valueGenerator3 = new RealDataEmulator(45, 75, 50);
        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/FirstLook/WPF/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/FirstLook/WPF/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/FirstLook/WPF/Resources.xaml", UriKind.RelativeOrAbsolute) });
            InitializeComponent();
            CultureInfo culture = new CultureInfo("en-US");
        }

        protected override void NewValue()
        {
            needle.Value = valueGenerator.GetNextValue(); 
            bar1.Value = valueGenerator2.GetNextValue(); 
            bar2.Value = valueGenerator3.GetNextValue();
        }
    }
}
