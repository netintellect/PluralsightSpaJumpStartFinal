using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using Telerik.Pivot.Core;
#if SILVERLIGHT
using Telerik.Windows.Controls;
#else
using System.Windows.Controls;
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.PivotGrid.Localization
{
    public partial class Example : System.Windows.Controls.UserControl
    {
        public Example()
        {
            InitializeComponent();

            this.Unloaded += this.OnExampleUnloaded;
            this.InitializeSupportedCultures();
            this.Reload();
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }

        private void InitializeSupportedCultures()
        {
            List<CultureInfo> supportedCultures = new List<CultureInfo>();
            supportedCultures.Add(CultureInfo.InvariantCulture);
            supportedCultures.Add(new CultureInfo("es"));
            supportedCultures.Add(new CultureInfo("de"));
            supportedCultures.Add(new CultureInfo("it"));
            supportedCultures.Add(new CultureInfo("fr"));
            supportedCultures.Add(new CultureInfo("tr"));
            supportedCultures.Add(new CultureInfo("en-US"));

            this.Cultures.ItemsSource = supportedCultures;
        }


        private void Cultures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Telerik.Windows.Controls.LocalizationManager.DefaultCulture = (CultureInfo)(sender as Telerik.Windows.Controls.RadComboBox).SelectedItem;

            if (e.RemovedItems.Count != 0)
            {
                this.Reload();
            }
        }

        private void Reload()
        {
            DataTemplate dataTemplate = this.Resources["LocalizedContent"] as DataTemplate;
            if (dataTemplate != null && this.LocalizationPresenter != null)
            {
                this.LocalizationPresenter.Content = dataTemplate.LoadContent();
            }

            this.RefreshProviderCulture();
        }

        private void RefreshProviderCulture()
        {
            var provider = this.Resources["dataProvider"] as LocalDataSourceProvider;
            var itemsSource = provider.ItemsSource;
            provider.ItemsSource = null;
            provider.Culture = Telerik.Windows.Controls.LocalizationManager.DefaultCulture;
            provider.ItemsSource = itemsSource;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Telerik.Windows.Controls.LocalizationManager.DefaultCulture = CultureInfo.InvariantCulture;
        }
    }
}
