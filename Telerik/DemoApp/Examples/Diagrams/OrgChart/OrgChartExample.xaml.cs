using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Controls.Diagrams.Extensions;
using Telerik.Windows.Diagrams.Core;
using System.Windows.Threading;
using Telerik.Windows.Examples.Diagrams.Common;
using Telerik.Windows.Examples.Diagrams.OrgChart.ViewModel;
using System.Collections.ObjectModel;
using Telerik.Windows.Examples.Diagrams.OrgChart.Interfaces;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Windows.Controls;
using Telerik.Windows.DragDrop;
using Telerik.Windows.Examples.Diagrams.OrgChart.CustomControls;
using System.Diagnostics;

namespace Telerik.Windows.Examples.Diagrams.OrgChart
{
	public partial class OrgChartExample
	{
		private OrgChartViewModel viewModel;
        private OrgTeamViewModel teamToExpand;
		private TreeLayout treeLayout;
		private Storyboard collapse, show;
		private static double minZoom, maxZoom, zoomFactor;
        private Dictionary<TreeLayoutType, List<ConnectorDescription>> layoutTypeBasedConnectors;
        private Point currentDragPosition;
        private readonly TimeSpan expandDelayInterval = TimeSpan.FromSeconds(0.5);
        private ActionDelayer actionDelayer;

		public OrgChartExample()
		{
            this.PopulateConnectorCollections();
			InitializeComponent();
			this.GetViewModelAndBindForEvents();
			this.Loaded += this.OnOrgChartExampleLoaded;
			this.Unloaded += this.OnOrgChartExampleUnloaded;
			this.BindComboBoxes();
			this.diagram.RoutingService.Router = this.viewModel.Router;
			this.treeLayout = new TreeLayout();
			this.BindOrgTreeView();
            DragDropManager.AddDragDropCompletedHandler(this.diagram, this.OnDragDropCompleted, true);
            DragDropManager.AddGiveFeedbackHandler(this.diagram, new Windows.DragDrop.GiveFeedbackEventHandler(OnGiveFeedBack), true);
            this.actionDelayer = new ActionDelayer();
		}

        #region Drag Drop
        private void OnGiveFeedBack(object sender, Telerik.Windows.DragDrop.GiveFeedbackEventArgs args)
        {
            OrgTeamMemberViewModel draggedModel = (OrgTeamMemberViewModel)(args.OriginalSource as FrameworkElement).DataContext;
            RadDiagramShape shapeUnderDragPosition = this.diagram.GetShapeUnderDragPosition();
            if (shapeUnderDragPosition != null)
            {
                bool isDropAllowed = false;
                OrgTeamViewModel targetModel = (OrgTeamViewModel)shapeUnderDragPosition.DataContext;
                if (targetModel != null && draggedModel.Team != targetModel )
                {
                    isDropAllowed = true;
                    this.viewModel.GraphSource.InternalItems.ForEach(team => team.IsDropTarget = false);
                    targetModel.IsDropTarget = true;
                }

                if (isDropAllowed)
                {
                    draggedModel.DropTarget = targetModel;
                    args.SetCursor(Cursors.Arrow);
                    this.ExpandItemDelayed(targetModel);
                }
                else
                {
                    draggedModel.DropTarget = null;                    
                }
            }
            else
            {
                draggedModel.DropTarget = null;
            }

            args.Handled = true;
        }

        private void ExpandItemDelayed(OrgTeamViewModel teamToExpand)
        {
            bool shouldExpand = this.teamToExpand != teamToExpand;
            if (shouldExpand)
            {
                this.teamToExpand = teamToExpand;
                this.actionDelayer.Execute(new Action(() =>
                {
                    this.teamToExpand.AreMembersVisible = true;
                }), this.expandDelayInterval);
            }
        }

        private void OnDragDropCompleted(object sender, DragDropCompletedEventArgs e)
        {
            RadDiagramShape shapeUnderDragPosition = this.diagram.GetShapeUnderDragPosition();
            if (shapeUnderDragPosition == null) return;

            if (e.OriginalSource is OrgChartTeamMember)
            {
                OrgTeamMemberViewModel draggedModel = (OrgTeamMemberViewModel)(e.OriginalSource as OrgChartTeamMember).DataContext;
                OrgTeamViewModel targetModel = (OrgTeamViewModel)shapeUnderDragPosition.DataContext;

                if (targetModel != draggedModel.Team)
                    this.viewModel.OpenDropMembersDialog(targetModel, draggedModel);
            }
        }
        #endregion

        #region Binding and Initial Setup

