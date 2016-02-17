using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PivotGrid.Layouts
{
    public class LayoutTemplateSelector : DataTemplateSelector
    {
        private DataTemplate compact;
        private DataTemplate outline;
        private DataTemplate tabular;

        public LayoutTemplateSelector()
        {
        }

        public DataTemplate Tabular
        {
            get { return tabular; }
            set { tabular = value; }
        }

        public DataTemplate Outline
        {
            get { return outline; }
            set { outline = value; }
        }

        public DataTemplate Compact
        {
            get { return compact; }
            set { compact = value; }
        }

        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item is PivotLayoutType)
            {
                PivotLayoutType layout = (PivotLayoutType)item;
                switch (layout)
                {
                    case PivotLayoutType.Compact: return this.Compact;
                    case PivotLayoutType.Outline: return this.Outline;
                    case PivotLayoutType.Tabular: return this.Tabular;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
}
