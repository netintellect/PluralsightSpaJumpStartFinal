using System;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Controls.Timeline;
#if WPF
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

#endif

namespace Telerik.Windows.Examples.Timeline.Selection
{
    public partial class Example : System.Windows.Controls.UserControl
    {
        private bool isSelectionHandlingSuspended = false;

        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Timeline;component/Selection/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Timeline;component/Selection/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }

            InitializeComponent();

            this.BindConfigurationPanel();

            this.SelectTimelineItemsForCategories();

            this.KingOfPopTimeline.SelectionChanged += this.KingOfPopTimeline_SelectionChanged;
            this.CategoriesSelector.SelectionChanged += this.Categories_SelectionChanged;
        }

        protected System.Windows.Controls.Panel ConfigurationPanel
        {
            get
            {
                return Telerik.Windows.Controls.QuickStart.QuickStart.GetConfigurationPanel(this);
            }
        }

        private void Categories_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.isSelectionHandlingSuspended)
                return;

            this.isSelectionHandlingSuspended = true;
            this.SelectTimelineItemsForCategories();
            this.isSelectionHandlingSuspended = false;
        }

        private void KingOfPopTimeline_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (this.isSelectionHandlingSuspended)
                return;

            this.isSelectionHandlingSuspended = true;
            this.SelectCategoriesForTimelineItems();
            this.isSelectionHandlingSuspended = false;
        }

        private void SelectTimelineItemsForCategories()
        {
            if (this.CategoriesSelector == null)
                return;

            var selectedCategories = this.CategoriesSelector.SelectedItems;

            var timeline = this.KingOfPopTimeline;
            var isSingleSelection = timeline.SelectionMode == SelectionMode.Single;
            var dataItems = (this.DataContext as ExampleViewModel).Data;

            if (isSingleSelection)
            {
                timeline.SelectedItem = null;
            }
            else
            {
                timeline.SelectedItems.Clear();
            }

            foreach (System.Windows.Controls.ListBoxItem selectedItem in selectedCategories)
            {
                if (isSingleSelection && timeline.SelectedItem != null)
                    break;

                var selectedCategory = selectedItem.Tag;

                foreach (LifeEvent item in dataItems)
                {
                    if (item.Categories.Any(category => string.Equals(category, selectedCategory)))
                    {
                        if (isSingleSelection)
                        {
                            timeline.SelectedItem = item;
                            break;
                        }
                        else
                        {
                            timeline.SelectedItems.Add(item);
                        }
                    }
                }
            }
        }

        private void SelectCategoriesForTimelineItems()
        {
            this.CategoriesSelector.SelectedItems.Clear();

            foreach (LifeEvent selectedItem in this.KingOfPopTimeline.SelectedItems)
            {
                var categories = selectedItem.Categories;

                foreach (System.Windows.Controls.ListBoxItem listBoxItem in this.CategoriesSelector.Items)
                {
                    if (categories.Any(category => string.Equals(category, listBoxItem.Tag)))
                    {
                        this.CategoriesSelector.SelectedItems.Add(listBoxItem);
                    }
                }
            }
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