        private void PopulateConnectorCollections()
        {
            layoutTypeBasedConnectors = new Dictionary<TreeLayoutType, List<ConnectorDescription>>();
            var left = new ConnectorDescription(ConnectorPosition.Left, new Point(0, 0.5), -16, -4, Visibility.Visible);
            var leftCollapsed = new ConnectorDescription(ConnectorPosition.Left, new Point(0, 0.5), 0, 0, Visibility.Collapsed);

            var right = new ConnectorDescription(ConnectorPosition.Right, new Point(1, 0.5), 9, -4, Visibility.Visible);
            var rightCollapsed = new ConnectorDescription(ConnectorPosition.Right, new Point(1, 0.5), 0, 0, Visibility.Collapsed);

            var top = new ConnectorDescription(ConnectorPosition.Top, new Point(0.5, 0), -4, -16, Visibility.Visible);
            var topCollapsed = new ConnectorDescription(ConnectorPosition.Top, new Point(0.5, 0), 0, 0, Visibility.Collapsed);

            var bottom = new ConnectorDescription(ConnectorPosition.Bottom, new Point(0.5, 1), -4, 6, Visibility.Visible);
            var bottomCollapsed = new ConnectorDescription(ConnectorPosition.Bottom, new Point(0.5, 1), -4, 6, Visibility.Collapsed);

            var customCollapsed = new ConnectorDescription(CustomConnectorPosition.TreeLeftBottom, new Point(0.15, 1), -4, 6, Visibility.Collapsed);

            layoutTypeBasedConnectors.Add(TreeLayoutType.TreeDown, new List<ConnectorDescription>() { topCollapsed, bottom });
            layoutTypeBasedConnectors.Add(TreeLayoutType.TreeUp, new List<ConnectorDescription>() { top, bottomCollapsed });
            layoutTypeBasedConnectors.Add(TreeLayoutType.TreeRight, new List<ConnectorDescription>() { leftCollapsed, right });
            layoutTypeBasedConnectors.Add(TreeLayoutType.TreeLeft, new List<ConnectorDescription>() { left, rightCollapsed });
            layoutTypeBasedConnectors.Add(TreeLayoutType.TipOverTree, new List<ConnectorDescription>() { topCollapsed, bottom, customCollapsed, leftCollapsed });
        }

        private void BindOrgTreeView()
        {
            this.OrgTreeView.ItemsSource = this.viewModel.HierarchicalDataSource;
            this.viewModel.HierarchicalDataSource[0].IsExpandedInTree = true;
        }

        private void GetViewModelAndBindForEvents()
        {
            this.viewModel = this.RootGrid.Resources["ViewModel"] as OrgChartViewModel;
            this.viewModel.ChildTreeLayoutViewModel.LayoutSettingsChanged += (_, __) => this.LayoutOrgChart(false, false);
            this.viewModel.ChildrenIsExpandedChanged += this.OnViewModelChildrenExpandedOrCollapsed;
            this.viewModel.TeamMembersVisibilityChanged += this.OnViewModelTeamMembersVisibilityChanged;
        }

        private void BindComboBoxes()
        {
            ObservableCollection<ViewModelBase> source = new ObservableCollection<ViewModelBase>();
            foreach (var team in this.viewModel.GraphSource.InternalItems)
            {
                source.Add(team);
                source.AddRange(team.TeamMembers);
            }
            this.employeesComboBox.ItemsSource = source;
        }

        private void BindSelectionChangedEvents()
        {
            this.viewModel.CurrentLayoutTypeChanged += (_, __) => this.LayoutOrgChart(false, false);
        }
        #endregion

        private void DiagramGraphSourceChanged(object sender, EventArgs e)
        {
            var graphSource = this.diagram.GraphSource as GraphSource;
            if (graphSource != null)
            {
                graphSource.InternalItems.CollectionChanged += GraphSourceItemsCollectionChanged;
                graphSource.InternalLinks.CollectionChanged += (o, s) => this.LayoutOrgChart(false, false);
            }
        }

        private void GraphSourceItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                // Removes the deleted team from the TreeView's ItemsSource.
                var removedNode = e.OldItems[0] as OrgTeamViewModel;
                if (removedNode != null)
                {
                    this.viewModel.FindAndRemove(removedNode);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // Bring the new team into view.
                var newTeam = e.NewItems[0] as OrgTeamViewModel;
                if (newTeam != null)
                {
                    this.InvokeDispatchedAction(() => this.DiagramBringIntoView(newTeam));                   
                }
            }
            this.LayoutOrgChart(false, false);
        }
	       
