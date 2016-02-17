using System.Windows.Controls;
#if !WPF
using Telerik.Windows.Controls;
#endif
using System.Windows;

namespace Telerik.Windows.Examples.TreeView
{
    public class ContentControlEx : ContentControl
    {
        public DataTemplateSelector TemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(TemplateSelectorProperty); }
            set { SetValue(TemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty TemplateSelectorProperty =
            DependencyProperty.Register("TemplateSelector", typeof(DataTemplateSelector), typeof(ContentControlEx), new PropertyMetadata(null));

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (this.TemplateSelector != null)
            {
                this.ContentTemplate = this.TemplateSelector.SelectTemplate(newContent, this);
            }
        }
    }
}
