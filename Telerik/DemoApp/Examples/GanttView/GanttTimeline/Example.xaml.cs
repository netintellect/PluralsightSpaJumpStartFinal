using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.GanttView.Scrolling; 

namespace Telerik.Windows.Examples.GanttView.GanttTimeline
{
    public partial class Example : UserControl
    {
		private bool isGanttLoaded;

        public Example()
        {
            InitializeComponent();
        }

        private void timeLine_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
		    var viewModel = this.DataContext as ViewModel;

		    var movie = e.AddedItems.FirstOrDefault() as Movie;
			
		    if (movie != null && this.isGanttLoaded)
		    {
				var indexToCollapse = viewModel.IndexOf(e.RemovedItems.FirstOrDefault() as Movie);
				if (indexToCollapse > -1)
				{
					var movieToCollapse = viewModel.Tasks[indexToCollapse];
					this.ganttView.ExpandCollapseService.CollapseItem(movieToCollapse);
				}				

				var movieToExpand = viewModel.Tasks[viewModel.IndexOf(movie)];
				this.ganttView.ScrollingService.ScrollIntoView(movieToExpand, new ScrollSettings
																							{
																								HorizontalScrollPosition = HorizontalScrollPosition.Left,
																								VerticalScrollPosition = VerticalScrollPosition.Top
																							});
				this.ExpandItem(movieToExpand);
		    }			
        }

		private void ExpandItem(GanttTask task)
		{
			this.ganttView.ExpandCollapseService.ExpandItem(task);

			foreach (GanttTask childItem in task.Children)
			{
				this.ganttView.ExpandCollapseService.ExpandItem(childItem);

				if (childItem.Children.Any())
				{
					this.ExpandItem(childItem);
				}
			}
		}

		private void OnGanttLoaded(object sender, System.Windows.RoutedEventArgs e)
		{
			this.isGanttLoaded = true;

			this.ExpandItem((this.DataContext as ViewModel).Tasks.First());
		}
    }
}
