using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.TransitionControl;
using Telerik.Windows.Controls.TreeMap;
#if WPF
using C = System.Windows.Controls;
using P = System.Windows.Controls.Primitives;
#else
using C = Telerik.Windows.Controls;
using P = Telerik.Windows.Controls.Primitives;
#endif

namespace Telerik.Windows.Examples.Treemap.Selection
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void RadTreeMap_Loaded(object sender, RoutedEventArgs e)
        {
            RadTreeMapItem rootItem = this.RadTreeMap.FindChildByType<RadTreeMapItem>();
            if (rootItem.ItemContainerGenerator.Status == P.GeneratorStatus.ContainersGenerated)
            {
                SelectItemFromGenerator(rootItem.ItemContainerGenerator);
            }
            else
            {
                rootItem.ItemContainerGenerator.StatusChanged += this.RootItemItemContainerGenerator_StatusChanged;
            }
        }

        private void RootItemItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            C.ItemContainerGenerator rootItemItemContainerGenerator = sender as C.ItemContainerGenerator;
            if (rootItemItemContainerGenerator.Status == P.GeneratorStatus.ContainersGenerated)
            {
                SelectItemFromGenerator(rootItemItemContainerGenerator);
            }
        }
  
        private void SelectItemFromGenerator(C.ItemContainerGenerator rootItemItemContainerGenerator)
        {
            RadTreeMapItem russiaContainer = rootItemItemContainerGenerator.ContainerFromIndex(0) as RadTreeMapItem;
            russiaContainer.IsSelected = true;
        }

        private void RadTreeMap_PreviewSelectionChanged(object sender, SelectionChangedRoutedEventArgs e)
        {
            if (e.SelectedItem == null)
                e.Cancel = true;
        }

        private void RadTreeMap_SelectionChanged(object sender, RadRoutedEventArgs e)
        {
            TransitionWrapper.Content = this.RadTreeMap.SelectedItem;
        }

        private void TransitionWrapper_TransitionStatusChanged(object sender, TransitionStatusChangedEventArgs e)
        {
            RadTransitionControl tc = (RadTransitionControl)sender;
            if (tc.Duration.TotalSeconds == 0)
            {
                tc.Dispatcher.BeginInvoke(new Action(ChangeDuration));
            }
        }

        private void ChangeDuration()
        {
            this.TransitionWrapper.Duration = new TimeSpan(0, 0, 1);
        }
    }
}