		private void OnViewModelChildrenExpandedOrCollapsed(object sender, TeamExpandCollapseChangeEventArgs e)
		{
			if (this.viewModel.ShouldLayoutAfterExpandCollapse)
			{
                this.UpdateViewPortWhenTeamVisualChange(e.Team, true);
			}
			this.navigationPane.RefreshThumbnail();
		}

		private void OnOrgChartExampleLoaded(object sender, RoutedEventArgs e)
		{
			minZoom = DiagramConstants.MinimumZoom;
			maxZoom = DiagramConstants.MaximumZoom;

			DiagramConstants.MinimumZoom = 0.2d;
			DiagramConstants.MaximumZoom = 2d;

			this.navigationPane.RefreshZoomSlider();

			this.BindSelectionChangedEvents();
			this.SetLayoutRoots();
			this.LayoutOrgChart(false, false);
            this.InvokeDispatchedAction(() => this.diagram.AutoFit());
			this.Loaded -= OnOrgChartExampleLoaded;

            // Invalidating export command.
            this.exportButton.DropDownOpened += (o, s) => CommandManager.InvalidateRequerySuggested();
		}

		private void OnOrgChartExampleUnloaded(object sender, RoutedEventArgs e)
		{
			DiagramConstants.MinimumZoom = minZoom;
			DiagramConstants.MaximumZoom = maxZoom;
		}	

