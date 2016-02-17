using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Rendering;

namespace Telerik.Windows.Examples.GanttView.FirstLook
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.ganttview.Loaded += OnGanttViewLoaded;
		}

		void OnGanttViewLoaded(object sender, RoutedEventArgs e)
		{
			var panels = this.ganttview.ChildrenOfType<LogicalCanvasPanel>().ToList();

			double visibleArea = panels.Where(p => p.Name == "EventsPanel").First().ViewportWidth;

			var viewModel = this.ganttview.DataContext as ViewModel;

			viewModel.VisibleArea = (long)visibleArea;
		}
	}
}
