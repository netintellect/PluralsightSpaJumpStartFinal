using System;
using System.Linq;
#if WPF
using System.Windows.Controls;
#endif
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.Examples.Diagrams.TableShape.Models;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Examples.Diagrams.Common;
using System.Windows.Threading;

namespace Telerik.Windows.Examples.Diagrams.TableShape
{
    public partial class Example : System.Windows.Controls.UserControl
    {
        private Telerik.Windows.Controls.Diagrams.Extensions.FileManager fileManager;
        private TablesGraphSource dc;
        private bool isClear;

        static Example()
        {
            var saveBinding = new CommandBinding(DiagramCommands.Save, ExecuteSave, CanExecutedSave);
            var openBinding = new CommandBinding(DiagramCommands.Open, ExecuteOpen);

            CommandManager.RegisterClassCommandBinding(typeof(Example), saveBinding);
            CommandManager.RegisterClassCommandBinding(typeof(Example), openBinding);
        }

        public Example()
        {
            DiagramConstants.RoutingGridSize = 40d;
            DiagramConstants.ContainerMargin = 0d;
            InitializeComponent();

            this.fileManager = new Controls.Diagrams.Extensions.FileManager(this.diagram);
            this.DataContext = this.dc = new TablesGraphSource();
            var newRouter = new AStarRouter(this.diagram) { WallOptimization = true };
            this.diagram.RoutingService.Router = newRouter;
            this.diagram.RoutingService.FreeRouter = newRouter;
            this.Loaded += this.OnLoaded;
        }

        private static void CanExecutedSave(object sender, CanExecuteRoutedEventArgs e)
        {
            var owner = sender as Example;
            e.CanExecute = owner != null && owner.diagram != null && owner.diagram.Items.Count > 0;
        }

        private static void ExecuteSave(object sender, ExecutedRoutedEventArgs e)
        {
            var owner = sender as Example;
            if (owner != null)
                owner.fileManager.SaveToFile();
        }

        private static void ExecuteOpen(object sender, ExecutedRoutedEventArgs e)
        {
            var owner = sender as Example;
            if (owner != null)
            {
                owner.ClearDiagram();
                owner.fileManager.LoadFromFile();
            }
        }

        private void OnConnectionManipulationCompleted(object sender, ManipulationRoutedEventArgs e)
        {
            if (e.ManipulationPoint.Type != ManipulationPointType.Intermediate)
                e.Handled = e.Shape == null;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                foreach (var container in this.diagram.Shapes.OfType<RadDiagramContainerShape>())
                {
                    if (container.IsSelected)
                        container.ZIndex = 4;
                    else
                        container.ZIndex = 0;
                }
            }
        }

        private void OnPreviewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 1)
            {
                foreach (var item in e.AddedItems)
                {
                    if (item is RowModel) continue;

                    var container = this.diagram.ContainerGenerator.ContainerFromItem(item);
                    container.IsSelected = true;
                }
                e.Handled = true;
            }
        }

        private void OnNewClick(object sender, RoutedEventArgs e)
        {
            this.RefreshDiagram();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.RefreshDiagram();
        }

        private void LoadDefaultTables()
        {
            SamplesFactory.LoadSample(this.diagram, "tableShape");
        }

        private void ClearDiagram()
        {
            this.diagram.UndoRedoService.Clear();
            var graphSource = this.DataContext as TablesGraphSource;
            if (graphSource != null)
            {
                graphSource.ClearCache();
                graphSource.Clear();
            }
        }

        private void OnItemsChanging(object sender, DiagramItemsChangingEventArgs e)
        {
            if (this.isClear) return;

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                var rowModel = e.OldItems.ElementAt(0) as RowModel;
                var command = new CompositeCommand("Remove Connections");
                if (rowModel != null)
                {
                    this.RemoveRowModel(rowModel, command);
                    if (command.Commands.Count() > 0)
                        this.diagram.UndoRedoService.ExecuteCommand(command);
                }
                else
                {
                    var tableModel = e.OldItems.ElementAt(0) as TableModel;
                    if (tableModel != null)
                    {
                        foreach (var item in tableModel.InternalItems)
                        {
                            this.RemoveRowModel(item as RowModel, command);
                        }
                        if (command.Commands.Count() > 0)
                            this.diagram.UndoRedoService.ExecuteCommand(command);

                        tableModel.InternalItems.Clear();
                    }
                }
            }
        }

        private void RemoveRowModel(RowModel rowModel, CompositeCommand command)
        {
            var container = this.diagram.ContainerGenerator.ContainerFromItem(rowModel) as IShape;
            if (container == null) return;

            foreach (var connection in this.diagram.GetConnectionsForShape(container).ToList())
            {
                var link = this.diagram.ContainerGenerator.ItemFromContainer(connection) as LinkViewModelBase<NodeViewModelBase>;
                command.AddCommand(new UndoableDelegateCommand(
                    "Remove link",
                    new Action<object>((o) => this.dc.RemoveLink(link)),
                    new Action<object>((o) => this.dc.AddLink(link))));
            }
        }

        private void RefreshDiagram()
        {
            this.isClear = true;
            this.diagram.DeselectAll();
            this.ClearDiagram();
            this.LoadDefaultTables();
            this.isClear = false;
        }

        private void OnDiagramDeserialized(object sender, RadRoutedEventArgs e)
        {
            // We need to update the connections after the containers have been collapsed.
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                foreach (var connection in this.diagram.Connections)
                {
                    connection.Update();
                }
#if WPF
            }), DispatcherPriority.ApplicationIdle);
#else
            }));
#endif
        }
    }
}
