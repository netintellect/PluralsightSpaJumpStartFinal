using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Examples.HeatMap.Selection.ViewModels;

namespace Telerik.Windows.Examples.HeatMap.Selection.Views
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class CountryShape : UserControl
    {
        public CountryShape()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/HeatMap;component/Selection/Resources/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/HeatMap;component/Selection/Resources/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/HeatMap;component/Selection/Resources/Resources.xaml", UriKind.RelativeOrAbsolute) });
            InitializeComponent();
        }

        private void Path_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.UpdateMargin();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.UpdateMargin();
        }

        private void UpdateMargin()
        {

            var vm = this.DataContext as CountriesViewModel;
            if (vm != null && this.PathCountryShape != null && vm.SelectedCountry != null)
            {
                double offset = ((vm.SelectedCountry.UnemploymentRate / 30) * this.PathCountryShape.ActualHeight) + this.TextBoxUnemploymentRate.ActualHeight;
                this.CanvasInformationContainer.Margin = new Thickness(-50, 0, 0, offset);
            }
        }
    }
}