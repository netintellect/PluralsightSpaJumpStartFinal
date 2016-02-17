using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GanttView.Highlighting
{
    public class ViewModel : GanttViewModel
    {
        private DateRange visibleRange;

        public ViewModel()
        {
            var start = new DateTime(DateTime.Today.Year, Math.Max(1, DateTime.Today.Month - 1), 1);
            var end = start.AddMonths(5);
            this.visibleRange = new DateRange(start, end);

            this.HighlightCommand = new DelegateCommand(this.HighlightExecuted);
        }
        private DelegateCommand highlightCommand;
        public DelegateCommand HighlightCommand
        {
            get
            {
                return this.highlightCommand;
            }
            set
            {
                this.highlightCommand = value;
            }
        }
        private List<GanttTask> ExpandAllTasks()
        {

            return ExpandItems(this.Tasks);
        }

        private List<GanttTask> ExpandItems(IEnumerable items)
        {
            var criticalItems = new List<GanttTask>();
            foreach (var child in items)
            {
                var task = child as GanttTask;
                criticalItems.Add(task);
                criticalItems.AddRange(task.Children.OfType<GanttTask>());
            }
            return criticalItems;
        }

        private IEnumerable<object> highlightItems;

        public IEnumerable<object> HighlightedItems
        {
            get
            {
                return highlightItems;

            }
            set
            {
                highlightItems = value;
                OnPropertyChanged(() => HighlightedItems);
            }

        }
        /// <Summary>Gets or sets VisibleRange and notifies for changes</Summary>
        public DateRange VisibleRange
        {
            get { return this.visibleRange; }
            set
            {
                if (this.visibleRange != value)
                {
                    this.visibleRange = value;
                    this.OnPropertyChanged(() => this.VisibleRange);
                }
            }
        }

        public IList<HighlightModes> HighlightModes { get; private set; }

        private void HighlightExecuted(object parameter)
        {
            var criticalItems = ExpandItems(new[] { this.Tasks[0], this.Tasks[1], this.Tasks[3] });
            var lateTasks = ExpandItems(new[] { this.Tasks[0], this.Tasks[3], this.Tasks[4] });

            switch (parameter.ToString())
            {
                case "All":
                    this.HighlightedItems = ExpandAllTasks();
                    break;
                case "None":
                    this.HighlightedItems = null;
                    break;
                case "Critical":
                    this.HighlightedItems = criticalItems;
                    break;
                case "Late":
                    this.HighlightedItems = lateTasks;
                    break;
            }
        }
    }
}
