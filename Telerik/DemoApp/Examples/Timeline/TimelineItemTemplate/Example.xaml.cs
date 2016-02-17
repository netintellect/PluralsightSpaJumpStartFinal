using System;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Timeline.TimelineItemTemplate
{
    public partial class Example : UserControl
    {
        protected Panel ConfigurationPanel
        {
            get
            {
                return Telerik.Windows.Controls.QuickStart.QuickStart.GetConfigurationPanel(this);
            }
        }

        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Timeline;component/TimelineItemTemplate/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Timeline;component/TimelineItemTemplate/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Timeline;component/TimelineItemTemplate/Resources.xaml", UriKind.RelativeOrAbsolute) });

            InitializeComponent();
            this.BindConfigurationPanel();
        }

        private void BindConfigurationPanel()
        {
            if (this.ConfigurationPanel.DataContext == null)
            {
                this.ConfigurationPanel.DataContext = this.DataContext;
            }
        }
    }
}
