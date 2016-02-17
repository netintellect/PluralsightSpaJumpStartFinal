using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.DragDrop;
using Telerik.Windows.Diagrams.Core;
using System.Collections;
using Telerik.Windows.Controls.Diagrams;
using System.Windows.Input;


namespace Telerik.Windows.Examples.Diagrams.ClassDiagram
{
	public partial class Example : UserControl
	{
		private bool isInitialSizeChange = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="MainView"/> class.
		/// </summary>
		public Example()
		{
			InitializeComponent();

			DragDropManager.AddDragInitializeHandler(this.treeView, this.OnDragInitialize);
			DragDropManager.AddDropHandler(diagram, this.OnDrop);
			DragDropManager.AddGiveFeedbackHandler(this, this.OnGiveFeedback);			
			diagram.SizeChanged += this.OnDiagramSizeChanged;
		}
		
		private void OnDiagramSizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (this.isInitialSizeChange)
			{
				this.diagram.Layout();
				this.isInitialSizeChange = false;
			}
		}

		/// <summary>
		/// Called when the drag operation is initialized.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="Telerik.Windows.DragDrop.DragInitializeEventArgs"/> instance containing the event data.</param>
		private void OnDragInitialize(object sender, Telerik.Windows.DragDrop.DragInitializeEventArgs e)
		{
			e.Data = treeView.SelectedItems;
			e.AllowedEffects = DragDropEffects.All;
			e.Handled = true;
		}

		/// <summary>
		/// Called when an items has been dropped on the surface.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="Telerik.Windows.DragDrop.DragEventArgs"/> instance containing the event data.</param>
		private void OnDrop(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
		{
			diagram.SelectedIndex = -1;

			// this offset is necessary when multiple items are dropped at one; it keeps them separate though the same drop point is given
			var offset = 0;
#if WPF
			if (e.Data == null || !(e.Data is DataObject)) return;
			var droppedClassViewModels = (e.Data as DataObject).GetData(treeView.SelectedItems.GetType()) as IEnumerable;
#else
			if (e.Data == null || !(e.Data is IEnumerable)) return;
			var droppedClassViewModels = e.Data as IEnumerable;
#endif
			if (droppedClassViewModels == null) return;
			foreach (var viewModel in droppedClassViewModels)
			{
				var classViewModel = viewModel as ClassViewModel;
				var currentPosition = diagram.GetTransformedPoint(e.GetPosition(diagram));
				if (classViewModel != null)
				{
					this.AddNewItemToDiagram(classViewModel, currentPosition, ref offset);
				}
				else
				{
					var namespaceViewModel = viewModel as NamespaceViewModel;
					foreach (var type in namespaceViewModel.Types) this.AddNewItemToDiagram(type, currentPosition, ref offset);
				}
			}

			e.Handled = true;
		}

		/// <summary>
		/// Adds new (dropped) item to diagram.
		/// </summary>
		/// <param name="classViewModel">The model (representing a type) to be added.</param>
		/// <param name="point">The position.</param>
		/// <param name="offset">The displacement.</param>
		private void AddNewItemToDiagram(ClassViewModel classViewModel, Point point, ref int offset)
		{
			if (this.DataContext == null || !(this.DataContext is MainViewModel)) return;
			classViewModel.Position = new Point(point.X + ((offset % 5) * 200), point.Y + ((offset / 5) * 200));
			(this.DataContext as MainViewModel).ClassDiagramGraphSource.AddItem(classViewModel);
			offset++;
		}

		private void OnDiagramItemsChanged(object sender, DiagramItemsChangedEventArgs e)
		{
			if (this.isInitialSizeChange) return;
			foreach (var item in e.NewItems.OfType<ClassViewModel>()) item.IsSelected = true;
		}

		private void OnExplorerButtonClick(object sender, RoutedEventArgs e)
		{
			solutionExplorer.Visibility = System.Windows.Visibility.Visible;
			explorerButton.IsEnabled = false;
		}

		private void OnCloseButtonClick(object sender, RoutedEventArgs e)
		{
			solutionExplorer.Visibility = System.Windows.Visibility.Collapsed;
			explorerButton.IsEnabled = true;
		}
		
		private void OnGiveFeedback(object sender, Telerik.Windows.DragDrop.GiveFeedbackEventArgs e)
		{
			e.SetCursor(Cursors.Arrow);
			e.Handled = true;
		}
	}
}
