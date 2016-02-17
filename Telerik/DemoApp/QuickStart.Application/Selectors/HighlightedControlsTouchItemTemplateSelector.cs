using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
    public class HighlightedControlsTouchItemTemplateSelector : DataTemplateSelector
    {
        private AllControlsTouchViewModel allControlsTouchViewModel;

        public DataTemplate NewItemTemplate { get; set; }

        public DataTemplate HighlightedItemTemplate { get; set; }

        public DataTemplate NormalTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            base.SelectTemplate(item, container);

            if (this.allControlsTouchViewModel == null)
            {
                // find the parent element with DataContext being the ViewModelBase

                FrameworkElement element = null;
                element = VisualTreeHelper.GetParent(container) as FrameworkElement;
                while (element != null)
                {
                    this.allControlsTouchViewModel = element.DataContext as AllControlsTouchViewModel;
                    if (this.allControlsTouchViewModel != null)
                    {
                        break;
                    }

                    element = VisualTreeHelper.GetParent(element) as FrameworkElement;
                }
            }

            var controlInfo = item as IControlInfo;

            if (this.allControlsTouchViewModel.NewControls.Contains(controlInfo))
            {
                return this.NewItemTemplate;
            }
            else if (this.allControlsTouchViewModel.HighlightedControls.Contains(controlInfo))
            {
                return this.HighlightedItemTemplate;
            }
            else
            {
                return this.NormalTemplate;
            }
        }
    }
}