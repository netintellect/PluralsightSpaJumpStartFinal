using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Telerik.Windows.QuickStart
{
    public class SingleControlExamplesTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HighlightedItemTemplate { get; set; }
        
        public DataTemplate GroupFirstHighlightedItemTemplate { get; set; }

        public DataTemplate NormalItemTemplate{ get; set; }

        public DataTemplate GroupFirstNormalItemTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            IExampleInfo exampleInfo = (item as IExampleInfo);
            if (exampleInfo.ExampleGroup.Name == "Overview" || exampleInfo.ExampleGroup.Name == "Highlights") // :(
            {
                if (exampleInfo.ExampleGroup.TouchExamples.First() == exampleInfo)
                {
                    return this.GroupFirstHighlightedItemTemplate;
                }
                else
                {
                    return this.HighlightedItemTemplate;
                }
            }
            else
            {
                if (exampleInfo.ExampleGroup.TouchExamples.First() == exampleInfo)
                {
                    return this.GroupFirstNormalItemTemplate;
                }
            }

            return this.NormalItemTemplate;
        }
    }
}