        #region BringIntoView
        private void EmployeesComboBoxKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				this.employeesComboBox.SelectedItem = null;
				this.employeesComboBox.Text = string.Empty;
			}
			else if (e.Key == Key.Enter)
			{
                this.BringTreeAndDiagramIntoView();
			}
		}

		private void EmployeesComboBoxDropDownClosed(object sender, EventArgs e)
		{
            this.BringTreeAndDiagramIntoView();
		}

        private void BringTreeAndDiagramIntoView()
        {
            object selected = this.employeesComboBox.SelectedItem;
            if (selected != null)
            {
                // Selects the team or person that is found in the autocomplete box.
                (selected as ISelectable).IsSelected = true;

                // Brings it in the TreeView.
                var selectedPath = selected as IPathEnabled;
                this.OrgTreeView.BringPathIntoView(selectedPath.Path);
                
                // Brings it in the Diagram.
                bool isTeam = selected is OrgTeamViewModel;
                OrgTeamViewModel team = isTeam ? selected as OrgTeamViewModel : (selected as OrgTeamMemberViewModel).Team;

                this.DiagramBringIntoView(team);
                this.DiagramExpandNodeByPath(team.Path);
            }
        }

		private void DiagramExpandNodeByPath(string path)
		{
			string[] pathParts = path.Split('|');
			if (pathParts.Length < 2) return;
			for (int i = 0; i < pathParts.Length - 1; i++)
			{
				var allLinks = this.viewModel.GraphSource.Links.ToList();
                var currLink = allLinks.FirstOrDefault(x => (x.Source as OrgTeamViewModel).Name == pathParts[i] && (x.Target as OrgTeamViewModel).Name == pathParts[i + 1]) as Link;
				if (currLink != null)
				{
					currLink.Visibility = Visibility.Visible;
					currLink.Source.Visibility = Visibility.Visible;
					currLink.Source.IsExpanded = true;

					//A) Making children visible.
					foreach (var item in currLink.Source.Children)
					{
						var link = this.viewModel.GraphSource.Links.FirstOrDefault(x => x.Source == currLink.Source && x.Target == item) as Link;
                        if (link != null)
                        {
                            link.Visibility = Visibility.Visible;
                        }
						item.Visibility = Visibility.Visible;

						//B) Presumption till not changed in A.
						(item as OrgTeamViewModel).IsExpanded = true;
					}
				}
			}
			this.navigationPane.RefreshThumbnail();
		}

		private void DiagramBringIntoView(OrgTeamViewModel node)
		{
			var shape = this.diagram.ContainerGenerator.ContainerFromItem(node) as RadDiagramShape;
			if (shape != null)
			{
				this.diagram.BringIntoView(shape, 1, true);
			}
		}

        private void OrgTreeViewItemClick(object sender, RadRoutedEventArgs e)
        {
            var item = e.OriginalSource as RadTreeViewItem;
            if (item != null && item.DataContext != null)
            {
                var node = item.DataContext as OrgTeamViewModel;
                if (node != null)
                {
                    this.DiagramBringIntoView(node);
                    this.DiagramExpandNodeByPath(node.Path);
                }
                else
                {
                    var member = item.DataContext as OrgTeamMemberViewModel;
                    if (member != null)
                    {
                        this.DiagramBringIntoView(member.Team);
                        this.DiagramExpandNodeByPath(member.Team.Path);
                    }
                }
            }
        }	
        #endregion

        #region Layout Related Code
        private void LayoutOrgChart(bool shouldAutoFit, bool isLayoutSynchronous)
        {
            // suspend auto update for all connections:
            this.diagram.Connections.ForEach(x => RadDiagramConnection.SetIsAutoUpdateSuppressed((RadDiagramConnection)x, true));
            this.EnsureConnectors();

            if (isLayoutSynchronous)
            {
                this.diagram.Layout(LayoutType.Tree, this.viewModel.ChildTreeLayoutViewModel.CurrentLayoutSettings);
            }
            else
            {
                this.diagram.LayoutAsync(LayoutType.Tree, this.viewModel.ChildTreeLayoutViewModel.CurrentLayoutSettings);
            }

            // unsuspend auto update for all connections & update:
            this.diagram.Connections.ForEach(x => RadDiagramConnection.SetIsAutoUpdateSuppressed((RadDiagramConnection)x, false));
            this.diagram.Connections.ForEach(x => x.Update());

            if (shouldAutoFit)
            {
                this.diagram.AutoFit(new Thickness(10), false);
            }

            this.InvokeDispatchedThumbnailRefresh();
        }

        private void LayoutButtonClicked(object sender, RoutedEventArgs e)
		{
			this.LayoutOrgChart(false, false);
		}

		private void LayoutTypeButtonClick(object sender, RoutedEventArgs e)
		{
			RadGeometryButton button = sender as RadGeometryButton;
			if (button != null && button.Geometry != null && button.Content != null)
			{
				Geometry geometry = button.Geometry.Clone();
				this.LayoutTypeDropDown.Geometry = geometry;

				string layoutType = button.Content.ToString();
				this.viewModel.CurrentTreeLayoutType = (TreeLayoutType)Enum.Parse(typeof(TreeLayoutType), layoutType, true);
			}			
		}

        private void SetLayoutRoots()
        {
            foreach (var item in this.viewModel.HierarchicalDataSource)
            {
                RadDiagramShape shape = this.diagram.ContainerGenerator.ContainerFromItem(item) as RadDiagramShape;
                this.viewModel.ChildTreeLayoutViewModel.CurrentLayoutSettings.Roots.Add(shape);
            }
        }

        private void EnsureConnectors()
        {
            this.diagram.Shapes.ForEach(shape =>
            {
                shape.Connectors.Clear();
                foreach (ConnectorDescription item in this.layoutTypeBasedConnectors[this.viewModel.CurrentTreeLayoutType])
                {
                    RadDiagramConnector connector = new RadDiagramConnector()
                    {
                        Offset = item.Offset,
                        Name = item.Name,
                        Visibility = item.Visibility
                    };
                    Canvas.SetLeft(connector, item.CanvasLeft);
                    Canvas.SetTop(connector, item.CanvasTop);
                    shape.Connectors.Add(connector);
                }
            });

            if (this.viewModel.CurrentTreeLayoutType == TreeLayoutType.TipOverTree)
            {
                var shapesWithIncomingLinks = this.diagram.Shapes.Where(x => x.IncomingLinks.Any()).ToList();
                shapesWithIncomingLinks.ForEach(y =>
                {
                    y.Connectors.ForEach(con =>
                        (con as RadDiagramConnector).Visibility = con.Name != CustomConnectorPosition.TreeLeftBottom ? Visibility.Collapsed : Visibility.Visible);
                });
            }
        }

        private void UpdateViewPortWhenTeamVisualChange(OrgTeamViewModel team, bool isLayoutSynchronous)
        {
            Point oldPosition = team.Position;
            this.LayoutOrgChart(false, isLayoutSynchronous);
            this.diagram.UpdateViewportRespectingShape(oldPosition, team.Position);
        }

        private void OnViewModelTeamMembersVisibilityChanged(object sender, TeamExpandCollapseChangeEventArgs e)
        {
            this.UpdateViewPortWhenTeamVisualChange(e.Team, false);
            this.navigationPane.RefreshThumbnail();
            this.LayoutOrgChart(false, false);
        }
		
		private void InvokeDispatchedThumbnailRefresh()
		{
			Action action = new Action(() => this.navigationPane.RefreshThumbnail());

#if WPF
			this.Dispatcher.BeginInvoke(action, DispatcherPriority.Background);
#else
			this.Dispatcher.BeginInvoke(action);
#endif
        }
        #endregion

        private void InvokeDispatchedAction(Action action)
        {
#if WPF
            Dispatcher.BeginInvoke(action, DispatcherPriority.Loaded);
#else
            Dispatcher.BeginInvoke(() => action());
#endif
        }
    }
}
