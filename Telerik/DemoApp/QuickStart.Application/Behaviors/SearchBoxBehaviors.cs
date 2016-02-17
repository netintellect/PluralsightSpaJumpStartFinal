using System;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls.QuickStart.Analytics;
using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
    public class SearchBoxBehaviors : DependencyObject
    {
        // Using a DependencyProperty as the backing store for UseDefaultQuickStartSearchBehavior.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseDefaultQuickStartSearchBehaviorProperty =
            DependencyProperty.RegisterAttached("UseDefaultQuickStartSearchBehavior", typeof(bool), typeof(SearchBoxBehaviors), new PropertyMetadata(false, OnUseDefaultQuickStartSearchBehaviorPropertyChanged));

        public static bool GetUseDefaultQuickStartSearchBehavior(DependencyObject obj)
        {
            return (bool)obj.GetValue(UseDefaultQuickStartSearchBehaviorProperty);
        }

        public static void SetUseDefaultQuickStartSearchBehavior(DependencyObject obj, bool value)
        {
            obj.SetValue(UseDefaultQuickStartSearchBehaviorProperty, value);
        }

        private static void OnUseDefaultQuickStartSearchBehaviorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is SearchBox))
            {
                return;
            }

            SearchBox searchBox = d as SearchBox;

            searchBox.Filter -= OnExampleSearchFilter;
            searchBox.SearchSelection -= OnExampleSearchSearchSelection;

            if ((bool)e.NewValue)
            {
                searchBox.Filter += OnExampleSearchFilter;
                searchBox.SearchSelection += OnExampleSearchSearchSelection;
            }
        }

        private static void OnExampleSearchFilter(object sender, SearchFilterEventArgs e)
        {
            IExampleInfo example = e.Item as IExampleInfo;

            string lowerSearchText = e.SearchText.ToLowerInvariant();

            if (example != null)
            {
                string exampleName = example.ExampleGroup.Control.Name.ToLowerInvariant();
                string text = example.Text.ToLowerInvariant();
                string keywords = example.Keywords.ToLowerInvariant();

                bool isExampleName = exampleName.Contains(lowerSearchText);
                bool isText = text.Contains(lowerSearchText);
                bool isKeywords = keywords.Contains(lowerSearchText);

                e.Accepted = isExampleName || isText || isKeywords;
            }
        }

        private static void OnExampleSearchSearchSelection(object sender, SearchSelectionEventArgs e)
        {
            // EQATEC: track navigation to page
            string analyticsString = string.Concat(EqatecConstants.NavigateBySearch, ".", e.SelectedItem.ToString().Replace("Telerik.Windows.Examples.", ""));
            EqatecMonitor.Instance.TrackFeature(analyticsString);
            
            var navigateCommand = ((sender as SearchBox).DataContext as QuickStartViewModelBase).NavigateCommand;
            navigateCommand.Execute(e.SelectedItem);
        }
    }
}