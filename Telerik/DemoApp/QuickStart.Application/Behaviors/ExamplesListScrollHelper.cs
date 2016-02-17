using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.QuickStart
{
    public class ExamplesListScrollHelper
    {
        private readonly FrameworkElement listView;
        private readonly FrameworkElement pageRoot;
        private double listViewScrollOffset = 0;

        public ExamplesListScrollHelper(FrameworkElement listView, FrameworkElement pageRoot)
        {
            this.pageRoot = pageRoot;
            this.listView = listView;
        }

        public void Initialize()
        {
            if (listView == null)
            {
                return;
            }

            this.pageRoot.PreviewMouseWheel += OnExamplesListPreviewMouseWheel;
        }

        private void OnExamplesListPreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var scrollViewer = this.listView.ChildrenOfType<ScrollViewer>().First();

            this.listViewScrollOffset += (-1) * e.Delta;

            // coerce listViewScrollOffset between 0 and scrollable width
            this.listViewScrollOffset = Math.Max(0, Math.Min(this.listViewScrollOffset, scrollViewer.ScrollableWidth));
            scrollViewer.ScrollToHorizontalOffset(this.listViewScrollOffset);
        }
    }
}
